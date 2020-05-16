using System.Collections.Generic;
using PearlsOfWisdom.Application.PearlLists.Queries.GetTodos;

namespace PearlsOfWisdom.Application.PearlLists.Queries.GetPearls
{
    public class PearlsVm
    {
        public IList<PriorityLevelDto> PriorityLevels { get; set; } = new List<PriorityLevelDto>();

        public IList<PearlListDto> Lists { get; set; } = new List<PearlListDto>();
    }
}
