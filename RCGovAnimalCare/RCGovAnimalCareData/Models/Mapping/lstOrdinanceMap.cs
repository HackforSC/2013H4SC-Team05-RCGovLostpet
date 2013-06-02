using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstOrdinanceMap : EntityTypeConfiguration<lstOrdinance>
    {
        public lstOrdinanceMap()
        {
            // Primary Key
            this.HasKey(t => t.OrdinanceID);

            // Properties
            this.Property(t => t.OrdinanceDescription)
                .HasMaxLength(150);

            this.Property(t => t.OrdinanceType)
                .HasMaxLength(150);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstOrdinance");
            this.Property(t => t.OrdinanceID).HasColumnName("OrdinanceID");
            this.Property(t => t.OrdinanceDescription).HasColumnName("OrdinanceDescription");
            this.Property(t => t.OrdinanceType).HasColumnName("OrdinanceType");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
