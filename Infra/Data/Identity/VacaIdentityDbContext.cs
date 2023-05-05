using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Identity
{
    public class VacaIdentityDbContext : IdentityDbContext<AppUser>
    {
        public VacaIdentityDbContext(DbContextOptions<VacaIdentityDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}