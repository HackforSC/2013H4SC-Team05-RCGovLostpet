using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class OffenderMap : EntityTypeConfiguration<Offender>
    {
        public OffenderMap()
        {
            // Primary Key
            this.HasKey(t => t.OffenderID);

            // Properties
            this.Property(t => t.OffenderName)
                .HasMaxLength(50);

            this.Property(t => t.OffenderAddress)
                .HasMaxLength(50);

            this.Property(t => t.OffenderCity)
                .HasMaxLength(30);

            this.Property(t => t.StateID)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.OffenderZip)
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.OffenderPlusFour)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("Offender");
            this.Property(t => t.OffenderID).HasColumnName("OffenderID");
            this.Property(t => t.OffenderName).HasColumnName("OffenderName");
            this.Property(t => t.OffenderAddress).HasColumnName("OffenderAddress");
            this.Property(t => t.OffenderCity).HasColumnName("OffenderCity");
            this.Property(t => t.StateID).HasColumnName("StateID");
            this.Property(t => t.OffenderZip).HasColumnName("OffenderZip");
            this.Property(t => t.OffenderPlusFour).HasColumnName("OffenderPlusFour");
            this.Property(t => t.OffenderDateOfBirth).HasColumnName("OffenderDateOfBirth");
            this.Property(t => t.RaceID).HasColumnName("RaceID");
            this.Property(t => t.OffenderHeightFeet).HasColumnName("OffenderHeightFeet");
            this.Property(t => t.OffenderHeightInches).HasColumnName("OffenderHeightInches");
            this.Property(t => t.OffenderWeight).HasColumnName("OffenderWeight");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
