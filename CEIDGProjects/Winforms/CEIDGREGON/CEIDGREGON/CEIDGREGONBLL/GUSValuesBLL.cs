using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEIDGREGON.CEIDGREGONDAL.GUSValuesBLLTableAdapters;

namespace CEIDGREGON.CEIDGREGONBLL
{
    internal class GUSValuesBLL
    {
        GUSValuesTableAdapter gus = new GUSValuesTableAdapter();
        internal int InsertXMLValuesToDB(string XMLValues, byte RaportType)
            =>
            gus.InsertValuesToDb(XMLValues, DateTime.Now, RaportType);
    }
}
