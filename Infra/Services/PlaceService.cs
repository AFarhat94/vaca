using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Services
{
    public class PlaceService : BaseRepository<Place>, IPlaceService
    {
        private readonly VacaDbContext _context;
        public PlaceService(VacaDbContext context) : base(context)
        { 
            _context = context;
        }

        public new async Task<IReadOnlyList<Place>> GetAllAsync()
        {
            return await _context.Places
                                    .Include(x=> x.Coordinations)
                                    .Include(x => x.Images)
                                    .ToListAsync();
        }

        public async Task<IReadOnlyList<Place>> GetAllByUserAsync(AppUser user)
        {
            return await _context.Places
                                    .Where(c => c.UserId == user.Id)
                                    .Include(x=> x.Coordinations)
                                    .Include(x => x.Images)
                                    .ToListAsync();
        }
    }
}