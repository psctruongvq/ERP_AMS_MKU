using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using ERP_Library;
using ERP_Library.Security;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERPNew.Main
{
    public partial class frmTSCDCaBiet_UpdateSuDung : DevExpress.XtraEditors.XtraForm
    {
        int _maCongTy = CurrentUser.Info.MaCongTy;
        DataTable tbl;
        long _maChungTuGhiTang;
        public frmTSCDCaBiet_UpdateSuDung()
        {
            InitializeComponent();
            tbl = new DataTable();        
        }

        private static DataTable dtTSCDCaBiet_UpdateSuDung(int maCongTy)
        {
            DataTable tbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spTSCDCaBiet_GetTSCDCaBietChuaSuDung";
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(tbl);
                }
            }
            return tbl;
        }

        private void TSCDCaBiet_UpdateSuDung( int maTSCDCaBiet,int maCongTy,Boolean? suDung,DateTime ngaySuDung)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
               
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cn.Open();
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spTSCDCaBiet_UpdateTSCDCaBietChuaSuDung";
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                    cm.Parameters.AddWithValue("@MaTSCDCaBiet", maTSCDCaBiet);
                    if(suDung!=null)
                     cm.Parameters.AddWithValue("@SuDung", suDung);
                    else
                        cm.Parameters.AddWithValue("@SuDung", DBNull.Value);
                    cm.Parameters.AddWithValue("@NgaySuDung", ngaySuDung);
                    cm.ExecuteNonQuery();
                }
            }
        }
        private void frmTSCDCaBiet_UpdateSuDung_Load(object sender, EventArgs e)
        {
            tbl = dtTSCDCaBiet_UpdateSuDung(_maCongTy);
            GridUtil.SetSTTForGridView(new GridView[] { this.gView_TSCDCaBiet_UpdateSuDung });
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLayDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tbl = dtTSCDCaBiet_UpdateSuDung(_maCongTy);
            if (tbl.Rows.Count>0)
            {
                gControl_TSCDCaBiet_UpdateSuDung.DataSource = tbl;               
            }
            else { DialogUtil.ShowOK("Không Có Dữ Liệu"); }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            using (DialogUtil.WaitForSave(this))
            {
                int i = 0;
                foreach (int maTSCDCaBiet in tbl.AsEnumerable().Select(r => r.Field<int>("MaTSCDCaBiet")).ToList())
                {
                    TSCDCaBiet_UpdateSuDung(maTSCDCaBiet, _maCongTy,
                               (Boolean?)gView_TSCDCaBiet_UpdateSuDung.GetRowCellValue(i, gView_TSCDCaBiet_UpdateSuDung.Columns["SuDung"]),
                                (DateTime)gView_TSCDCaBiet_UpdateSuDung.GetRowCellValue(i, gView_TSCDCaBiet_UpdateSuDung.Columns["NgaySuDung"])
                                );
                    i++;
                }
            }
            DialogUtil.ShowSaveSuccessful();
        }

        private void btnDanhSachChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachChungTu_GhiTangTSCDCaBiet.ShowSingleton(null, this.MdiParent);
        }

        private void btnExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //xuất excel danh sách tài sản cá biệt
            GridUtil.ExportToExcelXlsx(gridView: this.gView_TSCDCaBiet_UpdateSuDung, showOpenFilePrompt: true);
        }

        private void gView_TSCDCaBiet_UpdateSuDung_DoubleClick(object sender, EventArgs e)
        {
            frmGhiTangTSCDCaBiet frm = new frmGhiTangTSCDCaBiet(_maChungTuGhiTang);
            frm.ShowDialog();
        }

        private void gView_TSCDCaBiet_UpdateSuDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _maChungTuGhiTang = (long)gView_TSCDCaBiet_UpdateSuDung.GetRowCellValue(e.FocusedRowHandle, gView_TSCDCaBiet_UpdateSuDung.Columns["MaChungTuGhiTang"]);
        }
    }
}