using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HM.CourseManagement.Data
{
    /// <inheritdoc />
    /// <summary>
    /// The contract for the repository
    /// </summary>
    public class EnrollmentRepository : BaseRepository, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<Enrollment> GetAllByEagerLoading()
        {
            var courseList = this.Context.Enrollment
               .Include(p => p.CourseList).ThenInclude(n => n.Course)
               .Include(p => p.User);

            return courseList;
        }

        public bool IsEnrolled(string UserId, int CourseListId)
        {
            return this.Context.Enrollment.Any(x => x.UserId == UserId && x.CourseListId == CourseListId);
        }
    }
}