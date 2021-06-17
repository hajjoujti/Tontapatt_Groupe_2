using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class AnomalieDAO : DAO
    {
        public void InsererAnomalie(Anomalie anomalie)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"INSERT INTO anomalie
                                (id_demande, id_utilisateur_client, id_utilisateur_eleveur, id_type_anomalie, description_anomalie, date_declenchement_anomalie)
                                VALUES(@idDemande, @idUtilisateurClient, @idUtilisateurEleveur, @idTypeAnomalie, @descriptionAnomalie, @dateDeclenchementAnomalie)";

            cmd.Parameters.Add(new MySqlParameter("@idDemande", anomalie.IdDemande));
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateurClient", anomalie.IdUtilisateurClient));
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateurEleveur", anomalie.IdUtilisateurEleveur));
            cmd.Parameters.Add(new MySqlParameter("@idTypeAnomalie", anomalie.IdTypeAnomalie));
            cmd.Parameters.Add(new MySqlParameter("@descriptionAnomalie", anomalie.DescriptionAnomalie));
            cmd.Parameters.Add(new MySqlParameter("@dateDeclenchementAnomalie", anomalie.DateDeclenchementAnomalie));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public void FinAnomalie(int idAnomalie, DateTime dateFinAnomalie)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"UPDATE anomalie SET
                                date_fin_anomalie = @dateFinAnomalie
                                WHERE id_anomalie = @idAnomalie";

            cmd.Parameters.Add(new MySqlParameter("@idAnomalie", idAnomalie));
            cmd.Parameters.Add(new MySqlParameter("@dateFinAnomalie", dateFinAnomalie));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public Anomalie GetById(int idAnomalie)
        {
            Anomalie anomalie = null;

            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM anomalie
                                WHERE id_anomalie = @idAnomalie";

            cmd.Parameters.Add(new MySqlParameter("@idAnomalie", idAnomalie));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                anomalie = DataReaderAnomalie(dr);
            }

            cmd.Connection.Close();
            return anomalie;
        }

        public List<Anomalie> GetAllByIdDemandeDeReservation(int idDemande)
        {
            List<Anomalie> anomalies = new();

            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM anomalie
                                WHERE id_demande = @idDemande";

            cmd.Parameters.Add(new MySqlParameter("@idDemande", idDemande));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Anomalie anomalie = DataReaderAnomalie(dr);
                anomalies.Add(anomalie);
            }

            cmd.Connection.Close();
            return anomalies;
        }

        private static Anomalie DataReaderAnomalie(MySqlDataReader dr)
        {
            Anomalie anomalie = new();
            anomalie.IdAnomalie = dr.GetInt32("id_anomalie");
            anomalie.IdDemande = dr.GetInt32("id_demande");
            anomalie.IdUtilisateurClient = dr.GetInt32("id_utilisateur_client");
            anomalie.IdUtilisateurEleveur = dr.GetInt32("id_utilisateur_eleveur");
            anomalie.IdTypeAnomalie = dr.GetInt32("id_type_anomalie");
            anomalie.DescriptionAnomalie = dr.GetString("description_anomalie");
            anomalie.DateDeclenchementAnomalie = dr.GetDateTime("date_declenchement_anomalie");
            if (!dr.IsDBNull(dr.GetOrdinal("date_fin_anomalie")))
            {
                anomalie.DateFinAnomalie = dr.GetDateTime("date_fin_anomalie");
            }

            return anomalie;
        }
    }
}
