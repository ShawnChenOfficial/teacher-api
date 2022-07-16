using System;

namespace teacher_api.Application.Base.Interface
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets all as an IQueryable
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Get();

        /// <summary>
        /// Updates one item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        void Update(T item);

        /// <summary>
        /// Adds one item
        /// </summary>
        /// <returns></returns>
        void Add(T item);

        /// <summary>
        /// Saves many objects
        /// </summary>
        /// <returns></returns>
        void AddRange(IEnumerable<T> items, bool returnIds);

        /// <summary>
        /// Updates many objects
        /// </summary>
        /// <returns></returns>
        void UpdateRange(IEnumerable<T> items);

        /// <summary>
        /// Deletes objects.
        /// </summary>
        void RemoveRange(IEnumerable<T> items);

        /// <summary>
        /// Deletes objects.
        /// </summary>
        void RemoveRange(IQueryable<T> items);

        /// <summary>
        ///  Deletes one object
        /// </summary>
        /// <param name="item"></param>
        void Remove(T item);

        /// <summary>
        /// Find Item by Key Values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        T? Find(params object[] keyValues);
    }
}

