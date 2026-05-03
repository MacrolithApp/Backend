using Shared.Domain.Bases.Id;
using Shared.Domain.Methods;

namespace Shared.Domain.TypedIds.Plans;

public readonly struct WeeklyPlanId : IEntityId<Guid>
{
    public WeeklyPlanId() : this(Guid.Empty) { }
    private WeeklyPlanId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; init; }

    public static WeeklyPlanId New() => new(Guid.NewGuid());
    public static WeeklyPlanId New(Guid id) => new(id);
    public static WeeklyPlanId New(string id) => new(Guid.Parse(id));
    public static Guid Unwrap(WeeklyPlanId id) => id.Value;
    public static Guid? Unwrap(WeeklyPlanId? id) => id?.Value;

    public override bool Equals(object? obj)
        => obj is WeeklyPlanId foodId && this == foodId;

    public override int GetHashCode()
        => this.Value.GetHashCode() * PrimeNumberGenerator.GetRandomPrime();

    public override string ToString()
        => this.Value.ToString();

    public static bool operator ==(WeeklyPlanId left, WeeklyPlanId right)
        => left.Value == right.Value;

    public static bool operator !=(WeeklyPlanId left, WeeklyPlanId right)
        => !(left == right);
}