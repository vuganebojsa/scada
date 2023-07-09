using scada.DTOS;
using scada.Enums;
using scada.Models;

namespace scada.Interfaces
{
    public interface IReportService
    {
        ICollection<Alarm> GetAlarmsInTimePeriod(DateTime from, DateTime to, SortType sortType);
        ICollection<AlarmReportDTO> GetAlarmsByPriority(int priority, SortType sortType);

        ICollection<PastTagValuesDTO> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType);

        ICollection<PastTagValuesDTO> GetLastValuesOfAITags(SortType sortType);
        ICollection<PastTagValuesDTO> GetLastValuesOfDITags(SortType sortType);
        ICollection<PastTagValuesDTO> GetTagValuesById(string tagId, SortType sortType);

    }
}
