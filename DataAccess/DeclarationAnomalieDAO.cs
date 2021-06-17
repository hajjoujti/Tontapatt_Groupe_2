using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class DeclarationAnomalieDAO : DAO
    {
        public void InsererDeclarationAnomalie(int idDemandeDeReservation, int idUtilisateurClient, int idUtilisateurEleveur, int idTypeAnomalie, DateTime dateDeclenchementAnomalie, DateTime dateFinAnomalie)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"INSERT INTO anomalie
                                (id_demande, id_utilisateur_client, id_utilisateur_eleveur, id_type_anomalie, date_declenchement_anomalie, date_fin_anomalie)
                                VALUES
                                (@idDemandeDeReservation, @idUtilisateurClient, @idUtilisateurEleveur, @idTypeAnomalie, @dateDeclechementAnomalie, @dateFinAnomalie)";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateurClient", idUtilisateurClient));
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateurEleveur", idUtilisateurEleveur));
            cmd.Parameters.Add(new MySqlParameter("@idTypeAnomalie", idTypeAnomalie));
            cmd.Parameters.Add(new MySqlParameter("@dateDeclechementAnomalie", dateDeclenchementAnomalie));
            cmd.Parameters.Add(new MySqlParameter("@dateFinAnomalie", dateFinAnomalie));


            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public List<Anomalie> GetAllByIdDemandeDeReservastion(int idDemandeDeReservation)
        {
            List<Anomalie> anomalies = new();
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM anomalie
                                Where id_demande = @idDemandeDeReservation";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Anomalie anomalie = new();
                anomalie.IdAnomalie = dr.GetInt32("id_anomalie");
                anomalie.IdDemande = dr.GetInt32("id_demande");
                anomalie.IdUtilisateurClient = dr.GetInt32("id_utilisateur_client");
                anomalie.IdUtilisateurEleveur = dr.GetInt32("id_utilisateur_eleveur");
                anomalie.IdTypeAnomalie = dr.GetInt32("id_type_anomalie");

                anomalie.DateDeclenchementAnomalie = dr.GetDateTime("date_declenchement_anomalie");
                anomalie.DateFinAnomalie = dr.GetDateTime("dateFinAnomalie");
                anomalies.Add(anomalie);
            }

            cmd.Connection.Close();

            return anomalies;
        }
    }
}
