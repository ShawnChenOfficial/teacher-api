using System;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using teacher_api.Application.Base.Interface;
using teacher_api.Domain.Configurations;
using teacher_api.Domain.Extensions;

namespace teacher_api.Infrastructure.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ApplicationDbContext db;

        public Repository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public virtual void Add(T item)
        {
            db.Set<T>().Add(item);

            db.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<T> items, bool returnIds = false)
        {
            var itemsList = items.ToList();

            db.Set<T>().AddRange(itemsList);

            if (returnIds)
                db.IdentifiedInsert(itemsList);
            else
                db.BulkInsert(itemsList, new BulkConfig { BulkCopyTimeout = 0, BatchSize = 10000 });
        }

        public virtual void Remove(T item)
        {
            db.Set<T>().Remove(item);

            db.SaveChanges();
        }

        public virtual T? Find(params object[] keyValues)
        {
            return db.Set<T>().Find(keyValues);
        }

        public virtual IQueryable<T> Get()
        {
            return db.Set<T>();
        }

        public virtual void RemoveRange(IEnumerable<T> items)
        {
            db.BulkDelete(items.ToList());
        }

        public virtual void RemoveRange(IQueryable<T> items)
        {
            items.BatchDelete();
        }

        public virtual void Update(T item)
        {
            db.BulkUpdate(new List<T>() { item });
        }

        public virtual void UpdateRange(IEnumerable<T> items)
        {
            db.BulkUpdate(items.ToList());
        }
    }
}

