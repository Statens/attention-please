using System;
using System.Collections.Generic;

namespace AttentionPlease.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, T> predicate);

        T Save(T entity);
    }
}