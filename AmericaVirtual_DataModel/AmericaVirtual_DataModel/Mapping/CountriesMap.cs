using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace AmericaVirtual_DataModel.Mappings
{
    public class CountriesMap : EntityTypeConfiguration<Countries>
    {
        public CountriesMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Name).IsRequired().HasMaxLength(50);
            this.ToTable("Countries");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Date_Add).HasColumnName("Date_Add");
        }
    }
}

