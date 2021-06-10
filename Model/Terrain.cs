using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Totapatt.Model
{
    public class Terrain
    {
        public int IdTerrain { get; set; }
        public int? IdRaisonRetrait { get; set; }
        public int IdHumiditeTerrain { get; set; }
        public int IdCompositionTerrain { get; set; }
        public int IdPenteTerrain { get; set; }
        public int IdVilleCP { get; set; }
        public int IdHauteurHerbe { get; set; }
        public int IdUtilisateur { get; set; }
        public string NomTerrain { get; set; }
        public int SurfaceTerrain { get; set; }
        public string DescriptionTerrain { get; set; }
        public string AdresseTerrain { get; set; }
        public DateTime DateEnregistrementTerrain { get; set; }
        public string PhotoTerrain { get; set; }
        public DateTime? DateRetraitTerrain { get; set; }
    }
}
