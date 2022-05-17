using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserMembership.Data.Entities;
using UserMembership.Data.EntityTypeBuilder;
using UserMembership.Data.Seeds;

namespace UserMembership.Data
{
    public class UserMembershipDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public UserMembershipDbContext(DbContextOptions<UserMembershipDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Company> Companies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CompanyTypeBuilder())
                .ApplyConfiguration(new UserTypeBuilder());

            modelBuilder.ApplyConfiguration(new RoleSeed())
               .ApplyConfiguration(new UserSeed());

            base.OnModelCreating(modelBuilder);
        }
    }

}

