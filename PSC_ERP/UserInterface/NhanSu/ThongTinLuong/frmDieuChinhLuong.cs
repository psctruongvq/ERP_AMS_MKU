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
    public partial class frmDieuChinhLuong : Form
    {
        BoPhanList _Bophan;
        KyTinhLuongList _kyTinhLuong;
        DieuChinhLuongList _dieuChinhLuongList;
        ThongTinNhanVienTongHopList _nhanVien;
        LoaiDieuChinhLuongList _LoaiDC;
        Util util = new Util();

        public frmDieuChinhLuong()
        {
            InitializeComponent();
            this.Load_Source();
        }

        #region Load

        private void cmbu_kyluong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_kyluong.DisplayLayout.Bands[0],
          new string[2] { "Tenky", "maky" },
          new string[2] { "Tháng lương", "Mã số" },
          new int[2] { cmbu_kyluong.Width, 90 },
          new Control[2] { null, null },
          new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
          new bool[2] { false, false });
            cmbu_kyluong.DisplayLayout.Bands[0].Columns["Tenky"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_kyluong.DisplayLayout.Bands[0].Columns["maky"].Hidden = true;
        }

        private void grdu_DieuChinhLuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["maloaidieuchinh"].Hidden = true;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["maky"].Hidden = true;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["manhanvien"].Hidden = true;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["madieuchinh"].Hidden = true;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["Congtruluong"].Hidden = true;

            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Số";
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Họ Tên";
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["Sotiendieuchinh"].Header.Caption = "Số Tiền";
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["TenLoaiDieuChinh"].Header.Caption = "Loại ĐC";
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["Congtru"].Header.Caption = "Hình Thức";


            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 0;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["Sotiendieuchinh"].Header.VisiblePosition = 2;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["TenLoaiDieuChinh"].Header.VisiblePosition = 3;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 4;

            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 100;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 160;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["Sotiendieuchinh"].Width = 100;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["TenLoaiDieuChinh"].Width = 150;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 300;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["CongTru"].Width = 100;


            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["Sotiendieuchinh"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["TenLoaiDieuChinh"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["GhiChu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["CongTru"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;


            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].CellActivation = Activation.NoEdit;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellActivation = Activation.NoEdit;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["TenLoaiDieuChinh"].CellActivation = Activation.NoEdit;
            grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns["CongTru"].CellActivation = Activation.NoEdit;

            foreach (UltraGridColumn col in this.grdu_DieuChinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;

                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn";
                    col.Format = "###,###,###,###,###";
                }
            }
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_Bophan.DisplayLayout.Bands[0],
            new string[2] { "Tenbophan", "mabophan" },
            new string[2] { "Bộ Phận", "Mã bộ phận" },
            new int[2] { cmbu_Bophan.Width, 90 },
            new Control[2] { null, null },
            new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[2] { false, false });
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["Tenbophan"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["mabophan"].Hidden = true;
        }

        private void Load_Source()
        {
            _Bophan = BoPhanList.GetBoPhanList();
            BindS_BoPhan.DataSource = _Bophan;
            _kyTinhLuong = KyTinhLuongList.GetKyTinhLuongList();
            BindS_Kyluong.DataSource = _kyTinhLuong;
            _LoaiDC = LoaiDieuChinhLuongList.GetLoaiDieuChinhLuongList();
            BindS_LoaiDC.DataSource = _LoaiDC;
        }

        private void Load_Nguon()
        {
            if (cmbu_kyluong.ActiveRow != null)
            {
                if (cmbu_Bophan.ActiveRow != null)
                {
                    if (txtu_NhanVien.Text == "")
                    {
                        _nhanVien = ThongTinNhanVienTongHopList.GetThongTinNhanVienNghiTongHopListDieuChinhLuong_BophanAndKyLuong((int)cmbu_Bophan.Value, (int)cmbu_kyluong.Value);
                    }
                    else
                    {
                        _nhanVien = ThongTinNhanVienTongHopList.GetThongTinNhanVienNghiTongHopListDieuChinhLuong_BophanAndKyLuongNV((int)cmbu_Bophan.Value, (int)cmbu_kyluong.Value, txtu_NhanVien.Text);
                    }
                    lstvDsnguon.Items.Clear();
                    for (int i = 0; i < _nhanVien.Count; i++)
                    {
                        ListViewItem lstnguonitem;
                        lstnguonitem = lstvDsnguon.Items.Add(_nhanVien[i].MaNhanVien.ToString());
                        lstnguonitem.SubItems.Add(_nhanVien[i].MaQLNhanVien.ToString());
                        lstnguonitem.SubItems.Add(_nhanVien[i].TenNhanVien.ToString());
                        lstnguonitem.SubItems.Add(_nhanVien[i].TenChucVu.ToString());                        
                    }
                    lblTSODS.Text = "Tổng Số : " + _nhanVien.Count;
                }
            }
        }

        private void Load_Dich()
        {
            if (cmbu_kyluong.ActiveRow != null)
            {
                if (cmbu_Bophan.ActiveRow != null)
                {
                    _dieuChinhLuongList=DieuChinhLuongList.GetDieuChinhLuongList((int)cmbu_Bophan.Value,(int)cmbu_kyluong.Value);
                    BindS_DCLuong.DataSource = _dieuChinhLuongList;                    
                }
            }
        }
        #endregion

        #region Event
   
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            int maky=0;
            decimal Sotien=0;
            int maLoaiDC=0;
            string Ghichu="";
            bool Congtru=true;
            if (cmbu_kyluong.ActiveRow==null)
            {
                return ;
            }
            if (cmbu_LoaiDC.Value == null)
            {
                return;
            }
            if (cmbu_CongTru.Value == null)
            {
                return;
            }
            maky = (int)cmbu_kyluong.Value;
            Congtru = (bool)cmbu_CongTru.Value;
            maLoaiDC =(int) cmbu_LoaiDC.Value;
            Ghichu = txt_GhiChu.Text;
            Sotien = Convert.ToDecimal(cru_SoTien.Value);
            for (int i = 0; i < lstvDsnguon.Items.Count; i++)
            {
                long manhanvien=Convert.ToInt64(lstvDsnguon.Items[i].Text);
                if (lstvDsnguon.Items[i].Checked)
                {
                    DieuChinhLuong.ThemDieuChinh(maky,manhanvien , Sotien, Congtru, maLoaiDC, Ghichu);
                }
            }
            this.Load_Dich();
            this.Load_Nguon();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _dieuChinhLuongList.ApplyEdit();
                _dieuChinhLuongList.Save();
                MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (ApplicationException)
            {

            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Nguon();
            this.Load_Dich();
        }

        private void txtu_NhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Load_Nguon();
                this.Load_Dich();
            }
        }

        private void chkNguon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNguon.Checked == true)
            {
                for (int i = 0; i < lstvDsnguon.Items.Count; i++)
                {
                    lstvDsnguon.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < lstvDsnguon.Items.Count; i++)
                {
                    lstvDsnguon.Items[i].Checked = false;
                }
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DieuChinhLuong.ActiveRow != null)
            {
                grdu_DieuChinhLuong.DeleteSelectedRows();
            }
        }
        #endregion

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {

        }

        #region Process
     
        #endregion

    }
}