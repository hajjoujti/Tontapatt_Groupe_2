using Fr.EQL.Ai109.Totapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Totapatt.DataAccess
{
    public class UtilisateurDAO : DAO
    {
        public Utilisateur GetUtilisateurAuthentification(string mailUtilisateur, string mdpUtilisateur)
        {
            Utilisateur u = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM utilisateur
                                WHERE mail_utilisateur = @mailUtilisateur
                                AND mdp_utilisateur = @mdpUtilisateur";
            cmd.Parameters.Add(new MySqlParameter("@mailUtilisateur", mailUtilisateur));
            cmd.Parameters.Add(new MySqlParameter("@mdpUtilisateur", mdpUtilisateur));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                u = DataReaderUtilisateur(dr);
            }

            cmd.Connection.Close();
            return u;
        }

        private static Utilisateur DataReaderUtilisateur(MySqlDataReader dr)
        {
            Utilisateur u = new();
            u.IdUtilisateur = dr.GetInt32("id_utilisateur");
            u.IdVilleCP = dr.GetInt32("id_villecp");
            if (!dr.IsDBNull(dr.GetOrdinal("id_desinscription")))
            {
                u.IdDesinscritpion = dr.GetInt32("id_desinscription");
            }
            u.NomUtilisateur = dr.GetString("nom_utilisateur");
            u.PrenomUtilisateur = dr.GetString("prenom_utilisateur");
            u.MailUtilisateur = dr.GetString("mail_utilisateur");
            u.MdpUtilisateur = dr.GetString("mdp_utilisateur");
            u.AdresseUtilisateur = dr.GetString("adresse_utilisateur");
            u.DateInscriptionUtilisateur = dr.GetDateTime("date_inscription_utilisateur");
            if (!dr.IsDBNull(dr.GetOrdinal("description_utilisateur")))
            {
                u.DescriptionUtilisateur = dr.GetString("description_utilisateur");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("siret_entreprise")))
            {
                u.SiretEntreprise = dr.GetInt64("siret_entreprise");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_desinscription_utilisateur")))
            {
                u.DateDesinscriptionUtilisateur = dr.GetDateTime("date_desinscription_utilisateur");
            }
            return u;
        }
    }
}
