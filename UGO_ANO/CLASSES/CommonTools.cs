using System;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using Serilog;

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
                JsonSerializerOptions opt = new JsonSerializerOptions();
                opt.WriteIndented = true;
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Default,
                    WriteIndented = true
                };
                string jsonString = JsonSerializer.Serialize(p_Param, p_Param.GetType(), options);
                File.WriteAllText("param.json", jsonString);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erreur sur la serialisation fichier param.json");
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

                Param l_getParam = JsonSerializer.Deserialize<Param>(l_read, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return l_getParam;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erreur sur la deserialisation fichier param.json");
            }
            return null;
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

                JsonSerializerOptions opt = new JsonSerializerOptions();
                opt.WriteIndented = true;
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Default,
                    WriteIndented = true
                };
                string jsonString = JsonSerializer.Serialize(p_Status, p_Status.GetType(), options);
                File.WriteAllText(p_url, jsonString);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erreur sur la serialisation fichier status.json");
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

                Status l_getStatus = JsonSerializer.Deserialize<Status>(l_read, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return l_getStatus;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erreur sur la deserialisation fichier status.json");
            }
            return null;
        }

    }
}
