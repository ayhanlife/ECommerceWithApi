using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Concrate.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppOperationClaim> AppOperationClaims { get; set; }
        public DbSet<AppUserAppOperationClaim> AppUserAppOperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable("Users");
            base.OnModelCreating(modelBuilder);
        Assembly assembly = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //string connString = "Data Source =.; Initial Catalog = ECommerceDb; Integrated Security = True";
        //    //"";

        //    optionsBuilder.UseSqlServer("Server=.\\AYHAN;Initial Catalog=E1CommerceDb;MultipleActiveResultSets=true;User ID=sa;Password=sifre123@; TrustServerCertificate=True;");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //     //modelBuilder.ApplyConfiguration(new UserMap());
        //    //base.OnModelCreating(modelBuilder);
        //    //Assembly assemblyConfiguration = GetType().Assembly;
        //    //modelBuilder.ApplyConfigurationsFromAssembly(assemblyConfiguration);
        //}
    }
}
