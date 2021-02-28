using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace AmericaVirtual_DataModel.Mappings
{
    public class WeatherMap : EntityTypeConfiguration<Weather>
    {

        public WeatherMap()
        {
            this.HasKey(t => t.Id);
            this.ToTable("Weather");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Id_Country).HasColumnName("Id_Country");
            this.Property(t => t.Id_Province).HasColumnName("Id_Province");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.TypeWeather).HasColumnName("TypeWeather");
            this.Property(t => t.Sensation_C).HasColumnName("Sensation_C");
            this.Property(t => t.Sensation_F).HasColumnName("Sensation_F");
            this.Property(t => t.Rainfall).HasColumnName("Rainfall");
            this.Property(t => t.Humidity).HasColumnName("Humidity");
            this.Property(t => t.Wind).HasColumnName("Wind");
            this.Property(t => t.Date_Add).HasColumnName("Date_Add");
            this.HasRequired(t => t.Countries).WithMany(t => t.Weather).HasForeignKey(d => d.Id_Country);
            this.HasRequired(t => t.Provinces).WithMany(t => t.Weather).HasForeignKey(d => d.Id_Province);
        }
    }
}

