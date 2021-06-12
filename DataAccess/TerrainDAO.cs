using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class TerrainDAO : DAO
    {
        public Terrain GetById(int idTerrain)
        {
            Terrain t = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM terrain
                                WHERE id_terrain = @idTerrain";
            cmd.Parameters.Add(new MySqlParameter("@idTerrain", idTerrain));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                t = DataReaderTerrain(dr);
            }

            cmd.Connection.Close();
            return t;
        }

        public List<Terrain> GetByIdUtilisateur(int idUtilisateur)
        {
            List <Terrain> result = new();

            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM terrain
                                WHERE id_utilisateur = @idUtilisateur";
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateur", idUtilisateur));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Terrain t = DataReaderTerrain(dr);
                result.Add(t);
            }

            cmd.Connection.Close();

            return result;
        }

        public TerrainDetails GetByIdWithDetails(int idTerrain)
        {
            Terrain t = null;
            TerrainDetails td = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT t.*, v.nom_ville, v.code_postal, u.nom_utilisateur, u.prenom_utilisateur, u.description_utilisateur
                                FROM terrain t
                                INNER JOIN villecp v ON t.id_villecp = v.id_villecp
                                INNER JOIN utilisateur u ON t.id_utilisateur = u.id_utilisateur
                                WHERE t.id_terrain = @idTerrain";
            cmd.Parameters.Add(new MySqlParameter("@idTerrain", idTerrain));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                td = (TerrainDetails)DataReaderTerrain(dr);
                td.NomUtilisateur = dr.GetString("nom_utilisateur");
                td.PrenomUtilisateur = dr.GetString("prenom_utilisateur");
                if (!dr.IsDBNull(dr.GetOrdinal("description_utilisateur")))
                {
                    td.DescriptionUtilisateur = dr.GetString("description_utilisateur");
                }
                td.NomVilleTerrain = dr.GetString("nom_ville");
                td.CodePostalTerrain = dr.GetString("code_postal");
            }
            cmd.Connection.Close();
            return null;
        }

        private static Terrain DataReaderTerrain(MySqlDataReader dr)
        {
            Terrain t = new();
            t.IdTerrain = dr.GetInt32("id_terrain");
            if (!dr.IsDBNull(dr.GetOrdinal("id_raison_retrait")))
            {
                t.IdRaisonRetrait = dr.GetInt32("id_raison_retrait");
            }
            t.IdHumiditeTerrain = dr.GetInt32("id_humidite_terrain");
            t.IdCompositionTerrain = dr.GetInt32("id_composition_terrain");
            t.IdPenteTerrain = dr.GetInt32("id_pente_terrain");
            t.IdVilleCP = dr.GetInt32("id_villecp");
            t.IdHauteurHerbe = dr.GetInt32("id_hauteur_herbe");
            t.IdUtilisateur = dr.GetInt32("id_utilisateur");
            t.NomTerrain = dr.GetString("nom_terrain");
            t.SurfaceTerrain = dr.GetInt32("surface_terrain");
            if (!dr.IsDBNull(dr.GetOrdinal("description_terrain")))
            {
                t.DescriptionTerrain = dr.GetString("description_terrain");
            }
            t.AdresseTerrain = dr.GetString("adresse_terrain");
            t.DateEnregistrementTerrain = dr.GetDateTime("date_enregistrement_terrain");
            if (!dr.IsDBNull(dr.GetOrdinal("photo_terrain")))
            {
                t.PhotoTerrain = dr.GetString("photo_terrain");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_retrait_terrain")))
            {
                t.DateRetraitTerrain = dr.GetDateTime("date_retrait_terrain");
            }

            return t;
        }
    }
}
