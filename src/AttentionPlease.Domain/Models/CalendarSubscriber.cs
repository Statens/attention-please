using System;
using System.ComponentModel.DataAnnotations;

namespace AttentionPlease.Domain.Models
{
    public class CalendarSubscriber
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual Guid CalendarId { get; set; }

        public virtual string UserId { get; set; }
    }
}