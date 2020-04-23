using System;

namespace AttentionPlease.Domain.Repositories
{
    public interface IAggregate
    {
        Guid Id { get; set; }
    }
}