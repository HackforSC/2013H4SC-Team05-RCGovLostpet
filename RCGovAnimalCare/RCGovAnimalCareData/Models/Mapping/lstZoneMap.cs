using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstZoneMap : EntityTypeConfiguration<lstZone>
    {
        public lstZoneMap()
        {
            // Primary Key
            this.HasKey(t => t.ZoneID);

            // Properties
            this.Property(t => t.ZoneDescription)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstZones");
            this.Property(t => t.ZoneID).HasColumnName("ZoneID");
            this.Property(t => t.ZoneDescription).HasColumnName("ZoneDescription");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
