using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmDSTheoDoiDoiTuong : Form
    {
        HeThongTaiKhoan1List _HeThongTaiKhoan1List;
        public frmDSTheoDoiDoiTuong()
        {
            InitializeComponent();
        }

        private void grdu_DSTaiKhoan_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            
            frmDSDoiTuongTaiKhoan _frmDSDoiTuongTaiKhoan = new frmDSDoiTuongTaiKhoan((((HeThongTaiKhoan1)HeThongTaiKhoan_BindingSource.Current)).MaTaiKhoan,false);
            _frmDSDoiTuongTaiKhoan.ShowDialog();
            
        }

        private void grdu_DSTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            grdu_DSTaiKhoan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grdu_DSTaiKhoan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = true;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["MaTaiKhoanCha"].Hidden = true;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuCo"].Header.Caption = "Dư Có";
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuCo"].Width = 60;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuCo"].Header.VisiblePosition = 3;


            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuNo"].Header.Caption = "Dư Nợ";
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuNo"].Header.VisiblePosition = 4;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuNo"].Width = 60;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["SoDuNoDauNam"].Hidden = true;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["SoDuCoDauNam"].Hidden = true;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["MaLoaiTaiKhoan"].Hidden = true;

            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;

            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 275;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["CapTaiKhoan"].Header.Caption = "Cấp Tài Khoản";
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["CapTaiKhoan"].Header.VisiblePosition = 2;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["CapTaiKhoan"].Width = 95;

            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["CoDoiTuongTheoDoi"].Hidden = true;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["CoDoiTuongTheoDoi"].Header.Caption = "Có Đối Tượng Theo Dõi";
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["CoDoiTuongTheoDoi"].Header.VisiblePosition = 3;
            grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns["CoDoiTuongTheoDoi"].Width = 142;

            foreach (UltraGridColumn col in grdu_DSTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.CellActivation = Activation.NoEdit;
            }

        }

        private void frmDSTheoDoiDoiTuong_Load(object sender, EventArgs e)
        {
            _HeThongTaiKhoan1List = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListTheoDoi();
            HeThongTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1List;
        }

       
    }
}