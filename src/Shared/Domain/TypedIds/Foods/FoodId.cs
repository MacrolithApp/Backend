using Shared.Domain.Bases.Id;
using Shared.Domain.Methods;

namespace Shared.Domain.TypedIds.Foods;

public readonly struct FoodId : IEntityId<Guid>
{
    public FoodId() : this(Guid.Empty) { }
    private FoodId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; init; }

    public static FoodId New() => new(Guid.NewGuid());
    public static FoodId New(Guid id) => new(id);
    public static FoodId New(string id) => new(Guid.Parse(id));
    public static Guid Unwrap(FoodId id) => id.Value;
    public static Guid? Unwrap(FoodId? id) => id?.Value;

    public override bool Equals(object? obj)
        => obj is FoodId foodId && this == foodId;

    public override int GetHashCode()
        => this.Value.GetHashCode() * PrimeNumberGenerator.GetRandomPrime();

    public override string ToString()
        => this.Value.ToString();

    public static bool operator ==(FoodId left, FoodId right)
        => left.Value == right.Value;

    public static bool operator !=(FoodId left, FoodId right)
        => !(left == right);
}