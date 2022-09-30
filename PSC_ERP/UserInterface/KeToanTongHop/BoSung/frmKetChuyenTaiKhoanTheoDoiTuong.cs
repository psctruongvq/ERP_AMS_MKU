using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

//long


namespace PSC_ERP
{
    public partial class frmKetChuyenTaiKhoanTheoDoiTuong : Form
    {
        SoDuDauKyList _SoDuDauKyList;
        SoDuDauKy _SoDuDauKy;
        int _nam = 0;

        public frmKetChuyenTaiKhoanTheoDoiTuong()
        {
            InitializeComponent();
            KhoiTao();

        }

        private void KhoiTao()
        {
            //kyListBindingSource.DataSource = KyList.GetKyList();
            for (int i = 2010; i < 2020; i++)
            {
                cb_NamKeToan.Items.Add(i);
            }
            cb_NamKeToan.Text = DateTime.Today.Year.ToString();

        }
        
        private void bt_NhapSoDu_Click(object sender, EventArgs e)
        {
            if (cb_NamKeToan.Text != null)
                _nam = Convert.ToInt32(cb_NamKeToan.Text);

            if (SoDuDauKy.KiemTraNamKetChuyenSoDuTaiKhoanDoiTuong(_nam + 1, ERP_Library.Security.CurrentUser.Info.MaBoPhan) != 0)
            {
                if (MessageBox.Show(this, "Dữ liệu đã được tạo trong kỳ, Bạn có muốn cập nhật lại", "Thông Báo",
                                   MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        SoDuDauKyList.InSertGetSoDuTaiKhoanDoiTuongDauKy(_nam, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                        MessageBox.Show(this, "Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch 
                    {
                        MessageBox.Show(this, "Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }              
            }

            else
            {
                try
                {
                    SoDuDauKyList.InSertGetSoDuTaiKhoanDoiTuongDauKy(_nam, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    MessageBox.Show(this, "Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch 
                {
                    MessageBox.Show(this, "Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }                                    
        }

        private void cbu_KyKetChuyen_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //this.cbu_KyKetChuyen.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            //this.cbu_KyKetChuyen.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //foreach (UltraGridColumn col in this.cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            //    col.Hidden = true;
            //    //x =  //= System.Drawing.w;//RoyalBlue
            //}
            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Mã Kỳ";
            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 1;
            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Hidden = false;

            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 2;
            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;

            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.Caption = "Ngày Bắt Đầu";
            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.VisiblePosition = 3;
            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Hidden = false;

            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.Caption = "Ngày Kết Thúc";
            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.VisiblePosition = 4;
            //cbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = false;
        }      

    }
}
