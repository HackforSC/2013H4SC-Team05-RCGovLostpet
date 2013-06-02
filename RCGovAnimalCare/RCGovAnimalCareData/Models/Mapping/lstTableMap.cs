using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstTableMap : EntityTypeConfiguration<lstTable>
    {
        public lstTableMap()
        {
            // Primary Key
            this.HasKey(t => t.TableID);

            // Properties
            this.Property(t => t.Tablename)
                .HasMaxLength(100);

            this.Property(t => t.DisplayName)
                .HasMaxLength(100);

            this.Property(t => t.Modifiedby)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("lstTable");
            this.Property(t => t.TableID).HasColumnName("TableID");
            this.Property(t => t.Tablename).HasColumnName("Tablename");
            this.Property(t => t.DisplayName).HasColumnName("DisplayName");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.Modifiedby).HasColumnName("Modifiedby");
        }
    }
}
