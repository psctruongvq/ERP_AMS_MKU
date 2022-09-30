using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
namespace PSC_ERP
{
    public partial class frmNhanVien_DungCuLaoDong : Form
    {
        #region Properties
        NhanVien_DungCuLaoDong nv_dcLD;
        NhanVien_DungCuLaoDongList nv_dcLDList;
        DungCuLaoDongList _dungCuLDList;
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        long maNhanVien = 0;
        #endregion

        #region Events
        public frmNhanVien_DungCuLaoDong()
        {
            InitializeComponent();
            txtu_MaNhanVien.Focus();
          
            tlslblLuu.Enabled = false;
            tlslblXoa.Enabled = false;
            tlslblUndo.Enabled = false;
           
            toolStripButton1.Visible = false;
        
        }

       
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < nv_dcLDList.Count; i++)
                {
                    nv_dcLDList[i].MaNhanVien = maNhanVien;
                }
                    NhanVienDungCuLaoDong_bindingSource.EndEdit();
                grdData.UpdateData();
                nv_dcLDList.ApplyEdit();
                nv_dcLDList.Save();
                MessageBox.Show("Cập nhật thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        #region grdu_QuaTrinhDaoTao_InitializeLayout
        private void grdu_QuaTrinhDaoTao_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
         

            foreach (UltraGridColumn col in grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                col.Hidden = true;
            }
            grdData.DisplayLayout.Bands[0].Columns["MaDungCu"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayCap"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["ThoiHan"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayHetHan"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
           ;

           grdData.DisplayLayout.Bands[0].Columns["MaDungCu"].Header.Caption = "Tên Dụng Cụ";
           grdData.DisplayLayout.Bands[0].Columns["NgayCap"].Header.Caption = "Ngày Cấp";
           grdData.DisplayLayout.Bands[0].Columns["ThoiHan"].Header.Caption = "Thời Hạn";
           grdData.DisplayLayout.Bands[0].Columns["NgayHetHan"].Header.Caption = "Ngày Hết Hạn";
           grdData.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

           grdData.DisplayLayout.Bands[0].Columns["MaDungCu"].Width = cbDungCuLaoDong.Width;
           grdData.DisplayLayout.Bands[0].Columns["MaDungCu"].Header.VisiblePosition = 0;
           grdData.DisplayLayout.Bands[0].Columns["NgayCap"].Header.VisiblePosition = 1;
           grdData.DisplayLayout.Bands[0].Columns["ThoiHan"].Header.VisiblePosition = 2;
           grdData.DisplayLayout.Bands[0].Columns["NgayHetHan"].Header.VisiblePosition = 3;
           grdData.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 4;

           grdData.DisplayLayout.Bands[0].Columns["MaDungCu"].EditorComponent = cbDungCuLaoDong;
        }
        #endregion

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

      
        
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            
            grdData.DeleteSelectedRows();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
        private void TimKiem()
        {
            frmTimNhanVien form_TimNV = new frmTimNhanVien();
            if (form_TimNV.ShowDialog(this) != DialogResult.OK)
            {
                if (frmTimNhanVien.MaNhanVien != 0)
                {
                    maNhanVien = frmTimNhanVien.MaNhanVien;
                    TenNV _nhanVien = TenNV.GetTenNhanVien(maNhanVien);
                    nv_dcLDList = NhanVien_DungCuLaoDongList.GetNhanVien_DungCuLaoDongList(maNhanVien);
                    this.NhanVienDungCuLaoDong_bindingSource.DataSource = nv_dcLDList;
                    txtu_MaNhanVien.Text = _nhanVien.MaQLNhanVien.ToString();
                    txtu_TenNhanVien.Text = _nhanVien.TenNhanVien.ToString();
                }
            }
          
            tlslblLuu.Enabled = true;
            tlslblXoa.Enabled = true;
            tlslblUndo.Enabled = true;
        }
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            nv_dcLDList = NhanVien_DungCuLaoDongList.GetNhanVien_DungCuLaoDongList(maNhanVien);
            this.NhanVienDungCuLaoDong_bindingSource.DataSource = nv_dcLDList;
        }
        #endregion

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void frmQuaTrinhDaoTaoMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                TimKiem();
            }
        }

        private void frmQuaTrinhDaoTaoMoi_Load(object sender, EventArgs e)
        {
            nv_dcLDList = NhanVien_DungCuLaoDongList.GetNhanVien_DungCuLaoDongList(maNhanVien);
            this.NhanVienDungCuLaoDong_bindingSource.DataSource = nv_dcLDList;
            _dungCuLDList = DungCuLaoDongList.GetDungCuLaoDongList();
            bindingSource1_DungCuLaoDong.DataSource = _dungCuLDList;
            
        }
    }
}