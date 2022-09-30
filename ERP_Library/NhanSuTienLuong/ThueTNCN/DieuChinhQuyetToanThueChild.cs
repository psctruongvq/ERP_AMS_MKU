namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using Csla.Validation;
    using ERP_Library.Security;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [Serializable]
    public class DieuChinhQuyetToanThueChild : BusinessBase<DieuChinhQuyetToanThueChild>
    {
        private string _dienGiai;
        private int _id;
        private int _loai;
        private long _maNhanVien;
        private int _nam;
        private DateTime _ngayLap;
        private decimal _soTien;
        private int _userID;

        private DieuChinhQuyetToanThueChild()
        {
            this._id = 0;
            this._nam = 0;
            this._maNhanVien = 0L;
            this._userID = ERP_Library.Security.CurrentUser.Info.UserID;
            this._ngayLap = DateTime.Today;
            this._soTien = 0M;
            this._loai = 0;
            this._dienGiai = string.Empty;
            base.ValidationRules.CheckRules();
            base.MarkAsChild();
        }

        private DieuChinhQuyetToanThueChild(SafeDataReader dr)
        {
            this._id = 0;
            this._nam = 0;
            this._maNhanVien = 0L;
            this._userID = ERP_Library.Security.CurrentUser.Info.UserID;
            this._ngayLap = DateTime.Today;
            this._soTien = 0M;
            this._loai = 0;
            this._dienGiai = string.Empty;
            base.MarkAsChild();
            this.Fetch(dr);
        }

        protected override void AddBusinessRules()
        {
            this.AddCommonRules();
            this.AddCustomRules();
        }

        private void AddCommonRules()
        {
            base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringRequired), "DienGiai");
            base.ValidationRules.AddRule(new RuleHandler(CommonRules.StringMaxLength), new CommonRules.MaxLengthRuleArgs("DienGiai", 250));
        }

        private void AddCustomRules()
        {
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Nam", this._nam);
            cm.Parameters.AddWithValue("@MaNhanVien", this._maNhanVien);
            cm.Parameters.AddWithValue("@UserID", this._userID);
            cm.Parameters.AddWithValue("@NgayLap", this._ngayLap);
            cm.Parameters.AddWithValue("@SoTien", this._soTien);
            cm.Parameters.AddWithValue("@Loai", this._loai);
            cm.Parameters.AddWithValue("@DienGiai", this._dienGiai);
            cm.Parameters.AddWithValue("@ID", this._id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", this._id);
            cm.Parameters.AddWithValue("@Nam", this._nam);
            cm.Parameters.AddWithValue("@MaNhanVien", this._maNhanVien);
            cm.Parameters.AddWithValue("@UserID", this._userID);
            cm.Parameters.AddWithValue("@NgayLap", this._ngayLap);
            cm.Parameters.AddWithValue("@SoTien", this._soTien);
            cm.Parameters.AddWithValue("@Loai", this._loai);
            cm.Parameters.AddWithValue("@DienGiai", this._dienGiai);
        }

        internal void DeleteSelf(SqlTransaction tr)
        {
            if (this.IsDirty && !base.IsNew)
            {
                this.ExecuteDelete(tr);
                this.MarkNew();
            }
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Delete_DieuChinhQuyetToanThueChild";
                command.Parameters.AddWithValue("@ID", this._id);
                command.ExecuteNonQuery();
            }
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Insert_DieuChinhQuyetToanThueChild";
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
                command.CommandText = "spd_Update_DieuChinhQuyetToanThueChild";
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
            this._maNhanVien = dr.GetInt64("MaNhanVien");
            this._userID = dr.GetInt32("UserID");
            this._ngayLap = dr.GetDateTime("NgayLap");
            this._soTien = dr.GetDecimal("SoTien");
            this._loai = dr.GetInt32("Loai");
            this._dienGiai = dr.GetString("DienGiai");
        }

        internal static DieuChinhQuyetToanThueChild GetDieuChinhQuyetToanThueChild(SafeDataReader dr)
        {
            return new DieuChinhQuyetToanThueChild(dr);
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

        internal static DieuChinhQuyetToanThueChild NewDieuChinhQuyetToanThueChild()
        {
            return new DieuChinhQuyetToanThueChild();
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

        public string DienGiai
        {
            get
            {
                return this._dienGiai;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (!this._dienGiai.Equals(value))
                {
                    this._dienGiai = value;
                    this.PropertyHasChanged("DienGiai");
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

        public int Loai
        {
            get
            {
                return this._loai;
            }
            set
            {
                if (!this._loai.Equals(value))
                {
                    this._loai = value;
                    this.PropertyHasChanged("Loai");
                }
            }
        }

        public long MaNhanVien
        {
            get
            {
                return this._maNhanVien;
            }
            set
            {
                if (!this._maNhanVien.Equals(value))
                {
                    this._maNhanVien = value;
                    this.PropertyHasChanged("MaNhanVien");
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

        public decimal SoTien
        {
            get
            {
                return this._soTien;
            }
            set
            {
                if (!this._soTien.Equals(value))
                {
                    this._soTien = value;
                    this.PropertyHasChanged("SoTien");
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
    }
}

