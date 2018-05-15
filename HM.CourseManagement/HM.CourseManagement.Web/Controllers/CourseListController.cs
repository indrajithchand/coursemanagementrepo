using HM.CourseManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HM.CourseManagement.Web.Controllers
{
    [Authorize]
    public class CourseListController : Controller
    {
        public ICourseListRepository Repository { get; }

        public CourseListController(ICourseListRepository repository)
        {
            Repository = repository;
        }

        public IActionResult Index()
        {
            var courseList = Repository.GetAllByEagerLoading().AsEnumerable();
            return View(courseList);
        }
        
        public IActionResult Create()
        {
            var courses = Repository.GetAllByEagerLoading().AsEnumerable();
            return View(courses);
        }

        public IActionResult Details(int Id)
        {
            var courseList = Repository.GetCourseListById(Id);
            return View(courseList);
        }
    }
}