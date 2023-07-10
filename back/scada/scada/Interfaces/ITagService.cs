using scada.DTOS;
using scada.Models;

namespace scada.Interfaces
{
    public interface ITagService
    {

        ICollection<InTagDTO> GetInTags();
        bool DeleteOutTag(int id, string type);
        bool SetScan(int id, string type, bool isOn);
        ICollection<OutTagDTO> GetOutTags();

        bool SetValue(int id, string type, int value);

        AnalogInput createAnalogInput(AnalogInputDTO analogTagDto);
        AnalogOutputDTO CreateOutputTag(AnalogOutputDTO analogOutputDTO);
        DigitalOutputDTO CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto);
        DigitalInputDTO CreateDigitalInputTag(DigitalInputDTO digitalTagDto);
        bool DeleteInTag(int id, string type);
    }
}
