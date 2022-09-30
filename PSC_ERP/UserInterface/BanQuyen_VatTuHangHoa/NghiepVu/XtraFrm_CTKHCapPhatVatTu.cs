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


namespace PSC_ERP
{
    public partial class XtraFrm_CTKHCapPhatVatTu : DevExpress.XtraEditors.XtraForm
    {
        KHCapPhatVatTu _kHCapPhatVatTu;
        string _soKeHoach;
        NhomHangHoaBQ_VTList _nhomHangHoaBQ_VTList;

        int _userID = ERP_Library.Security.CurrentUser.Info.UserID;        
        DataSet dataSet = new DataSet();

        DateTime _ngayLap;
        public XtraFrm_CTKHCapPhatVatTu(KHCapPhatVatTu kh)
        {
            InitializeComponent();                 
            LoadForm();
            KhoiTaoPhieu(kh);
        }

        public XtraFrm_CTKHCapPhatVatTu()
        {
            InitializeComponent();            
            LoadForm();
            KhoiTao();
        }
                
        public void LoadForm()
        {
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList();
            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanList();
            loaiVatTuHHBQVTListBindingSource.DataSource = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHList();
             
            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Mã", typeof(byte));
            _dataTable.Columns.Add("Duyệt", typeof(string));
            _dataTable.Rows.Add(1, "Không duyệt");
            _dataTable.Rows.Add(2, "Duyệt");

            lueTinhTrang.Properties.DataSource = _dataTable;
            lueTinhTrang.Properties.ValueMember = "Mã";
            lueTinhTrang.Properties.DisplayMember = "Duyệt";

            spinEdit_Nam.EditValue = DateTime.Today.Year;      
        }

        private void KhoiTao()
        {
            _kHCapPhatVatTu = KHCapPhatVatTu.NewKHCapPhatVatTu();
            if (_kHCapPhatVatTu.IsNew)
                _kHCapPhatVatTu.SoKeHoach = KHCapPhatVatTu.SetSoKeHoach(_userID,_kHCapPhatVatTu.NgayLap);
            _soKeHoach = _kHCapPhatVatTu.SoKeHoach;
            kHCapPhatVatTuBindingSource.DataSource = _kHCapPhatVatTu;
            cTKHCapPhatVatTuListBindingSource.DataSource = _kHCapPhatVatTu.CT_KHCapPhatVatTuList;
        }

        private void KhoiTaoPhieu(KHCapPhatVatTu khCapPhatVatTu)
        {
            _kHCapPhatVatTu = khCapPhatVatTu;
            if (_kHCapPhatVatTu.IsNew)
                _kHCapPhatVatTu.SoKeHoach = KHCapPhatVatTu.SetSoKeHoach(_userID, _kHCapPhatVatTu.NgayLap);
            _soKeHoach = _kHCapPhatVatTu.SoKeHoach;
            kHCapPhatVatTuBindingSource.DataSource = _kHCapPhatVatTu;
            cTKHCapPhatVatTuListBindingSource.DataSource = _kHCapPhatVatTu.CT_KHCapPhatVatTuList;
        }

        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_KHCapPhatVatTu ct_kehoach in _kHCapPhatVatTu.CT_KHCapPhatVatTuList)
            {
                if (ct_kehoach.MaHangHoa == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else if (ct_kehoach.SoLuongDeXuatSD == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập số lượng đề xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }                
            }
            return kq;
        }

        private bool KiemTraDuLieu()
        { 
            bool kq = false;
            if (KHCapPhatVatTu.CheckSoKeHoach(_kHCapPhatVatTu.MakeHoachCapPhat, _kHCapPhatVatTu.SoKeHoach) != 0)
            {
                MessageBox.Show("Số kế hoạch đã tồn tại. \r\n Vui lòng lấy giá trị mặc định. \r\n Cập nhật thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _kHCapPhatVatTu.SoKeHoach = _soKeHoach;
                txtSoKeHoach.Focus();
            }
            else
            if (_kHCapPhatVatTu.MaBoPhan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn bộ phận lập kế hoạch", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lueBoPhan.Focus();
            }
            else if (_kHCapPhatVatTu.Nam == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinEdit_Nam.Focus();
            }
            else if (KiemTraChiTiet() == false)
            {
                grdv_CTKeHoach.Focus();
            }
            else kq = true;
            return kq;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtSoKeHoach.EditValue != null)//IF 1
            {
                string _soPhieu = txtSoKeHoach.EditValue.ToString();
                int _stt;
                if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                {
                    //B
                    try
                    {
                        if (KiemTraDuLieu() == true)
                        {
                            _kHCapPhatVatTu.ApplyEdit();
                            _kHCapPhatVatTu.Save();
                            MessageBox.Show(this, "Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //E
                }//END IF 2
                else
                {
                    MessageBox.Show("Số Phiếu Không Hợp Lệ! 4 ký tự đầu phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoKeHoach.Focus();
                }

            }//END IF 1
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTao();
            deNgayLap.Focus();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
        }              

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdv_CTKeHoach.DeleteSelectedRows();
        }

        #region grdv_CTKeHoach_CellValueChanged
        private void grdv_CTKeHoach_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdv_CTKeHoach.FocusedColumn.Name == "colMaHangHoa")
            {
                CT_KHCapPhatVatTu ct_KHCapPhatVT = (CT_KHCapPhatVatTu)cTKHCapPhatVatTuListBindingSource.Current;
                ct_KHCapPhatVT.SoLuongTHNamTruoc = HangHoaBQ_VT.GetSLXuatHangHoaTheoPhongBan(_kHCapPhatVatTu.MaBoPhan, ct_KHCapPhatVT.MaHangHoa, _kHCapPhatVatTu.NgayLap);
                
            }
        }
        #endregion 

        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void lueLoaiVatTu_EditValueChanged(object sender, EventArgs e)
        {
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList((int)lueLoaiVatTu.EditValue);
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTemplate _report = ReportTemplate.GetReportTemplate("DuTruKeHoach");
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
        }

        public void InDuTruKeHoach()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao InDuTruKeHoach
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DuTruKehoach";
                    cm.Parameters.AddWithValue("@MakeHoachCapPhat", _kHCapPhatVatTu.MakeHoachCapPhat);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_DuTruKehoach;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
            }//us
        }

        private void deNgayLap_EditValueChanged(object sender, EventArgs e)
        {
            _ngayLap = (DateTime)deNgayLap.EditValue;
        }
      
        private void grdv_CTKeHoach_KeyDown(object sender, KeyEventArgs e)//Copy nhieu dong
        {
            HamDungChung.CopyCell(grdv_CTKeHoach, e);
        }

        private void XtraFrm_CTKHCapPhatVatTu_Load(object sender, EventArgs e)
        {
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grdv_CTKeHoach, 35);
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraFrm_HangHoa dlg = new XtraFrm_HangHoa(0);
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if(lueLoaiVatTu.EditValue!=null)
                    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList((int)lueLoaiVatTu.EditValue);
                else
                    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList();
                if (cTKHCapPhatVatTuListBindingSource.Current == null)
                    grdv_CTKeHoach.AddNewRow();
                CT_KHCapPhatVatTu ct_KHCapPhatVatTu = (CT_KHCapPhatVatTu)cTKHCapPhatVatTuListBindingSource.Current;
                ct_KHCapPhatVatTu.MaHangHoa = dlg.MaHangHoaChon;
                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_KHCapPhatVatTu.MaHangHoa);
                grdv_CTKeHoach.RefreshData();

            }
        }

        
    }
}
