using Fr.EQL.Ai109.Tontapatt.Business;
using Fr.EQL.Ai109.Tontapatt.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.WebApplication.Controllers
{
    public class TerrainChoixController : Controller
    {
        [Route("TerrainChoix/Index/{idUtilisateur:int}")]
        public IActionResult Index(int idUtilisateur)
        {
            TerrainBU buTerrain = new();
            List<TerrainDetails> terrainsDetails = buTerrain.GetAllDetailsByIdUtilisateur(idUtilisateur);
            UtilisateurBU buUtilisateur = new();
            Utilisateur utilisateur = buUtilisateur.GetById(idUtilisateur);
            ViewBag.Utilisateur = idUtilisateur;
            return View(terrainsDetails);
        }
    }
}
