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

        public async Task<ICollection<AlarmReportDTO>> GetAlarmsByPriority(int priority, SortType sortType)
        {
            var alarms =  await this._reportRepository.GetAlarmsByPriority(priority, sortType);
            var alarmsDTO = new List<AlarmReportDTO>();
            foreach(Alarm alarm in alarms)
            {
                alarmsDTO.Add(new AlarmReportDTO(alarm));
            }
            return alarmsDTO;
        }

        public async Task<ICollection<GetAlarmDTO>> GetAlarmsInTimePeriod(DateTime from, DateTime to, SortType sortType)
        {
            return await this._reportRepository.GetAlarmsInTimePeriod(from, to, sortType);
        }

        public async Task<ICollection<PastTagValuesDTO>> GetLastValuesOfAITags(SortType sortType)
        {
            var tags = await this._reportRepository.GetLastValuesOfAITags(sortType);
            var pastTags = new List<PastTagValuesDTO>();
            foreach (var tag in tags)
            {
                pastTags.Add(new PastTagValuesDTO(tag.value, tag.timeStamp, tag.tag.tagName));
            }
            return pastTags;
        }

        public async Task<ICollection<PastTagValuesDTO>> GetLastValuesOfDITags(SortType sortType)
        {
            var tags = await this._reportRepository.GetLastValuesOfDITags(sortType);
            var pastTags = new List<PastTagValuesDTO>();
            foreach (var tag in tags)
            {
                pastTags.Add(new PastTagValuesDTO(tag.value, tag.timeStamp, tag.tag.tagName));
            }
            return pastTags;
        }

        public async Task<ICollection<PastTagValuesDTO>> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType)
        {
            var tags = await this._reportRepository.GetTagsInTimePeriod(from, to, sortType);
            var pastTags = new List<PastTagValuesDTO>();
            foreach(var tag in tags)
            {
                pastTags.Add(new PastTagValuesDTO(tag.value, tag.timeStamp, tag.tag.tagName));
            }
            return pastTags;
        }

        public async Task<ICollection<PastTagValuesDTO>> GetTagValuesById(string tagId, SortType sortType)
        {
            return await this._reportRepository.GetAllTagValuesById(tagId, sortType);
        }
    }
}
