using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Fr.EQL.Ai109.Tontapatt.WebApplication.Models
{
    public class AnnulationAvantAcceptationViewModel
    {
        public List<RaisonAnnulationDemande> raisonsAnnulationDemande { get; set; }
        public int IdUtilisateur { get; set; }
        [Required]
        public int IdDemandeDeReservation { get; set; }
        [Required]
        public int IdRaisonAnnul { get; set; }
    }
}
