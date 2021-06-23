using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.WebApplication.Models
{
    public class AnomalieDetailsViewModel
    {
        public int IdDemande { get; set; }

        public int IdUtilisateurClient { get; set; }

        public int IdUtilisateurEleveur { get; set; }

       [Required(ErrorMessage = "Vous devez choisir le type d'anomalie")]
        public int IdTypeAnomalie { get; set; }
       
        [Required]
        public string DescriptionAnomalie { get; set; }

        public DateTime? DateFinAnomalie { get; set; }

        public DateTime? DateDeclenchementAnomalie { get; set; }

        public string TypeAnomalie { get; set; }

        public DemandeDeReservationDetails DemandeDeReservationDetails { get; set; }

        public List<Anomalie> Anomalies { get; set; }
        
        public Anomalie Anomalie { get; set; }

        public int IdUtilisateurDeclarant { get; set; }

        public List<TypeAnomalie> TypesAnomalie { get; set; }
        public int IdClasse { get; set; }
    }
}
