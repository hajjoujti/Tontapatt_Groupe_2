using Fr.EQL.Ai109.Tontapatt.DataAccess;
using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Business
{
    public class DemandeDeReservationBU
    {
        public void InsererUneDemandeDeReservation(DemandeDeReservation demandeDeReservation)
        {
            demandeDeReservation.DateCreationDemande = DateTime.Now;
            demandeDeReservation.NumeroReservation = DateTime.Now.ToString("yyMMddHHmmssffff");

            new DemandeDeReservationDAO().CreateDemandeDeReservation(demandeDeReservation);
        }

        public DemandeDeReservationDetails GetByIdWithDetails(int idDemandeDeReservation)
        {
            DemandeDeReservationDetails demandeDeReservationDetails = new DemandeDeReservationDAO().GetByIdWithDetails(idDemandeDeReservation);
            demandeDeReservationDetails.TerrainDetails = new TerrainBU().GetByIdWithDetails(demandeDeReservationDetails.IdTerrain);
            demandeDeReservationDetails.OffreDeTonteDetails = new OffreDeTonteBU().GetWithDetailsByIdOffreEtPositionTerrain(demandeDeReservationDetails.IdOffre, demandeDeReservationDetails.IdTerrain);

            return demandeDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllEnAttenteWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            DemandeDeReservationDAO demandeDeReservationDAO = new();
            List<DemandeDeReservationDetails> demandesDeReservationDetails = demandeDeReservationDAO.GetAllEnAttentesWithDetailsByIdUtilisateur(idUtilisateur);

            foreach(DemandeDeReservationDetails d in demandesDeReservationDetails)
            {
                d.TerrainDetails = new TerrainBU().GetByIdWithDetails(d.IdTerrain);
                d.OffreDeTonteDetails = new OffreDeTonteBU().GetWithDetailsByIdOffreEtPositionTerrain(d.IdOffre, d.IdTerrain);
            }

            return demandesDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllEnCoursWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            DemandeDeReservationDAO demandeDeReservationDAO = new();
            List<DemandeDeReservationDetails> demandesDeReservationDetails = demandeDeReservationDAO.GetAllEnCoursWithDetailsByIdUtilisateur(idUtilisateur);

            foreach (DemandeDeReservationDetails d in demandesDeReservationDetails)
            {
                d.TerrainDetails = new TerrainBU().GetByIdWithDetails(d.IdTerrain);
                d.OffreDeTonteDetails = new OffreDeTonteBU().GetWithDetailsByIdOffreEtPositionTerrain(d.IdOffre, d.IdTerrain);
            }

            return demandesDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllTermineesWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            DemandeDeReservationDAO demandeDeReservationDAO = new();
            List<DemandeDeReservationDetails> demandesDeReservationDetails = demandeDeReservationDAO.GetAllTermineesWithDetailsByIdUtilisateur(idUtilisateur);

            foreach (DemandeDeReservationDetails d in demandesDeReservationDetails)
            {
                d.TerrainDetails = new TerrainBU().GetByIdWithDetails(d.IdTerrain);
                d.OffreDeTonteDetails = new OffreDeTonteBU().GetWithDetailsByIdOffreEtPositionTerrain(d.IdOffre, d.IdTerrain);
            }

            return demandesDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllAnnuleesWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            DemandeDeReservationDAO demandeDeReservationDAO = new();
            List<DemandeDeReservationDetails> demandesDeReservationDetails = demandeDeReservationDAO.GetAllAnnuleesWithDetailsByIdUtilisateur(idUtilisateur);

            foreach (DemandeDeReservationDetails d in demandesDeReservationDetails)
            {
                d.TerrainDetails = new TerrainBU().GetByIdWithDetails(d.IdTerrain);
                d.OffreDeTonteDetails = new OffreDeTonteBU().GetWithDetailsByIdOffreEtPositionTerrain(d.IdOffre, d.IdTerrain);
            }

            return demandesDeReservationDetails;
        }

        public void AccepterDemandeReservationById(int idDemandeDeReservation)
        {
            DateTime dateAcceptationDemande = DateTime.Now;
            DemandeDeReservation demandeDeReservation = new DemandeDeReservationDAO().GetById(idDemandeDeReservation);
            new DemandeDeReservationDAO().AccepterDemandeDeReservationById(idDemandeDeReservation, dateAcceptationDemande);
            // annulation de l'offre apres acceptation de demande
            new OffreDeTonteBU().AnnulerOffreDeTonteById(demandeDeReservation.IdOffre, 5); // 5 est l'id de l'annulation offre base sur l'acceptation de la demande
        }

        public void RefuserDemandeDeReservation(int idDemandeDeReservation, int idMotifRefus)
        {
            DateTime dateRefusDemande = DateTime.Now;
            new DemandeDeReservationDAO().RefuserDemandeDeReservationById(idDemandeDeReservation, idMotifRefus, dateRefusDemande);
        }

        public void AnnulationDemandeDeReservationByIdAvantAcceptation(int idDemandeDeReservation, int idRaisonAnnulClient)
        {
            DateTime dateAnnulationDemande = DateTime.Now;
            new DemandeDeReservationDAO().AnnulationDemandeDeReservationByIdAvantAcceptation(idDemandeDeReservation, idRaisonAnnulClient, dateAnnulationDemande);
        }

        public void AnnulationPrematureeDemandeDeReservationById(int idDemandeDeReservation, int idRaisonAnnulationPrem)
        {
            DateTime dateAnnulationPrematuree = DateTime.Now;
            new DemandeDeReservationDAO().AnnulationPrematureeDemandeDeReservationById(idDemandeDeReservation, idRaisonAnnulationPrem, dateAnnulationPrematuree);
        }

        public void TroupeauInstalleByIdDemandeDeReservation(int idDemandeDeReservation)
        {
            DateTime dateInstallationTroupeau = DateTime.Now;
            new DemandeDeReservationDAO().TroupeauInstalleByIdDemandeDeReservation(idDemandeDeReservation, dateInstallationTroupeau);
        }
    }
}
