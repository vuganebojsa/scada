using scada.DTOS;
using scada.Models;

namespace scada.Interfaces
{
    public interface ITagService
    {

        Task<ICollection<InTagDTO>> GetInTags();
        Task <bool> DeleteOutTag(int id, string type);
        Task<bool> SetScan(int id, string type, bool isOn);
        Task<ICollection<OutTagDTO>> GetOutTags();

        Task StartSimulation();
        Task<bool> SetValue(int id, string type, int value);

        Task<AnalogInput> createAnalogInput(AnalogInputDTO analogTagDto);
        Task<AnalogOutputDTO> CreateOutputTag(AnalogOutputDTO analogOutputDTO);
        Task<DigitalOutputDTO> CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto);
        Task<DigitalInputDTO> CreateDigitalInputTag(DigitalInputDTO digitalTagDto);
        Task<bool> DeleteInTag(int id, string type);
        

      
    }
}
