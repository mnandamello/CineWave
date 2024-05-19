using CineWave.Data;
using CineWave.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CineWave.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var session = HttpContext.Session.GetInt32("_Id");
            var find = _dataContext.Usuarios.Find(session);
            if (find == null)
            {
                return View();
            }

            return RedirectToAction("PerfilPage", "Usuario");
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
