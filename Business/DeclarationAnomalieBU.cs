using Fr.EQL.Ai109.Tontapatt.DataAccess;
using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Business
{
    public class DeclarationAnomalieBU
    {
        public void InsererDeclarationAnomalie(int idDemandeDeReservation, int idUtilisateurClient, int idUtilisateurEleveur, int idTypeAnomalie)
        {
            DateTime dateDeclenchementAnomalie = DateTime.Now;
            DateTime dateFinAnomalie = new DateTime(dateDeclenchementAnomalie.Year, dateDeclenchementAnomalie.Month, dateDeclenchementAnomalie.Day, 9, 0, 0);
            new DeclarationAnomalieDAO().InsererDeclarationAnomalie(idDemandeDeReservation, idUtilisateurClient, idUtilisateurEleveur, idTypeAnomalie, dateDeclenchementAnomalie, dateFinAnomalie);
        }

        public List<Anomalie> GetAllByIdDemandeDeReservastion(int idDemandeDeReservation)
        {
            return new DeclarationAnomalieDAO().GetAllByIdDemandeDeReservastion(idDemandeDeReservation);
        }
    }
}
