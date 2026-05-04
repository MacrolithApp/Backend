using Shared.Domain.Events;
using Shared.Domain.TypedIds.Foods;

namespace Modules.Food.Domain.Events;

public record FoodNutritionUpdatedEvent(FoodId FoodId) : IDomainEvent;