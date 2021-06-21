using Fr.EQL.Ai109.Tontapatt.DataAccess;
using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Business
{
    public class AnomalieBU
    {
        public void InsererAnomalie(Anomalie anomalie)
        {
            anomalie.DateDeclenchementAnomalie = DateTime.Now;
            new AnomalieDAO().InsererAnomalie(anomalie);
        }

        public void FinAnomalie(int idAnomalie)
        {
            DateTime dateFinAnomalie = DateTime.Now;
            new AnomalieDAO().FinAnomalie(idAnomalie, dateFinAnomalie);
        }

        public List<Anomalie> GetAllByIdDemandeDeReservation(int idDemandeDeReservation)
        {
            return new AnomalieDAO().GetAllByIdDemandeDeReservation(idDemandeDeReservation);
        }

        public Anomalie GetById(int idAnomalie)
        {
            return new AnomalieDAO().GetById(idAnomalie);
        }

        public bool IsUneAnomalieEnCours()
        {
            return new AnomalieDAO().IsUneAnomalieEnCours();
        }
    }
}
