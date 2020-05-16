using System;
using PearlsOfWisdom.Application.Common.Mappings;
using PearlsOfWisdom.Domain.Entities;
using System.Collections.Generic;

namespace PearlsOfWisdom.Application.PearlLists.Queries.GetPearls
{
    public class PearlListDto : IMapFrom<PearlList>
{
    public PearlListDto()
    {
        Items = new List<PearlItemDto>();
    }

    public Guid Id { get; set; }

    public string Title { get; set; }

    public IList<PearlItemDto> Items { get; set; }
}
}
