using System.Collections.Generic;
using PearlsOfWisdom.Domain.Common;

namespace PearlsOfWisdom.Domain.Entities
{
    public class PearlList : AuditableEntity
    {
        public PearlList()
        {
            Items = new List<PearlItem>();
        }

        public string Title { get; set; }

        public string Colour { get; set; }

        public IList<PearlItem> Items { get; set; }
    }
}