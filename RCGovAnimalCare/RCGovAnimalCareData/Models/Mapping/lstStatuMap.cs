using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstStatuMap : EntityTypeConfiguration<lstStatu>
    {
        public lstStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.StatusID);

            // Properties
            this.Property(t => t.StatusDescription)
                .IsFixedLength()
                .HasMaxLength(200);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstStatus");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.StatusDescription).HasColumnName("StatusDescription");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
