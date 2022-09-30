
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
namespace ERP_Library
{// 16-1-2010

    [Serializable()]
    public class ChiThuLao_NhanVienList : Csla.BusinessListBase<ChiThuLao_NhanVienList, ChiThuLao_NhanVien>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiThuLao_NhanVien item = ChiThuLao_NhanVien.NewChiThuLao_NhanVien();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        public static ChiThuLao_NhanVienList NewChiThuLao_NhanVien()
        {
            return new ChiThuLao_NhanVienList();
        }
        public static ChiThuLao_NhanVienList GetChiThuLao_NhanVien(long maChiThuLao)
        {
            return DataPortal.Fetch<ChiThuLao_NhanVienList>(new FilterCriteriaAll(maChiThuLao));
        }
        public static ChiThuLao_NhanVienList GetChiThuLao_NhanVien(long maChiThuLao,byte loaiNV)
        {
            return DataPortal.Fetch<ChiThuLao_NhanVienList>(new FilterCriteria(maChiThuLao,loaiNV));
        }

        private ChiThuLao_NhanVienList()
        {
            MarkAsChild();
        }

        private ChiThuLao_NhanVienList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        [Serializable()]
        private class FilterCriteriaAll
        {
            public long MaChiThuLao;
          
            public FilterCriteriaAll(long maChiThuLao)
            {
                this.MaChiThuLao = maChiThuLao;
                
            }
        }
        private class FilterCriteria
        {
            public long MaChiThuLao;
            public byte LoaiNhanVien;
            public FilterCriteria(long maChiThuLao,byte loaiNV)
            {
                this.MaChiThuLao = maChiThuLao;
                this.LoaiNhanVien = loaiNV;
            }
        }
       
        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChiThuLao_NhanVien.GetChiThuLao_NhanVien(dr));

            RaiseListChangedEvents = true;
        }
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }
        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblChiThuLao_NhanVien";
                    cm.Parameters.AddWithValue("@MaChiThuLao", ((FilterCriteria)criteria).MaChiThuLao);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteria)criteria).LoaiNhanVien);
                }
                else if(criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "spd_SelecttblChiThuLao_NhanVienAll";
                    cm.Parameters.AddWithValue("@MaChiThuLao", ((FilterCriteriaAll)criteria).MaChiThuLao);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiThuLao_NhanVien.GetChiThuLao_NhanVien(dr));
                }
            }//using
        }

        internal void Update(SqlTransaction tr, ChiThuLao parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiThuLao_NhanVien deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiThuLao_NhanVien child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        public void DataPortal_Delete(SqlTransaction tr, long MaChiThuLao)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblChiThuLao_NhanVienByMaChiThuLao";

                cm.Parameters.AddWithValue("@MaChiThuLao", MaChiThuLao);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access

    }

}