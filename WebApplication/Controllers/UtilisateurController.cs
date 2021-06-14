using Fr.EQL.Ai109.Tontapatt.Business;
using Fr.EQL.Ai109.Tontapatt.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.WebApplication.Controllers
{
    public class UtilisateurController : Controller
    {
        // GET: UtilisateurController
        public ActionResult Index()
        {
            return View();
        }

        [Route("Rechercher/ChoisirTerrain/{idUtilisateur:int}")]
        public IActionResult ChoixTerrainRecherche(int idUtilisateur)
        {
            TerrainBU buTerrain = new();
            List<Terrain> mesTerrains = buTerrain.GetAllByIdUtilisateur(idUtilisateur);
            UtilisateurBU buUtilisateur = new();
            ViewBag.Utilisateur = buUtilisateur.GetById(idUtilisateur);
            return View(mesTerrains);
        }

        [Route("Rechercher/ChoisirOffre/{idTerrain:int}")]
        public IActionResult ChoixOffreRecherche(int idTerrain)
        {
            OffreDeTonteBU buOffreDeTonte = new();
            List<OffreDeTonteDetails> offresDeTonteDetails = buOffreDeTonte.GetAllDetailsByPositionTerrain(idTerrain);

            return View(offresDeTonteDetails);
        }

    }
}
