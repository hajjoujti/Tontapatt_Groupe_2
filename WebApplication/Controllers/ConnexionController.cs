using Fr.EQL.Ai109.Tontapatt.Business;
using Fr.EQL.Ai109.Tontapatt.Model;
using Fr.EQL.Ai109.Tontapatt.WebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public IActionResult Connexion()
        {
            return View();
        }

        /* CREATION DES COOKIES --------------------
         * [HttpPost]
        public async Task<IActionResult> Index(string MailUtilisateur, string MdpUtilisateur, ConnexionViewModel connexionViewModel)
        {
            UtilisateurBU bu = new();
            Utilisateur utilisateur = bu.GetUtilisateurAuthentification(connexionViewModel.MailUtilisateur, connexionViewModel.MdpUtilisateur);

            if ((MailUtilisateur == connexionViewModel.MailUtilisateur) && (MdpUtilisateur == connexionViewModel.MdpUtilisateur))
            {
                ViewBag.IsInBDD = true;
                /*Response.Cookies.Append("idUtilisateur", utilisateur.IdUtilisateur.ToString());

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, MailUtilisateur),

                };
                var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
                return View("~/Views/Home/Index.cshtml", utilisateur);
            }
            else
            {
                return View();
            }       
        }

        public async Task<IActionResult> Deconnexion()
        {
            await HttpContext.SignOutAsync();
            Response.Cookies.Delete("idUtilisateur");
            return View("~/Views/Home/Index.cshtml");
        }*/
    }
}
