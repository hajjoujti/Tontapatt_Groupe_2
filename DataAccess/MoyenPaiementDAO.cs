using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public  class MoyenPaiementDAO : DAO
    {
        public List<MoyenPaiement> GetAll()
        {
            List<MoyenPaiement> moyensPaiementDAO = new();
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM moyenpaiement";
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MoyenPaiement moyenPaiement = new();
                moyenPaiement.IdMoyenPaiement = dr.GetInt32("id_moyen_paiement");
                moyenPaiement.TypeMoyenPaiement = dr.GetString("type_moyen_paiement");
                moyensPaiementDAO.Add(moyenPaiement);
            }

            cmd.Connection.Close();
            return moyensPaiementDAO;
        }
    }
}
