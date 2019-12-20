using System.Collections.Generic;
using AttentionPlease.Domain.Models;

namespace AttentionPlease.Domain.Repositories
{
    public interface ICalendarSubscriptionRepository : IRepository<CalendarSubscription>
    {
        IEnumerable<CalendarSubscription> GetByUser(string user);
    }
}