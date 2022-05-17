using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserMembership.Data.Entities;

namespace UserMembership.Data.EntityTypeBuilder
{

    public class UserTypeBuilder : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.HasKey(p => p.Id);

        }
    }
}
