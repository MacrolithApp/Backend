using Shared.Domain.TypedIds.Foods;

namespace Modules.Food.Domain.Repositories;

public interface IReads
{
    Task<Food> GetByIdAsync(FoodId id, CancellationToken ct = default);

    Task<IReadOnlyList<Food>> GetAllAsync(int page, int pageSize, CancellationToken ct = default);
}