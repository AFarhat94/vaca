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
            builder.Property(x => x.Name).IsRequired();
            builder
                .HasOne(x => x.Location)
                .WithOne();

            builder
                .HasMany(x => x.Images)
                .WithOne()
                .HasForeignKey(x => x.PlaceId);
        }
    }
}