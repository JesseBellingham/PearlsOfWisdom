using System;
using System.Collections;
using System.Collections.Generic;
using PearlsOfWisdom.Domain.Common;

namespace PearlsOfWisdom.Domain.Entities
{
    public class PearlItem : AuditableEntity
    {
        public PearlItem()
        {
            KeyPoints = new List<KeyPoint>();
        }
        
        public Guid ListId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }
        
        public string Transcription { get; set; }
        public string Author { get; set; }
        
        public IList<KeyPoint> KeyPoints { get; private set; }

        public bool Done { get; set; }

        public PearlList List { get; set; }
    }
}