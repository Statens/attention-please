using System;
using System.ComponentModel.DataAnnotations;

namespace AttentionPlease.Domain.Models
{
    public class AnniversaryCelebration
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual string Summary { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime Day { get; set; }
    }
}