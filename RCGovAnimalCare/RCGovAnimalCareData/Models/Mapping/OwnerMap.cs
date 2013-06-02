using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class OwnerMap : EntityTypeConfiguration<Owner>
    {
        public OwnerMap()
        {
            // Primary Key
            this.HasKey(t => t.OwnerID);

            // Properties
            this.Property(t => t.OwnerName)
                .HasMaxLength(40);

            this.Property(t => t.OwnerAddress)
                .HasMaxLength(50);

            this.Property(t => t.OwnerCity)
                .HasMaxLength(50);

            this.Property(t => t.StateID)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.OwnerZip)
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.OwnerPlusFour)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.OwnerPhoneAreaCode)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.OwnerPhonePrefix)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.OwnerPhoneSuffix)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.OwnerDriverLicenseState)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.OwnerDriverLicenseNumber)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("Owner");
            this.Property(t => t.OwnerID).HasColumnName("OwnerID");
            this.Property(t => t.OwnerName).HasColumnName("OwnerName");
            this.Property(t => t.OwnerAddress).HasColumnName("OwnerAddress");
            this.Property(t => t.OwnerCity).HasColumnName("OwnerCity");
            this.Property(t => t.StateID).HasColumnName("StateID");
            this.Property(t => t.OwnerZip).HasColumnName("OwnerZip");
            this.Property(t => t.OwnerPlusFour).HasColumnName("OwnerPlusFour");
            this.Property(t => t.OwnerPhoneAreaCode).HasColumnName("OwnerPhoneAreaCode");
            this.Property(t => t.OwnerPhonePrefix).HasColumnName("OwnerPhonePrefix");
            this.Property(t => t.OwnerPhoneSuffix).HasColumnName("OwnerPhoneSuffix");
            this.Property(t => t.OwnerDriverLicenseState).HasColumnName("OwnerDriverLicenseState");
            this.Property(t => t.OwnerDriverLicenseNumber).HasColumnName("OwnerDriverLicenseNumber");
            this.Property(t => t.TurnedinInd).HasColumnName("TurnedinInd");
            this.Property(t => t.RedeemedInd).HasColumnName("RedeemedInd");
            this.Property(t => t.DateRedeemed).HasColumnName("DateRedeemed");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
