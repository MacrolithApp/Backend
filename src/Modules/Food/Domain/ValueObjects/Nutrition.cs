using Shared.Domain.Primitives;
using Modules.Food.Domain.Validation;

namespace Modules.Food.Domain.ValueObjects;

public sealed record Nutrition : ValueObject
{
    private const int MaximumQuantity = 1000;
    private const int MinimumQuantity = 0;
    private Nutrition(
        int grams,
        int calories,
        int carbohydrates,
        int protein,
        int fats,
        int? sugar,
        int? saturatedFats,
        int? fiber,
        int? sodium)
    {
        Grams = grams;
        Calories = calories;
        Carbohydrates = carbohydrates;
        Protein = protein;
        Fats = fats;
        Sugar = sugar;
        SaturatedFats = saturatedFats;
        Fiber = fiber;
        Sodium = sodium;
    }

    public int Grams { get; }
    public int Calories { get; }
    public int Carbohydrates { get; }
    public int Protein { get; }
    public int Fats { get; }
    public int? Sugar { get; }
    public int? SaturatedFats { get; }
    public int? Fiber { get; }
    public int? Sodium { get; }

    public static Result<Nutrition> Create(
    int grams,
    int calories,
    int carbohydrates,
    int protein,
    int fats,
    int? sugar = null,
    int? saturatedFats = null,
    int? fiber = null,
    int? sodium = null)
    => new Nutrition(
            grams,
            calories,
            carbohydrates,
            protein,
            fats,
            sugar,
            saturatedFats,
            fiber,
            sodium)
        .ValidateMinimum()
        .ValidateMaximum();

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Grams;
        yield return Calories;
        yield return Carbohydrates;
        yield return Protein;
        yield return Fats;
        yield return Sugar ?? 0;
        yield return SaturatedFats ?? 0;
        yield return Fiber ?? 0;
        yield return Sodium ?? 0;
    }
}