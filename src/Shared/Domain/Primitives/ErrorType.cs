namespace Shared.Domain.Primitives;

public enum ErrorType
{
    None,
    NotFound,
    Validation,
    Conflict,
    Failure
}