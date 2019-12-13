using System;
using System.ComponentModel.DataAnnotations;

namespace AttentionPlease.Domain.Models
{
    public class Calendar
    {
        [Key]
        public virtual Guid Id { get; set; }

        //public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public Calendar()
        {
        }

        public Calendar(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}