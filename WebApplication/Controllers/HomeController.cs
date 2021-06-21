using Fr.EQL.Ai109.Tontapatt.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Home/Index/{idUtilisateur:int}")]
        public IActionResult Index(int idUtilisateur)
        {
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            return View();
        }

        public IActionResult Indexreturn(int idUtilisateur)
        {
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            return View("index");
        }

        public IActionResult Privacy()
        {
            return View("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
