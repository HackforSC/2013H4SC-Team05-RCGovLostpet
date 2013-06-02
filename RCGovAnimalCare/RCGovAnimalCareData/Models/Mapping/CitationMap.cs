using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class CitationMap : EntityTypeConfiguration<Citation>
    {
        public CitationMap()
        {
            // Primary Key
            this.HasKey(t => t.CitationID);

            // Properties
            this.Property(t => t.CitationNumber)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.CourtTimeHr)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.CourtTimeMin)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.CourtRoomNumber)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.CitationTimeHr)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.CitationTimeMin)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.CitationLocationNumber)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.CitationLocationStreet)
                .IsFixedLength()
                .HasMaxLength(60);

            this.Property(t => t.ViolationTimeHr)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.ViolationTimeMin)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.ViolationLocationNumber)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.ViolationLocationStreet)
                .IsFixedLength()
                .HasMaxLength(60);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("Citations");
            this.Property(t => t.CitationID).HasColumnName("CitationID");
            this.Property(t => t.OffenderID).HasColumnName("OffenderID");
            this.Property(t => t.MagistrateID).HasColumnName("MagistrateID");
            this.Property(t => t.CitationNumber).HasColumnName("CitationNumber");
            this.Property(t => t.CourtDate).HasColumnName("CourtDate");
            this.Property(t => t.CourtTimeHr).HasColumnName("CourtTimeHr");
            this.Property(t => t.CourtTimeMin).HasColumnName("CourtTimeMin");
            this.Property(t => t.CourtTimeInd).HasColumnName("CourtTimeInd");
            this.Property(t => t.CourtRoomNumber).HasColumnName("CourtRoomNumber");
            this.Property(t => t.OrdinanceID).HasColumnName("OrdinanceID");
            this.Property(t => t.CitationDate).HasColumnName("CitationDate");
            this.Property(t => t.CitationTimeHr).HasColumnName("CitationTimeHr");
            this.Property(t => t.CitationTimeMin).HasColumnName("CitationTimeMin");
            this.Property(t => t.CitationTimeInd).HasColumnName("CitationTimeInd");
            this.Property(t => t.CitationLocationNumber).HasColumnName("CitationLocationNumber");
            this.Property(t => t.CitationLocationStreet).HasColumnName("CitationLocationStreet");
            this.Property(t => t.ViolationDate).HasColumnName("ViolationDate");
            this.Property(t => t.ViolationTimeHr).HasColumnName("ViolationTimeHr");
            this.Property(t => t.ViolationTimeMin).HasColumnName("ViolationTimeMin");
            this.Property(t => t.ViolationTimeInd).HasColumnName("ViolationTimeInd");
            this.Property(t => t.ViolationLocationNumber).HasColumnName("ViolationLocationNumber");
            this.Property(t => t.ViolationLocationStreet).HasColumnName("ViolationLocationStreet");
            this.Property(t => t.OfficerID).HasColumnName("OfficerID");
            this.Property(t => t.BondAmmount).HasColumnName("BondAmmount");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateLastModified).HasColumnName("DateLastModified");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
