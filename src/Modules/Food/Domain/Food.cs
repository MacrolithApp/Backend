using Modules.Food.Domain.Events;
using Modules.Food.Domain.Validation;
using Modules.Food.Domain.ValueObjects;
using Shared.Domain.Bases.Entities;
using Shared.Domain.Primitives;
using Shared.Domain.TypedIds.Foods;

namespace Modules.Food.Domain;

public sealed class Food : BaseAggregateRoot
{
    private Food() { }

    private Food(FoodId id, string name, NutritionalInfo nutrition) : this()
    {
        this.Id = id;
        this.Name = name;
        this.Nutrition = nutrition;
    }

    public FoodId Id { get; init; }
    public string Name { get; private set; } = null!;
    public NutritionalInfo Nutrition { get; private set; } = null!;

    public static Result<Food> Create(string name, NutritionalInfo nutrition)
    {
        if (string.IsNullOrWhiteSpace(name))
            return FoodErrors.InvalidName;

        if (nutrition is null)
            return FoodErrors.InvalidNutrition;

        Food food = new(FoodId.New(), name, nutrition);

        food.RaiseDomainEvent(new FoodCreatedEvent(food.Id));

        return Result.Success(food);
    }

    public Result UpdateNutrition(NutritionalInfo newNutrition)
    {
        if (newNutrition is null)
            return FoodErrors.InvalidNutrition;

        Nutrition = newNutrition;

        this.RaiseDomainEvent(new FoodCreatedEvent(this.Id));

        return Result.Success();
    }
}