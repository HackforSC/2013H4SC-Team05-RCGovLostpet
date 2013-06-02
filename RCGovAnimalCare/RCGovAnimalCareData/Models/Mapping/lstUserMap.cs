using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstUserMap : EntityTypeConfiguration<lstUser>
    {
        public lstUserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserEmail)
                .HasMaxLength(75);

            this.Property(t => t.UserPassword)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.UserGUID)
                .HasMaxLength(50);

            this.Property(t => t.UserName)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstUser");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserEmail).HasColumnName("UserEmail");
            this.Property(t => t.UserPassword).HasColumnName("UserPassword");
            this.Property(t => t.UserGUID).HasColumnName("UserGUID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.UserSecurityLevel).HasColumnName("UserSecurityLevel");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
