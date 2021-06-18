using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Model
{
    public class EvaluationPrestation
    {
        public int IdEvalPrestation { get; set; }
        public int IdUtilisateurClient { get; set; }
        public int IdUtilisateurEleveur { get; set; }
        public int IdDemande { get; set; }

        [Range(0, 5, ErrorMessage="La Note de préstation doit être entre 0 et 5")]
        public int NotePrestation { get; set; }
        public string RemarqueEval { get; set; }
    }
}
