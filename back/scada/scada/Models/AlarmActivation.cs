namespace scada.Models
{
    public class AlarmActivation
    {
        public string? Id { get; set; }
        public DateTime Timestamp { get; set; }

        public Alarm alarm { get; set; }
        public string? alarmId { get; set; }

        public AlarmActivation()
        {
                
        }
        public AlarmActivation(Alarm newAlarm)
        {
            alarm = newAlarm;
            Timestamp = DateTime.Now;
            alarmId = newAlarm.Id;
        }
    }
}
