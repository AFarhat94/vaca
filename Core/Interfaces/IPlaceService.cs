using Core.Entities;
using Core.Entities.Identity;

namespace Core.Interfaces
{
    public interface IPlaceService : IBaseRepository<Place>
    {
        public Task<IReadOnlyList<Place>> GetAllByUserAsync(AppUser user);
    }
}