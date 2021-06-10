using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Totapatt.Model
{
    public class EvaluationPrestation
    {
        public int IdEvalPrestation { get; set; }
        public int? IdUtilisateurClient { get; set; }
        public int? IdUtilisateurEleveur { get; set; }
        public int IdDemande { get; set; }
        public int? NotePrestation { get; set; }
        public string RemarqueEval { get; set; }
    }
}
