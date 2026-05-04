namespace Shared.Domain.Primitives;

public abstract record ValueObject
{
    public abstract IEnumerable<object> GetAtomicValues();

    public virtual bool Equals(ValueObject? other)
        => other is not null
           && GetType() == other.GetType()
           && ValuesAreEqual(other);

    public override int GetHashCode()
        => GetAtomicValues().Aggregate(default(int), HashCode.Combine);

    private bool ValuesAreEqual(ValueObject other)
        => GetAtomicValues().SequenceEqual(other.GetAtomicValues());
}