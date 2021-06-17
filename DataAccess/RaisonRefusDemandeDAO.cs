using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class RaisonRefusDemandeDAO : DAO
    {
        public List<RaisonRefusDemande> GetAll()
        {
            List<RaisonRefusDemande> raisonsRefusDemande = new();
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM raisonrefusdemande";
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RaisonRefusDemande raisonRefusDemande = new();
                raisonRefusDemande.IdMotifRefus = dr.GetInt32("id_motif_refus");
                raisonRefusDemande.LibelleRefus = dr.GetString("libelle_refus");
                raisonsRefusDemande.Add(raisonRefusDemande);
            }

            cmd.Connection.Close();
            return raisonsRefusDemande;
        }
    }
}
