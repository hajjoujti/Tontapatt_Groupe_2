using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.WebApplication.Models
{
    public class RefusDemandeDePrestationViewModel
    {
        public List<RaisonRefusDemande> RaisonsRefusDemande { get; set; }
        public int IdDemandeDeReservation { get; set; }
        public int IdMotifRefus { get; set; }
        public int IdUtilisateur { get; set; }
    }
}
