using System;
using System.Linq;

namespace HM.CourseManagement.Data
{
    /// <inheritdoc />
    /// <summary>
    /// The contract for the repository
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Gets all entities of a specific type
        /// </summary>
        /// <typeparam name="T">Generic object type</typeparam>
        /// <returns>A list of objects</returns>
        IQueryable<T> GetAll<T>() where T : class;

        /// <summary>
        /// Gets a specific object by ID
        /// </summary>
        /// <typeparam name="T">Generic object type</typeparam>
        /// <param name="id">ID of the object</param>
        /// <returns>A matching object</returns>
        T GetById<T>(int id) where T : class;
        
        void Delete<T>(int id) where T : class;

        /// <summary>
        /// Inserts a new object into the database
        /// </summary>
        /// <typeparam name="T">Generic object type</typeparam>
        /// <param name="obj">Object to create</param>
        void Insert<T>(T obj) where T : class;

        /// <summary>
        /// Updates an object in the database
        /// </summary>
        /// <typeparam name="T">Generic object type</typeparam>
        /// <param name="obj">The object to update</param>
        void Update<T>(T obj) where T : class;

        /// <summary>
        /// Saves the database context
        /// </summary>
        void Save();
    }
}
