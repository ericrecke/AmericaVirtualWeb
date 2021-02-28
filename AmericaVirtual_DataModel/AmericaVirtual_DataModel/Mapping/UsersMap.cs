using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace AmericaVirtual_DataModel.Mappings
{
    public class UsersMap : EntityTypeConfiguration<Users>
    {
        public UsersMap()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Name).IsRequired().HasMaxLength(50);
            this.Property(t => t.Email).IsRequired().HasMaxLength(50);
            this.Property(t => t.Password).IsRequired().HasMaxLength(50);
            this.ToTable("Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.UserType).HasColumnName("UserType");
            this.Property(t => t.Date_Add).HasColumnName("Date_Add");
        }
    }
}