﻿using scada.DTOS;
using scada.Interfaces;
using scada.Models;

namespace scada.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public DigitalInputDTO CreateDigitalInputTag(DigitalInputDTO digitalTagDto)
        {
            return this._tagRepository.CreateDigitalInputTag(digitalTagDto);
        }

        public DigitalOutputDTO CreateDigitalOutputTag(DigitalOutputDTO digitalTagDto)
        {

            return this._tagRepository.CreateDigitalOutputTag(digitalTagDto);
        }

        public bool DeleteOutTag(int id, string type)
        {
            return this._tagRepository.DeleteOutTag(id, type);
        }

        public ICollection<InTagDTO> GetInTags()
        {
            var tags = _tagRepository.GetInTags();

            var newTags = new List<InTagDTO>();
            foreach(Tag tag in tags)
            {
                if (tag is AnalogInput)
                    newTags.Add(new InTagDTO(tag.id, tag.tagName, tag.currentValue, (tag as AnalogInput).OnOffScan, "AnalogInput"));
                else
                    newTags.Add(new InTagDTO(tag.id, tag.tagName, tag.currentValue, (tag as DigitalInput).OnOffScan, "DigitalInput"));

            }

            return newTags;
        }

        public ICollection<OutTagDTO> GetOutTags()
        {
            var tags = this._tagRepository.GetOutTags();

            var newTags = new List<OutTagDTO>();
            foreach(Tag tag in tags)
            {
                if (tag is AnalogOutput)
                    newTags.Add(new OutTagDTO(tag.id, tag.tagName, tag.currentValue, "AnalogOutput"));
                else
                    newTags.Add(new OutTagDTO(tag.id, tag.tagName, tag.currentValue, "DigitalOutput"));

            }

            return newTags;
        }


        public AnalogOutputDTO CreateOutputTag(AnalogOutputDTO analogOutputDTO)
        {
            return this._tagRepository.CreateAnalogOutput(analogOutputDTO);
        }

        public bool SetScan(int id, string type, bool isOn)
        {
            return this._tagRepository.SetScan(id, type, isOn);
        }

        public AnalogInput createAnalogInput(AnalogInputDTO analogTagDto)
        {
            
            return this._tagRepository.createAnalogInput(analogTagDto);

        }
    }
}
