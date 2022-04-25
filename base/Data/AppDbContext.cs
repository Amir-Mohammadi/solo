using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Solo.Base.Extensions;
using Solo.Domains;

namespace Solo.Base.Data
{
    public class AppDbContext : DbContext
    {
        // public readonly Assembly assembly;
        public AppDbContext(DbContextOptions options) : base(options)
        {
            // this.assembly = assembly ?? Assembly.GetEntryAssembly();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            // modelBuilder.AddRestrictDeleteBehaviorConvention();
            // modelBuilder.RegisterAllEntities(assembly: assembly);
            // modelBuilder.RegisterIEntityTypeConfiguration(assembly: assembly);
            // modelBuilder.AddPluralizingTableNameConvention();

            base.OnModelCreating(modelBuilder);

        }

        public virtual DbSet<Users> Users { get; set; }
    }
}