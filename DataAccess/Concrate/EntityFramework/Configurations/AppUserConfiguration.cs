using Core.Entities.Concrate;
using Core.Entities.Enums;
using Core.Utilities.Security.Hash.Sha512;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography;

namespace DataAccess.Concrate.EntityFramework.Mappings
{
    public class AppOperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("AppOperationClaims", @"dbo");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.FirstName)
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(x => x.LastName)
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(x => x.GsmNumber)
            .IsRequired();

            builder.Property(x => x.PasswordHash)
              .IsRequired();

            builder.Property(x => x.PasswordSalt)
            .HasMaxLength(20)
            .IsRequired();


            builder.Property(x => x.Email)
           .HasMaxLength(120)
           .IsRequired();

            builder.Property(x => x.ProfileImgUrl)
          .HasMaxLength(1000);

            builder.Property(x => x.UserTypeId)
          .IsRequired();

            builder.Property(x => x.CreatedDate)
            .HasDefaultValue("getdate()");

            byte[] passwordHash, passwordSalt;
            Sha512Helper.CreatePasswordHash("123456", out passwordHash, out passwordSalt);
            builder.HasData(new OperationClaim
            {
                Id = 1,
                UserName = "ayhanyildiz",
                FirstName = "Ayhan",
                LastName = "YILDIZ",
                CreatedDate = DateTime.Now,
                Adress = "BURSA",
                CreatedUserId = 1,
                Email = "ayhanyildiz001@hotmail.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                GsmNumber = String.Empty,
                ProfileImgUrl = String.Empty,
                UserTypeId = (int)AppUserTypes.SystemAdmin
            });




        }

    }
}
