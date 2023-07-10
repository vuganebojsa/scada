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

        bool SetValue(int id, string type, int value);
        AnalogOutputDTO CreateAnalogOutput(AnalogOutputDTO analogOutputDTO);
        AnalogInput createAnalogInput(AnalogInputDTO analogInputDTO);
        DigitalOutputDTO CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto);
        DigitalInputDTO CreateDigitalInputTag(DigitalInputDTO digitalTagDto);
        bool DeleteInTag(int id, string type);
        AnalogInput GetAnalogInputById(int id);
        DigitalInput GetDigitalInputById(int id);
        DigitalOutput GetDigitalOutputById(int id);
        AnalogOutput GetAnalogOutputById(int id);
        List<Tag> GetAllTagsWithScanOn();
        ICollection<DigitalInput> GetDigitalInputTags();
        ICollection<AnalogInput> GetAnalogInputTags();

    }
}
