using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Model
{
    public class TerrainDetails : Terrain
    {
        public string NomUtilisateur { get; set; }
        public string PrenomUtilisateur { get; set; }
        public string DescriptionUtilisateur { get; set; }
        public string NomVilleTerrain { get; set; }
        public string CodePostalTerrain { get; set; }
        public string HumiditeTerrain { get; set; }
        public string CompositionTerrain { get; set; }
        public string PenteTerrain { get; set; }
        public string HauteurHerbe { get; set; }
        public List<CompositionVegetationDetails> CompositionsVegetationTerrain { get; set; }

        public TerrainDetails(Terrain terrain)
        {
            IdTerrain = terrain.IdTerrain;
            IdRaisonRetrait = terrain.IdRaisonRetrait;
            IdHumiditeTerrain = terrain.IdHumiditeTerrain;
            IdCompositionTerrain = terrain.IdCompositionTerrain;
            IdPenteTerrain = terrain.IdPenteTerrain;
            IdVilleCP = terrain.IdVilleCP;
            IdHauteurHerbe = terrain.IdHauteurHerbe;
            IdUtilisateur = terrain.IdUtilisateur;
            NomTerrain = terrain.NomTerrain;
            SurfaceTerrain = terrain.SurfaceTerrain;
            DescriptionTerrain = terrain.DescriptionTerrain;
            AdresseTerrain = terrain.AdresseTerrain;
            DateEnregistrementTerrain = terrain.DateEnregistrementTerrain;
            PhotoTerrain = terrain.PhotoTerrain;
            DateRetraitTerrain = terrain.DateRetraitTerrain;
        }

        public TerrainDetails()
        {
        }
    }
}
