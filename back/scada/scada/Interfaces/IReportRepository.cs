using scada.DTOS;
using scada.Enums;
using scada.Models;

namespace scada.Interfaces
{
    public interface IReportRepository
    {
        Task<ICollection<Alarm>> GetAlarms(string priority);
        Task<ICollection<GetAlarmDTO>> GetAlarmsInTimePeriod(DateTime from, DateTime to, SortType sortType);
        Task<ICollection<Alarm>> GetAlarmsByPriority(int priority, SortType sortType);
        Task<ICollection<PastTagValues>> GetTagsInTimePeriod(DateTime from, DateTime to, SortType sortType);
        Task<ICollection<PastTagValues>> GetLastValuesOfAITags(SortType sortType);
        Task<ICollection<PastTagValues>> GetLastValuesOfDITags(SortType sortType);
        Task<ICollection<PastTagValuesDTO>> GetAllTagValuesById(string tagId, SortType sortType);




    }
}
