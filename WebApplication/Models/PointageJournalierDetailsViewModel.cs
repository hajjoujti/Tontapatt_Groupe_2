using Fr.EQL.Ai109.Tontapatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.WebApplication.Models
{
    public class PointageJournalierDetailsViewModel
    {
        public List<PointageJournalier> PointagesJournalier { get; set; }
        public DemandeDeReservation DemandeDeReservationDetails { get; set; }
    }
}
