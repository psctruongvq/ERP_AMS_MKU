using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;
//using System.Data.Common;
//using System.Windows.Forms;

namespace PSC_ERP_Common.Ado.Net
{
    public partial class SpeedDataAccess
    {
        public partial class ClsSchema
        {
            private readonly SpeedDataAccess _dataAccess;

            /// <summary>
            /// Initializes a new instance of the <see cref="ClsSchema"/> class.
            /// </summary>
            /// <param name="dataAccess">The data access.</param>
            public ClsSchema(SpeedDataAccess dataAccess)
            {
                _dataAccess = dataAccess;
            }
        }
    }
}
