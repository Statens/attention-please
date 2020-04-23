using System;
using AttentionPlease.Domain.Repositories;

namespace AttentionPlease.Domain.Models
{
    public class CalendarSubscription : IAggregate
    {
        public virtual Guid Id { get; set; }

        public virtual Guid CalendarId { get; set; }

        public virtual string UserId { get; set; }
    }
}