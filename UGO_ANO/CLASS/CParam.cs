using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UGO_ANO.CLASS
{
    [DataContract]
    public class CParam
    {
        [DataMember]
        public string DATABASE { get; set; }
        [DataMember]
        public DateTime DATE_BEGIN { get; set; }
        [DataMember]
        public DateTime DATE_END { get; set; }
        [DataMember]
        public List<CField> UGO { get; set; }
    }

}
