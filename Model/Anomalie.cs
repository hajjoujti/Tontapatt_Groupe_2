using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Model
{
    public class Anomalie
    {
        public int IdAnomalie { get; set; }
        public int IdDemande { get; set; }
        public int IdUtilisateurClient { get; set; }
        public int IdUtilisateurEleveur { get; set; }
        public int IdTypeAnomalie { get; set; }
        public DateTime DateDeclenchementAnomalie { get; set; }
        public DateTime? DateFinAnomalie { get; set; }
        public string DescriptionAnomalie { get; set; }

        public Anomalie()
        {
        }
    }
}
