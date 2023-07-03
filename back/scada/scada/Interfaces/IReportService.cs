using scada.Enums;
using scada.Models;

namespace scada.Interfaces
{
    public interface IReportService
    {
        ICollection<Alarm> GetAlarmsInTimePeriod(DateTime from, DateTime to, SortType sortType);
        ICollection<Alarm> GetAlarmsByPriority(int priority, SortType sortType);

        ICollection<Tag> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType);

        ICollection<Tag> GetLastValuesOfAITags(SortType sortType);
        ICollection<Tag> GetLastValuesOfDITags(SortType sortType);
        ICollection<Tag> GetTagValuesById(string tagId);

    }
}
