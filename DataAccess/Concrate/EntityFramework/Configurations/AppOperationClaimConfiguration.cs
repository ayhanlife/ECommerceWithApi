using Entities.Concrate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework.Configurations
{
    public class AppOperationClaimConfiguration : IEntityTypeConfiguration<AppOperationClaim>
    {
        public void Configure(EntityTypeBuilder<AppOperationClaim> builder)
        {
            builder.ToTable("AppOperationClaims", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new AppOperationClaim() { Id = 1, Name = "AppUser" },
                new AppOperationClaim() { Id = 2, Name = "AppUserType" },
                new AppOperationClaim() { Id = 3, Name = "Page" },
                new AppOperationClaim() { Id = 4, Name = "PageType" },
                new AppOperationClaim() { Id = 5, Name = "Product" },
                new AppOperationClaim() { Id = 6, Name = "ProductType" },
                new AppOperationClaim() { Id = 7, Name = "Contact" });
        }
    }
}