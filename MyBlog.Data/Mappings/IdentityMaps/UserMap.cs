using Microsoft.AspNetCore.Identity;
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
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var superAdmin = new AppUser
            {
                Id = Guid.Parse("B0F21285-8B81-4C46-BC74-3E1DB74290FB"),
                UserName = "melihomerkamar0@gmail.com",
                NormalizedUserName = "MELIHOMERKAMAR0@GMAIL.COM",
                Email = "melihomerkamar0@gmail.com",
                NormalizedEmail = "MELIHOMERKAMAR0@GMAIL.COM",
                PhoneNumber = "+905050900704",
                FirstName = "Melih SuperAdmin",
                LastName = "Kamar",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()

            };
            superAdmin.PasswordHash = CreatePasswordHash(superAdmin, "123456");

            var Admin = new AppUser
            {
                Id = Guid.Parse("D617EF9E-6C36-4099-8220-6372AAF5B196"),
                UserName = "melih.o.k@hotmail.com",
                NormalizedUserName = "MELIH.O.K@HOTMAIL.COM",
                Email = "melih.o.k@hotmail.com",
                NormalizedEmail = "MELIH.O.K@HOTMAIL.COM",
                PhoneNumber = "+905050900704",
                FirstName = "Melih Admin",
                LastName = "Kamar",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString()

            };
            Admin.PasswordHash = CreatePasswordHash(Admin, "123456");

            builder.HasData(superAdmin, Admin);
        }





        private string CreatePasswordHash(AppUser user,string password)
        {
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
