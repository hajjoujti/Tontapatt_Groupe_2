using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class PointageJournalierDAO : DAO
    {
        public void InsererPointageJournalier(int idDemandeDeReservation, DateTime heurePointage, DateTime heurePrevu)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"INSERT INTO pointagejournalier
                                (id_demande, heure_pointage, heure_prevu)
                                VALUES
                                (@idDemandeDeReservation, @heurePointage, @heurePrevu)";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));
            cmd.Parameters.Add(new MySqlParameter("@heurePointage", heurePointage));
            cmd.Parameters.Add(new MySqlParameter("@heurePrevu", heurePrevu));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public List<PointageJournalier> GetAllByIdDemandeDeReservastion(int idDemandeDeReservation)
        {
            List<PointageJournalier> pointagesJournaliers = new();
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM pointagejournalier
                                Where id_demande = @idDemandeDeReservation";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PointageJournalier pointageJournalier = new();
                pointageJournalier.IdPointage = dr.GetInt32("id_pointage");
                pointageJournalier.IdDemande = dr.GetInt32("id_demande");
                pointageJournalier.HeurePointage = dr.GetDateTime("heure_pointage");
                pointageJournalier.HeurePrevu = dr.GetDateTime("heure_prevu");
                pointagesJournaliers.Add(pointageJournalier);
            }

            cmd.Connection.Close();

            return pointagesJournaliers;
        }
    }
}
