using Core.Entities;
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
                                    .Include(x=> x.Location)
                                    .Include(x => x.Images)
                                    .ToListAsync();
        }
    }
}