using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
namespace PSC_ERP
{//lan
    public partial class frmCopyThuLao : Form
    {

        ChiThuLaoList _chiThuLaoList;
        ChuongTrinhList _chuongTrinhList;
        KyTinhLuongList _kyTinhLuongList;
        ChiThuLao _chiThuLao_NhanVienList = ChiThuLao.NewChiThuLao();
        GiayXacNhanChuongTrinhList _giayXacNhanChuongTrinhList = GiayXacNhanChuongTrinhList.NewGiayXacNhanChuongTrinhList();
        ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
        ChiTietGiayXacNhan chiTietGXN = ChiTietGiayXacNhan.NewChiTietGiayXacNhan();

          public bool IsOK = false;
          public   int maKyTinhluong = 0;
          public  int maChuongTrinh = 0;      
          public long maChiThuLao = 0;
          public int maChiTietGiayXacNhan = 0;
          public int maGiayXacNhan = 0;
          public string tenChuongTrinh = string.Empty;
          public int maNguonChuongTrinh = 0;
          public string tenNguonChuongTrinh = string.Empty;
          public string tenGiayXacNhan = string.Empty;
          public DateTime ngayLap = DateTime.Today.Date;
          public bool tinhDangPhi = false;
          public bool thucNhan = true;
          public bool nhapHo = false;
          public string tenChungTu = string.Empty;
          private void LoadControls()
          {
              _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
              this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

              _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
              this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;

              _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
              ChiTietGiayXacNhan itemAdd = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0, "Không Có Giấy Xác Nhận");
              _chiTietGiayXacNhanList.Insert(0, itemAdd);
              this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;


