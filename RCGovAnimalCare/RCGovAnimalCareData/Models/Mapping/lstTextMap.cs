using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstTextMap : EntityTypeConfiguration<lstText>
    {
        public lstTextMap()
        {
            // Primary Key
            this.HasKey(t => t.TextID);

            // Properties
            this.Property(t => t.TextHeader)
                .HasMaxLength(500);

            this.Property(t => t.TextBody)
                .HasMaxLength(6000);

            this.Property(t => t.TextFooter)
                .HasMaxLength(500);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstText");
            this.Property(t => t.TextID).HasColumnName("TextID");
            this.Property(t => t.TextHeader).HasColumnName("TextHeader");
            this.Property(t => t.TextHeaderFontsize).HasColumnName("TextHeaderFontsize");
            this.Property(t => t.TextBody).HasColumnName("TextBody");
            this.Property(t => t.TextBodyFontsize).HasColumnName("TextBodyFontsize");
            this.Property(t => t.TextFooter).HasColumnName("TextFooter");
            this.Property(t => t.TextFooterFontsize).HasColumnName("TextFooterFontsize");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
