using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.Model
{
    public class PointageJournalier
    {
        public int IdPointage { get; set; }
        public int IdDemande { get; set; }
        public DateTime HeurePointage { get; set; }
        public DateTime HeurePrevu { get; set; }
    }
}
