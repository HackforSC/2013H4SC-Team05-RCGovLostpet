using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstAnimalTypeMap : EntityTypeConfiguration<lstAnimalType>
    {
        public lstAnimalTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.AnimalTypeID);

            // Properties
            this.Property(t => t.AnimalTypeDescription)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstAnimalType");
            this.Property(t => t.AnimalTypeID).HasColumnName("AnimalTypeID");
            this.Property(t => t.AnimalTypeDescription).HasColumnName("AnimalTypeDescription");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
