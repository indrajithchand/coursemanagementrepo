using HM.CourseManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HM.CourseManagement.Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        public IRepository Repository { get; }

        public CourseController(IRepository repository)
        {
            Repository = repository;
        }

        public IActionResult Index()
        {
            var courses = Repository.GetAll<Course>().AsEnumerable();
            return View(courses);
        }
        
        public IActionResult Details(int Id)
        {
            var course = Repository.GetById<Course>(Id);
            return View(course);
        }
    }
}