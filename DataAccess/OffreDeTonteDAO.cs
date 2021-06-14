using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class OffreDeTonteDAO : DAO
    {
        public OffreDeTonte GetById(int idOffreDeTonte)
        {
            OffreDeTonte offreDeTonte = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM offredetonte
                                WHERE id_offre = @idOffreDeTonte";
            cmd.Parameters.Add(new MySqlParameter("@idOffreDeTonte", idOffreDeTonte));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                offreDeTonte = DataReaderOffreDeTonte(dr);
            }

            cmd.Connection.Close();
            return offreDeTonte;
        }

        public OffreDeTonteDetails GetByIdWithDetails(int idOffreDeTonte)
        {
            OffreDeTonteDetails offreDeTonteDetails = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT o.*, 
                                r.race_animal, 
                                e.espece_animal,
                                v.nom_ville, v.code_postal, v.longitude_ville, v.latitude_ville,
                                u.nom_utilisateur, u.prenom_utilisateur, u.description_utilisateur
                                FROM offredetonte o
                                INNER JOIN raceanimal r ON o.id_race_animal = r.id_race_animal
                                INNER JOIN espece e ON o.id_race_animal = r.id_race_animal AND r.id_espece_animal = e.id_espece_animal
                                INNER JOIN villecp v ON o.id_villecp = v.id_villecp
                                INNER JOIN utilisateur u ON o.id_utilisateur = u.id_utilisateur
                                where o.id_offre = @idOffreDeTonte AND o.date_annulation_offre IS NULL";
            cmd.Parameters.Add(new MySqlParameter("@idOffreDeTonte", idOffreDeTonte));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                offreDeTonteDetails = DataReaderOffreDeTonteDetals(dr);
            }
            cmd.Connection.Close();
            return offreDeTonteDetails;
        }

        public List<OffreDeTonteDetails> GetAllDetailsByPositionTerrain(double latitudeTerrain, double longitudeTerrain)
        {
            List<OffreDeTonteDetails> offresDeTonteDetails = new();
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT o.*,
                                r.race_animal, 
                                e.espece_animal,
                                v.nom_ville, v.code_postal, v.longitude_ville, v.latitude_ville,
                                u.nom_utilisateur, u.prenom_utilisateur, u.description_utilisateur,
                                CalcDistance(@latitudeTerrain, @longitudeTerrain, v.latitude_ville, v.longitude_ville) 'Distance'
                                from offredetonte o
                                INNER JOIN raceanimal r ON o.id_race_animal = r.id_race_animal
                                INNER JOIN espece e ON o.id_race_animal = r.id_race_animal AND r.id_espece_animal = e.id_espece_animal
                                INNER JOIN villecp v ON o.id_villecp = v.id_villecp
                                INNER JOIN utilisateur u ON o.id_utilisateur = u.id_utilisateur
                                where o.distance_maximale >= CalcDistance(@latitudeTerrain, @longitudeTerrain, v.latitude_ville, v.longitude_ville) 
                                AND o.date_annulation_offre IS NULL;";

            cmd.Parameters.Add(new MySqlParameter("@latitudeTerrain", latitudeTerrain));
            cmd.Parameters.Add(new MySqlParameter("@longitudeTerrain", longitudeTerrain));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                OffreDeTonteDetails offreDeTonteDetails = DataReaderOffreDeTonteDetals(dr);
                offreDeTonteDetails.DistanceOffreDeTonteTerrain = Math.Round(dr.GetDouble("Distance"), 2);
                offresDeTonteDetails.Add(offreDeTonteDetails);
            }

            cmd.Connection.Close();
            return offresDeTonteDetails;
        }

        private OffreDeTonteDetails DataReaderOffreDeTonteDetals(MySqlDataReader dr)
        {
            OffreDeTonteDetails offreDeTonteDetails = new(DataReaderOffreDeTonte(dr));
            offreDeTonteDetails.RaceAnimal = dr.GetString("race_animal");
            offreDeTonteDetails.EspeceAnimal = dr.GetString("espece_animal");
            offreDeTonteDetails.NomVilleOfrreDeTonte = dr.GetString("nom_ville");
            offreDeTonteDetails.CodePostaleOffreDeTonte = dr.GetString("code_postal");
            offreDeTonteDetails.LongitudeOffreDetonte = dr.GetDouble("longitude_ville");
            offreDeTonteDetails.LatitudeOffreDeTonte = dr.GetDouble("latitude_ville");
            offreDeTonteDetails.NomUtilisateur = dr.GetString("nom_utilisateur");
            offreDeTonteDetails.PrenomUtilisateur = dr.GetString("prenom_utilisateur");
            if (!dr.IsDBNull(dr.GetOrdinal("description_utilisateur")))
            {
                offreDeTonteDetails.DescriptionUtilisateur = dr.GetString("description_utilisateur");
            }

            return offreDeTonteDetails;
        }


        private OffreDeTonte DataReaderOffreDeTonte(MySqlDataReader dr)
        {
            OffreDeTonte offreDeTonte = new();
            offreDeTonte.IdOffre = dr.GetInt32("id_offre");
            offreDeTonte.IdRaceAnimal = dr.GetInt32("id_race_animal");
            if (!dr.IsDBNull(dr.GetOrdinal("id_annulation_offre")))
            {
                offreDeTonte.IdRaceAnimal = dr.GetInt32("id_annulation_offre");
            }
            offreDeTonte.IdUtilisateur = dr.GetInt32("id_utilisateur");
            offreDeTonte.IdVilleCP = dr.GetInt32("id_villecp");
            offreDeTonte.NomOffre = dr.GetString("nom_offre");
            offreDeTonte.AdresseTroupeau = dr.GetString("adresse_troupeau");
            offreDeTonte.DateDebutOffre = dr.GetDateTime("date_debut_offre");
            offreDeTonte.DateFinOffre = dr.GetDateTime("date_fin_offre");
            offreDeTonte.DateCreationOffre = dr.GetDateTime("date_creation_offre");
            if (!dr.IsDBNull(dr.GetOrdinal("description_offre")))
            {
            offreDeTonte.DescriptionOffre = dr.GetString("description_offre");
            }
            offreDeTonte.DistanceMaximale = dr.GetInt32("distance_maximale");
            offreDeTonte.CoutAnimalParJour = dr.GetDouble("cout_anilmal_par_jour");
            if (!dr.IsDBNull(dr.GetOrdinal("date_annulation_offre")))
            {
                offreDeTonte.DateAnnulationOffre = dr.GetDateTime("date_annulation_offre");
            }
            offreDeTonte.NombreAnimaux = dr.GetInt32("nombre_animaux");
                return offreDeTonte;
        }
    }
}
