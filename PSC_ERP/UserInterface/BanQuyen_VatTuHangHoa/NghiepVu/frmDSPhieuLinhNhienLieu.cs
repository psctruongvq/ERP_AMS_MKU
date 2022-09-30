using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Data.SqlClient;
//11/03/2013
namespace PSC_ERP
{
    public partial class frmDSPhieuLinhNhienLieu : DevExpress.XtraEditors.XtraForm
    {
        bool _chonDSPhieuLinhDeLapPhieuXuat = false;
        byte _loaiphieu = 1;
        #region An Hien BtnXoa
        void HidebtnXoa()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        void ShowbtnXoa()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        #endregion//An Hien BtnXoa
        DateTime _ngayPhieuXuatNhienLieu;
        public frmDSPhieuLinhNhienLieu()
        {
            InitializeComponent();
            //Init_lookUpEdit_TinhTrang();
            //LoadForm();
        }

        public void ShowPhieuLinhNhienLieu()
        {
            _loaiphieu = 1;
            Init_lookUpEdit_TinhTrang();
            LoadForm();
            this.Show();
            HidebtnXoa();
        }

        public void ShowPhieuDeNghiVatTu()
        {
            _loaiphieu = 2;
            Init_lookUpEdit_TinhTrang();
            LoadForm();
            this.Text = "Phiếu Đề Nghị Lĩnh Vật Tư Hàng Hóa";
            this.Show();
            HidebtnXoa();
        }

        PhieuLinhNhienLieuList _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
        PhieuLinhNhienLieu _phieuLinhNhienLieu = PhieuLinhNhienLieu.NewPhieuLinhNhienLieu();
        public PhieuLinhNhienLieu PhieuLinhNhienLieu
        {
            get { return _phieuLinhNhienLieu; }
        }
        //
        PhieuLinhNhienLieuList _phieuLinhNhienLieuDuocChonList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();

        public PhieuLinhNhienLieuList PhieuLinhNhienLieuDuocChonList
        {
            get { return _phieuLinhNhienLieuDuocChonList; }
        }
        int _ngayLap = 0;
        int _ngayHetHan = 0;
        long _maPhieuLinhNhienLieu = 0;
        long _maPhieuNhapXuat = 0;
        string _soChungTu = "";
        int _maKho = 0;
        byte _tinhTrang = 0;
        DateTime _tuNgayLap;
        DateTime _denNgayLap;
        DateTime _tuNgayHetHan;
        DateTime _denNgayHetHan;
        int _maBoPhan = 0;
        int _maNguoiNhan = 0;
        int _loai = 1;
        //Bien Cho Report
        int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;


        public frmDSPhieuLinhNhienLieu(int maKho, int maPhongBan, DateTime ngayPhieuXuatNhienLieu, byte loaiPhieu)
        {

            _ngayPhieuXuatNhienLieu = ngayPhieuXuatNhienLieu;
            _chonDSPhieuLinhDeLapPhieuXuat = true;
            InitializeComponent();
            _loaiphieu = loaiPhieu;
            LoadForm();
            _loai = 2;
            _maKho = maKho;
            lueKho.EditValue = _maKho;
            _maBoPhan = maPhongBan;
            lueBoPhanNhan.EditValue = _maBoPhan;
            _userID = 0;
            Init_lookUpEdit_TinhTrang();
            //_phieuLinhNhienLieuList = PhieuLinhNhienLieuList.GetPhieuLinhNhienLieuList(_ngayLap, _ngayHetHan, _maPhieuNhapXuat, _soChungTu, _maKho, 1, _tuNgayLap, _denNgayLap, _tuNgayHetHan, _denNgayHetHan, _maBoPhan, _maNguoiNhan, _userID);
            _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.GetPhieuLinhNhienLieuList(1, 0, _maPhieuNhapXuat, _soChungTu, _maKho, 1, _ngayPhieuXuatNhienLieu, _ngayPhieuXuatNhienLieu, _tuNgayHetHan, _denNgayHetHan, _maBoPhan, _maNguoiNhan, _userID, _loaiphieu);
            phieuLinhNhienLieuListBindingSource.DataSource = _phieuLinhNhienLieuList;

            //
            this.colChonPLNL.Visible = true;
            if (_loaiphieu == 2)
                this.Text = "DS Phiếu Đề Nghị Lĩnh Vật Tư Hàng Hóa";

        }

