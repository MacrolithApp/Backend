using Modules.Food.Domain.ValueObjects;
using Shared.Domain.Exceptions;
using Shared.Domain.Primitives;
using static Modules.Food.Domain.FoodConstants;

namespace Modules.Food.Domain.Validation;

internal static class Validations
{
    extension(Food food)
    {
        internal Result<Food> ValidateName()
            => food.CheckIf(x => x.Name, x => x is null ||
             x.Length is < MinimumNameLength or > MaximumNameLength, FoodErrors.InvalidName);

        internal Result<Food> ValidateNutrition()
            => food.CheckIf(x => x.Nutrition, x => x is null, FoodErrors.InvalidNutrition);
    }

    extension(Result<Food> food)
    {
        internal Result<Food> ValidateName()
            => food.CheckIf(x => x.Name, string.IsNullOrWhiteSpace, FoodErrors.InvalidName);

        internal Result<Food> ValidateNutrition()
            => food.CheckIf(x => x.Nutrition, x => x is null, FoodErrors.InvalidNutrition);
    }

    extension(Nutrition nutrition)
    {
        internal Result<Nutrition> ValidateMinimum()
        {
            bool invalid =
                nutrition.Grams < MinimumQuantity ||
                nutrition.Calories < MinimumQuantity ||
                nutrition.Carbohydrates < MinimumQuantity ||
                nutrition.Protein < MinimumQuantity ||
                nutrition.Fats < MinimumQuantity ||
                nutrition.Sugar < MinimumQuantity ||
                nutrition.SaturatedFats < MinimumQuantity ||
                nutrition.Fiber < MinimumQuantity ||
                nutrition.Sodium < MinimumQuantity;

            return invalid
                ? FoodErrors.InvalidNutrition
                : Result.Success(nutrition);
        }

        internal Result<Nutrition> ValidateMaximum()
        {
            bool exceeded =
                nutrition.Grams >= MaximumQuantity ||
                nutrition.Carbohydrates >= MaximumQuantity ||
                nutrition.Protein >= MaximumQuantity ||
                nutrition.Fats >= MaximumQuantity ||
                nutrition.Sugar >= MaximumQuantity ||
                nutrition.SaturatedFats >= MaximumQuantity ||
                nutrition.Fiber >= MaximumQuantity ||
                nutrition.Sodium >= MaximumQuantity;

            return exceeded
                ? FoodErrors.QuantityExceeded
                : Result.Success(nutrition);
        }
    }

    extension(Result<Nutrition> result)
    {
        internal Result<Nutrition> ValidateMinimum()
            => result.IsFailure
                ? result
                : result.Value.ValidateMinimum();

        internal Result<Nutrition> ValidateMaximum()
            => result.IsFailure
                ? result
                : result.Value.ValidateMaximum();
    }
}