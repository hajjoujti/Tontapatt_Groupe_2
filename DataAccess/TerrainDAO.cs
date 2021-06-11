using Fr.EQL.Ai109.Totapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Totapatt.DataAccess
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
