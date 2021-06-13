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

        public List<OffreDeTonteDetails> GetAllDetailsByPositionTerrain(double latitudeTerrain, double longitudeTerrain)
        {
            return new OffreDeTonteDAO().GetAllDetailsByPositionTerrain(latitudeTerrain, longitudeTerrain);
        }
    }
}
