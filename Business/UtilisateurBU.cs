using Fr.EQL.Ai109.Totapatt.DataAccess;
using Fr.EQL.Ai109.Totapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Totapatt.Business
{
    public class UtilisateurBU
    {
        public Utilisateur GetUtilisateurAuthentification(string mail, string mdp)
        {
            return new UtilisateurDAO().GetUtilisateurAuthentification(mail, mdp);
        }
    }
}
