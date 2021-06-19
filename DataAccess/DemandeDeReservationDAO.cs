using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class DemandeDeReservationDAO : DAO
    {
        public void InsererUneDemandeDeReservation(DemandeDeReservation demandeDeReservation)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"INSERT INTO demandedereservation (id_terrain, id_moyen_paiement, id_offre,
                                date_debut_demande, date_fin_demande, cout_demande, date_creation_demande,
                                numero_reservation, nombre_animaux)
                                VALUES (@idTerrain, @idMoyenPaiement, @idOffre,
                                @dateDebutDemande, @dateFinDemande, @coutDemande, @dateCreationDemande,
                                @numeroReservation, @nombreAnimaux)";
            cmd.Parameters.Add(new MySqlParameter("@idTerrain", demandeDeReservation.IdTerrain));
            cmd.Parameters.Add(new MySqlParameter("@idMoyenPaiement", demandeDeReservation.IdMoyenPaiement));
            cmd.Parameters.Add(new MySqlParameter("@idOffre", demandeDeReservation.IdOffre));
            cmd.Parameters.Add(new MySqlParameter("@dateDebutDemande", demandeDeReservation.DateDebutDemande));
            cmd.Parameters.Add(new MySqlParameter("@dateFinDemande", demandeDeReservation.DateFinDemande));
            cmd.Parameters.Add(new MySqlParameter("@coutDemande", demandeDeReservation.CoutDemande));
            cmd.Parameters.Add(new MySqlParameter("@dateCreationDemande", demandeDeReservation.DateCreationDemande));
            cmd.Parameters.Add(new MySqlParameter("@numeroReservation", demandeDeReservation.NumeroReservation));
            cmd.Parameters.Add(new MySqlParameter("@nombreAnimaux", demandeDeReservation.NombreAnimaux));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DemandeDeReservation GetById(int idDemandeDeReservation)
        {
            DemandeDeReservation demandeDeReservation = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM demandedereservation
                                WHERE id_demande = @idDemandeDeReservation";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                demandeDeReservation = DataReaderDemandeDeReservation(dr);
            }

            cmd.Connection.Close();
            return demandeDeReservation;
        }

        public DemandeDeReservationDetails GetByIdWithDetails(int idDemandeDeReservation)
        {
            DemandeDeReservationDetails demandeDeReservationDetails = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM demandedereservation
                                WHERE id_demande = @idDemandeDeReservation";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                demandeDeReservationDetails = new(DataReaderDemandeDeReservation(dr));
            }

            cmd.Connection.Close();
            return demandeDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllEnAttentesWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            List<DemandeDeReservationDetails> demandesDeReservationDetails = new();

            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT d.*
                                FROM demandedereservation d
                                INNER JOIN offredetonte o ON d.id_offre = o.id_offre
                                INNER JOIN utilisateur u ON o.id_utilisateur = u.id_utilisateur
                                WHERE u.id_utilisateur = @idUtilisateur
                                AND d.date_acceptaion_demande IS NULL 
                                AND d.date_annulation_demande IS NULL 
                                AND d.date_refus_demande IS NULL 
                                AND d.date_annulation_prematuree is NULL
                                UNION SELECT d.*
                                FROM demandedereservation d
                                INNER JOIN terrain t ON d.id_terrain = t.id_terrain
                                INNER JOIN utilisateur u ON t.id_utilisateur = u.id_utilisateur
                                WHERE u.id_utilisateur = @idUtilisateur
                                AND d.date_acceptaion_demande IS NULL 
                                AND d.date_annulation_demande IS NULL 
                                AND d.date_refus_demande IS NULL 
                                AND d.date_annulation_prematuree is NULL";
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateur", idUtilisateur));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DemandeDeReservationDetails demandeDeReservationDetails = new(DataReaderDemandeDeReservation(dr));
                demandesDeReservationDetails.Add(demandeDeReservationDetails);
            }

            return demandesDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllEnCoursWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            List<DemandeDeReservationDetails> demandesDeReservationDetails = new();

            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT d.*
                                FROM demandedereservation d
                                INNER JOIN offredetonte o ON d.id_offre = o.id_offre
                                INNER JOIN utilisateur u ON o.id_utilisateur = u.id_utilisateur
                                WHERE u.id_utilisateur = 65
                                AND NOT EXISTS (SELECT e.id_demande 
                                                   FROM  evaluationprestation e
                                                   WHERE  e.id_demande = d.id_demande)
                                AND d.date_acceptaion_demande IS NOT NULL
                                AND d.date_annulation_demande IS NULL 
                                AND d.date_refus_demande IS NULL
                                AND d.date_annulation_prematuree is NULL
                                UNION SELECT d.*
                                FROM demandedereservation d
                                INNER JOIN terrain t ON d.id_terrain = t.id_terrain
                                INNER JOIN utilisateur u ON t.id_utilisateur = u.id_utilisateur
                                WHERE u.id_utilisateur = 65
                                AND NOT EXISTS (SELECT e.id_demande 
                                                   FROM  evaluationprestation e
                                                   WHERE  e.id_demande = d.id_demande)
                                AND d.date_acceptaion_demande IS NOT NULL
                                AND d.date_annulation_demande IS NULL 
                                AND d.date_refus_demande IS NULL 
                                AND d.date_annulation_prematuree is NULL";
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateur", idUtilisateur));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DemandeDeReservationDetails demandeDeReservationDetails = new(DataReaderDemandeDeReservation(dr));
                demandesDeReservationDetails.Add(demandeDeReservationDetails);
            }

            return demandesDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllTermineesWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            List<DemandeDeReservationDetails> demandesDeReservationDetails = new();

            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT d.*
                                FROM demandedereservation d
                                INNER JOIN offredetonte o ON d.id_offre = o.id_offre
                                INNER JOIN utilisateur u ON o.id_utilisateur = u.id_utilisateur
                                INNER JOIN evaluationprestation e ON d.id_demande = e.id_demande
                                WHERE u.id_utilisateur = @idUtilisateur 
                                AND d.date_acceptaion_demande IS NOT NULL 
                                AND d.date_annulation_demande IS NULL 
                                AND d.date_refus_demande IS NULL 
                                AND d.date_annulation_prematuree is NULL
                                UNION SELECT d.*
                                FROM demandedereservation d
                                INNER JOIN terrain t ON d.id_terrain = t.id_terrain
                                INNER JOIN utilisateur u ON t.id_utilisateur = u.id_utilisateur
                                INNER JOIN evaluationprestation e ON d.id_demande = e.id_demande
                                WHERE u.id_utilisateur = @idUtilisateur 
                                AND d.date_acceptaion_demande IS NOT NULL 
                                AND d.date_annulation_demande IS NULL 
                                AND d.date_refus_demande IS NULL 
                                AND d.date_annulation_prematuree is NULL";
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateur", idUtilisateur));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DemandeDeReservationDetails demandeDeReservationDetails = new(DataReaderDemandeDeReservation(dr));
                demandesDeReservationDetails.Add(demandeDeReservationDetails);
            }

            return demandesDeReservationDetails;
        }

        public List<DemandeDeReservationDetails> GetAllAnnuleesWithDetailsByIdUtilisateur(int idUtilisateur)
        {
            List<DemandeDeReservationDetails> demandesDeReservationDetails = new();

            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT d.*
                                FROM demandedereservation d
                                INNER JOIN offredetonte o ON d.id_offre = o.id_offre
                                INNER JOIN utilisateur u ON o.id_utilisateur = u.id_utilisateur
                                WHERE u.id_utilisateur = @idUtilisateur 
                                AND( d.date_annulation_demande IS NOT NULL 
                                OR d.date_refus_demande IS NOT NULL 
                                OR d.date_annulation_prematuree is NOT NULL)
                                UNION SELECT d.*
                                FROM demandedereservation d
                                INNER JOIN terrain t ON d.id_terrain = t.id_terrain
                                INNER JOIN utilisateur u ON t.id_utilisateur = u.id_utilisateur
                                WHERE u.id_utilisateur = @idUtilisateur 
                                AND( d.date_annulation_demande IS NOT NULL 
                                OR d.date_refus_demande IS NOT NULL 
                                OR d.date_annulation_prematuree is NOT NULL)";
            cmd.Parameters.Add(new MySqlParameter("@idUtilisateur", idUtilisateur));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DemandeDeReservationDetails demandeDeReservationDetails = new(DataReaderDemandeDeReservation(dr));
                demandesDeReservationDetails.Add(demandeDeReservationDetails);
            }

            return demandesDeReservationDetails;
        }

        public void AccepterDemandeDeReservationById(int idDemandeDeReservation, DateTime dateAcceptationDemande)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"UPDATE demandedereservation SET
                                date_acceptaion_demande = @dateAcceptationDemande
                                WHERE id_demande = @idDemandeDeReservation";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));
            cmd.Parameters.Add(new MySqlParameter("@dateAcceptationDemande", dateAcceptationDemande));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void RefuserDemandeDeReservationById(int idDemandeDeReservation, int idMotifRefus, DateTime dateRefusDemande)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"UPDATE demandedereservation SET
                                id_motif_refus = @idMotifRefus,
                                date_refus_demande = @dateRefusDemande
                                WHERE id_demande = @idDemandeDeReservation";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));
            cmd.Parameters.Add(new MySqlParameter("@dateRefusDemande", dateRefusDemande));
            cmd.Parameters.Add(new MySqlParameter("@idMotifRefus", idMotifRefus));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void AnnulationDemandeDeReservationByIdAvantAcceptation(int idDemandeDeReservation, int idRaisonAnnulClient, DateTime dateAnnulationDemande)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"UPDATE demandedereservation SET
                                id_raison_annul = @idRaisonAnnulClient,
                                date_annulation_demande = @dateAnnulationDemande
                                WHERE id_demande = @idDemandeDeReservation 
                                AND date_acceptaion_demande IS NULL";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));
            cmd.Parameters.Add(new MySqlParameter("@dateAnnulationDemande", dateAnnulationDemande));
            cmd.Parameters.Add(new MySqlParameter("@idRaisonAnnulClient", idRaisonAnnulClient));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void AnnulationPrematureeDemandeDeReservationById(int idDemandeDeReservation, int idRaisonAnnulationPrem, DateTime dateAnnulationPrematuree)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"UPDATE demandedereservation SET
                                id_raison_annul_prem = @idRaisonAnnulationPrem,
                                date_annulation_prematuree = @dateAnnulationPrematuree
                                WHERE id_demande = @idDemandeDeReservation 
                                AND date_acceptaion_demande IS NOT NULL";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));
            cmd.Parameters.Add(new MySqlParameter("@dateAnnulationPrematuree", dateAnnulationPrematuree));
            cmd.Parameters.Add(new MySqlParameter("@idRaisonAnnulationPrem", idRaisonAnnulationPrem));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void TroupeauInstalleByIdDemandeDeReservation(int idDemandeDeReservation, DateTime dateInstallationTroupeau)
        {
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"UPDATE demandedereservation SET
                                date_installation_troupeau = @dateInstallationTroupeau
                                WHERE id_demande = @idDemandeDeReservation 
                                AND date_acceptaion_demande IS NOT NULL 
                                AND d.date_annulation_demande IS NULL 
                                AND d.date_refus_demande IS NULL 
                                AND d.date_annulation_prematuree is NULL";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));
            cmd.Parameters.Add(new MySqlParameter("@dateInstallationTroupeau", dateInstallationTroupeau));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private static DemandeDeReservation DataReaderDemandeDeReservation(MySqlDataReader dr)
        {
            DemandeDeReservation demandeDeReservation = new();
            demandeDeReservation.IdDemande = dr.GetInt32("id_demande");

            if (!dr.IsDBNull(dr.GetOrdinal("id_raison_annul_prem")))
            {
                demandeDeReservation.IdRaisonAnnulationPrem = dr.GetInt32("id_raison_annul_prem");
            }
            demandeDeReservation.IdTerrain = dr.GetInt32("id_terrain");

            if (!dr.IsDBNull(dr.GetOrdinal("id_raison_annul")))
            {
                demandeDeReservation.IdRaisonAnnulClient = dr.GetInt32("id_raison_annul");
            }

            if (!dr.IsDBNull(dr.GetOrdinal("id_motif_refus")))
            {
                demandeDeReservation.IdMotifRefus = dr.GetInt32("id_motif_refus");
            }

            demandeDeReservation.IdMoyenPaiement = dr.GetInt32("id_moyen_paiement");

            demandeDeReservation.IdOffre = dr.GetInt32("id_offre");

            demandeDeReservation.DateDebutDemande = dr.GetDateTime("date_debut_demande");

            demandeDeReservation.DateFinDemande = dr.GetDateTime("date_fin_demande");

            demandeDeReservation.CoutDemande = dr.GetInt32("cout_demande");

            if (!dr.IsDBNull(dr.GetOrdinal("date_acceptaion_demande")))
            {
                demandeDeReservation.DateAcceptationDemande = dr.GetDateTime("date_acceptaion_demande");
            }

            if (!dr.IsDBNull(dr.GetOrdinal("date_annulation_demande")))
            {
                demandeDeReservation.DateAnnulationDemande = dr.GetDateTime("date_annulation_demande");
            }

            demandeDeReservation.DateCreationDemande = dr.GetDateTime("date_creation_demande");

            if (!dr.IsDBNull(dr.GetOrdinal("date_installation_troupeau")))
            {
                demandeDeReservation.DateInstallationTroupeau = dr.GetDateTime("date_installation_troupeau");
            }

            if (!dr.IsDBNull(dr.GetOrdinal("date_annulation_prematuree")))
            {
                demandeDeReservation.DateAnnulationPrematuree = dr.GetDateTime("date_annulation_prematuree");
            }

            demandeDeReservation.NumeroReservation = dr.GetString("numero_reservation");

            if (!dr.IsDBNull(dr.GetOrdinal("date_refus_demande")))
            {
                demandeDeReservation.DateRefusDemande = dr.GetDateTime("date_refus_demande");
            }

            demandeDeReservation.NombreAnimaux = dr.GetInt32("nombre_animaux");
            return demandeDeReservation;
        }
    }
}
