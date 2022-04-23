using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Solo.Base.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddRestrictDeleteBehaviorConvention(this ModelBuilder modelBuilder )
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

                foreach(var fk in cascadeFKs)
                {
                    fk.DeleteBehavior = DeleteBehavior.Restrict;
                }
        }

        public static void RegisterIEntityTypeConfiguration(this ModelBuilder modelBuilder , Assembly assembly)
        {
            
        }
    } 
}