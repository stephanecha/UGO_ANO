using System;
using System.IO;
using Serilog;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
    }
}
