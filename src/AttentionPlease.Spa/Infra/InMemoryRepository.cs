using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AttentionPlease.Domain.Models;
using AttentionPlease.Domain.Repositories;

namespace AttentionPlease.Spa.Infra
{
    public class InMemoryRepository : ICalendarSubscriptionRepository, ICalendarRepository
    {
        private readonly IDictionary<Guid, object> _store = new ConcurrentDictionary<Guid, object>();

        public InMemoryRepository()
        {
            var celebrations = new[]
            {
                Celebration.Birthday(DateTime.Parse("2015-02-22T22:11:00.000Z"), "Signe큦 birthday"),
                Celebration.Birthday(DateTime.Parse("2009-04-04T03:42:00.000Z"), "Desmond큦 birthday"),
                new Celebration
                (
                    DateTime.Parse("2005-07-03T18:15:00.000Z"),
                    "J+J first date",
                    CelebrationType.Anniversary
                ),
                new Celebration(
                    DateTime.Parse("2011-11-05T18:00:00.000Z"),
                    "J+J wedding day",
                    CelebrationType.WeddingDay
                ),
                new Celebration(
                    DateTime.Parse("1980-06-01T08:00:00.000Z"),
                  "Jenny큦 birthday",
                 CelebrationType.Birthday),
                new Celebration(
                   DateTime.Parse("1980-05-16T12:00:00.000Z"),
                 "Jonas큦 birthday",
                  CelebrationType.Birthday
                    )
            };

            var calendar = new Calendar("Fam Jerndin") {Celebrations = celebrations.ToList()};

            Save(calendar);
        }


        public IEnumerable<Calendar> GetAll(Func<Calendar, bool> match) => GetAllBase(match);

        public IEnumerable<CalendarSubscription> GetAll(Func<CalendarSubscription, bool> match) => GetAllBase(match);

        private IEnumerable<T> GetAllBase<T>(Func<T, bool> match) where T: class
        {
            return _store.Values.Where(x => x.GetType() == typeof(T)).Cast<T>().Where(match);
        }

        IEnumerable<Calendar> IRepository<Calendar>.GetByIds(IEnumerable<Guid> ids)
            => GetByIdsBase<Calendar>(ids);

        IEnumerable<CalendarSubscription> IRepository<CalendarSubscription>.GetByIds(IEnumerable<Guid> ids) 
            => GetByIdsBase<CalendarSubscription>(ids);

        private IEnumerable<T> GetByIdsBase<T>(IEnumerable<Guid> ids) where T : class, IAggregate
        {
            return _store.Values.Where(x => x.GetType() == typeof(T)).Cast<T>().Where(x => ids.Contains(x.Id));
        }

        public CalendarSubscription Save(CalendarSubscription entity)
        {
            _store[entity.Id] = entity;
            return entity;
        }

        public Calendar Save(Calendar entity)
        {
            _store[entity.Id] = entity;
            return entity;
        }

        public IEnumerable<CalendarSubscription> GetByUser(string user)
            => GetAllBase<CalendarSubscription>(x => x.UserId == user);
    }
}