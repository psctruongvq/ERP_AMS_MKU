
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ReportTemplate : Csla.BusinessBase<ReportTemplate>
	{
		#region Business Properties and Methods

		//declare members
		private string _id = string.Empty;
		private byte[] _data;
        private int _userID = 0;
        private DateTime _denNgay = DateTime.Today;
        private string _tenPhuongThuc = string.Empty;
        private int _thuMuc = 0;
        private string _tenBaoCao = string.Empty;
        private int _soTTSapXep = 0;
        private bool _chon = false;
		[System.ComponentModel.DataObjectField(true, false)]
		public string Id
		{
			get
			{
				CanReadProperty("Id", true);
				return _id;
			}
            set
            {
                CanWriteProperty("Id", true);
                if (!_id.Equals(value))
                {
                    _id = value;
                    PropertyHasChanged("Id");
                }
            }
		}

		public byte[] Data
		{
			get
			{
				CanReadProperty("Data", true);
				return _data;
			}
            set
            {
                CanWriteProperty("Data", true);
                _data = value;
                PropertyHasChanged("Data");
            }
		}

        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay.Date;
            }
            set
            {
                CanWriteProperty("DenNgay", true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay =value;
                    PropertyHasChanged("DenNgay");
                }
            }
        }

        public int UserID
        {
            get
            {
                CanReadProperty("UserID", true);
                return _userID;
            }
            set
            {
                CanWriteProperty("UserID", true);
                if (!_userID.Equals(value))
                {
                    _userID = value;
                    PropertyHasChanged("UserID");
                }
            }
        }

        public string TenPhuongThuc
        {
            get
            {
                CanReadProperty("TenPhuongThuc", true);
                return _tenPhuongThuc;
            }
            set
            {
                CanWriteProperty("TenPhuongThuc", true);
                if (!_tenPhuongThuc.Equals(value))
                {
                    _tenPhuongThuc = value;
                    PropertyHasChanged("TenPhuongThuc");
                }
            }
        }

        public int ThuMuc
        {
            get
            {
                CanReadProperty("ThuMuc", true);
                return _thuMuc;
            }
            set
            {
                CanWriteProperty("ThuMuc", true);
                if (!_thuMuc.Equals(value))
                {
                    _thuMuc = value;
                    PropertyHasChanged("ThuMuc");
                }
            }
        }

        public string TenBaoCao
        {
            get
            {
                CanReadProperty("TenBaoCao", true);
                return _tenBaoCao;
            }
            set
            {
                CanWriteProperty("TenBaoCao", true);
                if (!_tenBaoCao.Equals(value))
                {
                    _tenBaoCao = value;
                    PropertyHasChanged("TenBaoCao");
                }
            }
        }

        public int SoTTSapXep
        {
            get
            {
                CanReadProperty("SoTTSapXep", true);
                return _soTTSapXep;
            }
            set
            {
                CanWriteProperty("SoTTSapXep", true);
                if (!_soTTSapXep.Equals(value))
                {
                    _soTTSapXep = value;
                    PropertyHasChanged("SoTTSapXep");
                }
            }
        }
        public bool Chon
        {
            get
            {
                CanReadProperty("Chon", true);
                return _chon;
            }
            set
            {
                CanWriteProperty("Chon", true);
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged("Chon");
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _id + _userID;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
			//
			// Id
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "Id");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Id", 500));
		}

		protected override void AddBusinessRules()
		{
            //AddCommonRules();
            //AddCustomRules();
		}
		#endregion //Validation Rules

		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Define authorization rules in ReportTemplate
			//AuthorizationRules.AllowRead("Id", "ReportTemplateReadGroup");
			//AuthorizationRules.AllowRead("Data", "ReportTemplateReadGroup");

			//AuthorizationRules.AllowWrite("Data", "ReportTemplateWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ReportTemplate
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ReportTemplateViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ReportTemplate
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ReportTemplateAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ReportTemplate
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ReportTemplateEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ReportTemplate
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ReportTemplateDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ReportTemplate()
		{ /* require use of factory method */ }

		public static ReportTemplate NewReportTemplate(string id, int userid, DateTime denngay, string tenphuongthuc, int thuMuc, string tenBaoCao, int soTTSapXep)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ReportTemplate");
            return DataPortal.Create<ReportTemplate>(new Criteria(id, userid, denngay, tenphuongthuc, thuMuc, tenBaoCao, soTTSapXep));
		}

        public static ReportTemplate GetReportTemplate(string id, int userid, DateTime denngay)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ReportTemplate");
            return DataPortal.Fetch<ReportTemplate>(new Criteria(id, userid, denngay));
		}

        public static ReportTemplate GetReportTemplate(string id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ReportTemplate");
            return DataPortal.Fetch<ReportTemplate>(new CriteriaDefault(id));
        }

        public static ReportTemplate GetReportTemplateExit(string id, int userid, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ReportTemplate");
            return DataPortal.Fetch<ReportTemplate>(new CriteriaExit(id, userid, denngay));
        }

        public static void DeleteReportTemplate(string id, int userid, DateTime denngay)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ReportTemplate");
			DataPortal.Delete(new Criteria(id,  userid, denngay));
		}

		public override ReportTemplate Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ReportTemplate");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ReportTemplate");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ReportTemplate");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ReportTemplate(string id)
		{
			this._id = id;
		}

		internal static ReportTemplate NewReportTemplateChild(string id)
		{
			ReportTemplate child = new ReportTemplate(id);
			//child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ReportTemplate GetReportTemplate(SafeDataReader dr)
		{
			ReportTemplate child =  new ReportTemplate();
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
			public string Id;
            public int UserID;
            public DateTime DenNgay;
            public string TenPhuongThuc;
            public int ThuMuc;
            public string TenBaoCao;
            public int SoTTSapXep;

			public Criteria(string id, int userid, DateTime denngay, string tenPhuongThuc, int thuMuc, string tenBaoCao, int soTTSapXep)
			{
				this.Id = id;
                this.UserID = userid;
                this.DenNgay = denngay;
                this.TenPhuongThuc = tenPhuongThuc;
                this.ThuMuc = thuMuc;
                this.TenBaoCao = tenBaoCao;
                this.SoTTSapXep = soTTSapXep;
			}

            public Criteria(string id, int userid, DateTime denngay)
            {
                this.Id = id;
                this.UserID = userid;
                this.DenNgay = denngay;
            }
		}

        private class CriteriaDefault
        {
            public string Id;

            public CriteriaDefault(string id)
            {
                this.Id = id;
            }
        }

        private class CriteriaExit
        {
            public string Id;
            public int UserID;
            public DateTime DenNgay;

            public CriteriaExit(string id, int userid, DateTime denngay)
            {
                this.Id = id;
                this.UserID = userid;
                this.DenNgay = denngay;
            }
        }
		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_id = criteria.Id;
            _userID = criteria.UserID;
            _denNgay = criteria.DenNgay;
            _tenPhuongThuc = criteria.TenPhuongThuc;
            _thuMuc = criteria.ThuMuc;
            _tenBaoCao = criteria.TenBaoCao;
            _soTTSapXep = criteria.SoTTSapXep;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelectReportTemplate";
                    cm.Parameters.AddWithValue("@ID", ((Criteria)criteria).Id);
                    cm.Parameters.AddWithValue("@USerID", ((Criteria)criteria).UserID);                  
                }
                if (criteria is CriteriaDefault)
                {
                    cm.CommandText = "spd_SelectReportTemplate_Defaulte";
                    cm.Parameters.AddWithValue("@ID", ((CriteriaDefault)criteria).Id);
                }
                else if (criteria is CriteriaExit)
                {
                    cm.CommandText = "spd_SelectReportTemplateExit";
                    cm.Parameters.AddWithValue("@ID", ((CriteriaExit)criteria).Id);
                    cm.Parameters.AddWithValue("@USerID", ((CriteriaExit)criteria).UserID);
                    cm.Parameters.AddWithValue("@DenNgay", ((CriteriaExit)criteria).DenNgay);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        //dr.Read();
                        FetchObject(dr);
                    }
					ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(dr);
				}
			}//using
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteInsert(tr, null);

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					if (base.IsDirty)
					{
						ExecuteUpdate(tr, null);
					}

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_id,_userID, _denNgay));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteDelete(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_DeleteReportTemplate";

				cm.Parameters.AddWithValue("@ID", criteria.Id);
                cm.Parameters.AddWithValue("@UserID", criteria.UserID);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			//ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_id = dr.GetString("ID");
			_data = (byte[])dr["Data"];
            _userID = dr.GetInt32("UserID");
            _denNgay = dr.GetDateTime("DenNgay");
            _tenPhuongThuc = dr.GetString("TenPhuongThuc");
            _thuMuc = dr.GetInt32("ThuMuc");
            _tenBaoCao = dr.GetString("TenBaoCao");
            _soTTSapXep = dr.GetInt32("SoTTSapXep");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ReportTemplateList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ReportTemplateList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_InsertReportTemplate";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ReportTemplateList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@ID", _id);
			cm.Parameters.AddWithValue("@Data", _data);
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay);
            cm.Parameters.AddWithValue("@ThuMuc", _thuMuc);
            cm.Parameters.AddWithValue("@TenPhuongThuc", _tenPhuongThuc);
            cm.Parameters.AddWithValue("@TenBaoCao", _tenBaoCao);
            cm.Parameters.AddWithValue("@SoTTSapXep", _soTTSapXep);

		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ReportTemplateList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ReportTemplateList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdateReportTemplate";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, ReportTemplateList parent)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters.AddWithValue("@Data", _data);
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay);
            cm.Parameters.AddWithValue("@ThuMuc", _thuMuc);
            cm.Parameters.AddWithValue("@TenPhuongThuc", _tenPhuongThuc);
            cm.Parameters.AddWithValue("@TenBaoCao", _tenBaoCao);
            cm.Parameters.AddWithValue("@SoTTSapXep", _soTTSapXep);
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

			ExecuteDelete(tr, new Criteria(_id, _userID, _denNgay));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
