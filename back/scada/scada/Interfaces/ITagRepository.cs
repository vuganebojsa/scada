using scada.DTOS;
using scada.Models;

namespace scada.Interfaces
{
    public interface ITagRepository
    {
        Task<ICollection<Tag>> GetTags();
        Task<ICollection<Tag>> GetOutTags();
        Task<bool> DeleteOutTag(int id, string type);
        Task<ICollection<Tag>> GetInTags();
        Task<bool> SetScan(int id, string type, bool isOn);

        Task<bool> SetValue(int id, string type, int value);
        Task<AnalogOutputDTO> CreateAnalogOutput(AnalogOutputDTO analogOutputDTO);
        Task<AnalogInput> createAnalogInput(AnalogInputDTO analogInputDTO);
        Task<DigitalOutputDTO> CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto);
        Task<DigitalInputDTO> CreateDigitalInputTag(DigitalInputDTO digitalTagDto);
        Task<bool> DeleteInTag(int id, string type);
        Task<AnalogInput> GetAnalogInputById(int id);
        Task<DigitalInput> GetDigitalInputById(int id);
        Task<DigitalOutput> GetDigitalOutputById(int id);
        Task<AnalogOutput> GetAnalogOutputById(int id);
        Task<List<Tag>> GetAllTagsWithScanOn();
        Task<ICollection<DigitalInput>> GetDigitalInputTags();
        Task<ICollection<AnalogInput>> GetAnalogInputTags();

        Task CreatePastTagValue(PastTagValues pastTagValues);
        Task UpdateAnalogInput(AnalogInput analogInput);
        Task UpdateDigitalInput(DigitalInput digitalInput);

    }
}
