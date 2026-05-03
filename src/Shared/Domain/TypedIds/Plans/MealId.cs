using Shared.Domain.Bases.Id;
using Shared.Domain.Methods;

namespace Shared.Domain.TypedIds.Plans;

public readonly struct MealId : IEntityId<Guid>
{
    public MealId() : this(Guid.Empty) { }
    private MealId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; init; }

    public static MealId New() => new(Guid.NewGuid());
    public static MealId New(Guid id) => new(id);
    public static MealId New(string id) => new(Guid.Parse(id));
    public static Guid Unwrap(MealId id) => id.Value;
    public static Guid? Unwrap(MealId? id) => id?.Value;

    public override bool Equals(object? obj)
        => obj is MealId foodId && this == foodId;

    public override int GetHashCode()
        => this.Value.GetHashCode() * PrimeNumberGenerator.GetRandomPrime();

    public override string ToString()
        => this.Value.ToString();

    public static bool operator ==(MealId left, MealId right)
        => left.Value == right.Value;

    public static bool operator !=(MealId left, MealId right)
        => !(left == right);
}