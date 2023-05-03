using Core.Entities;

namespace Core.Interfaces
{
    public interface IBaseRepository<T> where T: EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);
    }
}