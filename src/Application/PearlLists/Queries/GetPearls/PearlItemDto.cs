using System;
using AutoMapper;
using PearlsOfWisdom.Application.Common.Mappings;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.PearlLists.Queries.GetPearls
{
    public class PearlItemDto : IMapFrom<PearlItem>
    {
        public Guid Id { get; set; }

        public Guid ListId { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }

        public string Note { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PearlItem, PearlItemDto>();
        }
    }
}
