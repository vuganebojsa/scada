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
                
            }
            if (!_dataContext.AnalogInputs.Any())
            {
                AddAnalogInputTags();

            }
            if (!_dataContext.AnalogOutputs.Any())
            {
                AddAnalogOutputTags();

            }
            if (!_dataContext.DigitalInputs.Any())
            {
                AddDigitalInputTags();

            }
            if (!_dataContext.DigitalOutputs.Any())
            {
                AddDigitalOutputTags();

            }

            _dataContext.SaveChanges();
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
                new AnalogInput(20, "Opis", "Struja", "", 1, new List<Alarm>(), false, 0, 20, "mA", ""),
                new AnalogInput(20, "Opis", "Napon", "", 1, new List<Alarm>(), false, 0, 20, "mA", ""),
                new AnalogInput(20, "Opis", "Snaga", "", 20, new List<Alarm>(), false, 0, 50, "KW", ""),
            };
            _dataContext.AnalogInputs.AddRange(analogTags);
        }
        private void AddAnalogOutputTags()
        {
            var analogTags = new List<AnalogOutput>()
            {
                new AnalogOutput(5, "Strujica", "Opis", "", 1, 0, 20, "mA"),
                new AnalogOutput(5, "Naponcic", "Opis", "", 1, 0, 20, "V"),
                new AnalogOutput(5, "Snagica", "Opis", "", 1, 0, 20, "KW"),
            };
            _dataContext.AnalogOutputs.AddRange(analogTags);
        }
        private void AddDigitalInputTags()
        {
            var digitalTags = new List<DigitalInput>()
            {
                new DigitalInput(0, "Digic 1", "", "", 1, false, ""),
                new DigitalInput(1, "Digic 2", "", "", 1, false, ""),
                new DigitalInput(0, "Digic 3", "", "", 1, false, "")
            };
            _dataContext.DigitalInputs.AddRange(digitalTags);
        }
        private void AddDigitalOutputTags()
        {
            var digitalTags = new List<DigitalOutput>()
            {
                new DigitalOutput("Digic Out 1", "Opis", 0, "", 0),
                new DigitalOutput("Digic Out 2", "Opis", 1, "", 0),
                new DigitalOutput("Digic Out 3", "Opis", 1, "", 0),
            };
            _dataContext.DigitalOutputs.AddRange(digitalTags);
        }
    }
}
