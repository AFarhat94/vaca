using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data
{
    public class PlaceConfig : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder
                .HasOne(x => x.Coordinations)
                .WithOne()
                .HasForeignKey<Place>(x => x.CoordinationsId);

            builder
                .HasMany(x => x.Images)
                .WithOne()
                .HasForeignKey(x => x.PlaceId);
        }
    }
}