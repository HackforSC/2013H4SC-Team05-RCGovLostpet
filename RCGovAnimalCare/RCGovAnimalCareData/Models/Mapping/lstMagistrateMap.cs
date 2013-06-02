using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstMagistrateMap : EntityTypeConfiguration<lstMagistrate>
    {
        public lstMagistrateMap()
        {
            // Primary Key
            this.HasKey(t => t.MagistrateID);

            // Properties
            this.Property(t => t.MagistrateName)
                .HasMaxLength(150);

            this.Property(t => t.MagistrateAddressNumber)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.MagistrateAddressStreet)
                .HasMaxLength(50);

            this.Property(t => t.StateID)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstMagistrate");
            this.Property(t => t.MagistrateID).HasColumnName("MagistrateID");
            this.Property(t => t.MagistrateName).HasColumnName("MagistrateName");
            this.Property(t => t.MagistrateAddressNumber).HasColumnName("MagistrateAddressNumber");
            this.Property(t => t.MagistrateAddressStreet).HasColumnName("MagistrateAddressStreet");
            this.Property(t => t.MagistrateCity).HasColumnName("MagistrateCity");
            this.Property(t => t.StateID).HasColumnName("StateID");
            this.Property(t => t.MagistrateZip).HasColumnName("MagistrateZip");
            this.Property(t => t.MagistratePlusFour).HasColumnName("MagistratePlusFour");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
