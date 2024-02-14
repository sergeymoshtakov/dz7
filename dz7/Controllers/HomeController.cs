using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using dz7.Models;
using System.Diagnostics;

namespace dz7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userId))
            {
                userId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("UserId", userId);
            }

            Console.WriteLine(userId);

            UserCount.AddSessionId(userId);

            var uniqueSessionCount = UserCount.GetUniqueSessionCount();

            Console.WriteLine(uniqueSessionCount);

            return View(uniqueSessionCount);
        }

        public IActionResult Disconnect()
        {
            var sessionId = HttpContext.Session.Id;

            UserCount.RemoveSessionId(sessionId);

            return RedirectToAction("Index");
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