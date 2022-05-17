using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserMembership.Data.Entities;

namespace UserMembership.Data.EntityTypeBuilder
{
    public class CompanyTypeBuilder : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasMany(i => i.Users)
                .WithOne(i => i.Company)
                .HasForeignKey(i => i.CompanyID);


            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int")
                .UseIdentityColumn(1, 1);

        }
    }
}
