using System.Diagnostics;
using AdmissionCommittee.Manager.Contracts;
using AdmissionCommittee.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionCommittee.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentsManager studentsManager;

        public HomeController(IStudentsManager studentsManager)
        {
            this.studentsManager = studentsManager;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var student = await studentsManager.GetAllStudentsAsync(cancellationToken);
            var statistics = await studentsManager.GetStatisticsAsync(cancellationToken);

            var model = new StudentIndexViewModel
            {
                Students = student.ToList(),
                Statistics = statistics
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
