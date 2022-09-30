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
    public partial class frmTapHopChiPhiTheoThuLao_New : Form
    {
        KyTinhLuongList _kyTinhLuongList;
        ChiThuLaoList _chiThuLaoList;
        string _duLieu = "";
        ChungTu_ChiPhiSanXuat _ChungTu_ChiPhiSX = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();
        ChungTu_ChiPhiSanXuatList ct_cpsxlist = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
        ChiThuLaoList chiThuLaoTamList = ChiThuLaoList.NewChiThuLaoList();
        ChungTu_ChiPhiSanXuatList _ChungTu_ChiPhiSXList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
        public Boolean _isSave = false;
        ChiThuLaoList _chiThuLaoList_DaChon = frmBangKe_New._chiThuLaoList_DaChon;

        public frmTapHopChiPhiTheoThuLao_New()
        {
            InitializeComponent();

            _ChungTu_ChiPhiSXList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
            chiThuLaoTamList = ChiThuLaoList.NewChiThuLaoList();
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
            //Chuyển focus để đảm bảo dữ liệu đã được chọn
            cbKyTinhLuong.Focus();

            ChiThuLaoList _chiThuLaoMoiNhatList = ChiThuLaoList.NewChiThuLaoList();
            ChungTu_ChiPhiSanXuatList  _ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
            int _bienTam = 0;
            int _bien = 0;
            bool daCoChiThuLao = false;
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

                    //lay chung tu chi phi san xuat
                    _ChungTu_ChiPhiSX = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();
                    _ChungTu_ChiPhiSX.MaChuongTrinh = ctl.MaChuongTrinh;
                    _ChungTu_ChiPhiSX.SoTien = ctl.SoTien;
                    if (ctl.LoaiNV == true)
                    {
                        //Lấy mã tiểu mục bởi mã quản lý (nhân viên thì lấy mã quản lý 7019)
                        TieuMucNganSach tieuMucNganSach = TieuMucNganSach.GetTieuMucNganSachByMaQuanLy("7019");

                        if (tieuMucNganSach != null)
                        {
                            ButToanMucNganSach butToanMucNganSach = ButToanMucNganSach.NewButToanMucNganSach();
                            butToanMucNganSach.MaTieuMucNganSach = tieuMucNganSach.MaTieuMuc;
                            butToanMucNganSach.SoTien = ctl.SoTien;
                            butToanMucNganSach.DienGiai = "Quyết toán chương trình " + ctl.TenChuongTrinh.ToUpper() + " cho nhân viên";
                            _ChungTu_ChiPhiSX.ButtoanMucNganSachList.Add(butToanMucNganSach);
                        }
                    }
                    else
                    {
                        //Lấy mã tiểu mục bởi mã quản lý (cộng tác viên thì lấy mã quản lý 7018)
                        TieuMucNganSach tieuMucNganSach = TieuMucNganSach.GetTieuMucNganSachByMaQuanLy("7018");

                        if (tieuMucNganSach != null)
                        {
                            ButToanMucNganSach butToanMucNganSach = ButToanMucNganSach.NewButToanMucNganSach();
                            butToanMucNganSach.MaTieuMucNganSach = tieuMucNganSach.MaTieuMuc;
                            butToanMucNganSach.SoTien = ctl.SoTien;
                            butToanMucNganSach.DienGiai = "Quyết toán chương trình " + ctl.TenChuongTrinh.ToUpper() + " cho cộng tác viên";
                            _ChungTu_ChiPhiSX.ButtoanMucNganSachList.Add(butToanMucNganSach);
                        }
                    }
                    _ChungTu_ChiPhiSXList.Add(_ChungTu_ChiPhiSX);


                    //Lưu vết lại để tiến hành cập nhật mã chứng từ chi phí trong thù lao chương trình và thù lao nhân viên ngoài đài          
                    foreach (ChiThuLao item in _chiThuLaoList_DaChon)
                    {
                        if (item.MaBoPhanGui == ctl.MaBoPhanGui && item.MaChuongTrinh == ctl.MaChuongTrinh && item.SoTien == ctl.SoTien && item.LoaiNV == ctl.LoaiNV && item.SoDNCK == ctl.SoDNCK)
                        {
                            daCoChiThuLao = true;
                        }
                    }

                    if (daCoChiThuLao == false)
                    {
                        _chiThuLaoList_DaChon.Add(ctl);
                    }
                    daCoChiThuLao = false;
                }
            }

            ///Nếu cùng chương trình thì sum số tiền lại 
           foreach(ChungTu_ChiPhiSanXuat itemChiPhiSanXuat in _ChungTu_ChiPhiSXList)
           {
               foreach(ChungTu_ChiPhiSanXuat _itemChiPhiSanXuat in _ChiPhiSanXuatList )
               {
                   //Nếu đã có trong danh sach thì cộng số tiền lại
                   if (_itemChiPhiSanXuat.MaChuongTrinh == itemChiPhiSanXuat.MaChuongTrinh)
                   {
                       _itemChiPhiSanXuat.SoTien += itemChiPhiSanXuat.SoTien;

                       //Nếu cùng bút toán mục ngân sách thì cộng số tiền lại
                       if ( itemChiPhiSanXuat.ButtoanMucNganSachList[0].MaTieuMucNganSach == _itemChiPhiSanXuat.ButtoanMucNganSachList[0].MaTieuMucNganSach)
                       {
                           _itemChiPhiSanXuat.ButtoanMucNganSachList[0].SoTien += itemChiPhiSanXuat.ButtoanMucNganSachList[0].SoTien;
                       }
                       else if (_itemChiPhiSanXuat.ButtoanMucNganSachList.Count >1 && itemChiPhiSanXuat.ButtoanMucNganSachList[0].MaTieuMucNganSach == _itemChiPhiSanXuat.ButtoanMucNganSachList[1].MaTieuMucNganSach)
                       {
                           _itemChiPhiSanXuat.ButtoanMucNganSachList[1].SoTien += itemChiPhiSanXuat.ButtoanMucNganSachList[0].SoTien;
               
                       }
                       else // Nếu khác bút toán mục ngân sách sách tạo mới bút toán mục ngân sach1
                       {
                           ButToanMucNganSach butToanMucNganSach = ButToanMucNganSach.NewButToanMucNganSach();
                           butToanMucNganSach.MaTieuMucNganSach = itemChiPhiSanXuat.ButtoanMucNganSachList[0].MaTieuMucNganSach;
                           butToanMucNganSach.SoTien += itemChiPhiSanXuat.ButtoanMucNganSachList[0].SoTien;
                           butToanMucNganSach.DienGiai = itemChiPhiSanXuat.ButtoanMucNganSachList[0].DienGiai;
                           _itemChiPhiSanXuat.ButtoanMucNganSachList.Add(butToanMucNganSach);
                       }
                       _bienTam = 1;
                   }
               }

               if (_bienTam == 0)//Nếu chưa có trong danh sách thì mới thêm váo
               {
                   _ChiPhiSanXuatList.Add(itemChiPhiSanXuat);
               }

               _bienTam = 0;
           }
           
           frmChiPhiSanXuatChuongTrinh_New._chungTu_ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
           frmChiPhiSanXuatChuongTrinh_New._chungTu_ChiPhiSanXuatList = _ChiPhiSanXuatList;
           frmBangKe_New._chiThuLaoList_DaChon = _chiThuLaoList_DaChon;
           frmPhieuChi_New._chiThuLaoList_DaChon = _chiThuLaoList_DaChon;
           frmPhieuThu_New._chiThuLaoList_DaChon = _chiThuLaoList_DaChon;
           _isSave = true;
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
                        if (!ugrData.Rows[i].Hidden == true && (ugrData.Rows[i].Cells["SoDNCK"].Value.ToString().Trim() == _duLieu.Trim() || ugrData.Rows[i].Cells["NgayDNCK"].Value.ToString().Trim() == _duLieu.Trim() || ugrData.Rows[i].Cells["TenBoPhanGui"].Value.ToString().Trim() == _duLieu.Trim() || ugrData.Rows[i].Cells["TenChuongTrinh"].Value.ToString().Trim() == _duLieu.Trim() || ugrData.Rows[i].Cells["MaGiayXacNhanQL"].Value.ToString().Trim() == _duLieu.Trim() || ugrData.Rows[i].Cells["TenLoaiNhanVien"].Value.ToString().Trim() == _duLieu.Trim()))
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
            ugrData.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            ugrData.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            ugrData.DisplayLayout.Bands[0].Columns["Chon"].Width = 60;

            ugrData.DisplayLayout.Bands[0].Columns["SoDNCK"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["SoDNCK"].Header.Caption = "Số Đề Nghị";
            ugrData.DisplayLayout.Bands[0].Columns["SoDNCK"].Header.VisiblePosition = 1;
            ugrData.DisplayLayout.Bands[0].Columns["SoDNCK"].Width = 160;


            ugrData.DisplayLayout.Bands[0].Columns["NgayDNCK"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["NgayDNCK"].Header.Caption = "Ngày Đề Nghị";
            ugrData.DisplayLayout.Bands[0].Columns["NgayDNCK"].Header.VisiblePosition = 2;
            ugrData.DisplayLayout.Bands[0].Columns["NgayDNCK"].Width = 110;

            ugrData.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.Caption = "Bộ Phận Nhập";
            ugrData.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.VisiblePosition = 3;
            ugrData.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Width = 140;

            ugrData.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Mã Chương Trình";
            ugrData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 4;
            ugrData.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 100;

            ugrData.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            ugrData.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 5;
            ugrData.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 150;

            ugrData.DisplayLayout.Bands[0].Columns["MaGiayXacNhanQL"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["MaGiayXacNhanQL"].Header.Caption = "Số Giấy XN";
            ugrData.DisplayLayout.Bands[0].Columns["MaGiayXacNhanQL"].Header.VisiblePosition = 6;
            ugrData.DisplayLayout.Bands[0].Columns["MaGiayXacNhanQL"].Width = 80;

            //ugrData.DisplayLayout.Bands[0].Columns["NgayXacNhan"].Hidden = false;
            //ugrData.DisplayLayout.Bands[0].Columns["NgayXacNhan"].Header.Caption = "Ngày XN";
            //ugrData.DisplayLayout.Bands[0].Columns["NgayXacNhan"].Header.VisiblePosition = 4;
            //ugrData.DisplayLayout.Bands[0].Columns["NgayXacNhan"].Width = 80;

            ugrData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            ugrData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 7;
            ugrData.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;

            ugrData.DisplayLayout.Bands[0].Columns["TenLoaiNhanVien"].Hidden = false;
            ugrData.DisplayLayout.Bands[0].Columns["TenLoaiNhanVien"].Header.Caption = "Loại NV";
            ugrData.DisplayLayout.Bands[0].Columns["TenLoaiNhanVien"].Header.VisiblePosition = 8;
            ugrData.DisplayLayout.Bands[0].Columns["TenLoaiNhanVien"].Width = 80;

            ugrData.DisplayLayout.Bands[0].Columns["NgayDNCK"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        }

        private void ugrData_FilterCellValueChanged(object sender, FilterCellValueChangedEventArgs e)
        {
            _duLieu = "";
            UltraGridFilterCell filterCell = e.FilterCell;
            EmbeddableEditorBase editor = filterCell.EditorResolved;

            if (filterCell.Value !=null && editor.IsValid)
            {
                _duLieu = editor.Value.ToString();
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmChiPhiSanXuatChuongTrinh_New._chungTu_ChiPhiSanXuatList = null;
        }

        private void frmTapHopChiPhiTheoThuLao_New_FormClosed(object sender, FormClosedEventArgs e)
        {
 
        }
    }
}