        public void LoadForm()
        {
            deTuNgayLap.EditValue = DateTime.Today;
            deDenNgayLap.EditValue = DateTime.Today;
            deTuNgayHetHan.EditValue = DateTime.Today;
            deDenNgayHetHan.EditValue = DateTime.Today;
            lueBoPhanNhan.EditValue = null;
            lueKho.EditValue = null;
            lueNguoiNhan.EditValue = null;
            lueTinhTrang.EditValue = null;

            _maPhieuNhapXuat = 0;
            _soChungTu = "";
            _maKho = 0;
            _tinhTrang = 0;
            _tuNgayLap = (DateTime)deTuNgayLap.EditValue;
            _denNgayLap = (DateTime)deDenNgayLap.EditValue;
            _tuNgayHetHan = (DateTime)deTuNgayHetHan.EditValue;
            _denNgayHetHan = (DateTime)deDenNgayHetHan.EditValue;
            _maBoPhan = 0;
            _maNguoiNhan = 0;

            deTuNgayHetHan.Enabled = false;
            deDenNgayHetHan.Enabled = false;
            deTuNgayLap.Enabled = false;
            deDenNgayLap.Enabled = false;
            if (_loaiphieu == 1)
            {
                khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList(4);
                boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListForLinhNhienLieu();
                XeListBindingSource.DataSource = XeList.GetXeList();
            }
            else
            {
                khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoVatTuList();
                boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanList();
            }
            phieuLinhNhienLieuListBindingSource.DataSource = _phieuLinhNhienLieuList;
        }

        private void Init_lookUpEdit_TinhTrang()
        {
            DataTable _dataTable = new DataTable();

            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(1, "Chưa Lập Phiếu");
            _dataTable.Rows.Add(2, "Đã Lập Phiếu");
            _dataTable.Rows.Add(3, "Đã Quá Thời Gian");

            lueTinhTrang.Properties.DataSource = _dataTable;
            this.lueTinhTrang.Properties.ValueMember = "Ma";
            this.lueTinhTrang.Properties.DisplayMember = "Ten";
            lueTinhTrang.Properties.NullText = "Không Chọn";

            grd_CT_TinhTrang.DataSource = _dataTable;
            grd_CT_TinhTrang.ValueMember = "Ma";
            grd_CT_TinhTrang.DisplayMember = "Ten";
            grd_CT_TinhTrang.NullText = "Không Chọn";
        }


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            _phieuLinhNhienLieu = (PhieuLinhNhienLieu)grdvCT_PhieuLinhNhienLieu.GetFocusedRow();

