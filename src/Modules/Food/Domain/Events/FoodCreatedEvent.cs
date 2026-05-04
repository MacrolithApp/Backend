using Shared.Domain.Events;
using Shared.Domain.TypedIds.Foods;

namespace Modules.Food.Domain.Events;

public record FoodCreatedEvent(FoodId FoodId) : IDomainEvent;