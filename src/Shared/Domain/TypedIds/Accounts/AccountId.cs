using Shared.Domain.Bases.Id;
using Shared.Domain.Methods;

namespace Shared.Domain.TypedIds.Accounts;

public readonly struct AccountId : IEntityId<Guid>
{
	public AccountId() : this(Guid.Empty) { }
	private AccountId(Guid value)
	{
		Value = value;
	}

	public Guid Value { get; init; }

	public bool IsEmpty() => Value == Guid.Empty;
	public static AccountId New() => new(Guid.NewGuid());
	public static AccountId New(Guid id) => new(id);
	public static AccountId? New(Guid? id) => id is null ? null : new(id.Value);
	public static AccountId New(string? id) => id is null ? new() : new(Guid.Parse(id));
	public static Guid Unwrap(AccountId id) => id.Value;
	public static Guid? Unwrap(AccountId? id) => id?.Value;

	public override bool Equals(object? obj)
		=> obj is AccountId accountId && this == accountId;

	public override int GetHashCode()
		=> Value.GetHashCode() * PrimeNumberGenerator.GetRandomPrime();

	public override string ToString()
		=> Value.ToString();

	public static bool operator ==(AccountId left, AccountId right)
		=> left.Value == right.Value;

	public static bool operator !=(AccountId left, AccountId right)
		=> !(left == right);
}