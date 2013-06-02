using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstStateMap : EntityTypeConfiguration<lstState>
    {
        public lstStateMap()
        {
            // Primary Key
            this.HasKey(t => t.StateID);

            // Properties
            this.Property(t => t.StateID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.StateName)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstState");
            this.Property(t => t.StateID).HasColumnName("StateID");
            this.Property(t => t.StateName).HasColumnName("StateName");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
