using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace UGO_ANO.CLASS
{
    public static class CCommonTools
    {
        //Doit contenir les méthodes de chargement JSON (Chargement fichier paramétrage + Chargement et sauvegarde fichier Status)

        public static void SerialParam(CParam p_Status)
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
            { }
        }

        public static CParam DeserialParam(string p_url)
        {
            string l_read;
            try
            {
                using (StreamReader u_sr = new StreamReader(p_url))
                {
                    l_read = u_sr.ReadToEnd();
                }

                CParam l_getParam = JsonSerializer.Deserialize<CParam>(l_read);

                return l_getParam;
            }
            catch (Exception ex)
            { }
            return null;
        }

    }
}
