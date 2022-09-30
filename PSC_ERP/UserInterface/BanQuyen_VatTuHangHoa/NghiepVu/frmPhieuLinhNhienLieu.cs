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
//11/04/2013
namespace PSC_ERP
{
    public partial class frmPhieuLinhNhienLieu : DevExpress.XtraEditors.XtraForm
    {
        //
        byte _loai = 1;
        PhieuLinhNhienLieu _phieuLinhNhienLieu;
        CT_PhieuLinhNhienLieu _cT_PhieuLinhNhienLieu;
        string _soChungTu;
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        bool _notBindingIDXe = false;
        int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        //

        private bool KiemTraPhanHeCua2014()
        {
            if (_phieuLinhNhienLieu != null)
            {
                if (_phieuLinhNhienLieu.NgayLap.Year >= 2014)
                {
                    MessageBox.Show("Vui lòng nhập phiếu vào phân hệ 2014!");
                    return true;
                    this.Close();
                }
            }
            return false;
        }

        public frmPhieuLinhNhienLieu(PhieuLinhNhienLieu phieu)
        {
            _loai = phieu.Loai;
            InitializeComponent();
            _notBindingIDXe = true;
            LoadForm();
            KhoiTao(phieu);
        }

        public frmPhieuLinhNhienLieu()
        {
            InitializeComponent();
            //KhoiTao();
            //LoadForm();
        }
        public frmPhieuLinhNhienLieu(byte Loai)
        {
            InitializeComponent();
            _loai = Loai;
            KhoiTao();
            LoadForm();
            if (Loai == 2)
                this.Text = "Phiếu Đề Nghị Lĩnh Vật Tư Hàng Hóa";

        }
        public void ShowPhieuLinhNL()
        {
            _loai = 1;
            KhoiTao();
            LoadForm();
            this.Show();
        }

        public void ShowVatTuHH()
        {
            _loai = 2;
            KhoiTao();
            LoadForm();
            this.Text = "Phiếu Đề Nghị Lĩnh Vật Tư Hàng Hóa";
            this.Show();
        }

        public void LoadForm()
        {
            //thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            donViTinhBQVTListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            if (_loai == 1)
            {
                boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListForLinhNhienLieu();
                hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(4);
                khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList(4);
                lb_BienSo.Visible = true;
                GridLookupEdit_Xe.Visible = true;
                //Set Ngay Het Han M
                if (dateEdit_NgayLap.EditValue != null)
                {
                    DateTime _date = new DateTime();
                    if (DateTime.TryParse(dateEdit_NgayLap.EditValue.ToString(), out _date))
                    {
                        SetNgayHetHan(_date);
                    }
                }
                //END Set Ngay Het Han M
            }
            else
            {
                boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanList();
                hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList();
                khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoVatTuList();
                lb_BienSo.Visible = false;
                GridLookupEdit_Xe.Visible = false;
            }

        }

        private void KhoiTao()
        {
            _phieuLinhNhienLieu = PhieuLinhNhienLieu.NewPhieuLinhNhienLieu();
            _phieuLinhNhienLieu.SoChungTu = PhieuLinhNhienLieu.SetSoChungTu(_phieuLinhNhienLieu.NgayLap, UserId, _loai);
            _soChungTu = _phieuLinhNhienLieu.SoChungTu;
            _phieuLinhNhienLieu.Loai = _loai;

            if (_loai == 1)
            {
                //_phieuLinhNhienLieu.MaKho = KhoBQ_VT.GetKhoBQ_VT("KNL").MaKho;
                //_phieuLinhNhienLieu.MaBoPhanNhan = BoPhan.GetBoPhan("DV23").MaBoPhan;
                _phieuLinhNhienLieu.MaKho = KhoBQ_VTList.GetKhoBQ_VTList(4)[0].MaKho;
                _phieuLinhNhienLieu.MaBoPhanNhan = BoPhan.GetBoPhan(23).MaBoPhan;
                XeListBindingSource.DataSource = XeList.GetXeList(_phieuLinhNhienLieu.MaBoPhanNhan);
                //Set Ngay Het Han M
                if (dateEdit_NgayLap.EditValue != null)
                {
                    DateTime _date = new DateTime();
                    if (DateTime.TryParse(dateEdit_NgayLap.EditValue.ToString(), out _date))
                    {
                        //_date = (DateTime)dateEdit_NgayLap.EditValue;
                        SetNgayHetHan(_date);
                    }
                }
                //END Set Ngay Het Han M
            }
            else
            {
                //_phieuLinhNhienLieu.MaKho = 0;
                //_phieuLinhNhienLieu.MaBoPhanNhan = 0;
                _phieuLinhNhienLieu.MaKho = KhoBQ_VTList.GetKhoBQ_VTList(2)[0].MaKho;
                _phieuLinhNhienLieu.MaBoPhanNhan = BoPhan.GetBoPhan(9).MaBoPhan;
            }
            phieuLinhNhienLieuBindingSource.DataSource = _phieuLinhNhienLieu;
            cTPhieuLinhNhienLieuListBindingSource.DataSource = _phieuLinhNhienLieu.CT_PhieuLinhNhienLieuList;
        }

