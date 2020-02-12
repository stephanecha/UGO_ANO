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
        public string Table { get; set; }
        [DataMember]
        public string Column { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int Option { get; set; }

    }
}
