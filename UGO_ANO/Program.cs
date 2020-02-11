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

            #region Test Unitaire sur la serialisation/deserialisation du fichier param.json 
            CParam l_newParam = new CParam();
            l_newParam.DATABASE = "CONNECTIONSTRING";
            l_newParam.DATE_BEGIN = DateTime.Now.Date;
            l_newParam.DATE_END = DateTime.Now.AddDays(10).Date;


            List<CField> list = new List<CField>();
            list.Add(new CField() { TABLE = "T_NATURAL_PERSON", FIELD = "LASTNAME_VC", TYPE = "TBOLO" });
            list.Add(new CField() { TABLE = "T_NATURAL_PERSON", FIELD = "FIRSTNAME_VC", TYPE = "TBOLO" });
            list.Add(new CField() { TABLE = "T_NATURAL_PERSON", FIELD = "BirthDate_DT", TYPE = "TDATE", OPTION = 1 });
            list.Add(new CField() { TABLE = "T_POSTAL_ADDRESS", FIELD = "CODE_POSTAL", TYPE = "TINT" });
            l_newParam.UGO = list;


            CCommonTools.SerialParam(l_newParam);

            CParam l_getParam = CCommonTools.DeserialParam("Param.json");
            #endregion


            string chaineCaractere ="dupont" ;
            string chaineNombre = "054654";
            DateTime date = new DateTime(2018, 6, 1);

            //chainecar=CTransformer.TBOLO(12);

            Console.WriteLine(chaineCaractere.TBolo());
            Console.WriteLine(chaineNombre.TInt());
            Console.WriteLine(date.ToString("MM/dd/yyyy"));
            Console.WriteLine($"date naissance: {date},date ano: {CTransformer.TDateNaissance(date)}");

            Console.ReadKey();
        }
    }
}
