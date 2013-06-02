using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstReportMap : EntityTypeConfiguration<lstReport>
    {
        public lstReportMap()
        {
            // Primary Key
            this.HasKey(t => t.ReportID);

            // Properties
            this.Property(t => t.DisplayText)
                .IsFixedLength()
                .HasMaxLength(400);

            this.Property(t => t.ReportPath)
                .IsFixedLength()
                .HasMaxLength(3000);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstReports");
            this.Property(t => t.ReportID).HasColumnName("ReportID");
            this.Property(t => t.DisplayText).HasColumnName("DisplayText");
            this.Property(t => t.ReportPath).HasColumnName("ReportPath");
            this.Property(t => t.ReportSecureLevel).HasColumnName("ReportSecureLevel");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
