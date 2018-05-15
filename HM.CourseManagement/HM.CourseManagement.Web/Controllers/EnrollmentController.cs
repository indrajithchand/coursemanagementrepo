using HM.CourseManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HM.CourseManagement.Web.Controllers
{
    [Authorize]
    public class EnrollmentController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public IEnrollmentRepository Repository { get; }

        public EnrollmentController(UserManager<ApplicationUser> userManager, IEnrollmentRepository repository)
        {
            _userManager = userManager;
            Repository = repository;
        }

        public IActionResult Index()
        {
            var enrollments = Repository.GetAllByEagerLoading().AsEnumerable();
            return View(enrollments);
        }
        
        public async Task<IActionResult> Create(int courseListId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var isEnrolled = Repository.IsEnrolled(user.Id, courseListId);
            if(!isEnrolled)
            {
                var enrollment = new Enrollment() { UserId = user.Id, CourseListId = courseListId };
                Repository.Insert<Enrollment>(enrollment);
                Repository.Save();
                TempData["Message"] = "Your enrollment is successful";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "You have already enrolled to this course";
                return RedirectToAction("Index", "CourseList");
            }          
        }
    }
}