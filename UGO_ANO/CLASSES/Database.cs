using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Serilog;
using System.Data;

namespace UGO_ANO.CLASSES
{
    public class Database : INTERFACES.IDatabase
    {
        string _connectionString;

        public string ConnectionString { get => _connectionString; set => _connectionString = value; }

        public bool CheckTableColumn(List<string> p_listTable, List<string> p_listColumn)
        {
            string queryString = "select UPPER(TABLE_NAME), UPPER(COLUMN_NAME) from information_schema.COLUMNS";

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Supprimer les table et colonne qui sont présentent dans la base de données
                        }
                        //Si il reste des éléments dans l'un des deux liste en paramètre alors elles n'existent pas
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur sur la vérification du fichier de paramétrage");
                return false;
            }
            return true;
        }

        public bool InitDatabase(string p_connectionString)
        {
            ConnectionString = p_connectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    connection.Close();
                }
                Log.Information("Connection Base de donnée  OK");
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
