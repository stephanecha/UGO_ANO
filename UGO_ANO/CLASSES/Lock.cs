using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGO_ANO.CLASSES
{
    public static class Lock
    {
        public static bool createLock()
        {
            try
            {
                if (!File.Exists("LOCK"))
                {
                    File.Create("LOCK");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erreur sur la création du fichier LOCK");
            }
            return false;
        }

        public static void delLock()
        {
            try
            {
                File.Delete("LOCK");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erreur sur la suppression du fichier LOCK");
            }
         
        }
    }
}
