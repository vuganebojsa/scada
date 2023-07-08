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
        ICollection<Tag> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType);
        ICollection<Tag> GetLastValuesOfAITags(SortType sortType);
        ICollection<Tag> GetLastValuesOfDITags(SortType sortType);
        ICollection<PastTagValuesDTO> GetAllTagValuesById(string tagId, SortType sortType);




    }
}
