using Fr.EQL.Ai109.Tontapatt.DataAccess;
using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Business
{
    public class PointageJournalierBU
    {
        public void InsererPointageJournalier(int idDemandeDeReservation)
        {
            DateTime heurePointage = DateTime.Now;
            DateTime heurePrevu = new DateTime(heurePointage.Year, heurePointage.Month, heurePointage.Day, 9, 0, 0);
            new PointageJournalierDAO().InsererPointageJournalier(idDemandeDeReservation, heurePointage, heurePrevu);
        }

        public List<PointageJournalier> GetAllByIdDemandeDeReservastion(int idDemandeDeReservation)
        {
            return new PointageJournalierDAO().GetAllByIdDemandeDeReservastion(idDemandeDeReservation);
        }
    }
}
