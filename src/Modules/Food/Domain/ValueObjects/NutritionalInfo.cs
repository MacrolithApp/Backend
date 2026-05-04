using Shared.Domain.Primitives;
using Modules.Food.Domain.Validation;

namespace Modules.Food.Domain.ValueObjects;

public sealed record NutritionalInfo
{
    private NutritionalInfo(
        float calories,
        float carbohydrates,
        float protein,
        float fats,
        float? sugar,
        float? saturatedFats,
        float? fiber,
        float? sodium)
    {
        Calories = calories;
        Carbohydrates = carbohydrates;
        Protein = protein;
        Fats = fats;
        Sugar = sugar;
        SaturatedFats = saturatedFats;
        Fiber = fiber;
        Sodium = sodium;
    }

    public float Calories { get; }
    public float Carbohydrates { get; }
    public float Protein { get; }
    public float Fats { get; }
    public float? Sugar { get; }
    public float? SaturatedFats { get; }
    public float? Fiber { get; }
    public float? Sodium { get; }

    public static Result<NutritionalInfo> Create(
        float calories,
        float carbohydrates,
        float protein,
        float fats,
        float? sugar = null,
        float? saturatedFats = null,
        float? fiber = null,
        float? sodium = null)
    {
        if (calories < 0 || carbohydrates < 0 || protein < 0 || fats < 0)
            return Result.Failure<NutritionalInfo>(FoodErrors.InvalidNutrition);

        if (sugar < 0 || saturatedFats < 0 || fiber < 0 || sodium < 0)
            return Result.Failure<NutritionalInfo>(FoodErrors.InvalidNutrition);

        return Result.Success(new NutritionalInfo(
            calories, carbohydrates, protein, fats,
            sugar, saturatedFats, fiber, sodium));
    }
}