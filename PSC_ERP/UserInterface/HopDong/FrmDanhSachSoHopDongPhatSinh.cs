using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;

namespace PSC_ERP
{
    public partial class FrmDanhSachSoHopDongPhatSinh : DevExpress.XtraEditors.XtraForm
    {
        HopDongThuChiList _hopDongThuChiList = HopDongThuChiList.NewHopDongMuaBanList();
        long _maHopDong;
        int _maBoPhanChuQuan = 0;
        long _maDoiTac = 0;
        byte _loai;//0:admin; 1:user; 2:duaHopDongPS ve HD chinh thuc

        public FrmDanhSachSoHopDongPhatSinh()
        {
            InitializeComponent();


        }

        public FrmDanhSachSoHopDongPhatSinh(byte loai)
        {
            InitializeComponent();
            _loai = loai;//If Loai=2:Dua Hop Dong PS ve Hop Dong Chinh Thuc
            KhoiTao();
            DesignGridView_Loai();
            this.Text = "Danh Sách Số Hợp Đồng Phát Sinh";
            btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btn_LapHopDong.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btn_LapHopDong.Enabled = false;

        }

        public long MaHopDong
        {
            get { return _maHopDong; }
        }

        public void ShowDanhSachSoHopDongPhatSinh_Admin()
        {
            _loai = 0;//admin
            KhoiTao();
            DesignGridView_Admin();
            this.Text = "Danh Sách Số Hợp Đồng Phát Sinh";
            btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btn_LapHopDong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.Show();

        }

        public void ShowDanhSachSoHopDongPhatSinh_User()
        {
            _loai = 1;//user
            KhoiTao();
            DesignGridView_User();
            this.Text = "Danh Sách Số Hợp Đồng Phát Sinh";
            btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btn_LapHopDong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.Show();
        }
        private void KhoiTao()
        {
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            DoiTacList _doiTacList = DoiTacList.GetDoiTacList("", 0);
            DoiTac _doiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _doiTacList.Insert(0, _doiTac);
            doiTacListBindingSource.DataSource = _doiTacList;

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            HopDongThuChiList_bindingSource.DataSource = _hopDongThuChiList;
            gridControl1.DataSource = HopDongThuChiList_bindingSource;
            if (_loai != 2)//k phai Dua Hop Dong PS ve Hop Dong Chinh Thuc
                gridControl1.ContextMenuStrip = contextMenuStrip1;
        }
        #region Function
        private void GetThongTinSearch()
        {

            if (lookUpEdit_PhongBan.EditValue != null)
            {
                _maBoPhanChuQuan = Convert.ToInt32(lookUpEdit_PhongBan.EditValue);//(int) lookUpEdit_PhongBan.EditValue;
            }
            else
            {
                _maBoPhanChuQuan = 0;
            }

            if (grdLU_MaDoiTac.EditValue != null)
            {
                _maDoiTac = Convert.ToInt64(grdLU_MaDoiTac.EditValue);// (long)grdLU_MaDoiTac.EditValue;
            }
            else
            {
                _maDoiTac = 0;
            }

        }

