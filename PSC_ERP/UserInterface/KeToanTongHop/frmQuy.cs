using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Shared;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmQuy : Form
    {
        QuyList _quyList = QuyList.NewQuyList();

        #region Contructors
        public frmQuy()
        {
            InitializeComponent(); 
            KhoiTao();
        }
        #endregion 

        #region Khởi Tạo
        private void KhoiTao()
        {

            kyListBindingSource.DataSource = KyList.GetKyList();
            kyListBindingSource1.DataSource = KyList.GetKyList();
            _quyList = QuyList.GetQuyList();
            quyListBindingSource.DataSource = _quyList;
        }
        #endregion 

        #region Kiểm Tra Dữ Liệu
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (txt_MaQL.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaQL.Focus();
                kq = false;
                return kq;
            }
            else if (txt_TenQuy.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Quý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenQuy.Focus();
                kq = false;
                return kq;   
            }
            else if (cb_TuKy.SelectedValue == null || Convert.ToInt16(cb_TuKy.SelectedValue) == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Kỳ Bắt Đầu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_TuKy.Focus();
                kq = false;
                return kq;   
            }
            else if (cb_DenKy.SelectedValue == null || Convert.ToInt16(cb_DenKy.SelectedValue) == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Kỳ Kết Thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_DenKy.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(Quy quy)
        {
            Boolean kq = true;
            if (quy.MaQuanLy == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaQL.Focus();
                kq = false;
                return kq;
            }
            else if (quy.TenQuy == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Quý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenQuy.Focus();
                kq = false;
                return kq;
            }
            else if (quy.TuKy == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Kỳ Bắt Đầu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_TuKy.Focus();
                kq = false;
                return kq;
            }
            else if (quy.DenKy == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Kỳ Kết Thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_DenKy.Focus();
                kq = false;
                return kq;
            }
            return kq;         
        }
        #endregion

        #region grdu_Quy_InitializeLayout
        private void grdu_Quy_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdu_Quy.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_Quy.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_Quy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;                
                //x =  //= System.Drawing.w;//RoyalBlue
            }
            grdu_Quy.DisplayLayout.Bands[0].Columns["MaQuy"].Hidden = true;
            grdu_Quy.DisplayLayout.Bands[0].Columns["NgayBatDau"].Hidden = true;
            grdu_Quy.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = true;
            grdu_Quy.DisplayLayout.Bands[0].Columns["TuKy"].Hidden = true;
            grdu_Quy.DisplayLayout.Bands[0].Columns["DenKy"].Hidden = true;

            grdu_Quy.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quý";
            grdu_Quy.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            
            grdu_Quy.DisplayLayout.Bands[0].Columns["TenQuy"].Header.Caption = "Tên Quý";
            grdu_Quy.DisplayLayout.Bands[0].Columns["TenQuy"].Header.VisiblePosition = 2;

            grdu_Quy.DisplayLayout.Bands[0].Columns["TenKyBatDau"].Header.Caption = "Từ Kỳ";
            grdu_Quy.DisplayLayout.Bands[0].Columns["TenKyBatDau"].Header.VisiblePosition = 3;            

            grdu_Quy.DisplayLayout.Bands[0].Columns["TenKyKetThuc"].Header.Caption = "Đến Kỳ";
            grdu_Quy.DisplayLayout.Bands[0].Columns["TenKyKetThuc"].Header.VisiblePosition = 4;
            

        }
        #endregion 

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Quy quy in _quyList)
                {
                    KiemTraDuLieu(quy);
                }
                _quyList.ApplyEdit();
                _quyList.Save();
                MessageBox.Show(this, "Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "Cập nhật không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion 

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (_quyList.Count == 0)
            {
                Quy quy= Quy.NewQuy();
                _quyList.Add(quy);
                grdu_Quy.ActiveRow = grdu_Quy.Rows[_quyList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    Quy quy = Quy.NewQuy();
                    _quyList.Add(quy);
                    grdu_Quy.ActiveRow = grdu_Quy.Rows[_quyList.Count - 1];
                }
            }
        }
        #endregion 

        #region cb_TuKy_SelectedValueChanged
        private void cb_TuKy_SelectedValueChanged(object sender, EventArgs e)
        {
            if (quyListBindingSource.Current != null && cb_TuKy.SelectedValue != null)
            {
                Ky ky = Ky.GetKy(Convert.ToInt32(cb_TuKy.SelectedValue));
                ((Quy)quyListBindingSource.Current).TuKy = ky.MaKy;
                ((Quy)quyListBindingSource.Current).TenKyBatDau = ky.TenKy;
                ((Quy)quyListBindingSource.Current).NgayBatDau = ky.NgayBatDau ;
            }
        }
        #endregion 

        #region cb_DenKy_SelectedValueChanged
        private void cb_DenKy_SelectedValueChanged(object sender, EventArgs e)
        {
            if (quyListBindingSource.Current != null && cb_DenKy.SelectedValue != null)
            {
                Ky ky = Ky.GetKy(Convert.ToInt32(cb_DenKy.SelectedValue));
                ((Quy)quyListBindingSource.Current).DenKy = ky.MaKy;
                ((Quy)quyListBindingSource.Current).TenKyKetThuc = ky.TenKy;
                ((Quy)quyListBindingSource.Current).NgayKetThuc = ky.NgayKetThuc;
            }
        }
        #endregion 

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 
    }
}