using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace AmericaVirtual_DataModel.Mappings
{
    public class ProvincesMap : EntityTypeConfiguration<Provinces>
    {

        public ProvincesMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Name).IsRequired().HasMaxLength(50);
            this.ToTable("Provinces");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Id_Country).HasColumnName("Id_Country");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Date_Add).HasColumnName("Date_Add");
            this.HasRequired(t => t.Countries).WithMany(t => t.Provinces).HasForeignKey(d => d.Id_Country);
        }
    }
}