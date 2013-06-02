using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstAnimalColorMap : EntityTypeConfiguration<lstAnimalColor>
    {
        public lstAnimalColorMap()
        {
            // Primary Key
            this.HasKey(t => t.AnimalColorID);

            // Properties
            this.Property(t => t.AnimalColorDescription)
                .HasMaxLength(150);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstAnimalColor");
            this.Property(t => t.AnimalColorID).HasColumnName("AnimalColorID");
            this.Property(t => t.AnimalColorDescription).HasColumnName("AnimalColorDescription");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
