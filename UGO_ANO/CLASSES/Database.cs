using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Serilog;

namespace UGO_ANO.CLASSES
{
    class Database : INTERFACES.IDatabase
    {
        string _connectionString;

        public string ConnectionString { get => _connectionString; set => _connectionString = value; }

        public bool InitDatabase(string p_connectionString)
        {
            ConnectionString = p_connectionString;

            try
            {
                Log.Information("Connection Base de données..");
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    connection.Close();
                }
                Log.Information("Terminée avec succès");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur sur la connection à la base de données");
                return false;
            }
            return true;
        }

    }
}
