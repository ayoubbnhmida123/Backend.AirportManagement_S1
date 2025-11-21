using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Data.Configurations
{
    public class PlaneConfig : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.ToTable("MyPlanes"); // nom de la table
            builder.HasKey(p => p.PlaneID);
            builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity");
        }
    }
}
