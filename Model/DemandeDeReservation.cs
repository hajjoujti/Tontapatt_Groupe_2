using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Model
{
    public class DemandeDeReservation
    {
        public int IdDemande { get; set; }
        public int? IdRaisaonAnnulationPrem { get; set; }
        public int IdTerrain { get; set; }
        public int? IdRaisonAnnulClient { get; set; }
        public int? IdMotifRefus { get; set; }
        public int? IdMoyenPaiement { get; set; }
        public int IdOffre { get; set; }
        public DateTime DateDebutDemande { get; set; }
        public DateTime DateFinDemande { get; set; }
        public double CoutDemande { get; set; }
        public DateTime? DateAcceptationDemande { get; set; }
        public DateTime? DateAnnulationDemande { get; set; }
        public DateTime DateCreationDemande { get; set; }
        public DateTime? DateInstallationTroupeau { get; set; }
        public DateTime? DateAnnulationPrematuree { get; set; }
        public int NumeroReservation { get; set; }
        public DateTime? DateRefusDemande { get; set; }
    }
}
