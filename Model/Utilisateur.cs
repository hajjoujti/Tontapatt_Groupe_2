using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Model
{
    public class Utilisateur
    {
        public int IdUtilisateur { get; set; }
        public int IdVilleCP { get; set; }
        public int? IdDesinscritpion { get; set; }
        public string NomUtilisateur { get; set; }
        public string PrenomUtilisateur { get; set; }
        public string MailUtilisateur { get; set; }
        public string MdpUtilisateur { get; set; }
        public string AdresseUtilisateur { get; set; }
        public DateTime DateInscriptionUtilisateur { get; set; }
        public string DescriptionUtilisateur { get; set; }
        public long? SiretEntreprise { get; set; }
        public DateTime? DateDesinscriptionUtilisateur { get; set; }
    }
}
