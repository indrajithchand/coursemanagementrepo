using System;
using System.Linq;

namespace HM.CourseManagement.Data
{
    /// <summary>
    /// Entity framework implementation of the repository
    /// </summary>
    public class BaseRepository : IRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private ApplicationDbContext context;

        /// <summary>
        /// Disposed field for detecting redundant calls
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        protected ApplicationDbContext Context
        {
            get { return this.context; }
        }

        /// <summary>
        /// Gets all entities of a specific type
        /// </summary>
        /// <typeparam name="T">Generic object type</typeparam>
        /// <returns>
        /// A queryable list of objects
        /// </returns>
        /// <inheritdoc />
        public IQueryable<T> GetAll<T>() where T : class
        {
            return this.context.Set<T>().AsQueryable();
        }
        
        /// <summary>
        /// Gets a specific object by ID
        /// </summary>
        /// <typeparam name="T">Generic object type</typeparam>
        /// <param name="id">ID of the object</param>
        /// <returns>
        /// A matching object
        /// </returns>
        /// <inheritdoc />
        public T GetById<T>(int id) where T : class
        {
            return this.context.Find<T>(id);
        }

        /// <summary>
        /// Inserts a new object into the database
        /// </summary>
        /// <typeparam name="T">Generic object type</typeparam>
        /// <param name="obj">Object to create</param>
        /// <inheritdoc />
        public void Insert<T>(T obj) where T : class
        {
            this.context.Add<T>(obj);
        }

        /// <summary>
        /// Saves the database context
        /// </summary>
        /// <inheritdoc />
        public void Save()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Updates an object in the database
        /// </summary>
        /// <typeparam name="T">Generic object type</typeparam>
        /// <param name="obj">The object to update</param>
        /// <inheritdoc />
        public void Update<T>(T obj) where T : class
        {
            this.context.Update<T>(obj);
        }

        public void Delete<T>(int id) where T : class
        {
            var obj = this.context.Find<T>(id);
            this.context.Remove<T>(obj);
        }

        /// <inheritdoc />
        /// <summary>
        /// Disposes of the database context
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of the database context
        /// </summary>
        /// <param name="disposing">Dispose parameter</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }

                this.disposedValue = true;
            }
        }      
    }
}