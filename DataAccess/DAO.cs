using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.Ai109.Tontapatt.DataAccess
{
    abstract public class DAO
    {
        private const string CONNECTION_STRING = "Server = localhost; Database = tontapatt_bdd; Uid = root; Pwd = root;";

        protected MySqlCommand CreerCommand()
        {
            // creer une instance de connection :
            MySqlConnection cnx = new();
            // configurer la connection :
            cnx.ConnectionString = CONNECTION_STRING;
            // creer une instance de commande :
            MySqlCommand cmd = new();
            // IMPORTANT : lier la commande a sa connection avant l'ouverture
            cmd.Connection = cnx;
            return cmd;
        }
    }
}
