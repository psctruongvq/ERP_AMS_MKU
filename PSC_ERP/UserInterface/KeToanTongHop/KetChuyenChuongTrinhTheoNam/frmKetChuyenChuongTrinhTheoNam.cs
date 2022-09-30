using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
//03/04/2014
namespace PSC_ERP
{
    public partial class frmKetChuyenChuongTrinhTheoNam : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        SoDuDauKyChuongTrinhTheoNam _soDuDauKyChuongTrinhTheoNam;


        private int _nam = 0;
        private int _taiKhoan = 0;
        private bool _loadformFinish = false;
        private bool _choPhepSuaDuLieu = false;

        #endregion//End Properties

        #region Functions

        private void GetInformations()
        {
            if (cb_NamKeToan.Text != null)
            {
                _nam = Convert.ToInt32(cb_NamKeToan.Text);
            }
            else
            {
                MessageBox.Show("Thông Báo", "Vui lòng nhập thông tin Năm cần thực hiện!");
                cb_NamKeToan.Focus();
                _nam = 0;
            }

        }

        private bool KiemTraKetChuyen()
        {
            GetInformations();
            if (SoDuDauKyChuongTrinhTheoNam.KiemTraDaKetChuyenChuongTrinhTheoNam(_nam))
            {
                if (MessageBox.Show(string.Format("Năm {0} đã kết chuyển, bạn có muốn kết chuyển lại?", _nam), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int namHuy = _nam + 1;
                    SoDuDauKyChuongTrinhTheoNam.HuyKetChuyenSoDuDauKyChuongTrinhTheoNam(namHuy);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private bool KiemTraKhoaSo()
        {
            return true;
        }

        private bool KiemTraTruocKhiCapNhat()
        {
            GetInformations();
            if (SoDuDauKyChuongTrinhTheoNam.KiemTraSoDuDauKyChuongTrinhCPSXDaKetChuyen(_nam))
            {
                MessageBox.Show("Năm này đã kết chuyển số dư sang các năm sau, không thể thực hiện!", "Thông Báo");
                return false;
            }
            return true;
        }

        private bool KiemTraTruocKhiHuyKetChuyen()
        {
            GetInformations();
            return true;
        }

        private void SaveObject()
        {
            if (_soDuDauKyChuongTrinhTheoNam.IsNew == false)
            {
                if (KiemTraTruocKhiCapNhat())
                {
                    try
                    {
                        _soDuDauKyChuongTrinhTheoNam.ApplyEdit();
                        _soDuDauKyChuongTrinhTheoNam.Save();
                        MessageBox.Show("Cập nhật thành công!", "Thông Báo");
                        Show_HidebtnUpdate(true);
                        UnLock_LockDuLieu(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cập nhật thất bại!", "Thông Báo");
                    }
                }
            }
            else
            {
                GetInformations();
                _soDuDauKyChuongTrinhTheoNam.Nam = _nam;
                if(SoDuDauKyChuongTrinhTheoNam.KiemTraCoTonTaiSoDuDauKyTheoNam(_nam))
                {
                    MessageBox.Show(String.Format("Đã tồn tại số dư trong năm {0}, không thể thêm mới!", _nam), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        _soDuDauKyChuongTrinhTheoNam.ApplyEdit();
                        _soDuDauKyChuongTrinhTheoNam.Save();
                        MessageBox.Show("Cập nhật thành công!", "Thông Báo");
                        Show_HidebtnUpdate(true);
                        UnLock_LockDuLieu(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cập nhật thất bại!", "Thông Báo");
                    }
                }

            }
        }

        private void HuyKetChuyen()
        {
            if (KiemTraTruocKhiCapNhat())
            {
                GetInformations();
                if (MessageBox.Show(string.Format("Bạn thật sự muốn hủy số dư đầu chương trình theo tài khoản Năm {0}?", _nam), "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SoDuDauKyChuongTrinhTheoNam.HuyKetChuyenSoDuDauKyChuongTrinhTheoNam(_nam);
                    MessageBox.Show("Hủy kết chuyển thành công!");
                    ResetObject();
                }
            }
        }

        private void KetChuyen()
        {
            if (KiemTraKetChuyen())
            {
                try
                {
                    SoDuDauKyChuongTrinhTheoNam.KetChuyenSoDuDauKyChuongTrinhTheoNam(_nam);
                    MessageBox.Show("Kết chuyển thành công!");
                    ResetObject();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết chuyển thất bại!");
                }
            }
        }


        private void KhoiTao()
        {
            HeThongTaiKhoan1List heThongTaiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("<Tất cả>");
            //heThongTaiKhoanList.Insert(0, tk);
            heThongTaiKhoan1ListBindingSource.DataSource = heThongTaiKhoanList;

            ChuongTrinhList _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList();
            //ChuongTrinh itemChuongTrinh = ChuongTrinh.NewChuongTrinh("<Tất Cả>");
            //_chuongTrinhList.Insert(0, itemChuongTrinh);
            ChuongTrinh_BindingSource.DataSource = _chuongTrinhList;

            bs_SoDuDauKyChuongTrinhTheoNam.DataSource = typeof(SoDuDauKyChuongTrinhTheoNam);
            bs_CT_SoDuDauKyChuongTrinhTheoNamList.DataSource = typeof(CT_SoDuDauKyChuongTrinhTheoNamList);

            //Load Danh Sach Nam_Ky
            for (int i = 2010; i < 2020; i++)
            {
                cb_NamKeToan.Items.Add(i);
            }
            //cb_NamKeToan.Text = DateTime.Today.Year.ToString();
            cb_NamKeToan.SelectedItem = DateTime.Today.Year as object;
            //End Load Danh Sach Nam_Ky

            DesignGrid();

            _loadformFinish = true;
        }

        private void GetObjectSoDuDauKyChuongTrinhTheoNam(int nam)
        {
            _soDuDauKyChuongTrinhTheoNam = SoDuDauKyChuongTrinhTheoNam.NewSoDuDauKyChuongTrinhTheoNam();
            if (SoDuDauKyChuongTrinhTheoNam.KiemTraCoTonTaiSoDuDauKyTheoNam(nam))
            {
                _soDuDauKyChuongTrinhTheoNam = SoDuDauKyChuongTrinhTheoNam.GetSoDuDauKyChuongTrinhTheoNam(nam);
                BindingObject();
                Show_HidebtnUpdate(true);
            }
            else
            {
                MessageBox.Show(string.Format("Năm {0} chưa có dữ liệu!", _nam), "Thông Báo");
                ResetObject();
            }
        }

        private void DesignGrid()
        {
            gridControl1.DataSource = bs_CT_SoDuDauKyChuongTrinhTheoNamList;

            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, true, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaChuongTrinh", "TenChuongTrinh", "MaTaiKhoan", "TenTaiKhoan","NoDauKy","CoDauKy", "SoTienNo", "SoTienCo","LuyKeNo","LuyKeCo" },
                                new string[] { "Mã QL", "Tên chương trình", "Số hiệu TK", "Tên tài khoản","Nợ đầu kỳ","Có đầu kỳ", "PS Nợ", "PS Có","Lũy kế Nợ","Lũy kế có" },
                                             new int[] { 90, 150, 80, 120, 100, 100, 100, 100, 100, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaChuongTrinh", "TenChuongTrinh", "MaTaiKhoan", "TenTaiKhoan", "NoDauKy", "CoDauKy", "SoTienNo", "SoTienCo", "LuyKeNo", "LuyKeCo" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] {"NoDauKy","CoDauKy", "SoTienNo", "SoTienCo","LuyKeNo","LuyKeCo" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTienNo", "SoTienCo", "NoDauKy", "CoDauKy",  "LuyKeNo", "LuyKeCo" }, "{0:#,###.#}");

            NewRowGridViewDev(gridView1);

            UnLock_LockColumnChoseGridViewDev(gridView1, new string[] { "MaChuongTrinh", "TenChuongTrinh", "MaTaiKhoan", "TenTaiKhoan", "NoDauKy", "CoDauKy", "SoTienNo", "SoTienCo", "LuyKeNo", "LuyKeCo" }, false);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M

            //
            RepositoryItemGridLookUpEdit MaChuongTrinh_GrdLU = new RepositoryItemGridLookUpEdit();
            MaChuongTrinh_GrdLU.DataSource = ChuongTrinh_BindingSource;
            MaChuongTrinh_GrdLU.DisplayMember = "MaQL";
            MaChuongTrinh_GrdLU.ValueMember = "MaChuongTrinh";
            HamDungChung.InitRepositoryItemGridLookUpDev(MaChuongTrinh_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(MaChuongTrinh_GrdLU, new string[] { "MaQL", "TenChuongTrinh" }, new string[] { "Mã", "Tên" }, new int[] { 85, 150 }, true);

            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(MaChuongTrinh_GrdLU);
            MaChuongTrinh_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaChuongTrinh", MaChuongTrinh_GrdLU);

            //
            //
            RepositoryItemGridLookUpEdit MaTaiKhoan_GrdLU = new RepositoryItemGridLookUpEdit();
            MaTaiKhoan_GrdLU.DataSource = heThongTaiKhoan1ListBindingSource;
            MaTaiKhoan_GrdLU.DisplayMember = "SoHieuTK";
            MaTaiKhoan_GrdLU.ValueMember = "MaTaiKhoan";
            HamDungChung.InitRepositoryItemGridLookUpDev(MaTaiKhoan_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(MaTaiKhoan_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Mã", "Tên" }, new int[] { 85, 150 }, true);

            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(MaTaiKhoan_GrdLU);
            MaTaiKhoan_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaTaiKhoan", MaTaiKhoan_GrdLU);
            
            //gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick); 
            gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            gridView1.Appearance.GroupPanel.Options.UseFont = true;
            gridView1.GroupPanelText = "Danh Sách Số Dư Đầu Kỳ Chương Trình theo Tài Khoản năm . . .";

            gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
        }

        private void BindingObject()
        {
            bs_CT_SoDuDauKyChuongTrinhTheoNamList.DataSource = _soDuDauKyChuongTrinhTheoNam.ChiTiet_SoDuDauKyChuongTrinhTheoNamList;
        }

        private void ResetObject()
        {
            _soDuDauKyChuongTrinhTheoNam = SoDuDauKyChuongTrinhTheoNam.NewSoDuDauKyChuongTrinhTheoNam();
            BindingObject();
            gridView1.GroupPanelText = "Danh Sách Số Dư Đầu Kỳ Chương Trình theo Tài Khoản năm . . .";
        }

        public static void NewRowGridViewDev(GridView grid)
        {
            grid.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11F);
            grid.Appearance.Row.Options.UseFont = true;
            grid.Appearance.TopNewRow.Options.UseTextOptions = true;
            grid.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            grid.Appearance.ViewCaption.Font = new System.Drawing.Font("Times New Roman", 11F);
            grid.Appearance.ViewCaption.Options.UseFont = true;
            grid.NewItemRowText = "Thêm dòng mới";
            grid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

        }

        private void UnLock_LockColumnChoseGridViewDev(GridView grid, string[] fieldName, bool unlockColumn)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].OptionsColumn.AllowEdit = unlockColumn;
            }
        }

        private void UnLock_LockDuLieu(bool unlock)
        {
            //15 lock, 16 unlock
            if (unlock)
            {
                btnUpdate.Caption = "Khóa dữ liệu";
                btnUpdate.ImageIndex = 15;//Lock
                //unlock dữ liệu
                UnLock_LockColumnChoseGridViewDev(gridView1, new string[] { "MaChuongTrinh", "MaTaiKhoan", "SoTienNo", "SoTienCo","NoDauKy","CoDauKy","LuyKeNo","LuyKeCo" }, true);
            }
            else
            {
                btnUpdate.Caption = "Sửa dữ liệu";
                btnUpdate.ImageIndex = 16;//Unlock
                //Lock dữ liệu
                UnLock_LockColumnChoseGridViewDev(gridView1, new string[] { "MaChuongTrinh", "MaTaiKhoan", "SoTienNo", "SoTienCo", "NoDauKy", "CoDauKy", "LuyKeNo", "LuyKeCo" }, false);
            }

        }

        private void Show_HidebtnUpdate(bool isShow)
        {
            if (isShow)
            {
                btnUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        #endregion//End Functions

        #region Events

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private void cb_NamKeToan_SelectedValueChanged(object sender, EventArgs e)
        {
            //if(_loadformFinish)
            //{
            //    btnXem.PerformClick();
            //}

        }


        private void btnKetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KetChuyen();
        }

        private void btnXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetInformations();
            gridView1.GroupPanelText = string.Format("Danh Sách Số Dư Đầu Kỳ Chương Trình theo Tài Khoản năm {0}", _nam);
            GetObjectSoDuDauKyChuongTrinhTheoNam(_nam);

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveObject();
        }

        private void btnHuyKetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(_soDuDauKyChuongTrinhTheoNam.IsNew==false)
            {
                HuyKetChuyen();
            }
        }

        private void GridLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                if (_choPhepSuaDuLieu == true)
                {
                    if (KiemTraTruocKhiCapNhat())
                    {
                        HamDungChung.DeleteSelectedRowsGridViewDev(gridView1, e);
                    }
                }
                else
                    MessageBox.Show("Dữ liệu đang khóa, không thể xóa!", "Thông Báo");
            }

        }
        #endregion//End Events


        public frmKetChuyenChuongTrinhTheoNam()
        {
            InitializeComponent();
            Show_HidebtnUpdate(false);
            KhoiTao();
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _choPhepSuaDuLieu = !_choPhepSuaDuLieu;
            UnLock_LockDuLieu(_choPhepSuaDuLieu);
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _soDuDauKyChuongTrinhTheoNam = SoDuDauKyChuongTrinhTheoNam.NewSoDuDauKyChuongTrinhTheoNam();
            BindingObject();
            UnLock_LockDuLieu(true);
            Show_HidebtnUpdate(false);
        }











    }
}