              _chiThuLaoList = ChiThuLaoList.GetChiThuLaoListByUser(ERP_Library.Security.CurrentUser.Info.UserID);
              ChiThuLao itemChiTL = ChiThuLao.NewChiThuLao("Không Có Chứng Từ");
              _chiThuLaoList.Insert(0, itemChiTL);
              this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;
          }
        public frmCopyThuLao()
        {
            InitializeComponent();            
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);            
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChiThuLaoList);
            LoadControls();
        }
         private void frmThuLaoChuongTrinh_Load(object sender, EventArgs e)
        {
           
        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.IsOK = false;
            this.Close();
        }
        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhluong = (int)cbKyTinhLuong.Value;

            }
        }
        private void cbKyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
            foreach (UltraGridColumn col in this.cbKyTinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = cbKyTinhLuong.Width;
        }
        private void cbChungTu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChungTu, "SoChungTu");
            foreach (UltraGridColumn col in this.cbChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Phiếu Chi";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 120;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.Caption = "Tên Bộ Phận Nhận";
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Width = 150;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.VisiblePosition = 1;

            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.Caption = "Tên Bộ Phận Gửi";
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Width = 150;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.VisiblePosition = 2;

            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 200;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 3;

            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Width = 80;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 4;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 60;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 5;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";

            cbChungTu.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            cbChungTu.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 80;
            cbChungTu.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 6;

            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Width = 60;
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Header.VisiblePosition = 7;

        }

        private void cbChungTu_KeyDown(object sender, KeyEventArgs e)
        {
            FilterCombo _filter = new FilterCombo(cbChungTu, "SoChungTu");
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung hamdungchung = new HamDungChung();
            hamdungchung.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
        }

      

        private void cbChiTietGiayXacNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //HamDungChung.Combobox_InitializeLayout(sender, e);
            //FilterCombo f = new FilterCombo(cbChiTietGiayXacNhan, "TenGiayXacNhan");
        }

      

        private void cbChiTietGiayXacNhan_ValueChanged_1(object sender, EventArgs e)
        {
           
            if (cbChiTietGiayXacNhan.Value!=null)
            {
                maChiTietGiayXacNhan = Convert.ToInt32(cbChiTietGiayXacNhan.Value);
                ChiTietGiayXacNhan ct = ChiTietGiayXacNhan.GetChiTietGiayXacNhan(maChiTietGiayXacNhan);
                GiayXacNhanChuongTrinh gxn = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(ct.MaGiayXacNhan);
                cmbu_ChuongTrinh.Value = gxn.MaChuongTrinh;
            }
           
            
        }

        private void cbChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (cbChungTu.Value != null)
            {

                maChiThuLao = Convert.ToInt64(cbChungTu.Value);
                ChiThuLao ctl = ChiThuLao.GetChiThuLao(maChiThuLao);
                cmbu_ChuongTrinh.Value = ctl.MaChuongTrinh;
               
            }       

        }

        private void cbChiTietGiayXacNhan_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChiTietGiayXacNhan, "TenGiayXacNhan");
            foreach (UltraGridColumn col in this.cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.Caption = "Tên Giấy Xác Nhận";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.VisiblePosition = 0;

            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";            
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "###,###,###,###,###";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 2;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Header.Caption = "Đơn Vị Gửi";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDi"].Header.VisiblePosition = 3;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Header.Caption = "Đơn Vị Nhận";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanDen"].Header.VisiblePosition = 4;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 5;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.Caption = "Nhập Hộ";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.VisiblePosition = 6;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["HoanTat"].Header.VisiblePosition = 7;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            cbChiTietGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 8;
        }

        private void chbTinhDangPhi_CheckedChanged(object sender, EventArgs e)
        {
            tinhDangPhi = chbTinhDangPhi.Checked;
        }

        private void cbDinhMuc_CheckedChanged(object sender, EventArgs e)
        {
            thucNhan = cbDinhMuc.Checked;
        }

        private void dateTimePicker_NgayLap_ValueChanged(object sender, EventArgs e)
        {
            ngayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maChiTietGiayXacNhan != 0 )
            {
                ChiTietGiayXacNhan ct = ChiTietGiayXacNhan.GetChiTietGiayXacNhan(maChiTietGiayXacNhan);
                GiayXacNhanChuongTrinh gxn = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(ct.MaGiayXacNhan);
                maChuongTrinh = gxn.MaChuongTrinh;
                nhapHo = ct.DuocNhapHo;
                maChiTietGiayXacNhan = ct.MaChiTietGiayXacNhan;
                maGiayXacNhan = gxn.MaGiayXacNhan;
                tenGiayXacNhan = gxn.TenGiayXacNhan;
                maChiThuLao = 0;
                tenChungTu = string.Empty;
            }
             if ( maChiThuLao != 0)
            {
                ChiThuLao ctl = ChiThuLao.GetChiThuLao(maChiThuLao);
                maChuongTrinh = ctl.MaChuongTrinh;
                tenChungTu = ctl.SoChungTu;
                maGiayXacNhan = 0;
                maChiTietGiayXacNhan = 0;                 
                tenGiayXacNhan = string.Empty;
                 
            }
            if (maChiThuLao != 0 && maGiayXacNhan != 0)
            {
                int _maChuongTrinh = ChiThuLao.GetChiThuLao(maChiThuLao).MaChuongTrinh;
                int _maChuongTrinh1 = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(maGiayXacNhan).MaChuongTrinh;
                if (_maChuongTrinh != _maChuongTrinh1)
                {
                    MessageBox.Show("Chứng Từ và Giấy Xác Nhận có chương trình không giống nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (maChuongTrinh==0||maKyTinhluong==0)
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ChuongTrinh ctr= ChuongTrinh.GetChuongTrinh(maChuongTrinh);
            tenChuongTrinh = ctr.TenChuongTrinh;
            maNguonChuongTrinh = ctr.MaNguon;
            tenNguonChuongTrinh = ctr.TenNguon;

            this.IsOK = true;
            this.Close();
        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_ChuongTrinh, "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;
        }

        private void cmbu_ChuongTrinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.Value != null)
                maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.Value);
        }
    }
}
