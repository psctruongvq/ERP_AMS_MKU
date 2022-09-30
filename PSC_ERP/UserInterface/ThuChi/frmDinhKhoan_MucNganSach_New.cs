using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using PSC_ERP;


namespace PSC_ERP
{// 4-1-2010
    public partial class frmDinhKhoan_MucNganSach_New : Form
    {
        #region Properties
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        ButToanMucNganSach _butToanMucNganSach;
        ButtoanMucNganSachList _butToanMucNganSachList_Deleted = ButtoanMucNganSachList.NewButtoanMucNganSachList();
        Util _Util = new Util();
        decimal _soTienButToan = 0;
        public static Boolean isSave = false;
        string _dienGiaiMucNganSach = "";

        private string _NoTK = string.Empty;

        //static ButtoanMucNganSachList _butToanMucNganSachListFirst = null;
        public ButtoanMucNganSachList _butToanMNSList;
        #endregion

        #region Events

        private void LoadDaTa()
        {
            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach_BindingSource.DataSource = _tieuMucNganSachList;

            //_butToanMucNganSachListFirst = ButtoanMucNganSachList.NewButtoanMucNganSachList();
            //foreach (ButToanMucNganSach btnns in butToanMucNganSachList)
            //{
            //    _butToanMucNganSachListFirst.Add(btnns);
            //}
            isSave = false;
        }

