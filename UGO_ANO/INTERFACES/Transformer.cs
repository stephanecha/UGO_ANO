using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGO_ANO.INTER
{
    interface ITransformer
    {
        bool supports();
        Object transform(String dataType, Object dataValue);
    }
}
