namespace Modules.Food.Domain.Repositories;

public interface IWrites
{
    Task<Food> AddAsync(Food food, CancellationToken ct = default);
    void Remove(Food food);
}