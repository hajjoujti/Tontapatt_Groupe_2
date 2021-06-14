using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class UtilisateurDAO : DAO
    {
        public Utilisateur GetById(int idUtilisateur)
        {
            Utilisateur utilisateur = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM utilisateur
                                WHERE id_utilisateur = @idUtilisateur";
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateur", idUtilisateur));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                utilisateur = DataReaderUtilisateur(dr);
            }

            cmd.Connection.Close();
            return utilisateur;
        }

        public Utilisateur GetUtilisateurAuthentification(string mailUtilisateur, string mdpUtilisateur)
        {
            Utilisateur utilisateur = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM utilisateur
                                WHERE mail_utilisateur = @mailUtilisateur
                                AND mdp_utilisateur = @mdpUtilisateur And date_desinscription_utilisateur IS NULL";
            cmd.Parameters.Add(new MySqlParameter("@mailUtilisateur", mailUtilisateur));
            cmd.Parameters.Add(new MySqlParameter("@mdpUtilisateur", mdpUtilisateur));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                utilisateur = DataReaderUtilisateur(dr);
            }

            cmd.Connection.Close();
            return utilisateur;
        }

        private static Utilisateur DataReaderUtilisateur(MySqlDataReader dr)
        {
            Utilisateur utilisateur = new();
            utilisateur.IdUtilisateur = dr.GetInt32("id_utilisateur");
            utilisateur.IdVilleCP = dr.GetInt32("id_villecp");
            if (!dr.IsDBNull(dr.GetOrdinal("id_desinscription")))
            {
                utilisateur.IdDesinscritpion = dr.GetInt32("id_desinscription");
            }
            utilisateur.NomUtilisateur = dr.GetString("nom_utilisateur");
            utilisateur.PrenomUtilisateur = dr.GetString("prenom_utilisateur");
            utilisateur.MailUtilisateur = dr.GetString("mail_utilisateur");
            utilisateur.MdpUtilisateur = dr.GetString("mdp_utilisateur");
            utilisateur.AdresseUtilisateur = dr.GetString("adresse_utilisateur");
            utilisateur.DateInscriptionUtilisateur = dr.GetDateTime("date_inscription_utilisateur");
            if (!dr.IsDBNull(dr.GetOrdinal("description_utilisateur")))
            {
                utilisateur.DescriptionUtilisateur = dr.GetString("description_utilisateur");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("siret_entreprise")))
            {
                utilisateur.SiretEntreprise = dr.GetInt64("siret_entreprise");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_desinscription_utilisateur")))
            {
                utilisateur.DateDesinscriptionUtilisateur = dr.GetDateTime("date_desinscription_utilisateur");
            }
            return utilisateur;
        }
    }
}
