using Fr.EQL.Ai109.Tontapatt.DataAccess;
using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Business
{
    public class EvaluationPrestationBU
    {
        public void InsererEvaluationPrestation(EvaluationPrestation evaluationPrestation)
        {
            new EvaluationPrestationDAO().InsererEvaluationPrestation(evaluationPrestation);
        }

        public EvaluationPrestation GetById(int idEvaluationPrestation)
        {
            return new EvaluationPrestationDAO().GetById(idEvaluationPrestation);
        }

        public List<EvaluationPrestation> GetAllByIdDemandeDeReservation(int idDemandeDeReservation)
        {
            return new EvaluationPrestationDAO().GetAllByIdDemandeDeReservation(idDemandeDeReservation);
        }
    }
}
