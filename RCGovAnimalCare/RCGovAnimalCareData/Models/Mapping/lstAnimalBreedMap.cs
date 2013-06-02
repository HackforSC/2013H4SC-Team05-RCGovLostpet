using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstAnimalBreedMap : EntityTypeConfiguration<lstAnimalBreed>
    {
        public lstAnimalBreedMap()
        {
            // Primary Key
            this.HasKey(t => t.AnimalBreedID);

            // Properties
            this.Property(t => t.AnimalBreedDescription)
                .HasMaxLength(150);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstAnimalBreed");
            this.Property(t => t.AnimalBreedID).HasColumnName("AnimalBreedID");
            this.Property(t => t.AnimalBreedDescription).HasColumnName("AnimalBreedDescription");
            this.Property(t => t.AnimalTypeID).HasColumnName("AnimalTypeID");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
