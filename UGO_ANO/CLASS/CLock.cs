using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGO_ANO.CLASS
{
    public static class CLock
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
            { }
            finally
            {

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
            { }
            finally
            {
            }
        }
    }
}
