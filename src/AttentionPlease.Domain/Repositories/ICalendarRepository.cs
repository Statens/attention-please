using System;
using System.Collections.Generic;
using AttentionPlease.Domain.Models;

namespace AttentionPlease.Domain.Repositories
{
    public interface ICalendarRepository : IRepository<Calendar>
    {
        IEnumerable<Calendar> GetById(IEnumerable<Guid> id);
    }
}