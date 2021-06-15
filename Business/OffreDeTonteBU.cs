using Fr.EQL.Ai109.Tontapatt.DataAccess;
using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Business
{
    public class OffreDeTonteBU
    {
        public OffreDeTonte GetById(int idOffreDeTonte)
        {
            return new OffreDeTonteDAO().GetById(idOffreDeTonte);
        }

        public OffreDeTonteDetails GetByIdWithDetails(int idOffreDeTonte)
        {
            return new OffreDeTonteDAO().GetByIdWithDetails(idOffreDeTonte);
        }

        public List<OffreDeTonteDetails> GetAllDetailsByPositionTerrain(int idTerrain)
        {
            TerrainDetails terrainDetails = new TerrainDAO().GetByIdWithDetails(idTerrain);
            return new OffreDeTonteDAO().GetAllDetailsByPositionTerrain(terrainDetails.LatitudeTerrain, terrainDetails.LongitudeTerrain);
        }

        public OffreDeTonteDetails GetWithDetailsByIdOffreEtPositionTerrain(int idOffreDeTonte, int idTerrain)
        {
            TerrainDetails terrainDetails = new TerrainDAO().GetByIdWithDetails(idTerrain);
            return new OffreDeTonteDAO().GetWithDetailsByIdOffreEtPositionTerrain(idOffreDeTonte, terrainDetails.LatitudeTerrain, terrainDetails.LongitudeTerrain);
        }
    }
}
