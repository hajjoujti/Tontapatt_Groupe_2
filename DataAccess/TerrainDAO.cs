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
            Terrain terrain = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM terrain
                                WHERE id_terrain = @idTerrain";
            cmd.Parameters.Add(new MySqlParameter("@idTerrain", idTerrain));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                terrain = DataReaderTerrain(dr);
            }

            cmd.Connection.Close();
            return terrain;
        }

        public List<Terrain> GetByIdUtilisateur(int idUtilisateur)
        {
            List <Terrain> terrains = new();

            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM terrain
                                WHERE id_utilisateur = @idUtilisateur";
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateur", idUtilisateur));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Terrain terrain = DataReaderTerrain(dr);
                terrains.Add(terrain);
            }

            cmd.Connection.Close();

            return terrains;
        }

        public TerrainDetails GetByIdWithDetails(int idTerrain)
        {
            TerrainDetails terrainDetails = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT t.*, 
                                v.nom_ville, v.code_postal, v.longitude_ville, v.latitude_ville, 
                                u.nom_utilisateur, u.prenom_utilisateur, u.description_utilisateur, 
                                hu.humidite_terrain, 
                                co.composition_terrain,
                                p.pente_terrain,
                                ha.hauteur_herbe
                                FROM terrain t
                                INNER JOIN villecp v ON t.id_villecp = v.id_villecp
                                INNER JOIN utilisateur u ON t.id_utilisateur = u.id_utilisateur
                                INNER JOIN humiditeterrain hu ON t.id_humidite_terrain = hu.id_humidite_terrain
                                INNER JOIN compositionterrain co ON t.id_composition_terrain = co.id_composition_terrain
                                INNER JOIN penteterrain p ON t.id_pente_terrain = p.id_pente_terrain
                                INNER JOIN hauteurherbe ha ON t.id_hauteur_herbe = ha.id_hauteur_herbe
                                WHERE t.id_terrain = @idTerrain";
            cmd.Parameters.Add(new MySqlParameter("@idTerrain", idTerrain));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                terrainDetails = DataReaderTerrainDetails(dr);
            }
            cmd.Connection.Close();

            cmd.CommandText = @"SELECT
                                t.id_terrain, 
                                vege.id_type_vegetation,
                                vege.type_vegetation,
                                compo.pourcentage_vegetation
                                FROM terrain t
                                INNER JOIN compositionvegetation compo ON t.id_terrain = compo.id_terrain
                                INNER JOIN typevegetation vege ON compo.id_type_vegetation = vege.id_type_vegetation
                                WHERE t.id_terrain = @idTerrain";

            cmd.Connection.Open();
            MySqlDataReader dr2 = cmd.ExecuteReader();
            List<CompositionVegetationDetails> compositionsVegetationDetails = new();

            while (dr2.Read())
            {
                CompositionVegetationDetails compositionvegetationDetails = new();
                compositionvegetationDetails.IdTerrain = dr2.GetInt32("id_terrain");
                compositionvegetationDetails.IdTypeVegetation = dr2.GetInt32("id_type_vegetation");
                compositionvegetationDetails.TypeVegetaion = dr2.GetString("type_vegetation");
                compositionvegetationDetails.PourcentageVegetation = dr2.GetInt32("pourcentage_vegetation");
                compositionsVegetationDetails.Add(compositionvegetationDetails);
            }

            terrainDetails.CompositionsVegetationTerrain = compositionsVegetationDetails;

            cmd.Connection.Close();
            return terrainDetails;
        }

        private static TerrainDetails DataReaderTerrainDetails(MySqlDataReader dr)
        {
            TerrainDetails terrainDetails = new(DataReaderTerrain(dr));
            terrainDetails.NomUtilisateur = dr.GetString("nom_utilisateur");
            terrainDetails.PrenomUtilisateur = dr.GetString("prenom_utilisateur");
            if (!dr.IsDBNull(dr.GetOrdinal("description_utilisateur")))
            {
                terrainDetails.DescriptionUtilisateur = dr.GetString("description_utilisateur");
        }
            terrainDetails.NomVilleTerrain = dr.GetString("nom_ville");
            terrainDetails.CodePostalTerrain = dr.GetString("code_postal");
            terrainDetails.LongitudeTerrain = dr.GetDecimal("longitude_ville");
            terrainDetails.LatitudeTerrain = dr.GetDecimal("latitude_ville");
            terrainDetails.HumiditeTerrain = dr.GetString("humidite_terrain");
            terrainDetails.CompositionTerrain = dr.GetString("composition_terrain");
            terrainDetails.PenteTerrain = dr.GetString("pente_terrain");
            terrainDetails.HauteurHerbe = dr.GetString("hauteur_herbe");
            return terrainDetails;
        }

        public TerrainDetails GetByIdWithDetails(int idTerrain)
        {
            TerrainDetails terrainDetails = null;
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
                terrainDetails = DataReaderTerrainDetails(dr);
            }
            cmd.Connection.Close();
            return terrainDetails;
        }

        private static TerrainDetails DataReaderTerrainDetails(MySqlDataReader dr)
        {
            TerrainDetails terrainDetails = new(DataReaderTerrain(dr));
            terrainDetails.NomUtilisateur = dr.GetString("nom_utilisateur");
            terrainDetails.PrenomUtilisateur = dr.GetString("prenom_utilisateur");
            if (!dr.IsDBNull(dr.GetOrdinal("description_utilisateur")))
            {
                terrainDetails.DescriptionUtilisateur = dr.GetString("description_utilisateur");
            }
            terrainDetails.NomVilleTerrain = dr.GetString("nom_ville");
            terrainDetails.CodePostalTerrain = dr.GetString("code_postal");
            return terrainDetails;
        }

        private static Terrain DataReaderTerrain(MySqlDataReader dr)
        {
            Terrain terrain = new();
            terrain.IdTerrain = dr.GetInt32("id_terrain");
            if (!dr.IsDBNull(dr.GetOrdinal("id_raison_retrait")))
            {
                terrain.IdRaisonRetrait = dr.GetInt32("id_raison_retrait");
            }
            terrain.IdHumiditeTerrain = dr.GetInt32("id_humidite_terrain");
            terrain.IdCompositionTerrain = dr.GetInt32("id_composition_terrain");
            terrain.IdPenteTerrain = dr.GetInt32("id_pente_terrain");
            terrain.IdVilleCP = dr.GetInt32("id_villecp");
            terrain.IdHauteurHerbe = dr.GetInt32("id_hauteur_herbe");
            terrain.IdUtilisateur = dr.GetInt32("id_utilisateur");
            terrain.NomTerrain = dr.GetString("nom_terrain");
            terrain.SurfaceTerrain = dr.GetInt32("surface_terrain");
            if (!dr.IsDBNull(dr.GetOrdinal("description_terrain")))
            {
                terrain.DescriptionTerrain = dr.GetString("description_terrain");
            }
            terrain.AdresseTerrain = dr.GetString("adresse_terrain");
            terrain.DateEnregistrementTerrain = dr.GetDateTime("date_enregistrement_terrain");
            if (!dr.IsDBNull(dr.GetOrdinal("photo_terrain")))
            {
                terrain.PhotoTerrain = dr.GetString("photo_terrain");
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_retrait_terrain")))
            {
                terrain.DateRetraitTerrain = dr.GetDateTime("date_retrait_terrain");
            }

            return terrain;
        }
    }
}
