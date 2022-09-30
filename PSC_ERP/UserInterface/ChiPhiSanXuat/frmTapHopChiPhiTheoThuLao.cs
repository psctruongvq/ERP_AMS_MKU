using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmTapHopChiPhiTheoThuLao : Form
    {
        KyTinhLuongList _kyTinhLuongList;
        ChiThuLaoList _chiThuLaoList;
        string _duLieu = "";
        ChungTu_ChiPhiSanXuat _ChungTu_ChiPhiSX = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();
        ChungTu_ChiPhiSanXuatList ct_cpsxlist = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
        ChiThuLaoList chiThuLaoTamList = ChiThuLaoList.NewChiThuLaoList();
        ChungTu_ChiPhiSanXuatList _ChungTu_ChiPhiSXList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();

        public frmTapHopChiPhiTheoThuLao(ChungTu_ChiPhiSanXuatList _chungTuChiPhiSXList)
        {
            InitializeComponent();

            _ChungTu_ChiPhiSXList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
            chiThuLaoTamList = ChiThuLaoList.NewChiThuLaoList();
            ct_cpsxlist = _chungTuChiPhiSXList;
        }

        private void button_Xem_Click(object sender, EventArgs e)
        {
            _chiThuLaoList = ChiThuLaoList.GetChiThuLaoListByChiPhiSanXuatTheoThang(Convert.ToInt32(cbKyTinhLuong.Value), dateTimePicker_TuNgay.Value.Date, dateTimePicker_DenNgay.Value.Date, ERP_Library.Security.CurrentUser.Info.UserID);

            if (_chiThuLaoList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            BindingSource_ChiThuLaoList.DataSource = _chiThuLaoList;
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

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.ActiveRow != null)
            {
                KyTinhLuong kyluong = KyTinhLuong.GetKyTinhLuong(Convert.ToInt32(cbKyTinhLuong.ActiveRow.Cells["MaKy"].Value));
                dateTimePicker_TuNgay.Value = kyluong.NgayBatDau;
                dateTimePicker_DenNgay.Value = kyluong.NgayKetThuc;
            }
        }


        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            ChiThuLaoList _chiThuLaoMoiNhatList = ChiThuLaoList.NewChiThuLaoList();
            ChungTu_ChiPhiSanXuatList  _ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
            int _bienTam = 0;
            int _bien = 0;
            if (_chiThuLaoList == null)
            {
                MessageBox.Show("Chưa có dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ChiThuLao ctl in _chiThuLaoList)
            {
                if (ctl.Chon == true)
                {
                    _bien = 1;
                }
            }

            if (_bien == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (ChiThuLao ctl in _chiThuLaoList)
            {
                if (ctl.Chon == true)
                {
                    ctl.MaLoaiKinhPhi = 1;
                    ctl.MaBoPhanNhan = ctl.MaBoPhanGui;

                    //lay chi thu lao moi nhat dung de loc du lieu
                    _chiThuLaoMoiNhatList.Add(ctl);

                    //lay chung tu chi phi san xuat
                    _ChungTu_ChiPhiSX = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();
                    _ChungTu_ChiPhiSX.MaChuongTrinh = ctl.MaChuongTrinh;
                    _ChungTu_ChiPhiSX.SoTien = ctl.SoTien;
                    _ChungTu_ChiPhiSXList.Add(_ChungTu_ChiPhiSX);
                }
            }

            ///Nhom cac chi phi san xuat lai voi nhau           
           foreach(ChungTu_ChiPhiSanXuat itemChiPhiSanXuat in _ChungTu_ChiPhiSXList)
           {
               foreach(ChungTu_ChiPhiSanXuat _itemChiPhiSanXuat in _ChiPhiSanXuatList )
               {
                   if (_itemChiPhiSanXuat.MaChuongTrinh == itemChiPhiSanXuat.MaChuongTrinh)
                   {
                       _bienTam = 1;
                   }
               }

               if (_bienTam == 0)
               {
                   foreach (ChiThuLao itemChiThuLao in _chiThuLaoMoiNhatList)
                   {
                       if (itemChiPhiSanXuat.MaChuongTrinh == itemChiThuLao.MaChuongTrinh)
                       {
                           itemChiPhiSanXuat.ChiThuLaoList.Add(itemChiThuLao);
                       }
                   }

                   _ChiPhiSanXuatList.Add(itemChiPhiSanXuat);
               }

               _bienTam = 0;
           }
           //Gan cac chi thu lao vao chi phi san xuat
           int _bien_Tam = 0;
           foreach (ChungTu_ChiPhiSanXuat item in _ChiPhiSanXuatList)
           {
              ChiThuLaoList chiThuLaoList = ChiThuLaoList.NewChiThuLaoList();
               decimal _soTien = 0;
               foreach (ChiThuLao itemChiThuLao in item.ChiThuLaoList)
               {
                   foreach (ChiThuLao _itemChiThuLao in chiThuLaoList)
                   {
                       if (_itemChiThuLao.MaBoPhanNhan == itemChiThuLao.MaBoPhanNhan)
                       {
                           _bien_Tam = 1;

                           _itemChiThuLao.SoTien += itemChiThuLao.SoTien;
                       }
                   }
                   if (_bien_Tam == 0)
                   {
                       item.ChiThuLaoList = ChiThuLaoList.NewChiThuLaoList();
                       chiThuLaoList.Add(itemChiThuLao);
                   }

                   _bien_Tam = 0;
                   _soTien += itemChiThuLao.SoTien;
               }

               item.ChiThuLaoList = ChiThuLaoList.NewChiThuLaoList();
               item.SoTien = _soTien;
               item.ChiThuLaoList = chiThuLaoList;
           }

           frmChiPhiSanXuatChuongTrinh._chungTu_ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
           frmChiPhiSanXuatChuongTrinh._chungTu_ChiPhiSanXuatList = _ChiPhiSanXuatList;

            this.Close();
        }
        private void Check_TatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (_duLieu.Trim().CompareTo("") != 0 && _duLieu.Trim().CompareTo("(NonBlanks)") != 0)
            {
                if (Check_TatCa.Checked == true)
                {
                    for (int i = 0; i < ugrData.Rows.Count; i++)
                    {
                        if (!ugrData.Rows[i].Hidden == true && (ugrData.Rows[i].Cells["TenBoPhanGui"].Value.ToString().Trim() == _duLieu.Trim() || ugrData.Rows[i].Cells["TenChuongTrinh"].Value.ToString().Trim() == _duLieu.Trim() || ugrData.Rows[i].Cells["MaGiayXacNhanQL"].Value.ToString().Trim() == _duLieu.Trim() || ugrData.Rows[i].Cells["TenLoaiNhanVien"].Value.ToString().Trim() == _duLieu.Trim()))
                        {
                            ugrData.Rows[i].Cells["Chon"].Value = (object)true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ugrData.Rows.Count; i++)
                    {
                        ugrData.Rows[i].Cells["Chon"].Value = (object)false;
                    }
                }

                _duLieu = "";
            }
            else
            {

                if (Check_TatCa.Checked == true)
                {
                    for (int i = 0; i < ugrData.Rows.Count; i++)
                    {
                        if (!ugrData.Rows[i].Hidden == true)
                        {
                            ugrData.Rows[i].Cells["Chon"].Value = (object)true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ugrData.Rows.Count; i++)
                    {
                        ugrData.Rows[i].Cells["Chon"].Value = (object)false;
                    }
                }
            }
        }

        private void ugrData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.ugrData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.Format = "#,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }

            // ugrData.DisplayLayout.Bands[0].Columns["Chon"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;

            e.Layout.Override.TemplateAddRowAppearance.BackColor = Color.FromArgb(245, 250, 255);
            e.Layout.Override.TemplateAddRowAppearance.ForeColor = SystemColors.GrayText;
            e.Layout.Override.AddRowAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.AddRowAppearance.ForeColor = Color.Blue;
            e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = SystemColors.Control;
            e.Layout.Override.TemplateAddRowPromptAppearance.ForeColor = Color.Maroon;
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            ugrData.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chon";
            ugrData.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            ugrData.DisplayLayout.Bands[0].Columns["Chon"].Width = 60;

            ugrData.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.Caption = "Bộ Phận Nhập";
            ugrData.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.VisiblePosition = 1;
            ugrData.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Width = 140;

            ugrData.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Mã Chương Trình";
            ugrData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 2;
            ugrData.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 100;

            ugrData.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            ugrData.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 3;
            ugrData.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 150;

            ugrData.DisplayLayout.Bands[0].Columns["MaGiayXacNhanQL"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["MaGiayXacNhanQL"].Header.Caption = "Số Giấy XN";
            ugrData.DisplayLayout.Bands[0].Columns["MaGiayXacNhanQL"].Header.VisiblePosition = 4;
            ugrData.DisplayLayout.Bands[0].Columns["MaGiayXacNhanQL"].Width = 80;

            //ugrData.DisplayLayout.Bands[0].Columns["NgayXacNhan"].Hidden = false;
            //ugrData.DisplayLayout.Bands[0].Columns["NgayXacNhan"].Header.Caption = "Ngày XN";
            //ugrData.DisplayLayout.Bands[0].Columns["NgayXacNhan"].Header.VisiblePosition = 4;
            //ugrData.DisplayLayout.Bands[0].Columns["NgayXacNhan"].Width = 80;


            ugrData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            ugrData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 5;
            ugrData.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;


            ugrData.DisplayLayout.Bands[0].Columns["SoTienDaNhap"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["SoTienDaNhap"].Header.Caption = "Tiền Thuế";
            ugrData.DisplayLayout.Bands[0].Columns["SoTienDaNhap"].Header.VisiblePosition = 6;
            ugrData.DisplayLayout.Bands[0].Columns["SoTienDaNhap"].Width = 80;


            ugrData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Còn Lại";
            ugrData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 7;
            ugrData.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 100;


            ugrData.DisplayLayout.Bands[0].Columns["TenLoaiNhanVien"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["TenLoaiNhanVien"].Header.Caption = "Loại NV";
            ugrData.DisplayLayout.Bands[0].Columns["TenLoaiNhanVien"].Header.VisiblePosition = 8;
            ugrData.DisplayLayout.Bands[0].Columns["TenLoaiNhanVien"].Width = 80;
        }

        private void ugrData_FilterCellValueChanged(object sender, FilterCellValueChangedEventArgs e)
        {
            _duLieu = "";
            UltraGridFilterCell filterCell = e.FilterCell;
            EmbeddableEditorBase editor = filterCell.EditorResolved;

            if (editor.IsValid)
            {
                _duLieu = editor.Value.ToString();
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmChiPhiSanXuatChuongTrinh._chungTu_ChiPhiSanXuatList = null;
        }
    }
}
