using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGO_ANO.CLASSES;


namespace UGO_ANO
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Création fichier Lock

                //0 - Chargement des Logs (SeriLog)
                SeriLog.InitSeriLog();
                Log.Information("Démarrage de l'anonymisation..");

                //0.1 - Chargement des données depuis le fichier .config
                string l_urlParam = ConfigurationManager.AppSettings["URL_PARAM"];
                string l_urlStatus = ConfigurationManager.AppSettings["URL_STATUS"];

                //1 - Chargement fichier de paramétrage, connexion BDD ok ? Entitie Framework ?
                Param l_param = CommonTools.DeserialParam(l_urlParam);
                Database l_database = new Database();
                if (!l_database.InitDatabase(l_param.Database))
                    throw new Exception("Impossible de se connecter à la base de données");

                //2 - Init etat d'avancement
                Status l_status = InitStatus();


                //3 - Traitement anonymisation
                //3.1 Mise a jour fichier Status.json

                //4 - Fin, Mise a jour Etat d'avancement         


                #region TEST STEPH
                //string chaineCaractere = "dupont";
                //string chaineNombre = "054654";
                //DateTime date = new DateTime(2018, 6, 1);
                //for (int i = 0; i < 1000; i++)
                //{
                //    Console.WriteLine("\n");
                //    Console.WriteLine($"ligne:{i}");
                //    Console.WriteLine(DateTime.Now);
                //    Console.WriteLine($"TBolo:{chaineCaractere.TBolo()}");
                //    Console.WriteLine($"TInt:{chaineNombre.TInt()}");
                //    Console.WriteLine($"date naissance: {date},date ano: {Transformer.TDateNaissance(date)}");
                //    Console.WriteLine($"date naissance: {date},date ano: {date.TDateNaissance()}");
                //}
                #endregion
                               
                Log.Information("Fin de l'anonymisation avec succès");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Fatal : Une erreur a été détectée");
            }
            Console.ReadKey();
        }

        static Status InitStatus()
        {
            Status l_status = new Status();

            l_status.DateBegin = DateTime.Now;
            //l_status.LogName =
            l_status.State = 0;

            return l_status;
        }
    }
}
