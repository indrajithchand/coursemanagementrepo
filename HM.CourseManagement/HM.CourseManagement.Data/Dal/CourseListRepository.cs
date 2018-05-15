using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HM.CourseManagement.Data
{
    /// <inheritdoc />
    /// <summary>
    /// The contract for the repository
    /// </summary>
    public class CourseListRepository : BaseRepository, ICourseListRepository
    {
        public CourseListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<CourseList> GetAllByEagerLoading()
        {
            var courseList = this.Context.CourseList
               .Include(p => p.Course)
               .Include(p => p.Faculty);

            return courseList;
        }

        public CourseList GetCourseListById(int Id)
        {
            var courseList = this.Context.CourseList
               .Include(p => p.Course)
               .Include(p => p.Faculty).FirstOrDefault(x => x.Id == Id);

            return courseList;
        }
    }
}