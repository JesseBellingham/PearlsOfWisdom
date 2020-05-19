using System;
using PearlsOfWisdom.Domain.Common;

namespace PearlsOfWisdom.Domain.Entities
{
    public class KeyPoint : AuditableEntity
    {
        public string Text { get; set; }
        
        public PearlItem PearlItem { get; set; }
        
        public Guid PearlItemId { get; set; }
    }
}