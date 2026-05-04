namespace Shared.Domain.Primitives;

public sealed class Result<T> : Result
{
    private readonly T? _value;

    internal Result(T? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    public T Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("Cannot access Value of a failed result.");

    public static implicit operator Result<T>(T value) =>
        Result.Success(value);
}