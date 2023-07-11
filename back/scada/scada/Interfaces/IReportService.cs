using scada.DTOS;
using scada.Enums;
using scada.Models;

namespace scada.Interfaces
{
    public interface IReportService
    {
        Task<ICollection<Alarm>> GetAlarmsInTimePeriod(DateTime from, DateTime to, SortType sortType);
        Task<ICollection<AlarmReportDTO>> GetAlarmsByPriority(int priority, SortType sortType);

        Task<ICollection<PastTagValuesDTO>> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType);

        Task<ICollection<PastTagValuesDTO>> GetLastValuesOfAITags(SortType sortType);
        Task<ICollection<PastTagValuesDTO>> GetLastValuesOfDITags(SortType sortType);
        Task<ICollection<PastTagValuesDTO>> GetTagValuesById(string tagId, SortType sortType);

    }
}
