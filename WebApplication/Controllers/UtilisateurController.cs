using Fr.EQL.Ai109.Tontapatt.Business;
using Fr.EQL.Ai109.Tontapatt.Model;
using Fr.EQL.Ai109.Tontapatt.WebApplication.Models;
using Microsoft.AspNetCore.Authorization;
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
            ViewBag.IdUtilisateur = idUtilisateur;

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

            ViewBag.IdUtilisateur = new TerrainBU().GetById(idTerrain).IdUtilisateur;
            ViewBag.IdTerrain = idTerrain;
            ViewBag.IsInBDD = true;

            DemandeDeReservationViewModel demandeDeReservationViewModel = new();
            demandeDeReservationViewModel.OffreDeTonteDetails = offresDeTonteDetails;

            demandeDeReservationViewModel.TerrainDetails = new TerrainBU().GetByIdWithDetails(idTerrain);
            return View(demandeDeReservationViewModel);
        }

        [Route("Utilisateur/ChoixTerrainDescription{idTerrain:int}")]
        public IActionResult ChoixTerrainDescription(int idTerrain)
        {
            TerrainBU buTerrain = new();
            TerrainDetails terrainsDetails = buTerrain.GetByIdWithDetails(idTerrain);
            ViewBag.IdUtilisateur = terrainsDetails.IdUtilisateur;
            ViewBag.IsInBDD = true;

            return View(terrainsDetails);
        }

       
        /*[Authorize] ----- FONCTIONNE AVEC LES COOKIE */
        [Route("Utilisateur/listePrestation/{idUtilisateur:int}")]
        public IActionResult ListePrestation(int idUtilisateur)
        {

            DemandeDeReservationBU bu = new();
            UtilisateurPrestationModel prestationList = new();
            prestationList.demandeDeReservationDetails = bu.GetAllEnAttenteWithDetailsByIdUtilisateur(idUtilisateur);
            ViewBag.classe = 0;
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            return View(prestationList);
        }

        [Route("Utilisateur/listePrestationEnCour/{idUtilisateur:int}")]
        public IActionResult ListePrestationEncour(int idUtilisateur)
        {

            DemandeDeReservationBU bu = new();
            UtilisateurPrestationModel prestationList = new();
            prestationList.demandeDeReservationDetails = bu.GetAllEnCoursWithDetailsByIdUtilisateur(idUtilisateur);
            ViewBag.classe = 1;
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            return View("ListePrestation", prestationList);
        }

        [Route("Utilisateur/listePrestationTerminer/{idUtilisateur:int}")]
        public IActionResult ListePrestationTerminer(int idUtilisateur)
        {

            DemandeDeReservationBU bu = new();
            UtilisateurPrestationModel prestationList = new();
            prestationList.demandeDeReservationDetails = bu.GetAllTermineesWithDetailsByIdUtilisateur(idUtilisateur);
            ViewBag.classe = 2;
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            return View("ListePrestation", prestationList);
        }

        [Route("Utilisateur/listePrestationAnnuler/{idUtilisateur:int}")]
        public IActionResult ListePrestationAnnuler(int idUtilisateur)
        {

            DemandeDeReservationBU bu = new();
            UtilisateurPrestationModel prestationList = new();
            prestationList.demandeDeReservationDetails = bu.GetAllAnnuleesWithDetailsByIdUtilisateur(idUtilisateur);
            ViewBag.classe = 3;
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            return View("ListePrestation", prestationList);
        }


        [HttpPost]
        public IActionResult NouvelleDemandeDeReservation(DemandeDeReservationViewModel d)
        {
            ViewBag.IsInBDD = true;
            d.TerrainDetails = new TerrainBU().GetByIdWithDetails(d.IdTerrain);
            d.OffreDeTonteDetails = new OffreDeTonteBU().GetWithDetailsByIdOffreEtPositionTerrain(d.IdOffre, d.IdTerrain);
            ViewBag.IdUtilisateur = new TerrainBU().GetById(d.TerrainDetails.IdUtilisateur);
            if (ModelState.IsValid)
            {
                DemandeDeReservation demandeDeReservation = new();
                demandeDeReservation.IdTerrain = d.IdTerrain;
                demandeDeReservation.IdMoyenPaiement = d.IdMoyenPaiement.Value;
                demandeDeReservation.IdOffre = d.IdOffre;
                demandeDeReservation.DateDebutDemande = d.DateDebutDemande.Value;
                demandeDeReservation.DateFinDemande = d.DateFinDemande.Value;
                demandeDeReservation.NombreAnimaux = d.NombreAnimaux;
                demandeDeReservation.CoutDemande = d.CoutDemande;

                DemandeDeReservationBU bu = new DemandeDeReservationBU();
                bu.InsererUneDemandeDeReservation(demandeDeReservation);
                return View("");
            }
            else
            {
                return View("ChoixOffreDescription", d);
            }
        }

        [HttpGet]
        public IActionResult PrestationDetailsClient(int idDemandeDeReservation, int idClasse)
        {
            ViewBag.IsInBDD = true;
            DemandeDeReservationDetails demandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(idDemandeDeReservation);
            ViewBag.IdUtilisateur = demandeDeReservationDetails.TerrainDetails.IdUtilisateur;
            ViewBag.classe = idClasse;

            return View(demandeDeReservationDetails);
        }

        [HttpGet]
        public IActionResult PrestationDetailsEleveur(int idDemandeDeReservation)
        {
            ViewBag.IsInBDD = true;
            DemandeDeReservationDetails demandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(idDemandeDeReservation);
            ViewBag.IdUtilisateur = demandeDeReservationDetails.OffreDeTonteDetails.IdUtilisateur;

            return View(demandeDeReservationDetails);
        }

        [HttpGet]
        public IActionResult PointageJournalierEleveur(int idDemandeDeReservation, int idUtilisateur)
        {
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IdDemandeDeReservation = idDemandeDeReservation;
            ViewBag.IsInBDD = true;

            PointageJournalierDetailsViewModel pointageJournalierDetailsViewModel = new();
            pointageJournalierDetailsViewModel.ListPointagesJournalier = new PointageJournalierBU().GetAllByIdDemandeDeReservastion(idDemandeDeReservation);
            pointageJournalierDetailsViewModel.DemandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(idDemandeDeReservation);

            return View(pointageJournalierDetailsViewModel);
        }

        [HttpGet]
        public IActionResult PointageJournalierClient(int idDemandeDeReservation, int idUtilisateur)
        {
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IdDemandeDeReservation = idDemandeDeReservation;
            ViewBag.IsInBDD = true;

            PointageJournalierDetailsViewModel pointageJournalierDetailsViewModel = new();
            pointageJournalierDetailsViewModel.ListPointagesJournalier = new PointageJournalierBU().GetAllByIdDemandeDeReservastion(idDemandeDeReservation);
            pointageJournalierDetailsViewModel.DemandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(idDemandeDeReservation);

            return View(pointageJournalierDetailsViewModel);
        }

        [HttpGet]
        public IActionResult PointageJournalier(int idDemandeDeReservation, int idUtilisateur)
        {
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IdDemandeDeReservation = idDemandeDeReservation;
            ViewBag.IsInBDD = true;

    
            PointageJournalierBU pointageJournalierBU = new();
            pointageJournalierBU.InsererPointageJournalier(idDemandeDeReservation);
            /*test de reussite*/
            ViewBag.Message = "Pointage reussit";
            return View("Reussite");
        }

        public IActionResult ValidationDemandeReservation(int idOffreDeTonte, int idTerrain)
        {
            OffreDeTonteBU buOffreDeTonte = new();
            OffreDeTonteDetails offresDeTonteDetails = buOffreDeTonte.GetWithDetailsByIdOffreEtPositionTerrain(idOffreDeTonte, idTerrain);

            ViewBag.IdUtilisateur = new TerrainBU().GetById(idTerrain).IdUtilisateur;
            ViewBag.IdTerrain = idTerrain;
            ViewBag.IsInBDD = true;

            DemandeDeReservationViewModel demandeDeReservationViewModel = new();
            demandeDeReservationViewModel.OffreDeTonteDetails = offresDeTonteDetails;

            demandeDeReservationViewModel.TerrainDetails = new TerrainBU().GetByIdWithDetails(idTerrain);
            return View(demandeDeReservationViewModel);
        }

        /*----------------------------- Anomalie */
        public IActionResult DeclarationAnomalieEleveur(AnomalieDetailsViewModel a)
        {
            ViewBag.IsInBDD = true;
            a.DeamandeDeReservation = new AnomalieBU().GetById(a.IdDemande);
            a.

            if (ModelState.IsValid)
            {
                Anomalie anomalie = new();
                anomalie.IdDemande = a.IdDemande;
                anomalie.IdUtilisateurClient = a.IdUtilisateurClient.Value;
                anomalie.IdUtilisateurEleveur = a.IdUtilisateurEleveur.Value;
                anomalie.IdTypeAnomalie = a.IdTypeAnomalie.Value;
                anomalie.DescriptionAnomalie = a.DescriptionAnomalie.Value;

                AnomalieBU bu = new AnomalieBU();
                bu.InsererAnomalie(anomalie);
                return View("");
            }
            else
            {
                return View("ChoixOffreDescription", d);
            }
        }
    }
}