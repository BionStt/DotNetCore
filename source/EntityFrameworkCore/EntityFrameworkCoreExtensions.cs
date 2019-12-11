using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DotNetCore.EntityFrameworkCore
{
    public static class EntityFrameworkCoreExtensions
    {
        public static void ApplyConfigurationsFromAssembly(this ModelBuilder modelBuilder)
        {
            static bool Expression(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>);

            var types = Assembly.GetCallingAssembly().GetTypes().Where(type => type.GetInterfaces().Any(Expression)).ToList();

            foreach (var configuration in types.Select(Activator.CreateInstance))
            {
                modelBuilder.ApplyConfiguration((dynamic)configuration);
            }
        }

        public static void DetectChangesLazyLoading(this DbContext context, bool enabled)
        {
            context.ChangeTracker.AutoDetectChangesEnabled = enabled;
            context.ChangeTracker.LazyLoadingEnabled = enabled;
            context.ChangeTracker.QueryTrackingBehavior = enabled ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;
        }

        public static IQueryable<T> Include<T>(this IQueryable<T> queryable, Expression<Func<T, object>>[] includes) where T : class
        {
            includes?.ToList().ForEach(include => queryable = queryable.Include(include));

            return queryable;
        }

        public static IQueryable<T> Queryable<T>(this DbContext context) where T : class
        {
            context.DetectChangesLazyLoading(false);

            return context.Set<T>().AsNoTracking();
        }
    }
}
