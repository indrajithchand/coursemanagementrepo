using HM.CourseManagement.Data;
using System.Linq;

namespace HM.CourseManagement.Core
{
    public sealed class CourseService : ICourseService
    {
        private readonly ICourseListRepository _repository;
        public CourseService(ICourseListRepository repository)
        {
            this._repository = repository;
        }

        public void CreateCourse(Course course)
        {
            this._repository.Insert<Course>(course);
            this._repository.Save();
        }

        public void DeleteCourse(int courseId)
        {
            this._repository.Delete<Course>(courseId);
            this._repository.Save();
        }

        public Course RetrieveCourse(int courseId)
        {
            return this._repository.GetById<Course>(courseId);
        }

        public IQueryable<Course> RetrieveCourses()
        {
            return this._repository.GetAll<Course>();
        }

        public void UpdateCourse(Course course)
        {
            this._repository.Update<Course>(course);
            this._repository.Save();
        }
    }
}
