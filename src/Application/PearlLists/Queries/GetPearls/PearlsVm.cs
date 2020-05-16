using System.Collections.Generic;

namespace PearlsOfWisdom.Application.PearlLists.Queries.GetPearls
{
    public class PearlsVm
    {
        public IList<PearlListDto> Lists { get; set; } = new List<PearlListDto>();
    }
}
