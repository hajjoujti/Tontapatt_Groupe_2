using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class RaisonAnnulationPrematureeDAO : DAO
    {
        public List<RaisonAnnulationPrematuree> GetAll()
        {
            List<RaisonAnnulationPrematuree> raisonsAnnulationPrematuree = new();
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM raisonannulationprematuree";
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RaisonAnnulationPrematuree raisonAnnulationPrematuree = new();
                raisonAnnulationPrematuree.IdRaisonAnnulPrem = dr.GetInt32("id_raison_annul_prem");
                raisonAnnulationPrematuree.LibelleAnnulPrem = dr.GetString("libelle_annul_prem");
                raisonsAnnulationPrematuree.Add(raisonAnnulationPrematuree);
            }

            cmd.Connection.Close();
            return raisonsAnnulationPrematuree;
        }
    }
}
