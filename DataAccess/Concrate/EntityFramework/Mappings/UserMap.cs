using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", @"dbo");

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


            builder.Property(x => x.Password)
              .HasMaxLength(20)
              .IsRequired();


            builder.Property(x => x.Gender)
              .IsRequired();


            builder.Property(x => x.DateOfBirth)
              .IsRequired();

            builder.Property(x => x.DateOfBirth).HasDefaultValue(DateTime.Now);


            builder.HasData(new User
            {
                Id = 1,
                UserName = "ayhanyildiz",
                FirstName = "Ayhan",
                LastName = "YILDIZ",
                Password = "123456",
                Gender = true,
                DateOfBirth = Convert.ToDateTime("1993-08-30"),
                CreatedDate = DateTime.Now,
                Adress = "BURSA",
                CreatedUserId = 1,
                Email = "ayhanyildiz001@hotmail.com",
            });




        }

    }
}
