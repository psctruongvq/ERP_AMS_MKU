
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTuRutGonList : Csla.BusinessListBase<ChungTuRutGonList, ChungTuRutGon>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ChungTuRutGon item = ChungTuRutGon.NewChungTuRutGon();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private ChungTuRutGonList()
		{ /* require use of factory method */ }

		public static ChungTuRutGonList NewChungTuRutGonList()
		{
			return new ChungTuRutGonList();
		}

		public static ChungTuRutGonList GetChungTuRutGonList()
		{
			return DataPortal.Fetch<ChungTuRutGonList>(new FilterCriteria());
		}      
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
		
			public FilterCriteria()
			{
				
			}
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblChungTuList";
			
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChungTuRutGon.GetChungTuRutGon(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch
        public static ChungTuRutGonList GetChungTuListByLoaiChungTu(int loaiChungTu)
        {
            ChungTuRutGonList listChungTu;
            listChungTu = new ChungTuRutGonList();
            try

            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SelectChungTuByLoai";

                        cm.Parameters.AddWithValue("@MaLoaiChungTu", loaiChungTu);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);


                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTuRutGon.GetChungTuRutGon(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        public static ChungTuRutGonList GetChungTuList( DateTime tuNgay, DateTime denNgay,string tkNo,string tkCo)
        {
            ChungTuRutGonList listChungTu;
            listChungTu = new ChungTuRutGonList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelectChungTuByNoCoTaiKhoan";                        
                        cm.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay.Date);
                        cm.Parameters.AddWithValue("@NoTK", tkNo);
                        cm.Parameters.AddWithValue("@CoTK", tkCo);
                        cm.Parameters.AddWithValue("@MaBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.MaBoPhan);


                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTuRutGon.GetChungTuRutGon(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }
        public static ChungTuRutGonList GetChungTuList(int loaiChungTu,DateTime tuNgay,DateTime denNgay)
        {
            ChungTuRutGonList listChungTu;
            listChungTu = new ChungTuRutGonList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        //cm.CommandText = "SelectChungTuByLoaiNgayLap";
                        cm.CommandText = "SelectChungTuByLoaiNgayLap_1";
                        cm.Parameters.AddWithValue("@MaLoaiChungTu", loaiChungTu);
                        cm.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay.Date);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);


                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                //listChungTu.Add(ChungTuRutGon.GetChungTuRutGon(dr));
                                listChungTu.Add(ChungTuRutGon.GetChungTuRutGon_UserId(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        public static ChungTuRutGonList GetChungTuList_1(int loaiChungTu, DateTime tuNgay, DateTime denNgay)
        {
            ChungTuRutGonList listChungTu;
            listChungTu = new ChungTuRutGonList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SelectChungTuByLoaiNgayLap_1";
                        cm.Parameters.AddWithValue("@MaLoaiChungTu", loaiChungTu);
                        cm.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay.Date);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);


                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTuRutGon.GetChungTuRutGonForUNC(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        public static ChungTuRutGonList GetChungTuListAllByUserId(DateTime tungay,DateTime dengay)
        {
            ChungTuRutGonList listChungTu;
            listChungTu = new ChungTuRutGonList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SelectChungTuByLoaiNgayLap_All_ByUserId";
                        cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.Parameters.AddWithValue("@TuNgay", tungay);
                        cm.Parameters.AddWithValue("@DenNgay", dengay);


                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTuRutGon.GetChungTuRutGon_UserId(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }
        public static ChungTuRutGonList GetChungTuListAll(DateTime tuNgay, DateTime denNgay)
        {
            ChungTuRutGonList listChungTu;
            listChungTu = new ChungTuRutGonList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        //cm.CommandText = "SelectChungTuByLoaiNgayLap_All";                       
                        cm.CommandText = "SelectChungTuByLoaiNgayLap_All_1";                       
                        cm.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay.Date);
                        cm.Parameters.AddWithValue("@Mabophan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);


                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                //listChungTu.Add(ChungTuRutGon.GetChungTuRutGon(dr));
                                listChungTu.Add(ChungTuRutGon.GetChungTuRutGon_UserId(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        public static ChungTuRutGonList GetChungTuListAll_1(DateTime tuNgay, DateTime denNgay)
        {
            ChungTuRutGonList listChungTu;
            listChungTu = new ChungTuRutGonList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SelectChungTuByLoaiNgayLap_All_1";
                        cm.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay.Date);
                        cm.Parameters.AddWithValue("@Mabophan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);


                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTuRutGon.GetChungTuRutGonForUNC(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }
        // Loc Co lay theo but toan de duyet tinh trang chung tu thue
        public static ChungTuRutGonList GetChungTuListAll_ByLoc(DateTime tuNgay, DateTime denNgay)
        {
            ChungTuRutGonList listChungTu;
            listChungTu = new ChungTuRutGonList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SelectChungTuByLoaiNgayLap_All_ByLoc";
                        cm.CommandTimeout = 0;
                        cm.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay.Date);
                        cm.Parameters.AddWithValue("@Mabophan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        if (ERP_Library.Security.CurrentUser.Info.TenGroup == "AdminThue")
                        {
                            cm.Parameters.AddWithValue("@Admin", 1);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@Admin", 0);
                        }

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTuRutGon.GetChungTuRutGon_ByLoc(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        //==========20.03.2018======Truong
        public static ChungTuRutGonList GetDanhSachChungTuHoanPhi(DateTime tuNgay, DateTime denNgay)
        {
            ChungTuRutGonList listChungTu;
            listChungTu = new ChungTuRutGonList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_GetDanhSachChungTuHoanPhi";
                        cm.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay.Date);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);


                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTuRutGon.GetChungTuRutGon(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (ChungTuRutGon deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChungTuRutGon child in this)
                    {
                        //if (child.IsNew)
                        //    child.Insert(tr);
                        //else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }

		#endregion //Data Access
	}
}
