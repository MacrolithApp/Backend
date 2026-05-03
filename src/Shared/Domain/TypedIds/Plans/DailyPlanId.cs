using Shared.Domain.Bases.Id;
using Shared.Domain.Methods;

namespace Shared.Domain.TypedIds.Plans;

public readonly struct DailyPlanId : IEntityId<Guid>
{
    public DailyPlanId() : this(Guid.Empty) { }
    private DailyPlanId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; init; }

    public static DailyPlanId New() => new(Guid.NewGuid());
    public static DailyPlanId New(Guid id) => new(id);
    public static DailyPlanId New(string id) => new(Guid.Parse(id));
    public static Guid Unwrap(DailyPlanId id) => id.Value;
    public static Guid? Unwrap(DailyPlanId? id) => id?.Value;

    public override bool Equals(object? obj)
        => obj is DailyPlanId foodId && this == foodId;

    public override int GetHashCode()
        => this.Value.GetHashCode() * PrimeNumberGenerator.GetRandomPrime();

    public override string ToString()
        => this.Value.ToString();

    public static bool operator ==(DailyPlanId left, DailyPlanId right)
        => left.Value == right.Value;

    public static bool operator !=(DailyPlanId left, DailyPlanId right)
        => !(left == right);
}