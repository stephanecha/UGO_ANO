using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGO_ANO.CLASSES
{
    public static class SeriLog
    {
        public static void InitSeriLog()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings(null, "UGO_ANO.exe.config")
                .CreateLogger();
        }
    }
}
