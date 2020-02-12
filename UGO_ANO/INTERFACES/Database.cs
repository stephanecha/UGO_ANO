using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGO_ANO.INTERFACES
{
    public interface IDatabase
    {

        /// <summary>
        /// Return True if connection Database succes else false
        /// </summary>
        /// <param name="p_connectionString"></param>
        /// <returns></returns>
        bool InitDatabase(string p_connectionString);
        

        
    }
}
