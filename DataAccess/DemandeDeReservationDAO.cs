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
        public void CreateDemandeDeReservation(DemandeDeReservation demandeDeReservation)
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
                                FROM terrain
                                WHERE id_demande = @idDemandeDeReservation";
            cmd.Parameters.Add(new MySqlParameter("@idDemandeDeReservation", idDemandeDeReservation));
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
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
            }

            return demandeDeReservation;
        }

        public DemandeDeReservationDetails GetByIdWithDetails(int idDemandeDeReservation)
        {
            throw new NotImplementedException();
        }
    }
}
