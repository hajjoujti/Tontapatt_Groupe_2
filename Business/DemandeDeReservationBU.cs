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
            DemandeDeReservationDAO demandeDeReservationDAO = new();
            DemandeDeReservationDetails demandeDeReservationDetails = demandeDeReservationDAO.GetByIdWithDetails(idDemandeDeReservation);
            demandeDeReservationDetails.OffreDeTonteDetails = new OffreDeTonteDAO().GetByIdWithDetails(demandeDeReservationDetails.IdOffre);
            demandeDeReservationDetails.TerrainDetails = new TerrainDAO().GetByIdWithDetails(demandeDeReservationDetails.IdTerrain);

            return demandeDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllEnAttenteWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            DemandeDeReservationDAO demandeDeReservationDAO = new();
            List<DemandeDeReservationDetails> demandesDeReservationDetails = demandeDeReservationDAO.GetAllEnAttentesWithDetailsByIdUtilisateur(idUtilisateur);

            foreach(DemandeDeReservationDetails d in demandesDeReservationDetails)
            {
                d.OffreDeTonteDetails = new OffreDeTonteDAO().GetByIdWithDetails(d.IdOffre);
                d.TerrainDetails = new TerrainDAO().GetByIdWithDetails(d.IdTerrain);
            }

            return demandesDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllEnCoursWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            DemandeDeReservationDAO demandeDeReservationDAO = new();
            List<DemandeDeReservationDetails> demandesDeReservationDetails = demandeDeReservationDAO.GetAllEnCoursWithDetailsByIdUtilisateur(idUtilisateur);

            foreach (DemandeDeReservationDetails d in demandesDeReservationDetails)
            {
                d.OffreDeTonteDetails = new OffreDeTonteDAO().GetByIdWithDetails(d.IdOffre);
                d.TerrainDetails = new TerrainDAO().GetByIdWithDetails(d.IdTerrain);
            }

            return demandesDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllTermineesWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            DemandeDeReservationDAO demandeDeReservationDAO = new();
            List<DemandeDeReservationDetails> demandesDeReservationDetails = demandeDeReservationDAO.GetAllTermineesWithDetailsByIdUtilisateur(idUtilisateur);

            foreach (DemandeDeReservationDetails d in demandesDeReservationDetails)
            {
                d.OffreDeTonteDetails = new OffreDeTonteDAO().GetByIdWithDetails(d.IdOffre);
                d.TerrainDetails = new TerrainDAO().GetByIdWithDetails(d.IdTerrain);
            }

            return demandesDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllAnnuleesWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            DemandeDeReservationDAO demandeDeReservationDAO = new();
            List<DemandeDeReservationDetails> demandesDeReservationDetails = demandeDeReservationDAO.GetAllAnnuleesWithDetailsByIdUtilisateur(idUtilisateur);

            foreach (DemandeDeReservationDetails d in demandesDeReservationDetails)
            {
                d.OffreDeTonteDetails = new OffreDeTonteDAO().GetByIdWithDetails(d.IdOffre);
                d.TerrainDetails = new TerrainDAO().GetByIdWithDetails(d.IdTerrain);
            }

            return demandesDeReservationDetails;
        }

        public void AccepterDemandeReservationById(int idDemandeDeReservation)
        {
            DateTime dateAcceptationDemande = DateTime.Now;
            new DemandeDeReservationDAO().AccepterDemandeDeReservationById(idDemandeDeReservation, dateAcceptationDemande);
        }

        public void RefuserDemandeDeReservation(int idDemandeDeReservation, int idMotifRefus)
        {
            DateTime dateRefusDemande = DateTime.Now;
            new DemandeDeReservationDAO().RefuserDemandeDeReservationById(idDemandeDeReservation, idMotifRefus, dateRefusDemande);
        }
    }
}
