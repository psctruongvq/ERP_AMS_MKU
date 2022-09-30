namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using Csla.Validation;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [Serializable]
    public class BangKeThueTNCNNgoaiDai : BusinessBase<BangKeThueTNCNNgoaiDai>
    {
        private string _cmnd = string.Empty;
        private string _hoTen = string.Empty;
        internal int _id = 0;
        private string _mst = string.Empty;
        private int _nam = 0;
        private DateTime _ngayLap = DateTime.Today;
        private decimal _thueDaKhauTru = 0M;
        private decimal _thuNhapChiuThue = 0M;
        private int _userID = ERP_Library.Security.CurrentUser.Info.UserID;

        private BangKeThueTNCNNgoaiDai()
        {
        }

        protected override void AddBusinessRules()
        {
            this.AddCommonRules();
            this.AddCustomRules();
        }

        private void AddCommonRules()
        {
            base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringRequired), "HoTen");
            base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringMaxLength), new CommonRules.MaxLengthRuleArgs("HoTen", 50));
            base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringRequired), "Mst");
            base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringMaxLength), new CommonRules.MaxLengthRuleArgs("Mst", 50));
            base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringRequired), "Cmnd");
            base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringMaxLength), new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
        }

        private void AddCustomRules()
        {
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Nam", this._nam);
            cm.Parameters.AddWithValue("@HoTen", this._hoTen);
            cm.Parameters.AddWithValue("@MST", this._mst);
            cm.Parameters.AddWithValue("@CMND", this._cmnd);
            cm.Parameters.AddWithValue("@ThuNhapChiuThue", this._thuNhapChiuThue);
            cm.Parameters.AddWithValue("@ThueDaKhauTru", this._thueDaKhauTru);
            cm.Parameters.AddWithValue("@UserID", this._userID);
            cm.Parameters.AddWithValue("@NgayLap", this._ngayLap);
            cm.Parameters.AddWithValue("@ID", this._id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", this._id);
            cm.Parameters.AddWithValue("@Nam", this._nam);
            cm.Parameters.AddWithValue("@HoTen", this._hoTen);
            cm.Parameters.AddWithValue("@MST", this._mst);
            cm.Parameters.AddWithValue("@CMND", this._cmnd);
            cm.Parameters.AddWithValue("@ThuNhapChiuThue", this._thuNhapChiuThue);
            cm.Parameters.AddWithValue("@ThueDaKhauTru", this._thueDaKhauTru);
            cm.Parameters.AddWithValue("@UserID", this._userID);
            cm.Parameters.AddWithValue("@NgayLap", this._ngayLap);
        }

        [RunLocal]
        protected override void DataPortal_Create()
        {
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
            this.DataPortal_Delete(new Criteria(this._id));
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

        public static void DeleteBangKeThueTNCNNgoaiDai(int id)
        {
            DataPortal.Delete(new Criteria(id));
        }

        internal void DeleteSelf(SqlTransaction tr)
        {
            if (this.IsDirty && !base.IsNew)
            {
                this.ExecuteDelete(tr, new Criteria(this._id));
                this.MarkNew();
            }
        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Delete_BangKeThueTNCNNgoaiDai";
                command.Parameters.AddWithValue("@ID", criteria.Id);
                command.ExecuteNonQuery();
            }
        }

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Select_BangKeThueTNCNNgoaiDai";
                command.Parameters.AddWithValue("@ID", criteria.Id);
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    reader.Read();
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
                command.CommandText = "spd_Insert_BangKeThueTNCNNgoaiDai";
                this.AddInsertParameters(command);
                command.ExecuteNonQuery();
                this._id = (int) command.Parameters["@ID"].Value;
            }
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Update_BangKeThueTNCNNgoaiDai";
                this.AddUpdateParameters(command);
                command.ExecuteNonQuery();
            }
        }

        private void Fetch(SafeDataReader dr)
        {
            this.FetchObject(dr);
            this.MarkOld();
            base.ValidationRules.CheckRules();
            this.FetchChildren(dr);
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }

        private void FetchObject(SafeDataReader dr)
        {
            this._id = dr.GetInt32("ID");
            this._nam = dr.GetInt32("Nam");
            this._hoTen = dr.GetString("HoTen");
            this._mst = dr.GetString("MST");
            this._cmnd = dr.GetString("CMND");
            this._thuNhapChiuThue = dr.GetDecimal("ThuNhapChiuThue");
            this._thueDaKhauTru = dr.GetDecimal("ThueDaKhauTru");
            this._userID = dr.GetInt32("UserID");
            this._ngayLap = dr.GetDateTime("NgayLap");
        }

        internal static BangKeThueTNCNNgoaiDai GetBangKeThueTNCNNgoaiDai(SafeDataReader dr)
        {
            BangKeThueTNCNNgoaiDai dai = new BangKeThueTNCNNgoaiDai();
            dai.MarkAsChild();
            dai.Fetch(dr);
            return dai;
        }

        public static BangKeThueTNCNNgoaiDai GetBangKeThueTNCNNgoaiDai(int id)
        {
            return DataPortal.Fetch<BangKeThueTNCNNgoaiDai>(new Criteria(id));
        }

        protected override object GetIdValue()
        {
            return this._id;
        }

        internal void Insert(SqlTransaction tr)
        {
            if (this.IsDirty)
            {
                this.ExecuteInsert(tr);
                this.MarkOld();
                this.UpdateChildren(tr);
            }
        }

        public static BangKeThueTNCNNgoaiDai NewBangKeThueTNCNNgoaiDai()
        {
            return DataPortal.Create<BangKeThueTNCNNgoaiDai>();
        }

        internal static BangKeThueTNCNNgoaiDai NewBangKeThueTNCNNgoaiDaiChild()
        {
            BangKeThueTNCNNgoaiDai dai = new BangKeThueTNCNNgoaiDai();
            dai.ValidationRules.CheckRules();
            dai.MarkAsChild();
            return dai;
        }

        internal void Update(SqlTransaction tr)
        {
            if (this.IsDirty)
            {
                if (base.IsDirty)
                {
                    this.ExecuteUpdate(tr);
                    this.MarkOld();
                }
                this.UpdateChildren(tr);
            }
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }

        public string Cmnd
        {
            get
            {
                return this._cmnd;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (!this._cmnd.Equals(value))
                {
                    this._cmnd = value;
                    this.PropertyHasChanged("Cmnd");
                }
            }
        }

        public string HoTen
        {
            get
            {
                return this._hoTen;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (!this._hoTen.Equals(value))
                {
                    this._hoTen = value;
                    this.PropertyHasChanged("HoTen");
                }
            }
        }

        [DataObjectField(true, true)]
        public int Id
        {
            get
            {
                return this._id;
            }
        }

        public string Mst
        {
            get
            {
                return this._mst;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (!this._mst.Equals(value))
                {
                    this._mst = value;
                    this.PropertyHasChanged("Mst");
                }
            }
        }

        public int Nam
        {
            get
            {
                return this._nam;
            }
            set
            {
                if (!this._nam.Equals(value))
                {
                    this._nam = value;
                    this.PropertyHasChanged("Nam");
                }
            }
        }

        public DateTime NgayLap
        {
            get
            {
                return this._ngayLap;
            }
            set
            {
                if (!this._ngayLap.Equals(value))
                {
                    this._ngayLap = value;
                    this.PropertyHasChanged("NgayLap");
                }
            }
        }

        public decimal ThueDaKhauTru
        {
            get
            {
                return this._thueDaKhauTru;
            }
            set
            {
                if (!this._thueDaKhauTru.Equals(value))
                {
                    this._thueDaKhauTru = value;
                    this.PropertyHasChanged("ThueDaKhauTru");
                }
            }
        }

        public decimal ThuNhapChiuThue
        {
            get
            {
                return this._thuNhapChiuThue;
            }
            set
            {
                if (!this._thuNhapChiuThue.Equals(value))
                {
                    this._thuNhapChiuThue = value;
                    this.PropertyHasChanged("ThuNhapChiuThue");
                }
            }
        }

        public int UserID
        {
            get
            {
                return this._userID;
            }
            set
            {
                if (!this._userID.Equals(value))
                {
                    this._userID = value;
                    this.PropertyHasChanged("UserID");
                }
            }
        }

        [Serializable]
        private class Criteria
        {
            public int Id;

            public Criteria(int id)
            {
                this.Id = id;
            }
        }
    }
}

