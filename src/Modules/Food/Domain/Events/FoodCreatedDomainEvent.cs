namespace Modules.Food.Domain.Events;

public sealed record FoodCreatedDomainEvent(FoodId FoodId) : IDomainEvent;