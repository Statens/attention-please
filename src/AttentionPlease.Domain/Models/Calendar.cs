using System;
using System.Collections.Generic;
using AttentionPlease.Domain.Repositories;

namespace AttentionPlease.Domain.Models
{
    public class Calendar : IAggregate
    {
        public virtual Guid Id { get; set; }
        
        public virtual string Name { get; set; }

        public virtual List<AnniversaryCelebration> AnniversaryCelebrations { get; set; }
        
        public virtual List<Celebration> Celebrations { get; set; }

        public Calendar()
        {
            //AnniversaryCelebrations = new List<AnniversaryCelebration>();
            //Celebrations = new List<Celebration>();
        }

        public Calendar(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            AnniversaryCelebrations = new List<AnniversaryCelebration>();
            Celebrations = new List<Celebration>();
        }
    }
}