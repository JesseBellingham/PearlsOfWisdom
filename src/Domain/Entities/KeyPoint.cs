using PearlsOfWisdom.Domain.Common;

namespace PearlsOfWisdom.Domain.Entities
{
    public class KeyPoint : AuditableEntity
    {
        public string Text { get; set; }
    }
}