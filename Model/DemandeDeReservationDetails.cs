using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Model
{
    public class DemandeDeReservationDetails : DemandeDeReservation
    {


        public DemandeDeReservationDetails()
        {
        }

        public DemandeDeReservationDetails(DemandeDeReservation demandeDeReservation)
        {
            IdDemande = demandeDeReservation.IdDemande;
            IdRaisaonAnnulationPrem = demandeDeReservation.IdRaisaonAnnulationPrem;
            IdTerrain = demandeDeReservation.IdTerrain;
            IdRaisonAnnulClient = demandeDeReservation.IdRaisonAnnulClient;
            IdMotifRefus = demandeDeReservation.IdMotifRefus;
            IdMoyenPaiement = demandeDeReservation.IdMoyenPaiement;
            IdOffre = demandeDeReservation.IdOffre;
            DateDebutDemande = demandeDeReservation.DateDebutDemande;
            DateFinDemande = demandeDeReservation.DateFinDemande;
            CoutDemande = demandeDeReservation.CoutDemande;
            DateAcceptationDemande = demandeDeReservation.DateAcceptationDemande;
            DateAnnulationDemande = demandeDeReservation.DateAnnulationDemande;
            DateCreationDemande = demandeDeReservation.DateCreationDemande;
            DateInstallationTroupeau = demandeDeReservation.DateInstallationTroupeau;
            DateAnnulationPrematuree = demandeDeReservation.DateAnnulationPrematuree;
            NumeroReservation = demandeDeReservation.NumeroReservation;
            DateRefusDemande = demandeDeReservation.DateRefusDemande;
        }
    }
}
