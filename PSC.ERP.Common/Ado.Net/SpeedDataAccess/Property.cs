using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
//using NPCDataAcess;
namespace PSC_ERP_Common.Ado.Net
{
    public partial class SpeedDataAccess
    {
        private static DataProvider defaultDataProvider_ = DataProvider.SQLServer;

        public String ConnectionString = String.Empty;
        public DbConnection Connection;
        protected DbCommand Command;
        public DataProvider Provider;
        protected DbTransaction _trans = null;
        protected DbDataAdapter _dataAdapter;
        private int _cmdTimeout;
        private const int COMMAND_TIMEOUT = 900;//600;//180;
        public ClsSchema Schema = null;
        /// <summary>
        /// Gets or sets the command timeout.
        /// </summary>
        /// <value>
        /// The command timeout.
        /// </value>
        public int CommandTimeout
        {
            get
            {
                if (_cmdTimeout == 0)
                {
                    return COMMAND_TIMEOUT;
                }
                return _cmdTimeout;
            }
            set
            {
                _cmdTimeout = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpeedDataAccess"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public SpeedDataAccess(String connectionString)
        {
            this.ConnectionString = connectionString;
            this.Provider =defaultDataProvider_;
            this.Connection = Factory.CreateConnection(connectionString, defaultDataProvider_);

            this.Schema = new ClsSchema(this);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SpeedDataAccess"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="connectionString">The connection string.</param>
        public SpeedDataAccess(DataProvider provider, String connectionString)
        {
            this.ConnectionString = connectionString;
            this.Provider = provider;
            this.Connection = Factory.CreateConnection(connectionString, provider);

            this.Schema = new ClsSchema(this);
        }
        //IDisposable
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            if (Command != null)
                Command.Dispose();
            if (Connection != null)
            {
                if (Connection.State == System.Data.ConnectionState.Open)
                {
                    this.Connection.Close();
                }
                Connection.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
