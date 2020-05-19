using System.Collections.Generic;
using PearlsOfWisdom.Application.PearlLists.Queries.Shared;

namespace PearlsOfWisdom.Application.PearlLists.Queries.GetPearlLists
{
    public class PearlListsVm
    {
        public IList<PearlListDto> Lists { get; set; } = new List<PearlListDto>();
    }
}
