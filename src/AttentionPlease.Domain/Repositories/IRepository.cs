using System;
using System.Collections.Generic;
using AttentionPlease.Domain.Models;

namespace AttentionPlease.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, T> predicate);

        T Save(T entity);
    }

    public interface ICalendarRepository : IRepository<Calendar>
    {

    }

    public interface ICalendarSubscriberRepository : IRepository<CalendarSubscriber>
    {

    }
}