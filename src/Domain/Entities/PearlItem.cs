using System;
using PearlsOfWisdom.Domain.Common;

namespace PearlsOfWisdom.Domain.Entities
{
    public class PearlItem : AuditableEntity
    {
        public Guid ListId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public bool Done { get; set; }

        public DateTime? Reminder { get; set; }

        public PearlList List { get; set; }
    }
}