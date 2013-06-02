using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class AnimalPickupMap : EntityTypeConfiguration<AnimalPickup>
    {
        public AnimalPickupMap()
        {
            // Primary Key
            this.HasKey(t => t.AnimalID);

            // Properties
            this.Property(t => t.ShelterID)
                .HasMaxLength(10);

            this.Property(t => t.PickUpAddressNumber)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.PickUpAddressStreet)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.PickUpState)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.PickUpZip)
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.PickUpPlusFour)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.Comments)
                .HasMaxLength(8000);

            this.Property(t => t.PenNumber)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.PhotoName)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("AnimalPickups");
            this.Property(t => t.AnimalID).HasColumnName("AnimalID");
            this.Property(t => t.ShelterID).HasColumnName("ShelterID");
            this.Property(t => t.FacilityID).HasColumnName("FacilityID");
            this.Property(t => t.AnimalTypeID).HasColumnName("AnimalTypeID");
            this.Property(t => t.OfficerID).HasColumnName("OfficerID");
            this.Property(t => t.ZoneID).HasColumnName("ZoneID");
            this.Property(t => t.DatePickedUp).HasColumnName("DatePickedUp");
            this.Property(t => t.PickUpAddressNumber).HasColumnName("PickUpAddressNumber");
            this.Property(t => t.PickUpAddressStreet).HasColumnName("PickUpAddressStreet");
            this.Property(t => t.CityID).HasColumnName("CityID");
            this.Property(t => t.PickUpState).HasColumnName("PickUpState");
            this.Property(t => t.PickUpZip).HasColumnName("PickUpZip");
            this.Property(t => t.PickUpPlusFour).HasColumnName("PickUpPlusFour");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.AnimalBreedID).HasColumnName("AnimalBreedID");
            this.Property(t => t.AnimalSizeID).HasColumnName("AnimalSizeID");
            this.Property(t => t.DateLicensed).HasColumnName("DateLicensed");
            this.Property(t => t.HoldDays).HasColumnName("HoldDays");
            this.Property(t => t.DateTransported).HasColumnName("DateTransported");
            this.Property(t => t.StatusInd).HasColumnName("StatusInd");
            this.Property(t => t.AnimalSexID).HasColumnName("AnimalSexID");
            this.Property(t => t.AnimalColorID).HasColumnName("AnimalColorID");
            this.Property(t => t.OwnerID).HasColumnName("OwnerID");
            this.Property(t => t.CitationID).HasColumnName("CitationID");
            this.Property(t => t.PenNumber).HasColumnName("PenNumber");
            this.Property(t => t.LicensedInd).HasColumnName("LicensedInd");
            this.Property(t => t.QuarantinedInd).HasColumnName("QuarantinedInd");
            this.Property(t => t.PhotoName).HasColumnName("PhotoName");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateLastModified).HasColumnName("DateLastModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
