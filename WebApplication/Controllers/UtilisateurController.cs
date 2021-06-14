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

        [HttpGet]
        [Route("Utilisateur/ChoixTerrainRecherche/{idUtilisateur:int}")]
        public IActionResult ChoixTerrainRecherche(int idUtilisateur)
        {
            TerrainBU buTerrain = new();
            List<TerrainDetails> terrainsDetails = buTerrain.GetAllDetailsByIdUtilisateur(idUtilisateur);
            UtilisateurBU buUtilisateur = new();
            Utilisateur utilisateur = buUtilisateur.GetById(idUtilisateur);
            ViewBag.Utilisateur = idUtilisateur;
            return View(terrainsDetails);
        }

        [Route("Utilisateur/ChoixOffreRecherche/{idTerrain:int}")]
        public IActionResult ChoixOffreRecherche(int idTerrain)
        {
            OffreDeTonteBU buOffreDeTonte = new();
            List<OffreDeTonteDetails> offresDeTonteDetails = buOffreDeTonte.GetAllDetailsByPositionTerrain(idTerrain);

            TerrainBU buTerrain = new();
            Terrain terrain = buTerrain.GetById(idTerrain);

            UtilisateurBU buUtilisateur = new();
            ViewBag.Utilisateur = buUtilisateur.GetById(terrain.IdUtilisateur);

            return View(offresDeTonteDetails);
        }

    }
}
