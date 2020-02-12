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
        /// <param name="p_Status"></param>
        public static void SerialParam(Param p_Status)
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
                string jsonString = JsonSerializer.Serialize(p_Status, p_Status.GetType(), options);
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

                Param l_getParam = JsonSerializer.Deserialize<Param>(l_read);

                return l_getParam;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erreur sur la deserialisation fichier param.json");
            }
            return null;
        }

    }
}
