using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Common.Ado.Net
{
    public partial class SpeedDataAccess
    {
        public partial class ClsSchema
        {
            public enum SchemaColection
            {
                AllColumns = 0,
                Columns,
                ColumnSetColumns,
                Databases,
                DataSourceInformation,
                DataTypes,
                ForeignKeys,
                IndexColumns,
                Indexes,
                MetaDataCollections,
                ProcedureParameters,
                Procedures,
                ReservedWords,
                Restrictions,
                StructuredTypeMembers,
                Tables,
                UserDefinedTypes,
                Users,
                ViewColumns,
                Views,
            }
        }
    }
}