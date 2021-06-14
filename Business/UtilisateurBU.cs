using Fr.EQL.Ai109.Tontapatt.DataAccess;
using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Business
{
    public class UtilisateurBU
    {
        public Utilisateur GetUtilisateurAuthentification(string mail, string mdp)
        {
            return new UtilisateurDAO().GetUtilisateurAuthentification(mail, mdp);
        }
    }
}
