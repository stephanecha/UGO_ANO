using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UGO_ANO.CLASSES
{
    [DataContract]
    public class Field
    {
        [DataMember]
        public string TABLE { get; set; }
        [DataMember]
        public string COLUMN { get; set; }
        [DataMember]
        public string TYPE { get; set; }
        [DataMember]
        public int OPTION { get; set; }

    }
}
