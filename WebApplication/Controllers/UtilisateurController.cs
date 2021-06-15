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
        Boolean isInBDD;
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

            ViewBag.IsInBDD = true;
            return View(utilisateurEtTerrainsDetailsViewModel);
        }

        [HttpGet]
        [Route("Utilisateur/ChoixOffreRecherche/{idTerrain:int}")]
        public IActionResult ChoixOffreRecherche(int idTerrain)
        {
            OffreDeTonteBU buOffreDeTonte = new();

            TerrainBU buTerrain = new();

            UtilisateurBU buUtilisateur = new();

            OffresDeTonteDetailsEtTerrainViewModel offresDeTonteDetailsEtTerrainViewModel = new();
            offresDeTonteDetailsEtTerrainViewModel.OffresDeTonteDetails = buOffreDeTonte.GetAllDetailsByPositionTerrain(idTerrain);
            offresDeTonteDetailsEtTerrainViewModel.TerrainDetails = buTerrain.GetByIdWithDetails(idTerrain); ;

            ViewBag.IsInBDD = true;

            return View(offresDeTonteDetailsEtTerrainViewModel);
        }

        [HttpGet]
        public IActionResult ChoixOffreDescription(int idOffreDeTonte, int idTerrain)
        {
            OffreDeTonteBU buOffreDeTonte = new();
            OffreDeTonteDetails offresDeTonteDetails = buOffreDeTonte.GetWithDetailsByIdOffreEtPositionTerrain(idOffreDeTonte, idTerrain);

            ViewBag.IdTerrain = idTerrain;
            ViewBag.IsInBDD = true;

            return View(offresDeTonteDetails);
        }

        [Route("Utilisateur/ChoixTerrainDescription{idTerrain:int}")]
        public IActionResult ChoixTerrainDescription(int idTerrain)
        {
            TerrainBU buTerrain = new();
            TerrainDetails TerrainsDetails = buTerrain.GetByIdWithDetails(idTerrain);

            ViewBag.IsInBDD = true;

            return View(TerrainsDetails);
        }

        [Route("Utilisateur/liste/Prestation")]
        public IActionResult ListePrestation()
        {
            ViewBag.IsInBDD = true;

            return View();
        }

        [HttpPost]
        public IActionResult NouvelleDemandeDeReservation(DemandeDeReservationViewModel d)
        {
            ViewBag.IsInBDD = true;
            if (ModelState.IsValid)
            {
                DemandeDeReservation demandeDeReservation = new();
                demandeDeReservation.IdTerrain = d.IdTerrain;
                demandeDeReservation.IdMoyenPaiement = d.IdMoyenPaiement;
                demandeDeReservation.IdOffre = d.IdOffre;
                demandeDeReservation.DateDebutDemande = d.DateDebutDemande;
                demandeDeReservation.DateFinDemande = d.DateFinDemande;
                demandeDeReservation.NombreAnimaux = d.NombreAnimaux;
                demandeDeReservation.CoutDemande = d.CoutDemande;

                DemandeDeReservationBU bu = new DemandeDeReservationBU();
                bu.InsererUneDemandeDeReservation(demandeDeReservation);
                return View("");
            }
            else
            {
                return View("");
            }
        }
    }
}