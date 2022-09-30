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
using System.IO;
using System.Diagnostics;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class frmPhanBoChiPhiCCDC : XtraForm
    {
        #region Properties
        PhanBoChiPhiCCDC _phanBoChiPhiCCDC = PhanBoChiPhiCCDC.NewPhanBoChiPhiCCDC();
        BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        DataSet dataSet = new DataSet();
        private int _maBoPhanPhanBo = -1;
        private DateTime _ngayPhanBoOld;
        int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        #endregion//Properties

        #region Constructors
        public frmPhanBoChiPhiCCDC()
        {
            InitializeComponent();
            _boPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            BoPhan boPhan = BoPhan.NewBoPhan("<<Tất cả>>");
            _boPhanList.Insert(0, boPhan);
            boPhanListBindingSource.DataSource = _boPhanList;

            KhoiTao();
        }

        public frmPhanBoChiPhiCCDC(PhanBoChiPhiCCDC phanBoChiPhiCCDC)
        {
            InitializeComponent();
            _boPhanList = BoPhanList.GetBoPhanList();
            BoPhan boPhan = BoPhan.NewBoPhan("<<Tất cả>>");
            _boPhanList.Insert(0, boPhan);
            boPhanListBindingSource.DataSource = _boPhanList;

            KhoiTaoPhieu(phanBoChiPhiCCDC);
        }
        #endregion //Constructors

        #region Methods
        private void KhoiTao()
        {
            _phanBoChiPhiCCDC = PhanBoChiPhiCCDC.NewPhanBoChiPhiCCDC();
            cTPhanBoChiPhiCCDCListBindingSource.DataSource = _phanBoChiPhiCCDC.CT_PhanBoChiPhiCCDCList;
            phanBoChiPhiCCDCBindingSource.DataSource = _phanBoChiPhiCCDC;
            _ngayPhanBoOld = _phanBoChiPhiCCDC.NgayPhanBo;          
            lookUpEdit_PhongBan.Properties.ReadOnly = false;
        }

        private void KhoiTaoPhieu(PhanBoChiPhiCCDC phanBoChiPhiCCDC)
        {
            _phanBoChiPhiCCDC = phanBoChiPhiCCDC;
            cTPhanBoChiPhiCCDCListBindingSource.DataSource = _phanBoChiPhiCCDC.CT_PhanBoChiPhiCCDCList;
            phanBoChiPhiCCDCBindingSource.DataSource = _phanBoChiPhiCCDC;
            _ngayPhanBoOld = _phanBoChiPhiCCDC.NgayPhanBo;
            lookUpEdit_PhongBan.Properties.ReadOnly = true;
        }

        private bool KiemTraDuLieu()
        {
            if (!CheckValidWhenChangeNgayPhanBo()) return false;

            //if (_phanBoChiPhiCCDC.MaBoPhan < 1)
            //{
            //    MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            else if (_phanBoChiPhiCCDC.CT_PhanBoChiPhiCCDCList.Count == 0)
            {
                MessageBox.Show(this, "Chưa có CCDC phân bổ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private decimal TinhSoTienPhanBo(decimal phanTram, decimal nguyenGia)
        {
            decimal returnValue = Math.Round(phanTram * nguyenGia / 100);
            return returnValue;
        }

        private bool CheckValidWhenChangeNgayPhanBo()//Them
        {
             ChungTu chungTu = ChungTu.GetChungTu(_phanBoChiPhiCCDC.MaChungTu);
             if (chungTu.MaChungTu != 0)
             {
                 DialogUtil.ShowWarning("Đã Lập chứng từ không thể xóa!\nVui lòng xóa chứng từ trước!");
                 return false;
             }
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phanBoChiPhiCCDC.NgayPhanBo);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!CCDC.KiemTraThaoTacCCDCHopLe(_phanBoChiPhiCCDC.NgayPhanBo))
            {
                MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (_phanBoChiPhiCCDC.NgayPhanBo.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_phanBoChiPhiCCDC.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayPhanBoOld);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (!CCDC.KiemTraThaoTacCCDCHopLe(_ngayPhanBoOld))
                {
                    MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (_ngayPhanBoOld.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (((DateTime)deNgayPhanBo.OldEditValue).Year != ((DateTime)deNgayPhanBo.EditValue).Year)
                {
                    MessageBox.Show(string.Format("Không thể chuyển đổi năm chạy phân bổ!", (_ngayPhanBoOld.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void frmPhanBoChiPhiCCDC_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.ConfigGridView(grdVCT_PhanBoChiPhi
                     , setSTT: true//
                     , initCopyCell: true//
                     , multiSelectCell: true//
                     , multiSelectRow: false
                     , initNewRowOnTop: false);
            kyListBindingSource.DataSource = KyList.GetKyList();            
        }

        private decimal TinhPhanTram(decimal nguyenGia, decimal soTienPhanBo)
        {
            decimal returnValue = Math.Round(soTienPhanBo / (nguyenGia / 100), 2);
            return returnValue;
        }

        private void ChayPhanBo()
        {
            _maBoPhanPhanBo = -1;
            if (lookUpEdit_PhongBan.EditValue != null)
            {
                int mabophanOut;
                if (int.TryParse(lookUpEdit_PhongBan.EditValue.ToString(), out mabophanOut))
                {
                    _maBoPhanPhanBo = mabophanOut;
                }
            }
            if (_maBoPhanPhanBo == -1)
            {
                MessageBox.Show("Vui lòng nhập thông tin phòng ban cần phân bổ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gridLookUpEdit_Ky.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ cần phân bổ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maKy = (int)gridLookUpEdit_Ky.EditValue;
            DateTime ngayphanBo = (DateTime)deNgayPhanBo.EditValue;

            //if (PhanBoChiPhiCCDC.KiemTraDaPhanBoTrongKy(_maBoPhanPhanBo, ngayphanBo))
            //{
            //    MessageBox.Show("Năm này đã chạy phân bổ, vui lòng xóa phân bổ để chạy lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (PhanBoChiPhiCCDC.KiemTraDuocPhepPhanBoTrongKy(_maBoPhanPhanBo, maKy)==2)
            {
                MessageBox.Show("Kỳ này đã chạy phân bổ, vui lòng xóa phân bổ để chạy lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (PhanBoChiPhiCCDC.KiemTraDuocPhepPhanBoTrongKy(_maBoPhanPhanBo, maKy) == 3)
            {
                MessageBox.Show("Kỳ này trước của kỳ này chưa chạy phân bổ, vui lòng chạy phân bổ kỳ trước đó!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (CCDC.KiemTraThaoTacCCDCHopLe(ngayphanBo))
            //{
            //    _phanBoChiPhiCCDC = PhanBoChiPhiCCDC.NewPhanBoChiPhiCCDC(_maBoPhanPhanBo, ngayphanBo);
            //}
            //else
            //{
            //    _phanBoChiPhiCCDC = PhanBoChiPhiCCDC.NewPhanBoChiPhiCCDC();
            //    MessageBox.Show("Thao tác không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            if (CCDC.KiemTraThaoTacCCDCHopLe(ngayphanBo))
            {
                _phanBoChiPhiCCDC = PhanBoChiPhiCCDC.NewPhanBoChiPhiCCDC(_maBoPhanPhanBo, maKy, _userID);
            }
            else
            {
                _phanBoChiPhiCCDC = PhanBoChiPhiCCDC.NewPhanBoChiPhiCCDC();
                MessageBox.Show("Thao tác không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cTPhanBoChiPhiCCDCListBindingSource.DataSource = _phanBoChiPhiCCDC.CT_PhanBoChiPhiCCDCList;
            phanBoChiPhiCCDCBindingSource.DataSource = _phanBoChiPhiCCDC;
        }
        #endregion//Methods

        #region Events
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            try
            {
                if (KiemTraDuLieu() == true)
                {
                    if (_phanBoChiPhiCCDC.IsNew)
                        _phanBoChiPhiCCDC.SoChungTu = PhanBoChiPhiCCDC.SetSoChungTu(_phanBoChiPhiCCDC.NgayPhanBo);
                    _phanBoChiPhiCCDC.ApplyEdit();
                    _phanBoChiPhiCCDC.Save();
                    _ngayPhanBoOld = _phanBoChiPhiCCDC.NgayPhanBo;
                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTao();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckValidWhenChangeNgayPhanBo())
            {
                grdVCT_PhanBoChiPhi.DeleteSelectedRows();
            }
        }

        private void grdVCT_PhanBoChiPhi_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ChungTu chungTu = ChungTu.GetChungTu(_phanBoChiPhiCCDC.MaChungTu);
            if (chungTu.MaChungTu == 0)
            {
                if (e.RowHandle >= 0)
                {
                    if (object.ReferenceEquals(e.Column, this.colPhanTram))//A
                    {
                        //MessageBox.Show("Test");
                        decimal nguyenGia = (decimal)grdVCT_PhanBoChiPhi.GetRowCellValue(e.RowHandle, this.colNguyenGia);
                        decimal phanTram = (decimal)e.Value;
                        decimal soTienPhanBo = TinhSoTienPhanBo(phanTram, nguyenGia);
                        decimal chiPhiConLai = (decimal)grdVCT_PhanBoChiPhi.GetRowCellValue(e.RowHandle, this.colChiPhiConLai);
                        if (soTienPhanBo > chiPhiConLai)
                        {
                            soTienPhanBo = chiPhiConLai;
                        }
                        //khi so tien phan bo duoc gan vao luoi
                        //phan tram phan bo se duoc tinh toan lai o //B
                        grdVCT_PhanBoChiPhi.SetRowCellValue(e.RowHandle, this.colSoTienPhanBo, soTienPhanBo);
                    }
                    else if (object.ReferenceEquals(e.Column, this.colSoTienPhanBo))//B
                    {
                        decimal nguyenGia = (decimal)grdVCT_PhanBoChiPhi.GetRowCellValue(e.RowHandle, this.colNguyenGia);
                        decimal soTienPhanBo = (decimal)e.Value;
                        decimal phanTramMoi = TinhPhanTram(nguyenGia, soTienPhanBo);
                        decimal phanTramCu = (decimal)grdVCT_PhanBoChiPhi.GetRowCellValue(e.RowHandle, this.colPhanTram);
                        if (phanTramMoi != phanTramCu)//tranh vong lap vo tan
                        {
                            grdVCT_PhanBoChiPhi.SetRowCellValue(e.RowHandle, colPhanTram, phanTramMoi);
                        }
                    }                    
                }
            }
            else
            {
                DialogUtil.ShowWarning("Phân bổ chi phí đã lập chứng từ không thể thay đổi!\nVui lòng xóa chứng từ rồi mới được phép chỉnh sửa!");
            }
        }

        #region btnIn_ItemClick
        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTemplate _report = ReportTemplate.GetReportTemplate("spd_DSCT_CCDC_cho_phan_bo_den_ngay");
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

        public void Inspd_DSCT_CCDC_cho_phan_bo_den_ngay() //Thang
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao Inspd_DSCT_CCDC_cho_phan_bo_den_ngay
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DSCT_CCDC_cho_phan_bo_den_ngay";
                    cm.Parameters.AddWithValue("@MaPhanBo", _phanBoChiPhiCCDC.MaPhanBo); //gridLookUpEdit_PhanBo.EditValue
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_DSCT_CCDC_cho_phan_bo_den_ngay";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

                DataTable dtngay = new DataTable();
                //dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                //dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = _phanBoChiPhiCCDC.NgayPhanBo;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
            }//us             
        }
        #endregion

        #region btn_PhieuKeToan_ItemClick
        private void btn_PhieuKeToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phanBoChiPhiCCDC.IsNew != true)
            {
                ChungTu chungTu = ChungTu.GetChungTu(_phanBoChiPhiCCDC.MaChungTu);
                if (chungTu.MaChungTu != 0)
                {
                    //frmBangKe frm = new frmBangKe(chungTu);
                    FrmChungTuKeToanCustomize frm = new FrmChungTuKeToanCustomize(chungTu.MaChungTu);
                    frm.ShowDialog();
                }
                else
                {
                    //frmBangKe frm = new frmBangKe(_phanBoChiPhiCCDC);
                    FrmChungTuKeToanCustomize frm = new FrmChungTuKeToanCustomize(_phanBoChiPhiCCDC);
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        _phanBoChiPhiCCDC = PhanBoChiPhiCCDC.GetPhanBoChiPhiCCDC(_phanBoChiPhiCCDC.MaPhanBo);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Vui lòng cập nhật phân bổ chi phí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void deNgayPhanBo_Leave(object sender, EventArgs e)
        {
            if (deNgayPhanBo.OldEditValue != deNgayPhanBo.EditValue)
            {
                if (!CheckValidWhenChangeNgayPhanBo())
                {
                    _phanBoChiPhiCCDC.NgayPhanBo = _ngayPhanBoOld;
                    deNgayPhanBo.EditValue = _ngayPhanBoOld as object;
                }
                else
                {
                    if (((DateTime)deNgayPhanBo.OldEditValue).Year != ((DateTime)deNgayPhanBo.EditValue).Year && _phanBoChiPhiCCDC.IsNew)
                    {
                        _phanBoChiPhiCCDC.CT_PhanBoChiPhiCCDCList.Clear();
                        cTPhanBoChiPhiCCDCListBindingSource.DataSource = _phanBoChiPhiCCDC.CT_PhanBoChiPhiCCDCList;
                    }
                }
            }
        }
        #endregion//Events

        private void btnChayPhanBo_Click(object sender, EventArgs e)
        {
            ChayPhanBo();
        }

        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                grdVCT_PhanBoChiPhi.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void ItemHyperLinkEdit_PhieuXuat_Click(object sender, EventArgs e)
        {
            frmPhieuXuatPhanBoCCDC_Update frm;
            using (DialogUtil.Wait())
            {
                PhieuNhapXuatCCDC phieuXuat = PhieuNhapXuatCCDC.GetPhieuNhapXuatTheoSoPhieu((cTPhanBoChiPhiCCDCListBindingSource.Current as CT_PhanBoChiPhiCCDC).SoChungTu);
                frm = new frmPhieuXuatPhanBoCCDC_Update(phieuXuat, 0);
            }
            frm.ShowDialog();
        }

        //private void calcEdit_phantramphanbo_Leave(object sender, EventArgs e)
        //{
        //if (calcEdit_phantramphanbo.OldEditValue != calcEdit_phantramphanbo.EditValue)
        //{
        //    decimal _phanTram = 0;

        //    if (calcEdit_phantramphanbo.EditValue != null)
        //    {
        //        _phanTram = Convert.ToDecimal(calcEdit_phantramphanbo.EditValue.ToString());// Convert.ToDecimal("50,6"); //
        //    }
        //    for (int i = 0; i < grdVCT_PhanBoChiPhi.RowCount; i++)
        //    {
        //        grdVCT_PhanBoChiPhi.SetRowCellValue(i, this.colPhanTram, _phanTram);
        //    }
        //    ////////////////foreach (CT_PhanBoChiPhiCCDC ct_PhanBoChiPhi in _phanBoChiPhiCCDC.CT_PhanBoChiPhiCCDCList)
        //    ////////////////{
        //    ////////////////    ct_PhanBoChiPhi.PhanTram = _phanTram;
        //    ////////////////    ct_PhanBoChiPhi.SoTienPhanBo = TinhSoTienPhanBo(_phanTram, ct_PhanBoChiPhi.NguyenGia);//Math.Round(_phanTram * ct_PhanBoChiPhi.NguyenGia / 100);
        //    ////////////////}
        //    grdVCT_PhanBoChiPhi.RefreshData();
        //}
        //}
    }
}