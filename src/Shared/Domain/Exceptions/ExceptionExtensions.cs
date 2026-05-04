using System.Linq.Expressions;
using Shared.Domain.Bases.Entities;
using Shared.Domain.Primitives;

namespace Shared.Domain.Exceptions;

public static class ExceptionExtensions
{
    extension<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        public Result<TEntity> CheckIf<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            Predicate<TProperty?> predicate,
            Error error)
        {
            TProperty? value = expression.Compile().Invoke(entity);

            if (predicate(value))
                return Result.Failure<TEntity>(error);

            return Result.Success(entity);
        }
    }

    extension<TEntity>(Result<TEntity> result) where TEntity : BaseEntity
    {
        public Result<TEntity> CheckIf<TProperty>(
            Expression<Func<TEntity, TProperty>> expression,
            Predicate<TProperty?> predicate,
            Error error)
        {
            if (result.IsFailure)
                return result;

            return result.Value.CheckIf(expression, predicate, error);
        }
    }
}