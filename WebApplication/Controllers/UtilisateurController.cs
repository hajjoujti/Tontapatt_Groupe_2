using Fr.EQL.Ai109.Tontapatt.Business;
using Fr.EQL.Ai109.Tontapatt.Model;
using Fr.EQL.Ai109.Tontapatt.WebApplication.Models;
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

            UtilisateurBU buUtilisateur = new();

            UtilisateurEtTerrainsDetailsViewModel utilisateurEtTerrainsDetailsViewModel = new();
            utilisateurEtTerrainsDetailsViewModel.TerrainsDetails = buTerrain.GetAllDetailsByIdUtilisateur(idUtilisateur);
            utilisateurEtTerrainsDetailsViewModel.Utilisateur = buUtilisateur.GetById(idUtilisateur);

            return View(utilisateurEtTerrainsDetailsViewModel);
        }

        [Route("Utilisateur/ChoixOffreRecherche/{idTerrain:int}")]
        public IActionResult ChoixOffreRecherche(int idTerrain)
        {
            OffreDeTonteBU buOffreDeTonte = new();

            TerrainBU buTerrain = new();

            UtilisateurBU buUtilisateur = new();

            OffresDeTonteDetailsEtTerrainViewModel offresDeTonteDetailsEtTerrainViewModel = new();
            offresDeTonteDetailsEtTerrainViewModel.OffresDeTonteDetails = buOffreDeTonte.GetAllDetailsByPositionTerrain(idTerrain);
            offresDeTonteDetailsEtTerrainViewModel.TerrainDetails = buTerrain.GetByIdWithDetails(idTerrain); ;

            return View(offresDeTonteDetailsEtTerrainViewModel);
        }

        [Route("Rechercher/ChoisirOffre/Description/{idOffreDeTonte:int}")]
        public IActionResult ChoixOffreDescription(int idOffreDeTonte)
        {
            OffreDeTonteBU buOffreDeTonte = new();
            OffreDeTonteDetails offresDeTonteDetails = buOffreDeTonte.GetByIdWithDetails(idOffreDeTonte);

            return View(offresDeTonteDetails);
        }

        [Route("Utilisateur/ChoixTerrainRecherche/Description/{idUtilisateur:int}")]
        public IActionResult ChoixTerrainDescription(int idUtilisateur)
        {
            TerrainBU buTerrain = new();

            UtilisateurBU buUtilisateur = new();

            UtilisateurEtTerrainsDetailsViewModel utilisateurEtTerrainsDetailsViewModel = new();
            utilisateurEtTerrainsDetailsViewModel.TerrainsDetails = buTerrain.GetAllDetailsByIdUtilisateur(idUtilisateur);
            utilisateurEtTerrainsDetailsViewModel.Utilisateur = buUtilisateur.GetById(idUtilisateur);

            return View(utilisateurEtTerrainsDetailsViewModel);
        }

    }
}