        private void KhoiTao(PhieuLinhNhienLieu phieu)
        {
            _phieuLinhNhienLieu = phieu;
            _loai = _phieuLinhNhienLieu.Loai;
            //_phieuLinhNhienLieu.SoChungTu = PhieuLinhNhienLieu.SetSoChungTu(_phieuLinhNhienLieu.NgayLap, UserId, _loai);
            phieuLinhNhienLieuBindingSource.DataSource = _phieuLinhNhienLieu;
            cTPhieuLinhNhienLieuListBindingSource.DataSource = _phieuLinhNhienLieu.CT_PhieuLinhNhienLieuList;
            if (_loai == 2)
                this.Text = "Phiếu Đề Nghị Lĩnh Vật Tư Hàng Hóa";
        }

        private bool KiemTraDuLieu()
        {
            bool kq = false;
            if (PhieuLinhNhienLieu.CheckSoChungTu(_phieuLinhNhienLieu.MaPhieuLinhNhienLieu, _phieuLinhNhienLieu.SoChungTu) != 0)
            {
                MessageBox.Show("Số chứng từ đã tồn tại. \r\n Vui lòng lấy giá trị mặc định. \r\n Cập nhật thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _phieuLinhNhienLieu.SoChungTu = _soChungTu;
                textEdit_SoChungTu.Focus();
            }
            else
                if (_phieuLinhNhienLieu.MaBoPhanNhan == 0)
                {
                    MessageBox.Show(this, "Vui lòng chọn bộ phận nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    luePhongBan.Focus();
                }
                else if (_phieuLinhNhienLieu.MaNguoiNhan == 0)
                {
                    MessageBox.Show(this, "Vui lòng chọn người nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpEdit_NhanVien.Focus();
                }
                else if (_phieuLinhNhienLieu.MaKho == 0)
                {
                    MessageBox.Show(this, "Vui lòng chọn kho", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    gridLookUpEdit_KhoNhan.Focus();
                }
                else if (_phieuLinhNhienLieu.CT_PhieuLinhNhienLieuList.Count == 0)
                    MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else kq = true;
            return kq;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraPhanHeCua2014())
                return;
            textEdit_Focus.Focus();
            if (KiemTraDuLieu() == true)
                btLuu();
        }

        private void btLuu()
        {
            if (_phieuLinhNhienLieu.MaPhieuNhapXuat != 0)
            {
                MessageBox.Show(this, "Phiếu Lĩnh đã Xuất, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEdit_SoChungTu.EditValue != null)//IF 1
            {
                string _soChungTu = textEdit_SoChungTu.EditValue.ToString();
                int _stt;
                if (int.TryParse(_soChungTu.Substring(0, 4), out _stt))//IF 2
                {
                    //C
                    try
                    {
                        _phieuLinhNhienLieu.ApplyEdit();
                        _phieuLinhNhienLieu.Save();

                        MessageBox.Show(this, "Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                        MessageBox.Show(this, "Không thể lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //C
                }//END IF 2
                else
                {
                    MessageBox.Show("Số Phiếu Không Hợp Lệ! 4 ký tự đầu phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_SoChungTu.Focus();
                }

            }//END IF 4


        }
        private void SetNgayHetHan(DateTime date)
        {
            int day_NgayLap = date.Day;
            int month_NgayLap = date.Month;
            switch (month_NgayLap)
            {
                case 2:
                    {
                        if (day_NgayLap == 28)
                        {
                            _phieuLinhNhienLieu.NgayHetHan = date;
                        }
                        else if (day_NgayLap == 27)
                        {
                            _phieuLinhNhienLieu.NgayHetHan = date.AddDays(1);
                        }
                        else
                        {
                            _phieuLinhNhienLieu.NgayHetHan = date.AddDays(2);
                        }
                    }
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        if (day_NgayLap == 31)
                        {
                            _phieuLinhNhienLieu.NgayHetHan = date;
                        }
                        else if (day_NgayLap == 30)
                        {
                            _phieuLinhNhienLieu.NgayHetHan = date.AddDays(1);
                        }
                        else
                        {
                            _phieuLinhNhienLieu.NgayHetHan = date.AddDays(2);
                        }
                    }
                    break;
                default:
                    {
                        if (day_NgayLap == 30)
                        {
                            _phieuLinhNhienLieu.NgayHetHan = date;
                        }
                        else if (day_NgayLap == 29)
                        {
                            _phieuLinhNhienLieu.NgayHetHan = date.AddDays(1);
                        }
                        else
                        {
                            _phieuLinhNhienLieu.NgayHetHan = date.AddDays(2);
                        }
                    }
                    break;

            }
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (gridView_CTPhieuLinhNhienLieu.GetFocusedRow() != null)
            //{
            //    CT_PhieuLinhNhienLieu ct_pl = gridView_CTPhieuLinhNhienLieu.GetFocusedRow() as CT_PhieuLinhNhienLieu;
            //    _phieuLinhNhienLieu.TongSoLuongDuyet = _phieuLinhNhienLieu.TongSoLuongDuyet - ct_pl.SoLuongXuat;
            //    gridView_CTPhieuLinhNhienLieu.DeleteSelectedRows();
            //}
            gridView_CTPhieuLinhNhienLieu.DeleteSelectedRows();
            decimal tongSoLuongDuyet = 0;
            foreach (CT_PhieuLinhNhienLieu ct_plnl in _phieuLinhNhienLieu.CT_PhieuLinhNhienLieuList)
            {
                tongSoLuongDuyet += ct_plnl.SoLuongXuat;
            }
            _phieuLinhNhienLieu.TongSoLuongDuyet = tongSoLuongDuyet;

            
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
        }

        private void luePhongBan_EditValueChanged(object sender, EventArgs e)
        {
            _phieuLinhNhienLieu.MaBoPhanNhan = (int)luePhongBan.EditValue;
            if (luePhongBan.EditValue != null)
            {
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)luePhongBan.EditValue, false);
                XeListBindingSource.DataSource = XeList.GetXeList(_phieuLinhNhienLieu.MaBoPhanNhan);
                if(!_notBindingIDXe)
                _phieuLinhNhienLieu.IDXe = 0;

            }
            else
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            _notBindingIDXe = false;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DialogResult result = MessageBox.Show(this, "Bạn có muốn lưu không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            //switch (result)
            //{
            //    case DialogResult.Yes: btLuu(); this.Close(); break;
            //    case DialogResult.No: this.Close(); break;
            //    case DialogResult.Cancel: break;
            //}
            this.Close();
        }

        private void barBt_LapPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuLinhNhienLieu.IsNew)
            {
                if (_loai == 1)
                {
                    MessageBox.Show(this, "Vui Lòng Cập Nhật Phiếu Lĩnh Nhiên Liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show(this, "Vui Lòng Cập Nhật Phiếu Đề Nghị Lĩnh Vật Tư", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                PhieuNhapXuat _phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(_phieuLinhNhienLieu.MaPhieuNhapXuat);
                if (_loai == 1)
                {
                    FrmPhieuXuatNhienLieu frm;
                    if (_phieuNhapXuat.MaPhieuNhapXuat == 0)
                        frm = new FrmPhieuXuatNhienLieu(_phieuLinhNhienLieu);
                    else

                        frm = new FrmPhieuXuatNhienLieu(_phieuNhapXuat);
                    frm.ShowDialog();
                }
                else
                {
                    FrmPhieuXuatVatTuHangHoa frm;
                    if (_phieuNhapXuat.MaPhieuNhapXuat == 0)
                        frm = new FrmPhieuXuatVatTuHangHoa(_phieuLinhNhienLieu);
                    else frm = new FrmPhieuXuatVatTuHangHoa(_phieuNhapXuat, 1);
                    frm.ShowDialog();
                }
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTao();
        }

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
                    cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", _phieuLinhNhienLieu.MaPhieuLinhNhienLieu);


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
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
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
                    cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", _phieuLinhNhienLieu.MaPhieuLinhNhienLieu);
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
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate("", UserId, DateTime.Today);
                frmReport frm = new frmReport();
                frm.HienThiReport(_reportTemplate, dataSet);
                frm.Show();
            }//us
        }//END InDeNghiLinhVatTu
        public bool MauInPhieuLinhNhienLieu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                string tenKho = "";
                if (_phieuLinhNhienLieu.MaKho != 0)
                {
                    KhoBQ_VT kho = KhoBQ_VT.GetKhoBQ_VT(_phieuLinhNhienLieu.MaKho, maCongTy);
                    tenKho = kho.TenKho + " - " + kho.MaDiaChi;
                }
                DataTable tblTenKho = new DataTable();
                tblTenKho.TableName = "tblTenKho";
                tblTenKho.Columns.Add("TenKho", typeof(string));
                tblTenKho.Rows.Add(tenKho);
                dataSet.Tables.Add(tblTenKho);
                //tao bang_REPORT_ReportHeader 
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us 
            return true;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_loai == 1)
            {
                //dataSet = new DataSet();
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuLinhNhienLieu");
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, ERP_Library.Security.CurrentUser.Info.UserID, dtDenNgay);

                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = ERP_Library.Security.CurrentUser.Info.UserID;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }

                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
            }
            else
            {

                //dataSet = new DataSet();
                ReportTemplate _report = ReportTemplate.GetReportTemplate("DeNghiLinhVatTu");
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, ERP_Library.Security.CurrentUser.Info.UserID, dtDenNgay);

                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = ERP_Library.Security.CurrentUser.Info.UserID;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }

                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
            }

        }

