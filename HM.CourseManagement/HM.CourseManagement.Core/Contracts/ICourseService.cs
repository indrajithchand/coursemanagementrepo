using HM.CourseManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.CourseManagement.Core
{
    public interface ICourseService
    {
        void CreateCourse(Course course);
        
        IQueryable<Course> RetrieveCourses();

        Course RetrieveCourse(int courseId);

        void UpdateCourse(Course course);

        void DeleteCourse(int courseId);
    }
}