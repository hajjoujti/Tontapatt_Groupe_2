using Fr.EQL.Ai109.Tontapatt.DataAccess;
using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Business
{
    public class TerrainBU
    {
        public Terrain GetTerrain(int idTerrain)
        {
            return new TerrainDAO().GetById(idTerrain);
        }

        public List<Terrain> GetByIdUtilisateur(int idUtilisateur)
        {
            return new TerrainDAO().GetByIdUtilisateur(idUtilisateur);
        }
        
        public TerrainDetails GetByIdWithDetails(int idTerrain)
        {
            return new TerrainDAO().GetByIdWithDetails(idTerrain);
        }
    }
}
