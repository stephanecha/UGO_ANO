using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGO_ANO.CLASSES;

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

        //Vérifie les tables et colonnes si elles existent bien en BDD
        int CheckTableColumnType(List<Field> p_dataToAno);
    }
}
