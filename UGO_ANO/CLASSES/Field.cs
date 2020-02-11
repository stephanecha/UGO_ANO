using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UGO_ANO.CLASS
{
    [DataContract]
    public class Field
    {
        [DataMember]
        public string TABLE { get; set; }
        [DataMember]
        public string FIELD { get; set; }
        [DataMember]
        public string TYPE { get; set; }
        [DataMember]
        public int OPTION { get; set; }

    }
}
