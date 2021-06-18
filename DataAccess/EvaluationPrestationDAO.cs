using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class EvaluationPrestationDAO : DAO
    {
        public void InsererEvaluationPrestation(EvaluationPrestation evaluationPrestation)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"INSERT INTO evaluationprestation
                                (id_utilisateur_client, id_demande, id_utilisateur_eleveur, note_prestation, remarque_eval)
                                VALUES (idUtilisateurClient, @idDemande, idUtilisateurEleveur, notePrestation, remarqueEval)";

            cmd.Parameters.Add(new MySqlParameter("@idUtilisateurClient", evaluationPrestation.IdUtilisateurClient));
            cmd.Parameters.Add(new MySqlParameter("@idDemande", evaluationPrestation.IdDemande));
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateurEleveur", evaluationPrestation.IdUtilisateurEleveur));
            cmd.Parameters.Add(new MySqlParameter("@notePrestation", evaluationPrestation.NotePrestation));
            cmd.Parameters.Add(new MySqlParameter("@remarqueEval", evaluationPrestation.RemarqueEval));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }


        public EvaluationPrestation GetById(int idEvaluationPrestation)
        {
            EvaluationPrestation evaluationPrestation = null;

            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM evaluationprestation
                                WHERE id_eval_prestation = @idEvaluationPrestation";

            cmd.Parameters.Add(new MySqlParameter("@idEvaluationPrestation", idEvaluationPrestation));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                evaluationPrestation = DataReaderEvaluationPrestation(dr);
            }

            cmd.Connection.Close();

            return evaluationPrestation;

        }

        public List<EvaluationPrestation> GetAllByIdDemandeDeReservation(int idDemandeDeReservation)
        {
            List<EvaluationPrestation> evaluationsPrestation = new();

            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM evaluationprestation
                                WHERE id_demande = @idDemandeDeReservation";

            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                EvaluationPrestation evaluationPrestation = DataReaderEvaluationPrestation(dr);
                evaluationsPrestation.Add(evaluationPrestation);
            }

            cmd.Connection.Close();

            return evaluationsPrestation;
        }

        private static EvaluationPrestation DataReaderEvaluationPrestation(MySqlDataReader dr)
        {
            EvaluationPrestation evaluationPrestation = new();
            evaluationPrestation.IdEvalPrestation = dr.GetInt32("id_eval_prestation");
            evaluationPrestation.IdDemande = dr.GetInt32("id_demande");
            evaluationPrestation.IdUtilisateurClient = dr.GetInt32("id_utilisateur_client");
            evaluationPrestation.IdUtilisateurEleveur = dr.GetInt32("id_utilisateur_eleveur");
            evaluationPrestation.NotePrestation = dr.GetInt32("note_prestation");
            if (!dr.IsDBNull(dr.GetOrdinal("remarque_eval")))
            {
                evaluationPrestation.RemarqueEval = dr.GetString("remarque_eval");
            }

            return evaluationPrestation;
        }
    }
}
