using scada.DTOS;
using scada.Models;

namespace scada.Interfaces
{
    public interface ITagRepository
    {
        ICollection<Tag> GetTags();
        ICollection<Tag> GetOutTags();
        bool DeleteOutTag(int id, string type);
        ICollection<Tag> GetInTags();
        bool SetScan(int id, string type, bool isOn);
        AnalogOutputDTO CreateAnalogOutput(AnalogOutputDTO analogOutputDTO);
        AnalogInput createAnalogInput(AnalogInputDTO analogInputDTO);
        DigitalOutputDTO CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto);
        DigitalInputDTO CreateDigitalInputTag(DigitalInputDTO digitalTagDto);
        bool DeleteInTag(int id, string type);
        ICollection<AnalogInput> GetAnalogInputTags();
    }
}
