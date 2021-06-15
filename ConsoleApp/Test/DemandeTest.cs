using Fr.EQL.Ai109.Tontapatt.Business;
using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.ConsoleApp.Test
{
    public class DemandeTest
    {
        DemandeDeReservationBU bu = new();
        DemandeDeReservation demandeDeReservation = new();
        public void CreationDemande()
        {
            
            demandeDeReservation.IdTerrain = 78;
            demandeDeReservation.IdMoyenPaiement = 2;
            demandeDeReservation.IdOffre = 3;
            demandeDeReservation.DateDebutDemande = DateTime.Today;
            demandeDeReservation.DateFinDemande = DateTime.Today.AddDays(5);
            demandeDeReservation.CoutDemande = 1500;
            demandeDeReservation.NombreAnimaux = 10;
            bu.InsererUneDemandeDeReservation(demandeDeReservation);
        }

        public void AccepterDemande(int idDemande)
        {
            bu.AccepterDemandeReservationById(idDemande);
        }
    }
}
