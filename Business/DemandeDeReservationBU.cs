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
    }
}
