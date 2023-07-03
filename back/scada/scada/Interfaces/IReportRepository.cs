using scada.Models;

namespace scada.Interfaces
{
    public interface IReportRepository
    {
        ICollection<Alarm> GetAlarms(string priority);

    }
}
