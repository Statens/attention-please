﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            return _calendarRepository.GetByIds(subscriptions.Select(x => x.CalendarId));
            // return subscriptions.Select(c => c.Calendar);
        }
        
        public Calendar CreateCalendar(string calendarName, ClaimsIdentity user)
        {   
            var calendar = new Calendar(name: calendarName);
            
            var subscription = new CalendarSubscription
            {
                CalendarId = calendar.Id,
                UserId = user.Name
            };

            _calendarSubscriptionRepository.Save(subscription);
            return _calendarRepository.Save(calendar);
        }
    }
}