        private bool KiemTraTruocKhiThoat()
        {
            if(_NoTK.Contains("631") || _NoTK.Contains("4314"))
            {
                if(ButToanMucNganSach_BindingSource.Count==0)
                {
                    MessageBox.Show(this, "Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                }
            }
            return true;
        }

        public frmDinhKhoan_MucNganSach_New(ButtoanMucNganSachList butToanMucNganSachList, decimal soTienButToan, string dienGiai, string noTK)
        {
            InitializeComponent();
            _butToanMNSList = butToanMucNganSachList;
            //Lấy số tiền bút toán
            unumTongTien.Value = soTienButToan;
            _soTienButToan = soTienButToan;

            //Lấy diễn giải bút toán
            _dienGiaiMucNganSach = dienGiai;
            _NoTK = noTK;
            ButToanMucNganSach_BindingSource.DataSource = _butToanMNSList;
            LoadDaTa();
        }
        private void ThemMoi()
        {
            decimal soTienDaButToan = 0;

            ButtoanMucNganSachList buttoanMucNganSachList = ButToanMucNganSach_BindingSource.DataSource as ButtoanMucNganSachList;
            //Lấy số tiền của bút toán ngân sách
            foreach (ButToanMucNganSach item in buttoanMucNganSachList)
            {
                soTienDaButToan += item.SoTien;
            }
            if (_soTienButToan > 0 && _soTienButToan <= soTienDaButToan)
            {
                MessageBox.Show(this, "Không đủ tiền để bút toán mục ngân sách.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            _butToanMucNganSach = ButToanMucNganSach.NewButToanMucNganSach();
            _butToanMucNganSach.DienGiai = _dienGiaiMucNganSach;
            _butToanMucNganSach.SoTien = _soTienButToan - soTienDaButToan;

            buttoanMucNganSachList.Add(_butToanMucNganSach);
            ButToanMucNganSach_BindingSource.DataSource = buttoanMucNganSachList;

            ugrDSButToanMucNganSach.ActiveRow = ugrDSButToanMucNganSach.Rows[buttoanMucNganSachList.Count - 1];
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            ThemMoi();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            txtFocus.Focus();
            if (KiemTraTruocKhiThoat() == false)
                return;
           
            Decimal sum = 0;
            ButToanMucNganSach_BindingSource.EndEdit();
            _butToanMNSList = ButToanMucNganSach_BindingSource.DataSource as ButtoanMucNganSachList;

            foreach (ButToanMucNganSach buttoanMucNganSach in _butToanMNSList)
            {
                if (buttoanMucNganSach.SoTien == 0)
                {
                    MessageBox.Show(this, "Vui lòng nhập đầy đủ tiền.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                sum += buttoanMucNganSach.SoTien;

            }
            if (_butToanMNSList.Count > 0 && _soTienButToan != sum)
            {
                MessageBox.Show(this, "Số tiền chí phí sản xuất không bằng tiền bút toán mục ngân sách.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            foreach (ButToanMucNganSach buttoanMucNganSach in _butToanMNSList)
            {
                if (buttoanMucNganSach.MaTieuMucNganSach == 0)
                {
                    MessageBox.Show(this, "Phải chọn tiểu mục ngân sách cho các mục đã chọn.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            isSave = true;
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            Boolean daCoButToanMucNganSach = false;
            if (ugrDSButToanMucNganSach.Selected.Rows.Count == 0)
            {
                MessageBox.Show(_Util.chodongcanxoa, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ButToanMucNganSach buttoanMucNganSach = (ButToanMucNganSach)ButToanMucNganSach_BindingSource.Current;

            foreach (ButToanMucNganSach item in _butToanMucNganSachList_Deleted)
            {
                if (item == buttoanMucNganSach)
                {
                    daCoButToanMucNganSach = true;
                }
            }
            if (daCoButToanMucNganSach == false)
            {
                _butToanMucNganSachList_Deleted.Add(buttoanMucNganSach);
            }


            ugrDSButToanMucNganSach.DeleteSelectedRows();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void utxeditTenMuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThemMoi();
                ultraCombo_MaTieuMuc.Focus();
            }
        }

        private void ultraedit_DienGiai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThemMoi();
                ultraCombo_MaTieuMuc.Focus();
            }
        }
        #endregion

        #region InitializeLayout
        private void ugrDSButToanMucNganSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            foreach (UltraGridColumn col in this.ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                    col.CellAppearance.TextHAlign = HAlign.Center;
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###,###.##";
                    //col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
                    //col.Format = "###,###,###,###,###,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["MaButToanMucNganSach"].Header.Caption = "STT";
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["MaButToanMucNganSach"].Hidden = false;
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["MaButToanMucNganSach"].Header.VisiblePosition = 0;

            //ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["MaTieuMucNganSach"].Header.Caption = "Tiểu Mục";
            //ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["MaTieuMucNganSach"].EditorComponent = ultraCombo_MaTieuMuc;
            //ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["MaTieuMucNganSach"].Hidden = false;
            //ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["MaTieuMucNganSach"].Header.VisiblePosition = 1;
            //ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["MaTieuMucNganSach"].Width = 80;

            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["SoTien"].Width = 125;

            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            ugrDSButToanMucNganSach.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 275;

        }

        private void ultraCombo_MaTieuMuc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Hidden = false;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.Caption = "Mã Mục";
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.VisiblePosition = 0;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Width = 100;

            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Tiểu Mục";
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 100;

            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Hidden = false;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.Caption = "Tên Tiểu Mục";
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Header.VisiblePosition = 2;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenTieuMuc"].Width = 300;

            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["Chon"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Hidden = true;
            ultraCombo_MaTieuMuc.DisplayLayout.Bands[0].Columns["MaMucNganSach"].Hidden = true;

        }

        private void ultraCombo_MaTieuMuc_KeyDown(object sender, KeyEventArgs e)
        {
            FilterCombo _filterCombo = new FilterCombo(ultraCombo_MaTieuMuc, "TenTieuMuc");
        }

        private void frmDinhKhoan_MucNganSach_New_FormClosed(object sender, FormClosedEventArgs e)
        {
            ButToanMucNganSach_BindingSource.EndEdit();
        }
        #endregion

        private void unumSoTien_Leave(object sender, EventArgs e)
        {
            // decimal soTienDaButToan = (decimal)unumSoTien.Value;

            //if (_soTienButToan > 0 && _soTienButToan < soTienDaButToan)
            //{
            //    unumSoTien.Appearance.BackColor = Color.Red;
            //    unumSoTien.Focus();
            //    MessageBox.Show(this, "Không đủ tiền để bút toán mục ngân sách.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    unumSoTien.Appearance.BackColor = Color.White;
            //}
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            Boolean daCoButToanMucNganSach = false;
            ButToanMucNganSach butToanMucNganSach = (ButToanMucNganSach)ButToanMucNganSach_BindingSource.Current;

            if (butToanMucNganSach != null && butToanMucNganSach.IsNew)//Nếu là đối tượng mới thì xóa đi
            {
                ButToanMucNganSach_BindingSource.Remove(butToanMucNganSach);
            }
            else//Nếu là đối tượng cũ mà đã cập nhật dữ liệu thì trả về ban đầu
            {
                ButToanMucNganSach_BindingSource.CancelEdit();
            }
            //Nếu đã xóa đi dữ liệu cũ thì trả lại
            ButtoanMucNganSachList butToanMucNganSachList_Current = ButToanMucNganSach_BindingSource.DataSource as ButtoanMucNganSachList;
            foreach (ButToanMucNganSach butToanMucNganSach_Deleted in _butToanMucNganSachList_Deleted)
            {
                foreach (ButToanMucNganSach butToanMucNganSach_Curent in butToanMucNganSachList_Current)
                {
                    if (butToanMucNganSach_Deleted == butToanMucNganSach_Curent)
                    {
                        daCoButToanMucNganSach = true;
                    }
                }
                if (daCoButToanMucNganSach == false)
                {
                    ButToanMucNganSach_BindingSource.Add(butToanMucNganSach_Deleted);
                }
                daCoButToanMucNganSach = false;
            }
        }

        private void frmDinhKhoan_MucNganSach_New_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            //if (isSave==false)
            //{
            //    if (KiemTraTruocKhiThoat() == false)
            //    {
            //        e.Cancel = true;
            //    }
            //    //DialogResult kq = MessageBox.Show("Bạn có muốn lưu sự chuyển đổi?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //    //if (kq == DialogResult.Yes)
            //    //{
            //    //    tlslblLuu.PerformClick();
            //    //}
            //    //else if (kq == DialogResult.No)
            //    //{
            //    //    ButToanMucNganSach_BindingSource.DataSource = _butToanMucNganSachListFirst;
            //    //}
            //    //else if (kq == DialogResult.Cancel)
            //    //{
            //    //    e.Cancel = true;
            //    //}

            //}
        }
    }
}