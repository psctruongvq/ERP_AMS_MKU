using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace PSC_ERP_Common.Ado.Net
{
    public partial class SpeedDataAccess
    {
        /// <summary>
        /// Opens the connection.
        /// </summary>
        public void OpenConnection()
        {

            this.Connection = Factory.CreateConnection(this.ConnectionString, this.Provider);
            try
            {
                this.Connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Closes the connection.
        /// </summary>
        public void CloseConnection()
        {


            if (this.Connection != null)
            {
                this.Connection.Close();
            }

            this.Connection = null;
        }

    }
}
