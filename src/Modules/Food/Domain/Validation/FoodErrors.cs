using Shared.Domain.Primitives;

namespace Modules.Food.Domain.Validation;

public static class FoodErrors
{
    public static readonly Error InvalidName =
        Error.Validation("Food.InvalidName", "Food name cannot be null or empty.");

    public static readonly Error InvalidNutrition =
        Error.Validation("Food.InvalidNutrition", "Nutritional info cannot be null or negative.");

    public static readonly Error NotFound =
        Error.NotFound("Food.NotFound", "The food item was not found.");
}