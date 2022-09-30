
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
[Serializable()] 
public class NhanVien_TaiKhoanNganHangList : Csla.BusinessListBase<NhanVien_TaiKhoanNganHangList, NhanVien_TaiKhoanNganHang>
{
	#region BindingList Overrides
	protected override object AddNewCore()
	{
		NhanVien_TaiKhoanNganHang item = NhanVien_TaiKhoanNganHang.NewNhanVien_TaiKhoanNganHang();
		this.Add(item);
		return item;
	}
	#endregion //BindingList Overrides

	#region Factory Methods
	public static NhanVien_TaiKhoanNganHangList NewNhanVien_TaiKhoanNganHangList()
	{
		return new NhanVien_TaiKhoanNganHangList();
	}

	internal static NhanVien_TaiKhoanNganHangList GetNhanVien_TaiKhoanNganHangList(SafeDataReader dr)
	{
		return new NhanVien_TaiKhoanNganHangList(dr);
	}
    public static NhanVien_TaiKhoanNganHangList GetNhanVien_TaiKhoanNganHangList(long maNhanVien)
    {
        return DataPortal.Fetch<NhanVien_TaiKhoanNganHangList>(new FilterCriteriaByMaNhanVien(maNhanVien));
    }
	private NhanVien_TaiKhoanNganHangList()
	{
		MarkAsChild();
	}

	private NhanVien_TaiKhoanNganHangList(SafeDataReader dr)
	{
		MarkAsChild();
		//Fetch(dr);
	}
	#endregion //Factory Methods

    [Serializable()]
    private class FilterCriteriaByMaNhanVien
    {
        public long MaNhanVien;

        public FilterCriteriaByMaNhanVien(long MaNhanVien)
        {
            this.MaNhanVien = MaNhanVien;
        }
    }

	#region Data Access
    private void DataPortal_Fetch(object criteria)
    {
        RaiseListChangedEvents = false;

        using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        {
            cn.Open();
            try
            {
                ExecuteFetch(cn, criteria);
            }
            catch (SqlException ex)
            {
                HamDungChung.ThongBaoLoi(ex);
            }
        }//using

        RaiseListChangedEvents = true;
    }

    private void ExecuteFetch(SqlConnection cn, object criteria)
    {
        using (SqlCommand cm = cn.CreateCommand())
        {
            cm.CommandType = CommandType.StoredProcedure;
            if (criteria is FilterCriteriaByMaNhanVien)
            {
                cm.CommandText = "spd_SelecttblnsNhanVien_TaiKhoan";
                cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByMaNhanVien)criteria).MaNhanVien);
            }
            
            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
            {
                while (dr.Read())
                    this.Add(NhanVien_TaiKhoanNganHang.GetNhanVien_TaiKhoanNganHang(dr));
            }
        }//using
    }
    internal void Update(SqlTransaction tr, NhanVien parent)
    {
        RaiseListChangedEvents = false;
        try
        {
            // loop through each deleted child object
            foreach (NhanVien_TaiKhoanNganHang deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (NhanVien_TaiKhoanNganHang child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }
        }
        catch (SqlException ex)
        {
            tr.Rollback();
            HamDungChung.ThongBaoLoi(ex);
        }
        RaiseListChangedEvents = true;
    }
	#endregion //Data Access

}

}