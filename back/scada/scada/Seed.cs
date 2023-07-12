using scada.Data;
using scada.Models;

namespace scada
{
    public class Seed
    {
        private readonly DataContext _dataContext;
        public Seed(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SeedDataContext()
        {
            if (!_dataContext.Users.Any())
            {
                AddUsers();
                _dataContext.SaveChanges();

            }
            if (!_dataContext.AnalogInputs.Any())
            {
                AddAnalogInputTags();
                _dataContext.SaveChanges();

            }
            if (!_dataContext.AnalogOutputs.Any())
            {
                AddAnalogOutputTags();
                _dataContext.SaveChanges();

            }
            if (!_dataContext.DigitalInputs.Any())
            {
                AddDigitalInputTags();
                _dataContext.SaveChanges();

            }
            if (!_dataContext.DigitalOutputs.Any())
            {
                AddDigitalOutputTags();
                _dataContext.SaveChanges();

            }
            if (!_dataContext.Alarms.Any())
            {
                AddAlarms();
                _dataContext.SaveChanges();

            }
            if(!_dataContext.PastTagValues.Any())
            {
                AddPastTagValues();
                _dataContext.SaveChanges();
            }

        }

        private void AddUsers()
        {
            var users = new List<User>()
                {
                    new User("admin", "admin", "admin"),
                    new User("user", "user", "user")
                };

            _dataContext.Users.AddRange(users);


        }

        private void AddAnalogInputTags()
        {
            var analogTags = new List<AnalogInput>()
            {
                new AnalogInput(20, "Tag za merelje struje", "Struja", 1, new List<Alarm>()
                , true, 0, 50, "mA"),
                new AnalogInput(20, "Tag za merelje napona", "Napon",  3, new List<Alarm>(), true, 0, 20, "V"),
                new AnalogInput(20, "Tag za merelje snage", "Snaga", 4, new List<Alarm>()
                , true, 0, 50, "KW"),
            };
            _dataContext.AnalogInputs.AddRange(analogTags);
        }
        private void AddAnalogOutputTags()
        {
            var analogTags = new List<AnalogOutput>()
            {
                new AnalogOutput(5, "Strujica", "Opis", "R", 5, 0, 20, "mA"),
                new AnalogOutput(5, "Naponcic", "Opis", "S", 5, 0, 20, "V"),
                new AnalogOutput(5, "Snagica", "Opis", "C", 5, 0, 20, "KW"),
            };
            _dataContext.AnalogOutputs.AddRange(analogTags);
        }
        private void AddDigitalInputTags()
        {
            var digitalTags = new List<DigitalInput>()
            {
                new DigitalInput(0, "Digic 1", "Pazi da li je upaljen prekidac u wcu", "", 3, true, ""),
                new DigitalInput(1, "Digic 2", "Pazi da li je upaljen prekidac u garazi", "", 2, true, ""),
                new DigitalInput(0, "Digic 3", "Pazi da li radi susilica", "", 1, true, "")
            };
            _dataContext.DigitalInputs.AddRange(digitalTags);
        }
        private void AddDigitalOutputTags()
        {
            var digitalTags = new List<DigitalOutput>()
            {
                new DigitalOutput("Digic Out 1", "Opis DOUT 1", 0, "", 0),
                new DigitalOutput("Digic Out 2", "Opis DOUT 2", 1, "", 1),
                new DigitalOutput("Digic Out 3", "Opis DOUT 3", 1, "", 1)
            };
            _dataContext.DigitalOutputs.AddRange(digitalTags);
        }

        private void AddAlarms()
        {
            AnalogInput analogInput = _dataContext.AnalogInputs.FirstOrDefault();

            var alarms = new List<Alarm>()
            {
                new Alarm(30, "Visoka struja", analogInput, 1, "High", analogInput.Units),
                new Alarm(46, "Previsoka struja", analogInput, 3, "High", analogInput.Units),
                new Alarm(20, "Niska struja", analogInput, 2, "Low", analogInput.Units),
            };

            _dataContext.Alarms.AddRange(alarms);
            _dataContext.SaveChanges();
            Console.WriteLine(_dataContext.Alarms.FirstOrDefault());
            analogInput.Alarms = _dataContext.Alarms.ToList();
            _dataContext.SaveChanges();


        }
        private void AddPastTagValues()
        {
            AnalogInput analogInput = _dataContext.AnalogInputs.FirstOrDefault();
            DigitalInput digitalInput = _dataContext.DigitalInputs.FirstOrDefault();

            var pastTagValues = new List<PastTagValues>()
            {
                new PastTagValues(analogInput, 20, "R"),
                new PastTagValues(analogInput, 30, "C"),
                new PastTagValues(digitalInput, 30, "C"),
                new PastTagValues(digitalInput, 40, "S")
            };
            _dataContext.PastTagValues.AddRange(pastTagValues);
            _dataContext.SaveChanges();
        }



    }
}
