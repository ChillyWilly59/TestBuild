using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestBuild.Models;

namespace TestBuild.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            var projectNames = new List<string> { "TotalChats", "Duration", "Ratings", "ResponseTime", "Tags" };

            var viewModel = new ProjectViewModel
            {
                ProjectNames = projectNames
            };

            return View(viewModel);
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
