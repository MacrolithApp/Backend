using Modules.Food.Domain.Events;
using Modules.Food.Domain.Validation;
using Modules.Food.Domain.ValueObjects;

namespace Modules.Food.Domain;

public sealed class Food : BaseAggregateRoot
{
    private Food() { }

    private Food(FoodId id, string name, Nutrition nutrition) : this()
    {
        this.Id = id;
        this.Name = name;
        this.Nutrition = nutrition;
    }

    public FoodId Id { get; init; }
    public string Name { get; private set; } = null!;
    public Nutrition Nutrition { get; private set; } = null!;

    public static Result<Food> Create(string name, Nutrition nutrition)
    {
        FoodId id = FoodId.New();

        return new Food(id, name, nutrition)
            .ValidateName()
            .ValidateNutrition()
            .RaiseDomainEvent(new FoodCreatedDomainEvent(id));
    }

    public Result UpdateNutrition(Nutrition newNutrition)
    {
        if (newNutrition is null)
            return FoodErrors.InvalidNutrition;

        Nutrition = newNutrition;

        this.RaiseDomainEvent(new NutritionUpdatedDomainEvent(this.Id));

        return Result.Success();
    }
}