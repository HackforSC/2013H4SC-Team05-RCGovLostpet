using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstFacilityMap : EntityTypeConfiguration<lstFacility>
    {
        public lstFacilityMap()
        {
            // Primary Key
            this.HasKey(t => t.FacilityID);

            // Properties
            this.Property(t => t.FacilityName)
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.FacilityAddressNumber)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.FacilityAddressStreet)
                .IsFixedLength()
                .HasMaxLength(60);

            this.Property(t => t.FacilityState)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstFacility");
            this.Property(t => t.FacilityID).HasColumnName("FacilityID");
            this.Property(t => t.FacilityName).HasColumnName("FacilityName");
            this.Property(t => t.FacilityAddressNumber).HasColumnName("FacilityAddressNumber");
            this.Property(t => t.FacilityAddressStreet).HasColumnName("FacilityAddressStreet");
            this.Property(t => t.FacilityCity).HasColumnName("FacilityCity");
            this.Property(t => t.FacilityState).HasColumnName("FacilityState");
            this.Property(t => t.FacilityZip).HasColumnName("FacilityZip");
            this.Property(t => t.FacilityPlusFour).HasColumnName("FacilityPlusFour");
            this.Property(t => t.PerAnimalCostOne).HasColumnName("PerAnimalCostOne");
            this.Property(t => t.PerAnimalCostTwo).HasColumnName("PerAnimalCostTwo");
            this.Property(t => t.EuthanizeCost).HasColumnName("EuthanizeCost");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
