namespace Modules.Food.Domain.Events;

public sealed record NutritionUpdatedDomainEvent(FoodId FoodId) : IDomainEvent;