            if (_loai == 1)
            {
                if (_phieuLinhNhienLieu != null)
                {
                    PhieuLinhNhienLieu _p = PhieuLinhNhienLieu.GetPhieuLinhNhienLieu(_phieuLinhNhienLieu.MaPhieuLinhNhienLieu);
                    frmPhieuLinhNhienLieu frm = new frmPhieuLinhNhienLieu(_p);
                    //frm.ShowDialog();//Old
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        barBt_Tim.PerformClick();//New
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmPhieuLinhNhienLieu frm = new frmPhieuLinhNhienLieu();
            //if (_loaiphieu == 1)
            //{
            //    frm.ShowPhieuLinhNL();
            //}
            //else if (_loaiphieu == 2)
            //{
            //    frm.ShowVatTuHH();
            //}
            frmPhieuLinhNhienLieu frm = new frmPhieuLinhNhienLieu(_loaiphieu);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                barBt_Tim.PerformClick();

        }

        private void btXem_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_chonDSPhieuLinhDeLapPhieuXuat == false)
            {
                btLuu();
            }
            else
            {
                this.ChangeFocus();
                _phieuLinhNhienLieuDuocChonList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
                foreach (PhieuLinhNhienLieu item in _phieuLinhNhienLieuList)
                {
                    if (item.Chon && item.MaPhieuLinhNhienLieu != 0)
                    {
                        _phieuLinhNhienLieuDuocChonList.Add(item);
                    }
                }
                if (_phieuLinhNhienLieuDuocChonList != null && _phieuLinhNhienLieuDuocChonList.Count > 0)
                {
                    //can kiem tra co cung phong ban hay ko
                    int maBoPhan = PhieuLinhNhienLieuDuocChonList[0].MaBoPhanNhan;
                    int ngay = _ngayPhieuXuatNhienLieu.Day;//_phieuLinhNhienLieuDuocChonList[0].NgayLap.Day;
                    int thang = _ngayPhieuXuatNhienLieu.Month;//_phieuLinhNhienLieuDuocChonList[0].NgayLap.Month;
                    int nam = _ngayPhieuXuatNhienLieu.Year;//_phieuLinhNhienLieuDuocChonList[0].NgayLap.Year;
                    foreach (PhieuLinhNhienLieu item in _phieuLinhNhienLieuDuocChonList)
                    {
                        if (item.MaBoPhanNhan != maBoPhan)
                        {
                            MessageBox.Show("Vui lòng chọn phiếu lĩnh nhiên liệu cùng phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _phieuLinhNhienLieuDuocChonList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
                            return;
                        }
                        if (item.NgayLap.Day != ngay || item.NgayLap.Month != thang || item.NgayLap.Year != nam)
                        {
                            MessageBox.Show("Vui lòng chọn phiếu lĩnh nhiên liệu cùng ngày lập phiếu xuất nhiên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _phieuLinhNhienLieuDuocChonList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
                            return;
                        }
                    }
                }
                else
                {
                    if (_loaiphieu == 2)
                        MessageBox.Show("Vui lòng chọn phiếu đề nghị lĩnh vật tư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Vui lòng chọn phiếu lĩnh nhiên liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _phieuLinhNhienLieuDuocChonList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
                    return;
                }
                foreach (PhieuLinhNhienLieu item in _phieuLinhNhienLieuDuocChonList)
                {

                }
                this.Close();
            }
        }

        private void btLuu()
        {

            this.ChangeFocus();
            try
            {
                grd_Phieu.EndUpdate();
                _phieuLinhNhienLieuList.ApplyEdit();
                _phieuLinhNhienLieuList.Save();

                MessageBox.Show(this, "Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(this, "Không thể lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdvCT_PhieuLinhNhienLieu.GetSelectedRows() == null)
                MessageBox.Show(this, "Chọn dòng muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                foreach (int i in grdvCT_PhieuLinhNhienLieu.GetSelectedRows())
                {
                    PhieuLinhNhienLieu phieuLinhNhienLieu = _phieuLinhNhienLieuList[i];
                    if (phieuLinhNhienLieu.TinhTrang == 2)
                    {
                        if (phieuLinhNhienLieu.Loai == 1)
                            MessageBox.Show(this, "Phiếu Lĩnh đã được xuất. Không xóa được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(this, "Phiếu Đề nghị đã được xuất. Không xóa được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (MessageBox.Show(this, "Bạn muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    grdvCT_PhieuLinhNhienLieu.DeleteSelectedRows();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
        }

        private void barBt_LapPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_chonDSPhieuLinhDeLapPhieuXuat == true)
                this.Close();
            else
            {
                DialogResult result = MessageBox.Show(this, "Bạn có muốn lưu không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (result)
                {
                    case DialogResult.Yes: btLuu(); this.Close(); break;
                    case DialogResult.No: this.Close(); break;
                    case DialogResult.Cancel: break;
                }
            }


        }

        private void lueBoPhanNhan_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBoPhanNhan.EditValue != null)
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lueBoPhanNhan.EditValue, false);
            else
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
        }

        private void lueNguoiNhan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lueNguoiNhan.EditValue = null;
            }
        }

        private void lueKho_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lueKho.EditValue = null;
            }
        }

        private void lueBoPhanNhan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lueBoPhanNhan.EditValue = null;
            }
        }

        private void ceNgayHetHan_CheckedChanged(object sender, EventArgs e)
        {
            deTuNgayHetHan.Enabled = (bool)ceNgayHetHan.EditValue;
            deDenNgayHetHan.Enabled = (bool)ceNgayHetHan.EditValue;
            _ngayHetHan = (bool)ceNgayHetHan.EditValue ? 1 : 0;
        }

        private void ceNgayLap_CheckedChanged(object sender, EventArgs e)
        {
            deTuNgayLap.Enabled = (bool)ceNgayLap.EditValue;
            deDenNgayLap.Enabled = (bool)ceNgayLap.EditValue;
            _ngayLap = (bool)ceNgayLap.EditValue ? 1 : 0;
        }

