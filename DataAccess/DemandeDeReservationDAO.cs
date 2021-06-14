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
                                numero_reservation, nombre_animal)
                                VALUES (@id_terrain, @id_moyen_paiement, @id_offre,
                                @date_debut_demande, @date_fin_demande, @cout_demande, @date_creation_demande,
                                @numero_reservation, @nombre_animal)";
            cmd.Parameters.Add(new MySqlParameter("@id_terrain", demandeDeReservation.IdTerrain));
            cmd.Parameters.Add(new MySqlParameter("@id_moyen_paiement", demandeDeReservation.IdMoyenPaiement));
            cmd.Parameters.Add(new MySqlParameter("@id_offre", demandeDeReservation.IdOffre));
            cmd.Parameters.Add(new MySqlParameter("@date_debut_demande", demandeDeReservation.DateDebutDemande));
            cmd.Parameters.Add(new MySqlParameter("@date_fin_demande", demandeDeReservation.DateFinDemande));
            cmd.Parameters.Add(new MySqlParameter("@cout_demande", demandeDeReservation.CoutDemande));
            cmd.Parameters.Add(new MySqlParameter("@date_creation_demande", demandeDeReservation.DateCreationDemande));
            cmd.Parameters.Add(new MySqlParameter("@numero_reservation", demandeDeReservation.NumeroReservation));
            cmd.Parameters.Add(new MySqlParameter("@nombre_animal", demandeDeReservation.NombreAnimal));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DemandeDeReservationDetails GetByIdWithDetails(int idDemandeDeReservation)
        {
            throw new NotImplementedException();
        }
    }
}
