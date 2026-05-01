using Shared.Domain.Methods;

namespace Shared.Domain.Bases.Entities;

public abstract class BaseEntity : IEquatable<BaseEntity>
{
    protected BaseEntity(Guid id)
    {
        this.Id = id;
    }

    public Guid Id { get; private init; }

    public static bool operator ==(BaseEntity? first, BaseEntity? second)
        => first is not null && second is not null && first.Equals(second);

    public static bool operator !=(BaseEntity? first, BaseEntity? second)
        => !(first == second);

    public bool Equals(BaseEntity? other)
    {
        if (other is null || other.GetType() != this.GetType()) return false;

        return other.Id == this.Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != this.GetType()) return false;

        if (obj is not BaseEntity entity) return false;

        return entity.Id == this.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * PrimeNumberGenerator.GetRandomPrime();
    }
}