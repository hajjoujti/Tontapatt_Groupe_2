using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class RaisonAnnulationOffreDAO : DAO
    {
        public List<RaisonAnnulationOffre> GetAll()
        {
            List<RaisonAnnulationOffre> raisonsAnnulationOffre = new();
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM raisonannulationoffre";
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RaisonAnnulationOffre raisonAnnulationOffre = DataReaderRaisonAnnulationOffre(dr);
                raisonsAnnulationOffre.Add(raisonAnnulationOffre);
            }

            cmd.Connection.Close();
            return raisonsAnnulationOffre;
        }


        public RaisonAnnulationOffre GetByLibelleAnnulationAutoApresAcceptation()
        {
            RaisonAnnulationOffre raisonAnnulationOffre = null;
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM raisonannulationoffre
                                WHERE libele_annulation = 'Demande de prestation sur cette offre a été acceptée'";

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                raisonAnnulationOffre = DataReaderRaisonAnnulationOffre(dr);
            }

            cmd.Connection.Close();
            return raisonAnnulationOffre;
        }

        private static RaisonAnnulationOffre DataReaderRaisonAnnulationOffre(MySqlDataReader dr)
        {
            RaisonAnnulationOffre raisonAnnulationOffre = new();
            raisonAnnulationOffre.IdAnnulationOffre = dr.GetInt32("id_annulation_offre");
            raisonAnnulationOffre.LibelleAnnulation = dr.GetString("libele_annulation");
            return raisonAnnulationOffre;
        }
    }
}
