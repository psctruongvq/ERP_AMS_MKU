
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiNhanVienChild : Csla.BusinessBase<LoaiNhanVienChild>
	{
		  #region Business Properties and Methods

        //declare members
        private int _maLoaiNhanVien = 0;
        private string _tenLoaiNhanVien = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaLoaiNhanVien
        {
            get
            {
                CanReadProperty("MaLoaiNhanVien", true);
                return _maLoaiNhanVien;
            }
        }

        public string TenLoaiNhanVien
        {
            get
            {
                CanReadProperty("TenLoaiNhanVien", true);
                return _tenLoaiNhanVien;
            }
            set {
                _tenLoaiNhanVien = value;
            }
        }

        protected override object GetIdValue()
        {
            return _maLoaiNhanVien;
        }

        #endregion //Business Properties and Methods



	

		#region Factory Methods
		private LoaiNhanVienChild()
		{ /* require use of factory method */ }

		public static LoaiNhanVienChild NewLoaiNhanVienChild(int maLoaiNhanVien)
		{
			return DataPortal.Create<LoaiNhanVienChild>(new Criteria(maLoaiNhanVien));
		}
        public static LoaiNhanVienChild NewLoaiNhanVienChild(string p)
        {
            LoaiNhanVienChild item = new LoaiNhanVienChild();
            item._tenLoaiNhanVien = p;
            return item;
        }
		public static LoaiNhanVienChild GetLoaiNhanVienChild(int maLoaiNhanVien)
		{
			return DataPortal.Fetch<LoaiNhanVienChild>(new Criteria(maLoaiNhanVien));
		}

		public static void DeleteLoaiNhanVienChild(int maLoaiNhanVien)
		{
			DataPortal.Delete(new Criteria(maLoaiNhanVien));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private LoaiNhanVienChild(int maLoaiNhanVien)
		{
			this._maLoaiNhanVien = maLoaiNhanVien;
		}

		internal static LoaiNhanVienChild NewLoaiNhanVienChildChild(int maLoaiNhanVien)
		{
			LoaiNhanVienChild child = new LoaiNhanVienChild(maLoaiNhanVien);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiNhanVienChild GetLoaiNhanVienChild(SafeDataReader dr)
		{
			LoaiNhanVienChild child =  new LoaiNhanVienChild();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaLoaiNhanVien;

			public Criteria(int maLoaiNhanVien)
			{
				this.MaLoaiNhanVien = maLoaiNhanVien;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maLoaiNhanVien = criteria.MaLoaiNhanVien;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteFetch(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "GetLoaiNhanVienChild";

				cm.Parameters.AddWithValue("@MaLoaiNhanVien", criteria.MaLoaiNhanVien);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(dr);
				}
			}//using
		}

		#endregion //Data Access - Fetch

	


		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maLoaiNhanVien = dr.GetInt32("MaLoaiNhanVien");
			_tenLoaiNhanVien = dr.GetString("TenLoaiNhanVien");
		
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

	
		#endregion //Data Access
	}
}
