using PearlsOfWisdom.Application.Common.Mappings;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.PearlLists.Queries.Shared
{
    public class KeyPointDto : IMapFrom<KeyPoint>
    {
        public string Text { get; set; }
    }
}