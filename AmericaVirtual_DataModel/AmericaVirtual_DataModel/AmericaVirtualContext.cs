using AmericaVirtual_DataModel.Mappings;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AmericaVirtual_DataModel
{
    public class AmericaVirtualContext : DbContext
    {
        public AmericaVirtualContext()
            : base("name=AmericaVirtualContext")
        {
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Weather> Weather { get; set; }
        public virtual DbSet<Services_Log> Services_Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountriesMap());
            modelBuilder.Configurations.Add(new ProvincesMap());
            modelBuilder.Configurations.Add(new UsersMap());
            modelBuilder.Configurations.Add(new WeatherMap());           
            modelBuilder.Configurations.Add(new Services_LogMap());           
        }
    }
}
