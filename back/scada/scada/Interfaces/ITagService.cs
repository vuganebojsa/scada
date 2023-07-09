using scada.DTOS;

namespace scada.Interfaces
{
    public interface ITagService
    {

        ICollection<InTagDTO> GetInTags();
        bool DeleteOutTag(int id, string type);
        bool SetScan(int id, string type, bool isOn);
        ICollection<OutTagDTO> GetOutTags();
        AnalogOutputDTO CreateOutputTag(AnalogOutputDTO analogOutputDTO);
    }
}
