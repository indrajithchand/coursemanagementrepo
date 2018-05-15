using System;
using System.Linq;

namespace HM.CourseManagement.Data
{
    /// <inheritdoc />
    /// <summary>
    /// The contract for the repository
    /// </summary>
    public interface IEnrollmentRepository : IRepository
    {
        /// <summary>
        /// Gets all entities of a specific type
        /// </summary>
        /// <typeparam name="T">Generic object type</typeparam>
        /// <returns>A list of objects</returns>
        IQueryable<Enrollment> GetAllByEagerLoading();

        bool IsEnrolled(string UserId, int CourseListId);
    }
}