        private void lueTinhTrang_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lueTinhTrang.EditValue = null;
            }
        }

        private void barBt_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _maKho = 0;
            _tinhTrang = 0;
            _tuNgayLap = (DateTime)deTuNgayLap.EditValue;
            _denNgayLap = (DateTime)deDenNgayLap.EditValue;
            _tuNgayHetHan = (DateTime)deTuNgayHetHan.EditValue;
            _denNgayHetHan = (DateTime)deDenNgayHetHan.EditValue;

            if (lueKho.GetSelectedDataRow() == null)
                _maKho = 0;
            else
                _maKho = (int)lueKho.EditValue;
            if (lueTinhTrang.GetSelectedDataRow() == null)
                _tinhTrang = 0;
            else
                _tinhTrang = (byte)lueTinhTrang.EditValue;
            if (lueBoPhanNhan.GetSelectedDataRow() == null)
                _maBoPhan = 0;
            else
                _maBoPhan = (int)lueBoPhanNhan.EditValue;
            if (lueNguoiNhan.GetSelectedDataRow() == null)
                _maNguoiNhan = 0;
            else
                _maNguoiNhan = (int)lueNguoiNhan.EditValue;
            if (_loai == 2)
            {
                _tinhTrang = 1;
                _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.GetPhieuLinhNhienLieuList(1, 0, _maPhieuNhapXuat, _soChungTu, _maKho, 1, _ngayPhieuXuatNhienLieu, _ngayPhieuXuatNhienLieu, _tuNgayHetHan, _denNgayHetHan, _maBoPhan, _maNguoiNhan, _userID, _loaiphieu);
            }
            else _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.GetPhieuLinhNhienLieuList(_ngayLap, _ngayHetHan, _maPhieuNhapXuat, _soChungTu, _maKho, _tinhTrang, _tuNgayLap, _denNgayLap, _tuNgayHetHan, _denNgayHetHan, _maBoPhan, _maNguoiNhan, _userID, _loaiphieu);
            if (_phieuLinhNhienLieuList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
            phieuLinhNhienLieuListBindingSource.DataSource = _phieuLinhNhienLieuList;
            thongTinNhanVienTongHopListBindingSource1.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
        }

        #region grdvCT_PhieuLinhNhienLieu_KeyDown
        private void grdvCT_PhieuLinhNhienLieu_KeyDown(object sender, KeyEventArgs e)
        {
            #region Key delete
            //if (e.KeyCode == Keys.Delete)
            //{
            //    if (grdvCT_PhieuLinhNhienLieu.GetSelectedRows() == null)
            //        MessageBox.Show(this, "Chọn dòng muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    else
            //    {
            //        foreach (int i in grdvCT_PhieuLinhNhienLieu.GetSelectedRows())
            //        {
            //            PhieuLinhNhienLieu phieuLinhNhienLieu = _phieuLinhNhienLieuList[i];
            //            if (phieuLinhNhienLieu.TinhTrang == 2)
            //            {
            //                if (phieuLinhNhienLieu.Loai == 1)
            //                    MessageBox.Show(this, "Phiếu Lĩnh đã được xuất. Không xóa được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                else
            //                    MessageBox.Show(this, "Phiếu Đề nghị đã được xuất. Không xóa được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            }
            //        }
            //        if (MessageBox.Show(this, "Bạn muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            //            grdvCT_PhieuLinhNhienLieu.DeleteSelectedRows();
            //    }
            //}
            #endregion //Key delete
        }
        #endregion

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuLinhNhienLieu plnl = phieuLinhNhienLieuListBindingSource.Current as PhieuLinhNhienLieu;
            _maPhieuLinhNhienLieu = plnl.MaPhieuLinhNhienLieu;
            if (plnl.Loai == 1)
            {
                //IN Phieu Linh Nhien Lieu
                //BEGIN
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuLinhNhienLieu");
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();


                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _userID, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = _userID;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }
                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
                //END
            }
            else if (plnl.Loai == 2)
            {
                //IN Phieu De Nghi LInh
                //BEGIN
                ReportTemplate _report = ReportTemplate.GetReportTemplate("DeNghiLinhVatTu");
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();


                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, _userID, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = _userID;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }
                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
                //END
            }
        }

        private void frmDSPhieuLinhNhienLieu_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }
        private void btnChonPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmDSPhieuLinhNhienLieu_Load(object sender, EventArgs e)
        {
            if (_loai == 2)
                grdvCT_PhieuLinhNhienLieu.OptionsBehavior.Editable = true;//M
            else
                grdvCT_PhieuLinhNhienLieu.OptionsBehavior.Editable = false;//M
            Utils.GridUtils.SetSTTForGridView(grdvCT_PhieuLinhNhienLieu, 35);//M
            if (_loaiphieu == 1)
            {
                colIDXe.Visible = true;
                colIDXe.VisibleIndex = 2;
            }
            else
                colIDXe.Visible = false;
            //Sort theo So Chung tu
            //colSoChungTu.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            deTuNgayLap.EditValue = (object)DateTime.Today.Date;
            deDenNgayLap.EditValue = (object)DateTime.Today.Date;
            deTuNgayHetHan.EditValue = (object)DateTime.Today.Date;
            deDenNgayHetHan.EditValue = (object)DateTime.Today.Date;
        }

        #region Cac Ham Report
        public void InPhieuLinhNhienLieu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InPhieuLinhNhienLieu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_PhieuLinhNhienLieu";
                    cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", _maPhieuLinhNhienLieu);


                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_PhieuLinhNhienLieu;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", _userID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
                //END
            }//us 
        } //END InPhieuLinhNhienLieu()

        public void InDeNghiLinhVatTu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InDeNghiLinhVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_PhieuLinhNhienLieu";
                    cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", _maPhieuLinhNhienLieu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_PhieuLinhNhienLieu";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", _userID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate("", _userID, DateTime.Today);
                frmReport frm = new frmReport();
                frm.HienThiReport(_reportTemplate, dataSet);
                frm.Show();
            }//us
        }//END InDeNghiLinhVatTu

        #endregion//Cac Ham Report
    }
}