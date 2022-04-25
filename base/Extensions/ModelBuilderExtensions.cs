using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Solo.Base.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddRestrictDeleteBehaviorConvention(this ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public static void RegisterIEntityTypeConfiguration(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var applyGenericMethod = typeof(ModelBuilder).GetMethods().First(x => x.Name == nameof(modelBuilder.ApplyConfiguration));
            var types = assembly.GetExportedTypes()
                .Where(i => i.IsClass && !i.IsAbstract && i.IsPublic)
                .ToList();

            foreach (var type in types)
            {
                var iface = type.GetInterfaces().FirstOrDefault(x =>
                x.IsConstructedGenericType &&
                x.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

                if (iface != null)
                {
                    var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                    applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                }
            }
        }

        public static void RegisterAllEntities(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic
                && typeof(IEntity).IsAssignableFrom(c)).ToList();

            foreach (var type in types)
            {
                modelBuilder.Entity(type);
            }
        }
    }
}