using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstAnimalSexMap : EntityTypeConfiguration<lstAnimalSex>
    {
        public lstAnimalSexMap()
        {
            // Primary Key
            this.HasKey(t => t.AnimalSexID);

            // Properties
            this.Property(t => t.AnimalSexDescription)
                .HasMaxLength(30);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstAnimalSex");
            this.Property(t => t.AnimalSexID).HasColumnName("AnimalSexID");
            this.Property(t => t.AnimalSexDescription).HasColumnName("AnimalSexDescription");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
