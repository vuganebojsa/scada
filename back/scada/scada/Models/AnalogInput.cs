using scada.DTOS;

namespace scada.Models
{
    public class AnalogInput:Tag
    {
        public string? Id { get; set; }
        public string Description { get; set; }
        public string Driver { get; set; }
        public string IOAddress { get; set; }
        public int ScanTime { get; set; }
        public ICollection<Alarm> Alarms { get; set; } = new List<Alarm>();
        public bool OnOffScan { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Units { get; set; }
        public AnalogInput()
        {
        }

        public AnalogInput(string id, string description, string iOAddress, int scanTime, ICollection<Alarm> alarms, bool onOffScan, double lowLimit, double highLimit, string units, string driver)
        {
            Id = id;
            Description = description;
            IOAddress = iOAddress;
            ScanTime = scanTime;
            Alarms = alarms;
            OnOffScan = onOffScan;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Units = units;
            Driver = driver;
  
        }

        public AnalogInput(AnalogInputDTO analogInputDTO)
        {
            Description = analogInputDTO.Description;
            IOAddress = analogInputDTO.IOAddress;
            ScanTime = analogInputDTO.ScanTime;
            Alarms = new List<Alarm>();
            OnOffScan = true;
            LowLimit = analogInputDTO.LowLimit;
            HighLimit = analogInputDTO.HighLimit;
            Units = analogInputDTO.Units;
            Driver = analogInputDTO.Driver;
        }

        
    }
}
