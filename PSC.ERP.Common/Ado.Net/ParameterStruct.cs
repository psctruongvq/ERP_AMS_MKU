using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PSC_ERP_Common.Ado.Net
{
    // The sctrucure is to hold parameter info. An Array of this structure
    // is sent to the DAL bcos we should not bind to a
    // specific type of parameter like SQLParamter
    [Serializable()]
    public struct ParameterStruct
    {
        public string ParamName;
        public DbType DataType;
        public object value;
        public ParameterDirection direction;
        public string sourceColumn;
        public short size;
    }
}
