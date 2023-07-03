using scada.Data;
using scada.Interfaces;
using scada.Models;

namespace scada.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly DataContext _context;
        public ReportRepository(DataContext context)
        {
            _context = context;
        }

        ICollection<Alarm> IReportRepository.GetAlarms(string priority)
        {
            throw new NotImplementedException();
        }
    }
}
