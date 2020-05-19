using System;
using System.Collections.Generic;
using PearlsOfWisdom.Application.Common.Mappings;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.PearlLists.Queries.Shared
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
