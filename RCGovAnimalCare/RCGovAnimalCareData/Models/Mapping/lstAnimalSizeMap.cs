using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstAnimalSizeMap : EntityTypeConfiguration<lstAnimalSize>
    {
        public lstAnimalSizeMap()
        {
            // Primary Key
            this.HasKey(t => t.AnimalSizeID);

            // Properties
            this.Property(t => t.AnimalSizeDescription)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstAnimalSize");
            this.Property(t => t.AnimalSizeID).HasColumnName("AnimalSizeID");
            this.Property(t => t.AnimalSizeDescription).HasColumnName("AnimalSizeDescription");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateLastModified).HasColumnName("DateLastModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