        private void gridView_CTPhieuLinhNhienLieu_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.CopyCell(gridView_CTPhieuLinhNhienLieu, e);
        }

        private void frmPhieuLinhNhienLieu_Load(object sender, EventArgs e)
        {
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(gridView_CTPhieuLinhNhienLieu, 35);
            if (_loai == 1)
            {
                //_phieuLinhNhienLieu.MaKho = KhoBQ_VTList.GetKhoBQ_VTList(4)[0].MaKho;
                //_phieuLinhNhienLieu.MaBoPhanNhan = BoPhan.GetBoPhan(23).MaBoPhan;
                lbDiaChi.Visible = true;
                //Nut In Phieu Linh
                btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                SubbtnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                lbDiaChi.Visible = false;
                //Nut In Phieu De Nghi
                btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                SubbtnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            XtraFrm_HangHoa dlg = new XtraFrm_HangHoa(0);
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (dlg.MaHangHoaChon != 0)
                {
                    if (_loai == 1)
                    {
                        hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(4);
                    }
                    else
                    {
                        hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList();
                    }
                    if (cTPhieuLinhNhienLieuListBindingSource.Current == null)
                        gridView_CTPhieuLinhNhienLieu.AddNewRow();
                    CT_PhieuLinhNhienLieu ct_plnl = (CT_PhieuLinhNhienLieu)cTPhieuLinhNhienLieuListBindingSource.Current;
                    ct_plnl.MaHangHoa = dlg.MaHangHoaChon;
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_plnl.MaHangHoa);
                    ct_plnl.MaDonViTinh = hangHoa.MaDonViTinh;
                    gridView_CTPhieuLinhNhienLieu.RefreshData();
                }

            }
        }



        private void GridLookupEdit_Xe_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                //
                if (_phieuLinhNhienLieu.MaBoPhanNhan == 0)
                    MessageBox.Show("Vui lòng chọn Mã Bộ phận nhận trước khi thêm mới Biển số xe");
                else
                {

                    Frm_Xe frm = new Frm_Xe(_phieuLinhNhienLieu.MaBoPhanNhan);
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        if (frm.MaXeChon != 0)
                        {
                            XeListBindingSource.DataSource = XeList.GetXeList(_phieuLinhNhienLieu.MaBoPhanNhan);
                            GridLookupEdit_Xe.Refresh();
                            _phieuLinhNhienLieu.IDXe = frm.MaXeChon;
                        }
                    }
                }
                //
            }
            else if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookupEdit_Xe.EditValue = null;
                _phieuLinhNhienLieu.IDXe = 0;
            }

        }

        private void gridLookUpEdit_KhoNhan_EditValueChanged(object sender, EventArgs e)
        {

            if (gridLookUpEdit_KhoNhan.EditValue != null)
            {
                int Temp;
                if (int.TryParse(gridLookUpEdit_KhoNhan.EditValue.ToString(), out Temp))
                {
                    _phieuLinhNhienLieu.DiaChi = KhoBQ_VT.GetKhoBQ_VT(Temp, maCongTy).MaDiaChi;
                }
            }

        }

        private void gridView_CTPhieuLinhNhienLieu_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CT_PhieuLinhNhienLieu _ct_plnl = (CT_PhieuLinhNhienLieu)cTPhieuLinhNhienLieuListBindingSource.Current;
            if (e.Column.Name == "colMaHangHoa")
            {
                gridControl_CTPhieuLinhNhienLieu.Update();
                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(_ct_plnl.MaHangHoa);
                _ct_plnl.MaDonViTinh = hangHoa.MaDonViTinh;
            }
            decimal tongSoLuongDuyet = 0;
            foreach (CT_PhieuLinhNhienLieu ct_plnl in _phieuLinhNhienLieu.CT_PhieuLinhNhienLieuList)
            {
                tongSoLuongDuyet += ct_plnl.SoLuongXuat;
            }
            _phieuLinhNhienLieu.TongSoLuongDuyet = tongSoLuongDuyet;
        }

        private void btnInMauPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("MauInPhieuLinhNhienLieu");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
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

        private void btnInPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuLinhNhienLieu");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
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

        private void dateEdit_NgayLap_EditValueChanged(object sender, EventArgs e)
        {
            if (_loai == 1)
            {
                DateTime _dateChanged = new DateTime();
                if (DateTime.TryParse(dateEdit_NgayLap.EditValue.ToString(), out _dateChanged))
                {//_dateChanged = (DateTime)dateEdit_NgayLap.EditValue;
                    SetNgayHetHan(_dateChanged);
                    _phieuLinhNhienLieu.NgayLap = _dateChanged;
                }
            }
        }

        private void gridView_CTPhieuLinhNhienLieu_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuLinhNhienLieu _ct_PhieuLinhNhienLieu = (CT_PhieuLinhNhienLieu)cTPhieuLinhNhienLieuListBindingSource.Current;
            _ct_PhieuLinhNhienLieu.GhiChu = _phieuLinhNhienLieu.DienGiai;
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuLinhNhienLieu.MaPhieuNhapXuat != 0)
            {
                MessageBox.Show(this, "Phiếu Lĩnh đã Xuất, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(this, "Bạn muốn xóa Phiếu này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    PhieuLinhNhienLieu.DeletePhieuLinhNhienLieu(_phieuLinhNhienLieu);
                    MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnThemMoi.PerformClick();
                }
                catch
                {
                    MessageBox.Show(this, "Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }










    }
}