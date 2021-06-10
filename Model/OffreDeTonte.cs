using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Totapatt.Model
{
    public class OffreDeTonte
    {
        public int IdOffre { get; set; }
        public int IdRaceAnimal { get; set; }
        public int? IdAnnulationOffre { get; set; }
        public int IdUtilisateur { get; set; }
        public int IdVilleCP { get; set; }
        public string NomOffre { get; set; }
        public string AdresseTroupeau { get; set; }
        public DateTime DateDebutOffre { get; set; }
        public DateTime DateFinOffre { get; set; }
        public DateTime DateCreationOffre { get; set; }
        public string DescriptionOffre { get; set; }
        public int DistanceMaximale { get; set; }
        public double CoutAnimalParJour { get; set; }
        public DateTime? DateAnnulationOffre { get; set; }
        public int NombreAnimaux { get; set; }
    }
}
