using System;
using AutoMapper;
using PearlsOfWisdom.Application.Common.Mappings;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.PearlLists.Queries.Shared
{
    public class KeyPointVm : IMapFrom<KeyPoint>
    {
        public Guid PearlItemId { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<KeyPoint, KeyPointVm>();
        }
    }
}