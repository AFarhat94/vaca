using Core.Interfaces;
using Core.Entities;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Services
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly VacaDbContext _context;
        public BaseRepository(VacaDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}