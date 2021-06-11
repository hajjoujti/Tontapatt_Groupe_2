using Fr.EQL.Ai109.Totapatt.DataAccess;
using Fr.EQL.Ai109.Totapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Totapatt.Business
{
    public class TerrainBU
    {
        public Terrain GetTerrain(int id)
        {
            return new TerrainDAO().GetById(id);
        }

        public List<Terrain> GetByIdUtilisateur(int idUtilisateur)
        {
            return new TerrainDAO().GetByIdUtilisateur(idUtilisateur);
        }
    }
}
