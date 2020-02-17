using System;
using System.IO;
using Serilog;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Configuration;

namespace UGO_ANO.CLASSES
{
    /// <summary>
    /// Doit contenir les méthodes de chargement JSON (Chargement fichier paramétrage + Chargement et sauvegarde fichier Status)
    /// </summary>
    public static class CommonTools
    {


        /// <summary>
        /// Temporaire afin de générer divers fichiers de paramétrages
        /// </summary>
        /// <param name="p_Param"></param>
        public static void SerialParam(Param p_Param)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new StringEnumConverter());
                serializer.Formatting = Formatting.Indented;
                serializer.DateFormatString = "dd/MM/yyyy";
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(@"param.json"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, p_Param, typeof(Param));
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erreur sur la serialisation fichier param.json");
                throw ex;
            }
        }

        public static Param DeserialParam(string p_url)
        {
            string l_read;
            try
            {
                using (StreamReader u_sr = new StreamReader(p_url))
                {
                    l_read = u_sr.ReadToEnd();
                }

                Param l_getParam = JsonConvert.DeserializeObject<Param>(l_read, new JsonSerializerSettings
                {
                    DateFormatString = "dd/MM/yyyy"
                });
                return l_getParam;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erreur sur la deserialisation fichier param.json");
                throw ex;
            }
        }

        /// <summary>
        /// Création et mis a jour du fichier statt.json
        /// </summary>
        /// <param name="p_Status"></param>
        /// <param name="p_url"></param>
        public static void SerialStatus(Status p_Status, string p_url)
        {
            try
            {
                if (File.Exists(p_url))
                    File.Delete(p_url);


                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new StringEnumConverter());
                serializer.Formatting = Formatting.Indented;
                serializer.DateFormatString = "dd/MM/yyyy";
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(p_url))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, p_Status);
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erreur sur la serialisation fichier status.json");
                throw ex;
            }
        }

        /// <summary>
        /// Pour le cas d'une reprise
        /// </summary>
        /// <param name="p_url"></param>
        /// <returns></returns>
        public static Status DeserialStatus(string p_url)
        {
            string l_read;
            try
            {
                using (StreamReader u_sr = new StreamReader(p_url))
                {
                    l_read = u_sr.ReadToEnd();
                }

                Status l_getStatus = JsonConvert.DeserializeObject<Status>(l_read, new JsonSerializerSettings
                {
                    DateFormatString = "dd/MM/yyyy"
                });
                return l_getStatus;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erreur sur la deserialisation fichier status.json");
                throw ex;
            }
        }

        public static Status InitStatus()
        {
            Status l_status = new Status();

            l_status.DateBegin = DateTime.Now;
            l_status.LogName = ConfigurationManager.AppSettings["serilog:write-to:RollingFile.pathFormat"];
            l_status.LogName = l_status.LogName.Replace("{Date}", DateTime.Now.ToString("yyyyMMdd"));
            l_status.State = 0;

            return l_status;
        }

        public static void UpdateStatus(int p_state, DateTime p_currentDate, int p_nbLines, string p_currentTableColumn = null)
        {
            Program.CurrentStatus.State = p_state;
            Program.CurrentStatus.Lines = p_nbLines;
            Program.CurrentStatus.Date = p_currentDate;
            Program.CurrentStatus.CurrentTableColumn = p_currentTableColumn ?? p_currentTableColumn;
        }

        public static void SetErrorStatus(DateTime p_currentDate, string p_error, int p_nbLines = -1, string p_currentTableColumn = null)
        {
            Program.CurrentStatus.State = 2;
            Program.CurrentStatus.Lines = p_nbLines == -1 ? Program.CurrentStatus.Lines : p_nbLines;
            Program.CurrentStatus.Date = p_currentDate;
            Program.CurrentStatus.Error = p_error;
            Program.CurrentStatus.CurrentTableColumn = p_currentTableColumn ?? p_currentTableColumn;
        }

    }
}