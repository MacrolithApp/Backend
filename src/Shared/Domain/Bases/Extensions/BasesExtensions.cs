using Shared.Domain.Bases.Entities;
using Shared.Domain.Events;
using Shared.Domain.Primitives;

namespace Shared.Domain.Bases.Extensions;

public static class BasesExtensions
{
    extension<TAggregate>(TAggregate aggregate) where TAggregate : BaseAggregateRoot
    {
        public Result<TAggregate> RaiseDomainEvent(IDomainEvent domainEvent)
        {
            aggregate.RaiseDomainEvent(domainEvent);
            return Result.Success(aggregate);
        }
    }

    extension<TAggregate>(Result<TAggregate> result) where TAggregate : BaseAggregateRoot
    {
        public Result<TAggregate> RaiseDomainEvent(IDomainEvent domainEvent)
        {
            if (result.IsFailure)
                return result;

            result.Value.RaiseDomainEvent(domainEvent);
            return result;
        }
    }
}