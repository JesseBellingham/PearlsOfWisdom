using System;

namespace PearlsOfWisdom.Domain.Common
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; set; } = new Guid();
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
