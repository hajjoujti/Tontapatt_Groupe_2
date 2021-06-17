using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public  class RaisonAnnulationDemandeDAO : DAO
    {
        public List<RaisonAnnulationDemande> GetAll()
        {
            List<RaisonAnnulationDemande> raisonsAnnulationDemande = new();
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM raisonannulationdemande";
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RaisonAnnulationDemande raisonAnnulationDemande = new();
                raisonAnnulationDemande.IdRaisonAnnul = dr.GetInt32("id_raison_annul");
                raisonAnnulationDemande.LibelleAnnulDemande = dr.GetString("libelle_annul_demande");
                raisonsAnnulationDemande.Add(raisonAnnulationDemande);
            }

            cmd.Connection.Close();
            return raisonsAnnulationDemande;
        }
    }
}
