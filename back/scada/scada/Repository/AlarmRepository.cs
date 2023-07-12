using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<GetAlarmDTO>> GetAllAlarms()
        {
            await Global._semaphore.WaitAsync();
            try
            {
                var alarms =  await _context.Alarms.Where(x => x.isDeleted == false).OrderBy(x => x.Id).ToListAsync();
                var dtos = new List<GetAlarmDTO>();
                foreach(var alarm in alarms)
                {
                    dtos.Add(new GetAlarmDTO(alarm.analogId, alarm.threshHold, alarm.Message, alarm.priority, alarm.Type, alarm.timeStamp, alarm.MeasureUnit, alarm.Id));
                }
                return dtos;
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public async Task<ICollection<Alarm>> GetAlarmsBetweenTimes(DateTime startTime, DateTime endTime) {

            await Global._semaphore.WaitAsync();
            try
            {
                return await _context.Alarms.Where(x => x.timeStamp < endTime && x.timeStamp > startTime).ToListAsync();
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public async Task<ICollection<Alarm>> GetAlarmsByPriority(int priority)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return await _context.Alarms.Where(x => x.priority == priority).ToListAsync();
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public async Task<CreateAlarmDTO> CreateAlarm(CreateAlarmDTO alarm)
        {

            await Global._semaphore.WaitAsync();
            try
            {
                Alarm newAlarm= new Alarm();
            newAlarm.priority = alarm.Priority;
            newAlarm.timeStamp = DateTime.Now;
            newAlarm.analogId = alarm.AnalogId;
            newAlarm.Message = alarm.Message;
            newAlarm.threshHold = alarm.Threshold;
            
            newAlarm.Type = alarm.Type;


            AnalogInput ai = await _context.AnalogInputs.FindAsync(alarm.AnalogId);
            newAlarm.analogInput = ai;

            newAlarm.MeasureUnit = newAlarm.analogInput.Units;
            ai.Alarms.Add(newAlarm);
            await _context.SaveChangesAsync();


            return alarm;
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public async Task<bool> RemoveAlarm(string id)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                Alarm alarm = await this._context.Alarms.FindAsync(id);
            if (alarm == null) return false;
            alarm.isDeleted = true;
            //AnalogInput ao = this._context.AnalogInputs.Where(x => x.id == alarm.analogId).FirstOrDefault();
            //if (ao == null) return false;

            //ao.Alarms.Remove(alarm);

            await _context.SaveChangesAsync();

            return true;
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public async Task<ICollection<Alarm>> GetAllAlarmsById(int? tagId)
        {
            await Global._semaphore.WaitAsync();
            try
            {
                return await _context.Alarms.Where(x => x.analogId == tagId).ToListAsync();
            }
            finally
            {
                Global._semaphore.Release();
            }
        }

        public async Task AddAlarmActivation(AlarmActivation alarmActivation)
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

        public async Task<ICollection<GetActivatedAlarmDTO>> GetAllActivatedAlarms()
        {
            await Global._semaphore.WaitAsync();
            try
            {
                var activatedAlarms = await _context.AlarmActivations.OrderByDescending(x => x.Timestamp).ToListAsync();
                var dtos = new List<GetActivatedAlarmDTO>();

                foreach(var alarm in activatedAlarms)
                {
                    Alarm newAl = await _context.Alarms.Where(x => x.Id == alarm.alarmId).FirstOrDefaultAsync();

                        dtos.Add(new GetActivatedAlarmDTO(newAl.priority, newAl.Type, alarm.Timestamp, newAl.MeasureUnit));
                    
                }
                return dtos;
            }
            finally
            {
                Global._semaphore.Release();
            }
        }
    }
}