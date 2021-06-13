using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Model
{
    public class OffreDeTonteDetails : OffreDeTonte
    {
        public string EspeceAnimal { get; set; }
        public string RaceAnimal { get; set; }
        public int MyProperty { get; set; }
        public string NomUtilisateur { get; set; }
        public string PrenomUtilisateur { get; set; }
        public int DescriptionUtilisateur { get; set; }
        public string NomVilleOfrreDeTonte { get; set; }
        public string CodePostaleOffreDeTonte { get; set; }
        public decimal LatitudeOffreDeTonte { get; set; }
        public decimal LongitudeOffreDetonte { get; set; }
        public OffreDeTonteDetails()
        {
        }

        public OffreDeTonteDetails(OffreDeTonte offreDeTonte)
        {
            IdOffre = offreDeTonte.IdOffre;
            IdRaceAnimal = offreDeTonte.IdRaceAnimal;
            IdAnnulationOffre = offreDeTonte.IdAnnulationOffre;
            IdUtilisateur = offreDeTonte.IdUtilisateur;
            IdVilleCP = offreDeTonte.IdVilleCP;
            NomOffre = offreDeTonte.NomOffre;
            AdresseTroupeau = offreDeTonte.AdresseTroupeau;
            DateDebutOffre = offreDeTonte.DateDebutOffre;
            DateFinOffre = offreDeTonte.DateFinOffre;
            DateCreationOffre = offreDeTonte.DateCreationOffre;
            DescriptionOffre = offreDeTonte.DescriptionOffre;
            DistanceMaximale = offreDeTonte.DistanceMaximale;
            CoutAnimalParJour = offreDeTonte.CoutAnimalParJour;
            DateAnnulationOffre = offreDeTonte.DateAnnulationOffre;
            NombreAnimaux = offreDeTonte.NombreAnimaux;
        }
    }
}
