namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [Serializable]
    public class KhoaSoQuyetToan : BusinessBase<KhoaSoQuyetToan>
    {
        private bool _khoaSo = false;
        private int _nam = 0;

        private KhoaSoQuyetToan()
        {
        }

        protected override void AddBusinessRules()
        {
            this.AddCommonRules();
            this.AddCustomRules();
        }

        private void AddCommonRules()
        {
        }

        private void AddCustomRules()
        {
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Nam", this._nam);
            cm.Parameters.AddWithValue("@KhoaSo", this._khoaSo);
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Nam", this._nam);
            cm.Parameters.AddWithValue("@KhoaSo", this._khoaSo);
        }

        [RunLocal]
        private void DataPortal_Create(Criteria criteria)
        {
            this._nam = criteria.Nam;
            base.ValidationRules.CheckRules();
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection connection = new SqlConnection(Database.ERP_Connection))
            {
                connection.Open();
                SqlTransaction tr = connection.BeginTransaction();
                try
                {
                    this.ExecuteDelete(tr, criteria);
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        protected override void DataPortal_DeleteSelf()
        {
            this.DataPortal_Delete(new Criteria(this._nam));
        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection connection = new SqlConnection(Database.ERP_Connection))
            {
                connection.Open();
                SqlTransaction tr = connection.BeginTransaction();
                try
                {
                    this.ExecuteFetch(tr, criteria);
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        protected override void DataPortal_Insert()
        {
            using (SqlConnection connection = new SqlConnection(Database.ERP_Connection))
            {
                connection.Open();
                SqlTransaction tr = connection.BeginTransaction();
                try
                {
                    this.ExecuteInsert(tr);
                    this.UpdateChildren(tr);
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        protected override void DataPortal_Update()
        {
            using (SqlConnection connection = new SqlConnection(Database.ERP_Connection))
            {
                connection.Open();
                SqlTransaction tr = connection.BeginTransaction();
                try
                {
                    if (base.IsDirty)
                    {
                        this.ExecuteUpdate(tr);
                    }
                    this.UpdateChildren(tr);
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        public static void DeleteKhoaSoQuyetToan(int nam)
        {
            DataPortal.Delete(new Criteria(nam));
        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Delete_KhoaSoQuyetToan";
                command.Parameters.AddWithValue("@Nam", criteria.Nam);
                command.ExecuteNonQuery();
            }
        }

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Select_KhoaSoQuyetToan";
                command.Parameters.AddWithValue("@Nam", criteria.Nam);
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    this._nam = criteria.Nam;
                    this.FetchObject(reader);
                    base.ValidationRules.CheckRules();
                    this.FetchChildren(reader);
                }
            }
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Insert_KhoaSoQuyetToan";
                this.AddInsertParameters(command);
                command.ExecuteNonQuery();
            }
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Update_KhoaSoQuyetToan";
                this.AddUpdateParameters(command);
                command.ExecuteNonQuery();
            }
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }

        private void FetchObject(SafeDataReader dr)
        {
            if (dr.Read())
            {
                this._nam = dr.GetInt32("Nam");
                this._khoaSo = dr.GetBoolean("KhoaSo");
            }
        }

        protected override object GetIdValue()
        {
            return this._nam;
        }

        public static KhoaSoQuyetToan GetKhoaSoQuyetToan(int nam)
        {
            return DataPortal.Fetch<KhoaSoQuyetToan>(new Criteria(nam));
        }

        public static KhoaSoQuyetToan NewKhoaSoQuyetToan(int nam)
        {
            return DataPortal.Create<KhoaSoQuyetToan>(new Criteria(nam));
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }

        public bool KhoaSo
        {
            get
            {
                return this._khoaSo;
            }
            set
            {
                if (!this._khoaSo.Equals(value))
                {
                    this._khoaSo = value;
                    this.PropertyHasChanged("KhoaSo");
                }
            }
        }

        [DataObjectField(true, false)]
        public int Nam
        {
            get
            {
                return this._nam;
            }
        }

        [Serializable]
        private class Criteria
        {
            public int Nam;

            public Criteria(int nam)
            {
                this.Nam = nam;
            }
        }
    }
}

