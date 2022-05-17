using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserMembership.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "yunus",
                    NormalizedUserName = "YUNUS",
                    Email = "yunus@yunus.com",
                    NormalizedEmail = "YUNUS@YUNUS.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEDJ+SO90wp7h8BBv3JhnGZmuy/ai+JUhV0dgm20MbALPe+nP9jA8+NlzsnNXqjeA6g==",
                    SecurityStamp = "5NBSKH6Z6VKWRPWHFEXTEPBJC7IULAKT",
                    ConcurrencyStamp = "4d040826-902d-4a0c-8502-1d3a1d3da80a",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                }
            );
        }
    }
}
