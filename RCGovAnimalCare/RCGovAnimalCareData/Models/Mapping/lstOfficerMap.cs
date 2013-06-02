using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstOfficerMap : EntityTypeConfiguration<lstOfficer>
    {
        public lstOfficerMap()
        {
            // Primary Key
            this.HasKey(t => t.OfficerID);

            // Properties
            this.Property(t => t.OfficerName)
                .HasMaxLength(50);

            this.Property(t => t.OfficerBadgeNumber)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstOfficer");
            this.Property(t => t.OfficerID).HasColumnName("OfficerID");
            this.Property(t => t.OfficerName).HasColumnName("OfficerName");
            this.Property(t => t.OfficerBadgeNumber).HasColumnName("OfficerBadgeNumber");
            this.Property(t => t.StatusInd).HasColumnName("StatusInd");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
