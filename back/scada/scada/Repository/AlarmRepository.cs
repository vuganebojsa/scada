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
            return _context.Alarms.Where(x => x.isDeleted == false).OrderBy(x => x.Id).ToList();
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
            alarm.isDeleted = true;
            //AnalogInput ao = this._context.AnalogInputs.Where(x => x.id == alarm.analogId).FirstOrDefault();
            //if (ao == null) return false;

            //ao.Alarms.Remove(alarm);

            _context.SaveChanges();

            return true;
        }

        public ICollection<Alarm> GetAllAlarmsById(int? tagId)
        {

            return _context.Alarms.Where(x => x.analogId == tagId).ToList();
        }

        public async void AddAlarmActivation(AlarmActivation alarmActivation)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                _context.AlarmActivations.Add(alarmActivation);
                await _context.SaveChangesAsync();
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public ICollection<AlarmActivation> GetAllActivatedAlarms()
        {

            var activatedAlarms = _context.AlarmActivations.OrderByDescending(x => x.Timestamp).ToList();
            foreach(var alarm in activatedAlarms)
            {
                alarm.alarm = _context.Alarms.Where(x => x.Id == alarm.alarmId).FirstOrDefault();
            }
            return activatedAlarms;
        }
    }
}