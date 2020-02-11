using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGO_ANO.CLASS;

namespace UGO_ANO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Création fichier Lock

            //0 - Chargement des Logs (SeriLog)

            //1 - Chargement fichier de paramétrage, connexion BDD ok ? Entitie Framework ?

            //2 - Init etat d'avancement

            //3 - Traitement anonymisation
            //3.1 Mise a jour fichier Status.json

            //4 - Fin, Mise a jour Etat d'avancement         
            

            string chaineCaractere ="dupont" ;
            string chaineNombre = "054654";
            DateTime date = new DateTime(2018, 6, 1);

            //chainecar=CTransformer.TBOLO(12);

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"ligne:{i}");
                Console.WriteLine(DateTime.Now);
                Console.WriteLine($"TBolo:{chaineCaractere.TBolo()}");
                Console.WriteLine($"TInt:{chaineNombre.TInt()}");
                Console.WriteLine($"date naissance: {date},date ano: {Transformer.TDateNaissance(date)}");
            }

            Console.ReadKey();
        }
    }
}
