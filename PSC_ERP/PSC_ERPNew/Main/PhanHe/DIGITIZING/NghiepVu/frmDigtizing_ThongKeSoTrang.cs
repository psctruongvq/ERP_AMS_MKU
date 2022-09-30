using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
//

namespace PSC_ERPNew.Main
{
    public partial class frmDigtizing_ThongKeSoTrang : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDigtizing_ThongKeSoTrang singleton_ = null;
        public static frmDigtizing_ThongKeSoTrang Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDigtizing_ThongKeSoTrang();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion

        //Private Member field
        #region Private Member field
        app_users_Factory _app_users_Factory = new app_users_Factory();
        app_users _user = null;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDigtizing_ThongKeSoTrang()
        {
            InitializeComponent();
        }
        #endregion

        //Event Method
        #region Event Method
        private void UncheckAll_WithoutMe(List<CheckEdit> list, CheckEdit me)
        {
            foreach (var item in list)
            {
                if (!Object.ReferenceEquals(item, me))
                    item.Checked = false;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_DieuChuyenNoiBo, this.MdiParent);
        }
        #endregion

        private void frmDigtizing_ThongKeSoTrang_Load(object sender, EventArgs e)
        {
            dte_TuNgay.DateTime = _app_users_Factory.SystemDate;
            dte_DenNgay.DateTime = _app_users_Factory.SystemDate;

            List<app_users> app_user_list = _app_users_Factory.GetAll().ToList();
            app_user_list.Insert(0, new app_users() { UserID = 0, MaQLUser = "<<Tất cả>>", TenDangNhap = "<<Tất cả>>" });
            User_BindingSource.DataSource = app_user_list;
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 maUser = Convert.ToInt32(cbNhanVien.EditValue);
            if (dte_TuNgay.DateTime > dte_DenNgay.DateTime)
            {
                DialogUtil.ShowError("Từ Ngày - Đến Ngày không hợp lệ \nVui lòng chọn từ ngày nhỏ hơn hoặc bằng đến ngày!");
                return;
            }

            var ketQua = _app_users_Factory.Context.spd_DIGITIZING_ThongKeSoTrangTheoNgay_User(dte_TuNgay.DateTime, dte_DenNgay.DateTime, maUser).ToList();
            if (ketQua.Count() > 0)
            {
                spd_DIGITIZING_ThongKeSoTrangTheoNgay_User_Result_BinDingSource.DataSource = ketQua;
            }
            else
            {
                DialogUtil.ShowInfo("Không Tìm Thấy");
                spd_DIGITIZING_ThongKeSoTrangTheoNgay_User_Result_BinDingSource.DataSource = null;
            }
        }

        private void btn_XuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //xuất excel danh sách tài sản cá biệt
            if (this.grdView_ThongKeSoTrangUpLoad.RowCount > 0)
            {
                PSC_ERP_Common.GridUtil.ExportToExcel(gridView: this.grdView_ThongKeSoTrangUpLoad, showOpenFilePrompt: true);
            }
            else
            {
                DialogUtil.ShowError("Không có dữ liệu!");
            }
        }

        private void bnt_InBaoCaoTongHop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            app_users user = (app_users)cbNhanVien.GetSelectedDataRow();
            DateTime tuNgay = (Convert.ToDateTime(dte_TuNgay.EditValue).Date);
            DateTime denNgay = (Convert.ToDateTime(dte_DenNgay.EditValue).Date);

            ReportHelper.ShowReport("ThongKeSoTrangUpLoad_TongHop", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                //dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BienBanGiaoNhanChiTietTSCD_DCCTTS", "@MaNghiepVuDieuChuyenChiTietTS", _nghiepVuDieuChuyenChiTietTaiSan.MaNghiepVuDieuChuyenChiTiet);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spd_DIGITIZING_ThongKeSoTrangTheoNgay_User", "@TuNgay,@DenNgay,@MaUser",dte_TuNgay.DateTime,dte_DenNgay.DateTime,user.UserID);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = tuNgay;
                dr["DenNgay"] = denNgay;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "SubInfo";
                dataSet.Tables.Add(dtngay);
                #endregion
                return dataSet;
            }, "Digitizing", false, true);
        }

        private void btn_InBaoCaoChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            app_users user = (app_users)cbNhanVien.GetSelectedDataRow();
            DateTime tuNgay = (Convert.ToDateTime(dte_TuNgay.EditValue).Date);
            DateTime denNgay = (Convert.ToDateTime(dte_DenNgay.EditValue).Date);

            ReportHelper.ShowReport("ThongKeSoTrangUpLoad_ChiTiet", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                //dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BienBanGiaoNhanChiTietTSCD_DCCTTS", "@MaNghiepVuDieuChuyenChiTietTS", _nghiepVuDieuChuyenChiTietTaiSan.MaNghiepVuDieuChuyenChiTiet);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spd_DIGITIZING_ThongKeSoTrangTheoNgay_User_ChiTiet", "@TuNgay,@DenNgay,@MaUser", dte_TuNgay.DateTime, dte_DenNgay.DateTime, user.UserID);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = tuNgay;
                dr["DenNgay"] = denNgay;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "SubInfo";
                dataSet.Tables.Add(dtngay);
                #endregion
                return dataSet;
            }, "Digitizing", false, true);
        }

        private void btn_InBaoCaoChiTietTheoNgayLapChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            app_users user = (app_users)cbNhanVien.GetSelectedDataRow();
            DateTime tuNgay = (Convert.ToDateTime(dte_TuNgay.EditValue).Date);
            DateTime denNgay = (Convert.ToDateTime(dte_DenNgay.EditValue).Date);

            ReportHelper.ShowReport("ThongKeSoTrangUpLoadTheoNgayLapChungTu_ChiTiet", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spd_DIGITIZING_ThongKeSoTrangTheoNgayLapChungTu_User_ChiTiet", "@TuNgay,@DenNgay,@MaUser", dte_TuNgay.DateTime, dte_DenNgay.DateTime, user.UserID);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = tuNgay;
                dr["DenNgay"] = denNgay;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "SubInfo";
                dataSet.Tables.Add(dtngay);
                #endregion
                return dataSet;
            }, "Digitizing", false, true);

        }

    }
}