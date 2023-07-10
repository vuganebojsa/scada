using scada.Data;
using scada.DTOS;
using scada.Interfaces;
using scada.Models;

namespace scada.Repository
{
    public class AlarmRepositroy : IAlarmRepository
    {
        private readonly DataContext _context;
        public AlarmRepositroy(DataContext context)
        {
            _context = context;
        }

        ICollection<Alarm> IAlarmRepository.GetAllAlarms()
        {
            return _context.Alarms.OrderBy(x => x.Id).ToList();
        }

        ICollection<Alarm> IAlarmRepository.GetAlarmsBetweenTimes(DateTime startTime, DateTime endTime) {

            return _context.Alarms.Where(x => x.timeStamp < endTime && x.timeStamp > startTime).ToList();
        }

        ICollection<Alarm> IAlarmRepository.GetAlarmsByPriority(int priority)
        {
            return _context.Alarms.Where(x => x.priority == priority).ToList();
        }

        public CreateAlarmDTO CreateAlarm(CreateAlarmDTO alarm)
        {

            Alarm newAlarm= new Alarm();
            newAlarm.priority = alarm.Priority;
            newAlarm.timeStamp = DateTime.Now;
            newAlarm.analogId = alarm.AnalogId;
            newAlarm.Message = alarm.Message;
            newAlarm.threshHold = alarm.Threshold;
            
            newAlarm.Type = alarm.Type;


            AnalogInput ai = _context.AnalogInputs.Where(x => x.id == alarm.AnalogId).FirstOrDefault();
            newAlarm.analogInput = ai;

            newAlarm.MeasureUnit = newAlarm.analogInput.Units;
            ai.Alarms.Add(newAlarm);
            _context.SaveChanges();


            return alarm;
        }

        public bool RemoveAlarm(string id)
        {
            Alarm alarm = this._context.Alarms.Where(x => x.Id == id).FirstOrDefault();
            if (alarm == null) return false;

            AnalogInput ao = this._context.AnalogInputs.Where(x => x.id == alarm.analogId).FirstOrDefault();
            if (ao == null) return false;

            ao.Alarms.Remove(alarm);

            _context.SaveChanges();

            return true;
        }
    }
}