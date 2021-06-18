using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.WebApplication.Models
{
    public class RaisonAnnulationPrematureeViewModel
    {
        [Required]
        public int IdRaisonAnnulPrem { get; set; }

        public int IdUtilisateur { get; set; }

        public int IdDemande { get; set; }

        public int IdClasse { get; set; }

        public List<RaisonAnnulationPrematuree> RaisonsAnnulationPrematuree { get; set; }

        public DemandeDeReservationDetails DemandeDeReservationDetails { get; set; }
    }
}
