using Fr.EQL.Ai109.Tontapatt.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    public class TypeAnomalieDAO : DAO
    {
        public List<TypeAnomalie> GetAll()
        {
            List<TypeAnomalie> typesAnomalie = new();
            MySqlCommand cmd = CreerCommand();
            cmd.CommandText = @"SELECT *
                                FROM typeanomalie";
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TypeAnomalie typeAnomalie = new();
                typeAnomalie.IdTypeAnomalie = dr.GetInt32("id_type_anomalie");
                typeAnomalie.TypeAnomalieString = dr.GetString("id_type_anomalie");
                typesAnomalie.Add(typeAnomalie);
            }

            cmd.Connection.Close();
            return typesAnomalie;
        }
    }
}
