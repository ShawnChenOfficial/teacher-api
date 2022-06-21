using System;
using EFCore.BulkExtensions;
using teacher_api.Domain.Configurations;

namespace teacher_api.Infrastructure.Persistence.Extensions
{
    public static class DbContextExtensions
    {
        public static void IdentifiedInsert<T>(this ApplicationDbContext context, IList<T> items) where T : class
        {
            var bulkConfig = new BulkConfig
            {
                SetOutputIdentity = true,
                PreserveInsertOrder = true
            };

            var idPropertyInfo = context.Model.FindEntityType(typeof(T))?.FindPrimaryKey()?.Properties.Select(x => x.PropertyInfo).Single();

            var count = items.Count;

            for (var i = 0; i < count; i++)
            {
                idPropertyInfo?.SetValue(items[i], i - count);
            }

            context.BulkInsert(items, bulkConfig);
        }
    }
}

