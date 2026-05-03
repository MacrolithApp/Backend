using Shared.Domain.Bases.Id;
using Shared.Domain.Methods;

namespace Shared.Domain.TypedIds.Accounts;

public readonly struct GoalId : IEntityId<Guid>
{
    public GoalId() : this(Guid.Empty) { }
    private GoalId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; init; }

    public static GoalId New() => new(Guid.NewGuid());
    public static GoalId New(Guid id) => new(id);
    public static GoalId New(string id) => new(Guid.Parse(id));
    public static Guid Unwrap(GoalId id) => id.Value;
    public static Guid? Unwrap(GoalId? id) => id?.Value;

    public override bool Equals(object? obj)
        => obj is GoalId foodId && this == foodId;

    public override int GetHashCode()
        => this.Value.GetHashCode() * PrimeNumberGenerator.GetRandomPrime();

    public override string ToString()
        => this.Value.ToString();

    public static bool operator ==(GoalId left, GoalId right)
        => left.Value == right.Value;

    public static bool operator !=(GoalId left, GoalId right)
        => !(left == right);
}