using System;
using System.Runtime.Serialization;

namespace UGO_ANO.CLASSES
{

    [DataContract]
    public class Status
    {
        [DataMember]
        public DateTime DateBegin { get; set; }
        /// <summary>
        /// State 0 encours, 1 terminé, 2 erreur détectée
        /// </summary>
        [DataMember]
        public int State { get; set; }
        /// <summary>
        /// Dernière année achevée
        /// </summary>
        [DataMember]
        public int Year { get; set; }

        /// <summary>
        /// Nombre de lignes modifiées
        /// </summary>
        [DataMember]
        public int Lines { get; set; }

        [DataMember]
        public string LogName { get; set; }

        [DataMember]
        public string Error { get; set; }
    }
}
