using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.WebApplication.Models
{
    public class AnomalieDetailsViewModel
    {
        public int IdAnomalie { get; set; }
        public int IdDemande { get; set; }
        public int IdUtilisateurClient { get; set; }
        public int IdUtilisateurEleveur { get; set; }
       [Required(ErrorMessage = "Vous devez choisir le type d'anomalie")]
        public int IdTypeAnomalie { get; set; }
       
        public string? DescriptionAnomalie { get; set; }
    }
}
