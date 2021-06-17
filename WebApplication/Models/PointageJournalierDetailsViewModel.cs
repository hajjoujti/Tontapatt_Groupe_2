using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.WebApplication.Models
{
    public class PointageJournalierDetailsViewModel
    {
        public PointageJournalier PointageJournalier { get; set; }
        public List<PointageJournalier> ListPointagesJournalier { get; set; }
        public DemandeDeReservation DemandeDeReservationDetails { get; set; }
    }
}
