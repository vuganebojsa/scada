using scada.DTOS;
using scada.Enums;
using scada.Models;

namespace scada.Interfaces
{
    public interface IReportRepository
    {
        ICollection<Alarm> GetAlarms(string priority);
        ICollection<Alarm> GetAlarmsInTimePeriod(DateTime from, DateTime to, SortType sortType);
        ICollection<Alarm> GetAlarmsByPriority(int priority, SortType sortType);
        ICollection<PastTagValues> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType);
        ICollection<PastTagValues> GetLastValuesOfAITags(SortType sortType);
        ICollection<PastTagValues> GetLastValuesOfDITags(SortType sortType);
        ICollection<PastTagValuesDTO> GetAllTagValuesById(string tagId, SortType sortType);




    }
}
