using System;
using System.Collections.Generic;

namespace AttentionPlease.Domain.Repositories
{
    public interface IRepository<T> where T : class, IAggregate
    {
        IEnumerable<T> GetAll(Func<T, bool> match);

        IEnumerable<T> GetByIds(IEnumerable<Guid> ids);

        T Save(T entity);
    }
}