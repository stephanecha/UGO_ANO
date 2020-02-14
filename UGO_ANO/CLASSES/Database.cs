using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Serilog;

namespace UGO_ANO.CLASSES
{
    public class Database : INTERFACES.IDatabase
    {
        string _connectionString;

        public string ConnectionString { get => _connectionString; set => _connectionString = value; }

        /// <summary>
        /// Vérification des champs renseignés dans le fichier param.json
        /// Return  0 si ok
        ///         1 si liaison Table.Column n'existe pas
        ///         2 erreur de typage
        ///         -1 erreur 
        /// </summary>
        /// <param name="p_dataToAno"></param>
        /// <returns></returns>
        public int CheckTableColumnType(List<Field> p_dataToAno)
        {
            string queryString = "select UPPER(TABLE_NAME) as TN, UPPER(COLUMN_NAME) as CN, DATA_TYPE as DT from information_schema.COLUMNS";
            string l_missing = string.Empty;
            List<InformationSchema> l_listInformationSchema = new List<InformationSchema>();
            InformationSchema l_temp;

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
                            l_listInformationSchema.Add(new InformationSchema() { Table = reader[0].ToString(), Column = reader[1].ToString(), Type = reader[2].ToString() });
                        }
                    }

                    foreach (Field f_field in p_dataToAno)
                    {
                        l_temp = l_listInformationSchema.Find(delegate (InformationSchema p_is) { return p_is.Table == f_field.Table.ToUpper() && p_is.Column == f_field.Column.ToUpper(); });
                        if (l_temp == null)
                        {
                            Log.Warning(string.Format("Attention la liaison {0}.{1} n'existe pas. Merci de corriger avant de relancer l'application", f_field.Table, f_field.Column));
                            return 1;
                        }
                        switch (l_temp.Type)
                        {
                            case "varchar":
                            case "nchar":
                            case "nvarchar":
                            case "char":
                                if (!f_field.Type.Equals(Type.TBOLO) && !f_field.Type.Equals(Type.TINT))
                                {
                                    Log.Warning(string.Format("Attention le transformateur {0} n'est pas adapté pour la colonne {1}.{2}. Merci de corriger le fichier paramétrage json avant de relancer l'application", f_field.Type, f_field.Table, f_field.Column)); return 2;
                                }
                                break;
                            case "date":
                            case "datetime":
                                if (!f_field.Type.Equals(Type.TDATE))
                                {
                                    Log.Warning(string.Format("Attention le transformateur {0} n'est pas adapté pour la colonne {1}.{2}. Merci de corriger le fichier paramétrage json avant de relancer l'application", f_field.Type, f_field.Table, f_field.Column)); return 2;
                                }
                                if (f_field.Option != 0 && f_field.Option != 1)
                                {
                                    Log.Warning(string.Format("Attention l'option du transformateur {0} est mal renseignée. Merci de corriger le fichier paramétrage json avant de relancer l'application", f_field.Type, f_field.Table, f_field.Column)); return 2;
                                }
                                break;
                            default://TINT = bit,float,int,numeric,smallint
                                if (!f_field.Type.Equals(Type.TINT))
                                {
                                    Log.Warning(string.Format("Attention le transformateur {0} n'est pas adapté pour la colonne {1}.{2}. Merci de corriger le fichier paramétrage json avant de relancer l'application", f_field.Type, f_field.Table, f_field.Column)); return 2;
                                }
                                break;
                        }
                    }
                    return 0;
                }
                //TINT = bit,float,int,numeric,smallint,
                //TBOLO = varchar,char,nchar,nvarchar
                //TDATE = date,datetime
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erreur sur la vérification du fichier de paramétrage");
                return -1;
            }
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
                Log.Information("Connection Base de données  OK");
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
