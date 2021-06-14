using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class DemandeDeReservationDAO : DAO
    {
        public void CreateDeMandeDeReservation(DemandeDeReservation demandeDeReservation)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"INSERT INTO demandedereservation (id_terrain, id_moyen_paiement, id_offre,
                                date_debut_demande, date_fin_demande, cout_demande, date_creation_demande,
                                numero_reservation)
                                VALUES (@id_terrain, @id_moyen_paiement, @id_offre,
                                @date_debut_demande, @date_fin_demande, @cout_demande, @date_creation_demande,
                                @numero_reservation)";
        }
    }
}
