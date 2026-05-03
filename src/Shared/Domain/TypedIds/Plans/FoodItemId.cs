using Shared.Domain.Bases.Id;
using Shared.Domain.Methods;

namespace Shared.Domain.TypedIds.Plans;

public readonly struct FoodItemId : IEntityId<Guid>
{
    public FoodItemId() : this(Guid.Empty) { }
    private FoodItemId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; init; }

    public static FoodItemId New() => new(Guid.NewGuid());
    public static FoodItemId New(Guid id) => new(id);
    public static FoodItemId New(string id) => new(Guid.Parse(id));
    public static Guid Unwrap(FoodItemId id) => id.Value;
    public static Guid? Unwrap(FoodItemId? id) => id?.Value;

    public override bool Equals(object? obj)
        => obj is FoodItemId foodId && this == foodId;

    public override int GetHashCode()
        => this.Value.GetHashCode() * PrimeNumberGenerator.GetRandomPrime();

    public override string ToString()
        => this.Value.ToString();

    public static bool operator ==(FoodItemId left, FoodItemId right)
        => left.Value == right.Value;

    public static bool operator !=(FoodItemId left, FoodItemId right)
        => !(left == right);
}