using System;
using System.Collections.Generic;
using AutoMapper;
using PearlsOfWisdom.Application.Common.Mappings;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.PearlLists.Queries.Shared
{
    public class PearlItemVm : IMapFrom<PearlItem>
    {
        public Guid Id { get; set; }

        public Guid ListId { get; set; }

        public string Title { get; set; }
        
        public string Transcription { get; set; }
        
        public string Author { get; set; }

        public bool Done { get; set; }

        public string Note { get; set; }
        
        public IList<KeyPointVm> KeyPoints { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PearlItem, PearlItemVm>();
        }
    }
}
