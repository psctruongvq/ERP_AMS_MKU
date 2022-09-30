using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace PSC_ERP
{
    public partial class frmDSDoiTuongThuChi : Form
    {
        DoiTuongThuChiList _DoiTuongThuChiList= DoiTuongThuChiList.NewDoiTuongThuChiList();
        int MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        NhomCongViecList _nhomCongViecList = NhomCongViecList.NewNhomCongViecList();

        public frmDSDoiTuongThuChi()
        {
            InitializeComponent();
        }

        private void frmDSDoiTuongThuChi_Load(object sender, EventArgs e)
        {
            _DoiTuongThuChiList = DoiTuongThuChiList.GetDoiTuongThuChiListAll(MaCongTy);
            DoiTuongThuChi_BindingSource.DataSource = _DoiTuongThuChiList;
            _nhomCongViecList = NhomCongViecList.GetNhomCongViecList();
            NhomCongViec congViec = NhomCongViec.NewNhomCongViec("Không Có");
            _nhomCongViecList.Insert(0, congViec);
            this.bindingSource1_nhomCongViec.DataSource = _nhomCongViecList;
        }

        private void grdu_DoiTuongThuChi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
           // e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["STT"].Hidden = false;
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["STT"].Header.Caption = "Số thứ tự";
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["STT"].Header.VisiblePosition = 0;
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["STT"].Width = 100;

            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Hidden = false;
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Header.Caption = "Tên đối tượng";
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Header.VisiblePosition = 1;
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["TenDoiTuongThuChi"].Width = 200;

            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["SuDung"].Hidden = false;
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["SuDung"].Header.Caption = "Sử dụng";
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["SuDung"].Header.VisiblePosition = 2;
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["SuDung"].Width = 100;

            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["MaNhomDoiTuong"].Hidden = false;
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["MaNhomDoiTuong"].EditorComponent=cbNhomDoiTuong;
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["MaNhomDoiTuong"].Header.Caption = "Nhóm Đối Tượng";
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["MaNhomDoiTuong"].Header.VisiblePosition = 3;
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["MaNhomDoiTuong"].Width = 100;

            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["SoDuCuoiKy"].Hidden = false;            
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["SoDuCuoiKy"].Header.Caption = "Số Dư Cuối Kỳ(12/2009)";
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["SoDuCuoiKy"].Header.VisiblePosition = 4;
            
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["SoDuCuoiKy"].Format = "###,###,###,###";
            grdu_DoiTuongThuChi.DisplayLayout.Bands[0].Columns["SoDuCuoiKy"].CellAppearance.TextHAlign = HAlign.Right;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _DoiTuongThuChiList.Save();

                MessageBox.Show(this, "Lưu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception)
            {

                MessageBox.Show(this, "Lưu thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
              
            }
           
        }

        private void grdu_DoiTuongThuChi_KeyDown(object sender, KeyEventArgs e)
        {
            //grdu_DoiTuongThuChi.UpdateData();
        }

        private void cbDoiTuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.cbNhomDoiTuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cbNhomDoiTuong.DisplayLayout.Bands[0].Columns["TenNhomDoiTuong"].Hidden = false;
            cbNhomDoiTuong.DisplayLayout.Bands[0].Columns["TenNhomDoiTuong"].Header.Caption = "Nhóm Đối Tượng";
            cbNhomDoiTuong.DisplayLayout.Bands[0].Columns["TenNhomDoiTuong"].Header.VisiblePosition = 0;
            cbNhomDoiTuong.DisplayLayout.Bands[0].Columns["TenNhomDoiTuong"].Width = 100;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
