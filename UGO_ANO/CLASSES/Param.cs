using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UGO_ANO.CLASSES
{
    public class Param
    {
        public string Database { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public List<Field> DataToAno { get; set; }
    }
}
