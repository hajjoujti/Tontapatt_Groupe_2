using Fr.EQL.Ai109.Tontapatt.Business;
using Fr.EQL.Ai109.Tontapatt.Model;
using Fr.EQL.Ai109.Tontapatt.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Totapatt.WebApplication.Controllers
{
    public class ConnexionController : Controller
    {
        Boolean isInBDD;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ConnexionViewModel connexionViewModel)
        {
            UtilisateurBU bu = new();
            Utilisateur utilisateur = bu.GetUtilisateurAuthentification(connexionViewModel.MailUtilisateur, connexionViewModel.MdpUtilisateur);

            if(utilisateur is null)
            {
                ViewBag.IsInBDD = false;
                return View();
            }
            ViewBag.IsInBDD = true;
            ViewBag.IdUtilisateur = utilisateur.IdUtilisateur;
            return View("~/Views/Home/Index.cshtml", utilisateur);
        }

        public IActionResult Deconnexion()
        {
            ViewBag.IsInBDD = false;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
