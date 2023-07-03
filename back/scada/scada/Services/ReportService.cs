using scada.Enums;
using scada.Interfaces;
using scada.Models;

namespace scada.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository) {

            this._reportRepository = reportRepository;
        }

        public ICollection<Alarm> GetAlarmsByPriority(int priority, SortType sortType)
        {
            throw new NotImplementedException();
        }

        public ICollection<Alarm> GetAlarmsInTimePeriod(DateTime from, DateTime to, SortType sortType)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tag> GetLastValuesOfAITags(SortType sortType)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tag> GetLastValuesOfDITags(SortType sortType)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tag> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tag> GetTagValuesById(string tagId)
        {
            throw new NotImplementedException();
        }
    }
}
