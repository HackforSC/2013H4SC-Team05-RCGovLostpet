using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstRaceMap : EntityTypeConfiguration<lstRace>
    {
        public lstRaceMap()
        {
            // Primary Key
            this.HasKey(t => t.RaceID);

            // Properties
            this.Property(t => t.RaceDescription)
                .HasMaxLength(150);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstRace");
            this.Property(t => t.RaceID).HasColumnName("RaceID");
            this.Property(t => t.RaceDescription).HasColumnName("RaceDescription");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
