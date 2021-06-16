using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.WebApplication.Models
{
    public class DemandeDeReservationViewModel
    {
        [Required]
        public int IdTerrain { get; set; }
        [Required]
        public int IdMoyenPaiement { get; set; }
        [Required]
        public int IdOffre { get; set; }
        [Required]
        public DateTime DateDebutDemande { get; set; }
        [Required]
        public DateTime DateFinDemande { get; set; }
        [Required]
        public double CoutDemande { get; set; }
        [Required]
        public int NombreAnimaux { get; set; }
        public OffreDeTonteDetails OffreDeTonteDetails { get; set; }
        public TerrainDetails TerrainDetails { get; set; }
    }
}
