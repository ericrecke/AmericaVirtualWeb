using AmericaVirtual_DataModel.Mappings;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace AmericaVirtual_DataModel
{
    public class AmericaVirtualContext : DbContext, IDisposable
    {
        public AmericaVirtualContext()
            : base("name=" + ConnectionName())
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        }

        static private string ConnectionName()
        {
            var name = ConfigurationManager.AppSettings["CurrentConnection"];
            return string.IsNullOrEmpty(name) ? "AmericaVirtualContext" : name;
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