        private void LoadData()
        {
            GetThongTinSearch();
            if (checkEdit_Ngay.Checked == true)
            {
                _hopDongThuChiList = HopDongThuChiList.GetDanhDachSoHopDongPhatSinh(true, (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _maDoiTac, _maBoPhanChuQuan,_loai);
            }
            else
            {
                _hopDongThuChiList = HopDongThuChiList.GetDanhDachSoHopDongPhatSinh(false, (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _maDoiTac, _maBoPhanChuQuan,_loai);
            }
            HopDongThuChiList_bindingSource.DataSource = _hopDongThuChiList;
        }

        private bool LayMaHopDong()
        {
            if (KiemTraChonHopDongRow())
            {
                HopDongThuChi hopDongThuChi = gridView1.GetFocusedRow() as HopDongThuChi;
                if (hopDongThuChi != null)
                {
                    _maHopDong = hopDongThuChi.MaHopDong;
                    return true;
                }
            }
            return false;
        }

        private void LapHopDong()
        {
            if (LayMaHopDong())
            {
                this.Close();
            }
           
        }

        private void DesignGridView_Admin()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "TongTien", "MaLoaiTien", "NgayKy", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac", "DaLapHopDongString" },
                                new string[] { "Số hợp đồng", "Nội dung", "Giá trị HĐ", "Loại tiền", "Ngày ký", "Đơn vị chủ quản", "Đối tác", "Người liên lạc","Tình Trạng" },
                                             new int[] { 100, 100, 100, 75, 70, 100, 100, 100,120 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "TongTien", "MaLoaiTien", "NgayKy", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac","DaLapHopDongString" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien" }, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private void DesignGridView_User()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "TongTien", "MaLoaiTien", "NgayKy", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" },
                                new string[] { "Số hợp đồng", "Nội dung", "Giá trị HĐ", "Loại tiền", "Ngày ký", "Đơn vị chủ quản", "Đối tác", "Người liên lạc" },
                                             new int[] { 100, 100, 100, 75, 70, 100, 100, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "TongTien", "MaLoaiTien", "NgayKy", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien" }, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
        }

        private void DesignGridView_Loai()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "TongTien", "MaLoaiTien", "NgayKy", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" },
                                new string[] { "Số hợp đồng", "Nội dung", "Giá trị HĐ", "Loại tiền", "Ngày ký", "Đơn vị chủ quản", "Đối tác", "Người liên lạc" },
                                             new int[] { 100, 100, 100, 75, 70, 100, 100, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "TongTien", "MaLoaiTien", "NgayKy", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien" }, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private bool KiemTraChonHopDongRow()
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần thực hiện!");
                return false;
            }
            return true;
        }

        #endregion

        #region Event
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm frm = new XtraForm();
            frm = new FrmPhatSinhSoHopDong();
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                LoadData();
            }
        }
        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
            if (_hopDongThuChiList.Count == 0)//M
            {
                MessageBox.Show("Danh Sách Hợp đồng rỗng!");
            }
            else if (_loai == 2)//Dua Hop Dong PS ve Hop Dong Chinh Thuc
            {
                btn_LapHopDong.Enabled = true;
            }
        }

        private void GridLookUpEdit_MaDuAn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            if (_loai == 2)// Dua Hop Dong PS ve Hop Dong Chinh Thuc
            {
                LapHopDong();
            }
            else//double click de sua
            {
                //B
                if (gridView1.GetFocusedRow() != null)
                {
                    HopDongThuChi hopDongThuChi = gridView1.GetFocusedRow() as HopDongThuChi;
                    hopDongThuChi = HopDongThuChi.GetHopDongMuaBan(hopDongThuChi.MaHopDong);
                    if (hopDongThuChi.MaLoaiHopDong == 0)
                    {
                        XtraForm frm = new XtraForm();
                        frm = new FrmPhatSinhSoHopDong(hopDongThuChi);
                        //frm.ShowDialog();
                        if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        {
                            btn_Tim.PerformClick();

                        }//New
                    }
                    else
                    {
                        MessageBox.Show("Không có hiệu lực, vì Hợp Đồng này đã lập!");
                    }
                    

                }
                //E
            }
        }
        #endregion

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void btn_XuatRaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }





        private void TaoHDDuAnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonHopDongRow())
            {
                HopDongThuChi hopDongThuChi = gridView1.GetFocusedRow() as HopDongThuChi;
                hopDongThuChi = HopDongThuChi.GetHopDongMuaBan(hopDongThuChi.MaHopDong);
                if (hopDongThuChi.MaLoaiHopDong == 0)
                {
                    //
                    XtraForm frm = new XtraForm();
                    frm = new frmHopDongDuAn(hopDongThuChi, true);
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                    //
                }
                else
                {
                    MessageBox.Show("Hợp Đồng này đã lập, không thể tạo lại!");
                }
            }
        }

        private void FrmDanhSachHopDongThuChi_Load(object sender, EventArgs e)
        {
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
        }

        private void TaoHDMuaSamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonHopDongRow())
            {
                HopDongThuChi hopDongThuChi = gridView1.GetFocusedRow() as HopDongThuChi;
                hopDongThuChi = HopDongThuChi.GetHopDongMuaBan(hopDongThuChi.MaHopDong);
                if (hopDongThuChi.MaLoaiHopDong == 0)
                {
                    //
                    XtraForm frm = new XtraForm();
                    frm = new frmHopDongMuaSam(hopDongThuChi, true);
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                    //
                }
                else
                {
                    MessageBox.Show("Hợp Đồng này đã lập, không thể tạo lại!");
                }
                
            }
        }

        private void TaoHDBanQuyenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonHopDongRow())
            {
                HopDongThuChi hopDongThuChi = gridView1.GetFocusedRow() as HopDongThuChi;
                hopDongThuChi = HopDongThuChi.GetHopDongMuaBan(hopDongThuChi.MaHopDong);
                if (hopDongThuChi.MaLoaiHopDong == 0)
                {
                    //
                    XtraForm frm = new XtraForm();
                    frm = new FrmHopDongBanQuyen(hopDongThuChi, true);
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                    //
                }
                else
                {
                    MessageBox.Show("Hợp Đồng này đã lập, không thể tạo lại!");
                }
                
            }
        }

        private void TaoHDDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonHopDongRow())
            {
                HopDongThuChi hopDongThuChi = gridView1.GetFocusedRow() as HopDongThuChi;
                hopDongThuChi = HopDongThuChi.GetHopDongMuaBan(hopDongThuChi.MaHopDong);
                if (hopDongThuChi.MaLoaiHopDong == 0)
                {
                    //
                    XtraForm frm = new XtraForm();
                    frm = new FrmHopDongDoanhThu(hopDongThuChi, true);
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                    //
                }
                else
                {
                    MessageBox.Show("Hợp Đồng này đã lập, không thể tạo lại!");
                }
                
            }
        }

        private void btn_LapHopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LapHopDong();// Dua Hop Dong PS ve Hop Dong Chinh Thuc
        }


    }
}