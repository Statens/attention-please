using System;
using System.Collections.Generic;
using System.Linq;
using AttentionPlease.Domain.Models;
using AttentionPlease.Domain.Repositories;

namespace AttentionPlease.Domain.Services
{
    public class CelebrationService
    {
        private readonly ICalendarRepository _calendarRepository;
        private readonly ICalendarSubscriptionRepository _calendarSubscriptionRepository;

        public CelebrationService(
            ICalendarRepository calendarRepository, 
            ICalendarSubscriptionRepository calendarSubscriptionRepository)
        {
            _calendarRepository = calendarRepository;
            _calendarSubscriptionRepository = calendarSubscriptionRepository;
        }

        public IEnumerable<Celebration> AllCelebrations()
        {
            return _calendarRepository.GetAll(x => true).SelectMany(x => x.Celebrations);
        }

        public IEnumerable<Calendar> Calendars()
        {
            return _calendarRepository.GetAll(x => true);
        }
    }
}