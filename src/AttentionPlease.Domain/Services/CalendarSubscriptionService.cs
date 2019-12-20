using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttentionPlease.Domain.Models;
using AttentionPlease.Domain.Repositories;

namespace AttentionPlease.Domain.Services
{
    public class CalendarSubscriptionService
    {
        private readonly ICalendarRepository _calendarRepository;
        private readonly ICalendarSubscriptionRepository _calendarSubscriptionRepository;

        public CalendarSubscriptionService(ICalendarRepository calendarRepository, ICalendarSubscriptionRepository calendarSubscriptionRepository)
        {
            _calendarRepository = calendarRepository;
            _calendarSubscriptionRepository = calendarSubscriptionRepository;
        }

        public IEnumerable<Calendar> GetCalendarsByUser(string user)
        {
            var subscriptions = _calendarSubscriptionRepository.GetByUser(user);
            return subscriptions.Select(c => c.Calendar);
        }
        
        public Calendar StoreCalendar(Calendar calendar)
        {
            return _calendarRepository.Save(calendar);
        }
    }
}
