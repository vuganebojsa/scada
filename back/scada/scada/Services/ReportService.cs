using scada.DTOS;
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

        public ICollection<AlarmReportDTO> GetAlarmsByPriority(int priority, SortType sortType)
        {
            var alarms =  this._reportRepository.GetAlarmsByPriority(priority, sortType);
            var alarmsDTO = new List<AlarmReportDTO>();
            foreach(Alarm alarm in alarms)
            {
                alarmsDTO.Add(new AlarmReportDTO(alarm));
            }
            return alarmsDTO;
        }

        public ICollection<Alarm> GetAlarmsInTimePeriod(DateTime from, DateTime to, SortType sortType)
        {
            return this._reportRepository.GetAlarmsInTimePeriod(from, to, sortType);
        }

        public ICollection<Tag> GetLastValuesOfAITags(SortType sortType)
        {
            return this._reportRepository.GetLastValuesOfAITags(sortType);
        }

        public ICollection<Tag> GetLastValuesOfDITags(SortType sortType)
        {
            return this._reportRepository.GetLastValuesOfDITags(sortType);
        }

        public ICollection<PastTagValuesDTO> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType)
        {
            var tags =  this._reportRepository.GetTagsInTimePeriod(from, to, sortType);
            var pastTags = new List<PastTagValuesDTO>();
            foreach(var tag in tags)
            {
                pastTags.Add(new PastTagValuesDTO(tag.value, tag.timeStamp, tag.tag.tagName));
            }
            return pastTags;
        }

        public ICollection<PastTagValuesDTO> GetTagValuesById(string tagId, SortType sortType)
        {
            return this._reportRepository.GetAllTagValuesById(tagId, sortType);
        }
    }
}
