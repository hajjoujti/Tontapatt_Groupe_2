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
            UtilisateurPrestationViewModel prestationList = new();
            prestationList.demandeDeReservationDetails = bu.GetAllEnAttenteWithDetailsByIdUtilisateur(idUtilisateur);
            ViewBag.Classe = 0;
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            return View(prestationList);
        }

        [Route("Utilisateur/listePrestationEnCour/{idUtilisateur:int}")]
        public IActionResult ListePrestationEncour(int idUtilisateur)
        {

            DemandeDeReservationBU bu = new();
            UtilisateurPrestationViewModel prestationList = new();
            prestationList.demandeDeReservationDetails = bu.GetAllEnCoursWithDetailsByIdUtilisateur(idUtilisateur);
            ViewBag.Classe = 1;
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            return View("ListePrestation", prestationList);
        }

        [Route("Utilisateur/listePrestationTerminer/{idUtilisateur:int}")]
        public IActionResult ListePrestationTerminer(int idUtilisateur)
        {

            DemandeDeReservationBU bu = new();
            UtilisateurPrestationViewModel prestationList = new();
            prestationList.demandeDeReservationDetails = bu.GetAllTermineesWithDetailsByIdUtilisateur(idUtilisateur);
            ViewBag.Classe = 2;
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            return View("ListePrestation", prestationList);
        }

        [Route("Utilisateur/listePrestationAnnuler/{idUtilisateur:int}")]
        public IActionResult ListePrestationAnnuler(int idUtilisateur)
        {

            DemandeDeReservationBU bu = new();
            UtilisateurPrestationViewModel prestationList = new();
            prestationList.demandeDeReservationDetails = bu.GetAllAnnuleesWithDetailsByIdUtilisateur(idUtilisateur);
            ViewBag.Classe = 3;
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
            ViewBag.IdUtilisateur = d.TerrainDetails.IdUtilisateur;
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

                ViewBag.Message = "Demande de prestation transmise ";

                return View("Reussite");
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
            ViewBag.Classe = idClasse;

            return View(demandeDeReservationDetails);
        }

        [HttpGet]
        public IActionResult PrestationDetailsEleveur(int idDemandeDeReservation, int idClasse)
        {
            ViewBag.IsInBDD = true;
            DemandeDeReservationDetails demandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(idDemandeDeReservation);
            ViewBag.IdUtilisateur = demandeDeReservationDetails.OffreDeTonteDetails.IdUtilisateur;
            ViewBag.Classe = idClasse;

            return View(demandeDeReservationDetails);
        }

        [HttpGet]
        public IActionResult PointageJournalierEleveur(int idDemandeDeReservation, int idUtilisateur, int idClasse)
        {
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IdDemandeDeReservation = idDemandeDeReservation;
            ViewBag.IsInBDD = true;
            ViewBag.Classe = idClasse;

            PointageJournalierDetailsViewModel pointageJournalierDetailsViewModel = new();
            pointageJournalierDetailsViewModel.ListPointagesJournalier = new PointageJournalierBU().GetAllByIdDemandeDeReservastion(idDemandeDeReservation);
            pointageJournalierDetailsViewModel.DemandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(idDemandeDeReservation);

            return View(pointageJournalierDetailsViewModel);
        }

        [HttpGet]
        public IActionResult PointageJournalierClient(int idDemandeDeReservation, int idUtilisateur, int idClasse)
        {
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IdDemandeDeReservation = idDemandeDeReservation;
            ViewBag.IsInBDD = true;
            ViewBag.Classe = idClasse;

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

        [HttpGet]
        public IActionResult DeclarationAnomalieEleveur(int idDemandeDeReservation, int idUtilisateur, int idClasse)
        {
            ViewBag.IsInBDD = true;
            ViewBag.Classe = idClasse;
            ViewBag.IdUtilisateur = idUtilisateur;

            AnomalieDetailsViewModel anomalieDetailsViewModel = new();
            anomalieDetailsViewModel.DemandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(idDemandeDeReservation);
            anomalieDetailsViewModel.TypesAnomalie = new TypeAnomalieBU().GetAll();

            return View(anomalieDetailsViewModel);
        }

        [HttpPost]
        public IActionResult NouvelleAnomalieEleveur(AnomalieDetailsViewModel anomalieDetailsViewModel)
        {
            ViewBag.IsInBDD = true;
            ViewBag.IdUtilisateur = anomalieDetailsViewModel.IdUtilisateurEleveur;
            if (ModelState.IsValid)
            {
                Anomalie anomalie = new();
                anomalie.IdDemande = anomalieDetailsViewModel.IdDemande;
                anomalie.IdUtilisateurClient = anomalieDetailsViewModel.IdUtilisateurClient;
                anomalie.IdUtilisateurEleveur = anomalieDetailsViewModel.IdUtilisateurEleveur;
                anomalie.IdTypeAnomalie = anomalieDetailsViewModel.IdTypeAnomalie;
                anomalie.DescriptionAnomalie = anomalieDetailsViewModel.DescriptionAnomalie;

                new AnomalieBU().InsererAnomalie(anomalie);

                return View();
            }
            else
            {
                return View("DeclarationAnomalieEleveur", anomalieDetailsViewModel);
            }
        }

        [HttpGet]
        public IActionResult DeclarationAnomalieClient(int idDemandeDeReservation, int idUtilisateur, int idClasse)
        {
            ViewBag.IsInBDD = true;
            ViewBag.Classe = idClasse;
            ViewBag.IdUtilisateur = idUtilisateur;

            AnomalieDetailsViewModel anomalieDetailsViewModel = new();
            anomalieDetailsViewModel.DemandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(idDemandeDeReservation);
            anomalieDetailsViewModel.TypesAnomalie = new TypeAnomalieBU().GetAll();

            return View(anomalieDetailsViewModel);
        }

        [HttpPost]
        public IActionResult NouvelleAnomalieClient(AnomalieDetailsViewModel anomalieDetailsViewModel)
        {
            ViewBag.IsInBDD = true;
            ViewBag.IdUtilisateur = anomalieDetailsViewModel.IdUtilisateurClient;
            if (ModelState.IsValid)
            {
                Anomalie anomalie = new();
                anomalie.IdDemande = anomalieDetailsViewModel.IdDemande;
                anomalie.IdUtilisateurClient = anomalieDetailsViewModel.IdUtilisateurClient;
                anomalie.IdUtilisateurEleveur = anomalieDetailsViewModel.IdUtilisateurEleveur;
                anomalie.IdTypeAnomalie = anomalieDetailsViewModel.IdTypeAnomalie;
                anomalie.DescriptionAnomalie = anomalieDetailsViewModel.DescriptionAnomalie;

                new AnomalieBU().InsererAnomalie(anomalie);

                return View();
            }
            else
            {
                anomalieDetailsViewModel.DemandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(anomalieDetailsViewModel.IdDemande);
                anomalieDetailsViewModel.TypesAnomalie = new TypeAnomalieBU().GetAll();
                anomalieDetailsViewModel.Anomalies = new AnomalieBU().GetAllByIdDemandeDeReservation(anomalieDetailsViewModel.IdDemande);
                return View(anomalieDetailsViewModel);
            }
        }

        [HttpGet]
        public IActionResult AccepterPrestation(int idDemandeDeReservation, int idUtilisateur)
        {
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            /*function a utiliser*/
            DemandeDeReservationBU demandeDeReservationBU = new();
            demandeDeReservationBU.AccepterDemandeReservationById(idDemandeDeReservation);
            /*test de reussite*/
            ViewBag.Message = "validation reussit";
            return View("Reussite");
        }
        [HttpGet]
        public IActionResult FinPrestation(int idDemandeDeReservation, int idUtilisateur)
        {
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            FinPrestationViewModel finPrestationModel = new();
            finPrestationModel.demandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(idDemandeDeReservation);
            finPrestationModel.IdUtilisateurClient = finPrestationModel.demandeDeReservationDetails.TerrainDetails.IdUtilisateur;
            finPrestationModel.IdUtilisateurEleveur = finPrestationModel.demandeDeReservationDetails.OffreDeTonteDetails.IdUtilisateur;
            finPrestationModel.IdDemande = idDemandeDeReservation;

            return View("FinPrestation", finPrestationModel);
        }
        [HttpPost]
        public IActionResult FinPrestation(FinPrestationViewModel f)
        {
            ViewBag.IdUtilisateur = f.IdUtilisateur;
            ViewBag.IsInBDD = true;
            if (ModelState.IsValid)
            {
                EvaluationPrestation evaluationPrestation = new();
                evaluationPrestation.IdDemande = f.IdDemande;
                evaluationPrestation.IdUtilisateurClient = f.IdUtilisateurClient;
                evaluationPrestation.IdUtilisateurEleveur = f.IdUtilisateurEleveur;
                evaluationPrestation.NotePrestation = f.NotePrestation;
                evaluationPrestation.RemarqueEval = f.RemarqueEval;
                EvaluationPrestationBU evaluationPrestationBU = new();
                evaluationPrestationBU.InsererEvaluationPrestation(evaluationPrestation);
                ViewBag.Message = "Merci à la prochaine.";
                return View("Reussite");
            }
            else
            {

                return View(f);

            }

        }

        [HttpGet]
        public IActionResult ListeAnomalie(int idDemandeDeReservation, int idUtilisateur)
        {
            AnomalieDetailsViewModel anomalieDetailsViewModel  = new();
            anomalieDetailsViewModel.DemandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(idDemandeDeReservation);
            ViewBag.IdUtilisateur = idUtilisateur;
            ViewBag.IsInBDD = true;
            return View(anomalieDetailsViewModel);
        }

        [HttpGet]
        public IActionResult AnnulationPrematuree(int idDemandeDeReservation, int idUtilisateur, int idClasse)
        {
            ViewBag.Classe = idClasse;
            ViewBag.IsInBDD = true;
            ViewBag.IdUtilisateur = idUtilisateur;
            RaisonAnnulationPrematureeViewModel raisonAnnulationPrematureeViewModel = new();
            raisonAnnulationPrematureeViewModel.DemandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(idDemandeDeReservation);
            raisonAnnulationPrematureeViewModel.RaisonsAnnulationPrematuree = new RaisonAnnulationPrematureeBU().GetAll();

            return View(raisonAnnulationPrematureeViewModel);
        }

        [HttpPost]
        public IActionResult AnnulationPrematuree(RaisonAnnulationPrematureeViewModel raisonAnnulationPrematureeViewModel)
        {
            ViewBag.IsInBDD = true;
            ViewBag.IdUtilisateur = raisonAnnulationPrematureeViewModel.IdUtilisateur;
            if (ModelState.IsValid)
            {
                new DemandeDeReservationBU().AnnulationPrematureeDemandeDeReservationById(raisonAnnulationPrematureeViewModel.IdDemande, raisonAnnulationPrematureeViewModel.IdRaisonAnnulPrem);

                ViewBag.Message = "validation de l'annumaltion de la prestation";
                return View("Reussite");
            }
            else
            {
                raisonAnnulationPrematureeViewModel.DemandeDeReservationDetails = new DemandeDeReservationBU().GetByIdWithDetails(raisonAnnulationPrematureeViewModel.IdDemande);
                raisonAnnulationPrematureeViewModel.RaisonsAnnulationPrematuree = new RaisonAnnulationPrematureeBU().GetAll();
                return View(raisonAnnulationPrematureeViewModel);
            }
        }
    }
}