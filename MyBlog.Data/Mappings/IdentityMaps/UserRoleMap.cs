using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Mappings.IdentityMaps
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("B0F21285-8B81-4C46-BC74-3E1DB74290FB"),//SuperAdmin
                RoleId = Guid.Parse("BDD590D1-0C43-4A68-8E57-EDF67F70941C")
            });
            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("D617EF9E-6C36-4099-8220-6372AAF5B196"),//Admin
                RoleId = Guid.Parse("D3E6FB00-D801-49F4-9C9A-B69E0F7A0E68")
            });
        }
    }
}

