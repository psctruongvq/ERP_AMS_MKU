using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmDanhSachTongHopThueCTV : DevExpress.XtraEditors.XtraForm
    {
        #region
        NhanVienNgoaiDaiList _nhanVienList;
        ChungTuNganHangList _chungTuNganHangList;
        DataSet dataSet;
        #endregion

        public frmDanhSachTongHopThueCTV()
        {
            InitializeComponent();
            dte_DenNgay.EditValue = DateTime.Today.Date;
            dte_TuNgay.EditValue = DateTime.Today.Date;
        }

        private void TimKiem()
        {
            try
            {
                _nhanVienList = NhanVienNgoaiDaiList.NewNhanVienNgoaiDaiList();
                DateTime tuNgay = Convert.ToDateTime(dte_TuNgay.EditValue);
                DateTime denNgay = Convert.ToDateTime(dte_DenNgay.EditValue);

                _nhanVienList = ERP_Library.NhanVienNgoaiDaiList.GetChungTuThueTNCNNhanVienNgoaiDaiList_ByNgayLap(tuNgay, denNgay);
                NhanVienNgoaiDai_BindingSource.DataSource = _nhanVienList;

                if (_nhanVienList.Count == 0)
                {
                    MessageBox.Show("Không Có dữ liệu.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            catch (ApplicationException)
            {

            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
       
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimKiem();
        }

        private void frmDanhSachTongHopThueCTV_FormClosed(object sender, FormClosedEventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = " DevExpress Style";
        }

        private void frmDanhSachTongHopThueCTV_Load(object sender, EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2007 Blue";
            // Cài đặt ngày
            dte_TuNgay.EditValue = DateTime.Now.Date;
            dte_DenNgay.EditValue = DateTime.Now.Date;
            //Cài đặt stt
            Utils.GridUtils.SetSTTForGridView(gridView_ChungTuKhauTruThueTNCN, 35);
        }

        private void ExportExcel()
        {
            HamDungChung.ExportToExcelFromGridViewDev(gridView_ChungTuKhauTruThueTNCN);
        }
        private void btnExport_Excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportExcel();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }    
    }
}