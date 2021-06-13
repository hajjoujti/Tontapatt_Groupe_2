using Fr.EQL.Ai109.Tontapatt.Business;
using Fr.EQL.Ai109.Tontapatt.Model;
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
        public IActionResult Index(Utilisateur utilisateur)
        {
            UtilisateurBU bu = new();
            utilisateur = bu.GetUtilisateurAuthentification(utilisateur.MailUtilisateur, utilisateur.MdpUtilisateur);

            if(utilisateur is null)
            {
                ViewBag.IsInBDD = false;
                return View();
            }
            return View("/Home", utilisateur);
        }

        public IActionResult Echec()
        {
            
            return View();
        }
    }
}
