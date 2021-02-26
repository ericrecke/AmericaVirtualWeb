using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmericaVirtual_DataModel.Mappings
{
    public class Services_LogMap : EntityTypeConfiguration<Services_Log>
    {

        public Services_LogMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Service).IsRequired().HasMaxLength(50);
            this.ToTable("Services_Log");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Service).HasColumnName("Service");
            this.Property(t => t.Id_User_Add).HasColumnName("Id_User_Add");
            this.Property(t => t.Date_Add).HasColumnName("Date_Add");
        }
    }
}

