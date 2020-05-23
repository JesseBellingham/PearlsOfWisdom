using System;
using System.Collections.Generic;
using PearlsOfWisdom.Application.Common.Mappings;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.PearlLists.Queries.Shared
{
    public class PearlListVm : IMapFrom<PearlList>
    {
        public PearlListVm()
        {
            Items = new List<PearlItemVm>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public IList<PearlItemVm> Items { get; set; }
    }
}
