using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RCGovAnimalCareData.Models.Mapping
{
    public class lstTableAssistMap : EntityTypeConfiguration<lstTableAssist>
    {
        public lstTableAssistMap()
        {
            // Primary Key
            this.HasKey(t => t.AssistID);

            // Properties
            this.Property(t => t.AssistTable)
                .IsFixedLength()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("lstTableAssist");
            this.Property(t => t.AssistID).HasColumnName("AssistID");
            this.Property(t => t.TableID).HasColumnName("TableID");
            this.Property(t => t.TableKey).HasColumnName("TableKey");
            this.Property(t => t.AssistTable).HasColumnName("AssistTable");
        }
    }
}
