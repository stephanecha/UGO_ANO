using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UGO_ANO.CLASSES
{
    [DataContract]
    public class Param
    {
        [DataMember]
        public string Database { get; set; }
        [DataMember]
        public DateTime DateBegin { get; set; }
        [DataMember]
        public DateTime DateEnd { get; set; }
        [DataMember]
        public List<Field> DataToAno { get; set; }
    }
}
