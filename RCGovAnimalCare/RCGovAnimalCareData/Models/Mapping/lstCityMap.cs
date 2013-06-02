using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstCityMap : EntityTypeConfiguration<lstCity>
    {
        public lstCityMap()
        {
            // Primary Key
            this.HasKey(t => t.CityID);

            // Properties
            this.Property(t => t.CityName)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstCity");
            this.Property(t => t.CityID).HasColumnName("CityID");
            this.Property(t => t.CityName).HasColumnName("CityName");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
