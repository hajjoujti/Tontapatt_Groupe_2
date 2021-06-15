using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Model
{
    public class DemandeDeReservation
    {
        public int IdDemande { get; set; }
        public int? IdRaisonAnnulationPrem { get; set; }
        [Required]
        public int IdTerrain { get; set; }
        public int? IdRaisonAnnulClient { get; set; }
        public int? IdMotifRefus { get; set; }
        public int? IdMoyenPaiement { get; set; }
        [Required]
        public int IdOffre { get; set; }
        [Required]
        public DateTime DateDebutDemande { get; set; }
        [Required]
        public DateTime DateFinDemande { get; set; }
        [Required]
        public double CoutDemande { get; set; }
        public DateTime? DateAcceptationDemande { get; set; }
        public DateTime? DateAnnulationDemande { get; set; }
        [Required]
        public DateTime DateCreationDemande { get; set; }
        public DateTime? DateInstallationTroupeau { get; set; }
        public DateTime? DateAnnulationPrematuree { get; set; }
        [Required]
        public string NumeroReservation { get; set; }
        public DateTime? DateRefusDemande { get; set; }
        [Required]
        public int NombreAnimaux { get; set; }
    }
}
