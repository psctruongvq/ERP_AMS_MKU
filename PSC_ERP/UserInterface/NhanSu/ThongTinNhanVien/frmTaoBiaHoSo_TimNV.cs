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
namespace PSC_ERP
{
    public partial class frmTaoBiaHoSo_TimNV : Form
    {
        BoPhanList _BophanList = BoPhanList.NewBoPhanList();
        ThongTinNhanVienTongHopList _TTNhanvien = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
        DanhsachNVTheoBiaHoSoList _DSNVtheoBiahoso = DanhsachNVTheoBiaHoSoList.NewDanhsachNVTheoBiaHoSoList();

        public frmTaoBiaHoSo_TimNV()
        { 
            InitializeComponent();
            this.Load_Source();
        }

        #region Load
        private void Load_Source()
        {
            _BophanList = BoPhanList.GetBoPhanList();
            BindS_BoPhan.DataSource = _BophanList;
        }

        private void Load_Dich()
        {
            if (cmbu_Bophan.Value != null)
            {
                _DSNVtheoBiahoso = DanhsachNVTheoBiaHoSoList.GetNhanvienBiaHoSoByBoPhan((int)cmbu_Bophan.Value);
                BindS_Danhsach.DataSource = _DSNVtheoBiahoso;
            }
            if (txt_NhanVien.Text != "")
            {
                _DSNVtheoBiahoso = DanhsachNVTheoBiaHoSoList.GetNhanvienBiaHoSoByNhanVien(txt_NhanVien.Text);
                BindS_Danhsach.DataSource = _DSNVtheoBiahoso;
            }

        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_Bophan.DisplayLayout.Bands[0],
           new string[2] { "Tenbophan", "mabophan" },
           new string[2] { "Bộ phận", "Mã số" },
           new int[2] { ((int)cmbu_Bophan.Width) , 90 },
           new Control[2] { null, null },
           new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
           new bool[2] { false, false });
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = true;
        }

        private void grdu_DSNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Manhanvien"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tenchucvu"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["machucvu"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["mabophan"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Ngayvaolam"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["mabiaHoso"].Hidden = true;


            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQlNhanVien"].Header.Caption = "Mã Số";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tenbophan"].Header.Caption = "Bộ Phận";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenBiaHoSo"].Header.Caption = "Tên Bìa";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["LyLich"].Header.Caption = "Lý Lịch";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["DonXinViec"].Header.Caption = "Đơn Xin Việc";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["KhamsucKhoe"].Header.Caption = "Khám Sức Khỏe";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["HoKhau"].Header.Caption = "Hộ Khẩu";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["VanBang"].Header.Caption = "Văn Bằng";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GiayTamTru"].Header.Caption = "Giấy Tạm Trú";



            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQlNhanVien"].Header.VisiblePosition = 0;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tenbophan"].Header.VisiblePosition = 2;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenBiaHoSo"].Header.VisiblePosition = 3;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["LyLich"].Header.VisiblePosition = 4;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["DonXinViec"].Header.VisiblePosition = 5;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["KhamsucKhoe"].Header.VisiblePosition = 6;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["HoKhau"].Header.VisiblePosition = 7;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 8;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["VanBang"].Header.VisiblePosition = 9;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GiayTamTru"].Header.VisiblePosition = 10;



            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQlNhanVien"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tenbophan"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenBiaHoSo"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["LyLich"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["DonXinViec"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["KhamsucKhoe"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["HoKhau"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["VanBang"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GiayTamTru"].CellActivation = Activation.NoEdit;


            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQlNhanVien"].Width = 100;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tenbophan"].Width = 120;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenBiaHoSo"].Width = 100;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["LyLich"].Width = 100;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["DonXinViec"].Width = 100;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["KhamsucKhoe"].Width = 100;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["HoKhau"].Width = 100;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["VanBang"].Width = 100;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GiayTamTru"].Width = 100;

        }

        #endregion

        #region Event

        private void tlslblTimNhanVien_Click(object sender, EventArgs e)
        {
            this.Load_Dich();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Process
        #endregion

    }
}