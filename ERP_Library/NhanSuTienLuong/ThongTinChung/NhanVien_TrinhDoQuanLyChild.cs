
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_TrinhDoQuanLy : Csla.BusinessBase<NhanVien_TrinhDoQuanLy>
	{
		#region Business Properties and Methods
        
		//declare members
		private int _maTrinhDoQuanLy = 0;
		private long _maNhanVien = 0;
		private int _maQuanLyNhaNuoc = 0;
		private int _maQuanLyKinhTe = 0;
		private bool _trinhDoChinh = false;
        private string _tenTrinhDoQuanLyKinhTe = string.Empty;

      
        private string _tenTrinhDoQuanLyNhaNuoc = string.Empty;

      
		[System.ComponentModel.DataObjectField(true, true)]
        public string TenTrinhDoQuanLyNhaNuoc
        {
            get 
            {
                _tenTrinhDoQuanLyNhaNuoc = QuanLyNhaNuoc.GetQuanLyNhaNuoc(_maQuanLyNhaNuoc).TenQuanLyNhaNuoc;
                
                return _tenTrinhDoQuanLyNhaNuoc; }
            set { _tenTrinhDoQuanLyNhaNuoc = value; }
        }
        public string TenTrinhDoQuanLyKinhTe
        {
            get {
                _tenTrinhDoQuanLyKinhTe = QuanLyKinhTe.GetQuanLyKinhTe(_maQuanLyKinhTe).TenQuanLyKinhTe;
                return _tenTrinhDoQuanLyKinhTe; }
            set { _tenTrinhDoQuanLyKinhTe = value; }
        }
		public int MaTrinhDoQuanLy
		{
			get
			{
				return _maTrinhDoQuanLy;
			}
		}

		public long MaNhanVien
		{
			get
			{
				return _maNhanVien;
			}
			set
			{
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public int MaQuanLyNhaNuoc
		{
			get
			{
				return _maQuanLyNhaNuoc;
			}
			set
			{
				if (!_maQuanLyNhaNuoc.Equals(value))
				{
					_maQuanLyNhaNuoc = value;
					PropertyHasChanged("MaQuaLyNhaNuoc");
				}
			}
		}

		public int MaQuanLyKinhTe
		{
			get
			{
				return _maQuanLyKinhTe;
			}
			set
			{
				if (!_maQuanLyKinhTe.Equals(value))
				{
					_maQuanLyKinhTe = value;
					PropertyHasChanged("MaQuanLyKinhTe");
				}
			}
		}

		public bool TrinhDoChinh
		{
			get
			{
				return _trinhDoChinh;
			}
			set
			{
				if (!_trinhDoChinh.Equals(value))
				{
					_trinhDoChinh = value;
					PropertyHasChanged("TrinhDoChinh");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTrinhDoQuanLy;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{

		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		internal static NhanVien_TrinhDoQuanLy NewNhanVien_TrinhDoQuanLy()
		{
			return new NhanVien_TrinhDoQuanLy();
		}

		internal static NhanVien_TrinhDoQuanLy GetNhanVien_TrinhDoQuanLy(SafeDataReader dr)
		{
            NhanVien_TrinhDoQuanLy child = new NhanVien_TrinhDoQuanLy();
            child. _maTrinhDoQuanLy = dr.GetInt32("MaTrinhDoQuanLy");
            child._maNhanVien = dr.GetInt64("MaNhanVien");
            child. _maQuanLyNhaNuoc = dr.GetInt32("MaQuaLyNhaNuoc");
            child._maQuanLyKinhTe = dr.GetInt32("MaQuanLyKinhTe");
            child._trinhDoChinh = dr.GetBoolean("TrinhDoChinh");
            child.MarkOld();
            return child;
		}

		private NhanVien_TrinhDoQuanLy()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private NhanVien_TrinhDoQuanLy(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods


		#region Data Access

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
            while (dr.Read())
            {
                FetchObject(dr);
                MarkOld();
                //ValidationRules.CheckRules();

                //load child object(s)
                FetchChildren(dr);
            }
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maTrinhDoQuanLy = dr.GetInt32("MaTrinhDoQuanLy");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maQuanLyNhaNuoc = dr.GetInt32("MaQuaLyNhaNuoc");
			_maQuanLyKinhTe = dr.GetInt32("MaQuanLyKinhTe");
			_trinhDoChinh = dr.GetBoolean("TrinhDoChinh");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NhanVien parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNhanVien_TrinhDoQuanLy";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTrinhDoQuanLy = (int)cm.Parameters["@MaTrinhDoQuanLy"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (parent.MaNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maQuanLyNhaNuoc != 0)
				cm.Parameters.AddWithValue("@MaQuaLyNhaNuoc", _maQuanLyNhaNuoc);
			else
				cm.Parameters.AddWithValue("@MaQuaLyNhaNuoc", DBNull.Value);
			if (_maQuanLyKinhTe != 0)
				cm.Parameters.AddWithValue("@MaQuanLyKinhTe", _maQuanLyKinhTe);
			else
				cm.Parameters.AddWithValue("@MaQuanLyKinhTe", DBNull.Value);
			if (_trinhDoChinh != false)
				cm.Parameters.AddWithValue("@TrinhDoChinh", _trinhDoChinh);
			else
				cm.Parameters.AddWithValue("@TrinhDoChinh", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTrinhDoQuanLy", _maTrinhDoQuanLy);
			cm.Parameters["@MaTrinhDoQuanLy"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NhanVien parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsNhanVien_TrinhDoQuanLy";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
			cm.Parameters.AddWithValue("@MaTrinhDoQuanLy", _maTrinhDoQuanLy);
            if (parent.MaNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maQuanLyNhaNuoc != 0)
				cm.Parameters.AddWithValue("@MaQuaLyNhaNuoc", _maQuanLyNhaNuoc);
			else
				cm.Parameters.AddWithValue("@MaQuaLyNhaNuoc", DBNull.Value);
			if (_maQuanLyKinhTe != 0)
				cm.Parameters.AddWithValue("@MaQuanLyKinhTe", _maQuanLyKinhTe);
			else
				cm.Parameters.AddWithValue("@MaQuanLyKinhTe", DBNull.Value);
			if (_trinhDoChinh != false)
				cm.Parameters.AddWithValue("@TrinhDoChinh", _trinhDoChinh);
			else
				cm.Parameters.AddWithValue("@TrinhDoChinh", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr);
			MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsNhanVien_TrinhDoQuanLy";

				cm.Parameters.AddWithValue("@MaTrinhDoQuanLy", this._maTrinhDoQuanLy);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
