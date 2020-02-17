using System;
using System.Runtime.Serialization;

namespace UGO_ANO.CLASSES
{

    public class Status
    {
        /// <summary>
        /// Date de début de traitement
        /// </summary>
        public DateTime DateBegin { get; set; }
        /// <summary>
        /// State 0 encours, 1 terminé, 2 erreur détectée
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// Dernière année achevée
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Format : Nom_Table.Nom_Column
        /// </summary>
        public string CurrentTableColumn { get; set; }
        /// <summary>
        /// Nombre de lignes modifiées
        /// </summary>
        public int Lines { get; set; }

        public string LogName { get; set; }

        public string Error { get; set; }
    }
}
