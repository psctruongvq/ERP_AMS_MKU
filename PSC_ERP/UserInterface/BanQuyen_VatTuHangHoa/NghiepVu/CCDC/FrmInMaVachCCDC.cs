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
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class FrmInMaVachCCDC : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private bool _choPhepCapNhatNguyenGia = false;
        CCDCList _cCDCList = CCDCList.NewCongCuDungCuList();
        CCDCList _ccdcInList = CCDCList.NewCongCuDungCuList();
        HangHoaBQ_VTList _hangHoaList;
        BoPhanList _boPhanListAll;
        int _maBoPhan = 0;
        int _maHangHoa = 0;

        DataSet dataSet = new DataSet();
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        #endregion//Properties

        public FrmInMaVachCCDC()
        {
            InitializeComponent();
            initForm();
            KhoiTao();
            DesignGridView_HDBQ();
            DesignGrdLuBoPhan();
            DesignGrdLuHangHoa();
            LoadData();
        }

        private void KhoiTao()
        {
            congCuDungCuListBindingSource.DataSource = _cCDCList;
            gridControl1.DataSource = congCuDungCuListBindingSource;

            _hangHoaList = HangHoaBQ_VTList.NewHangHoaBQ_VTList();
            hangHoaBQVTListBindingSource.DataSource = _hangHoaList;

            _boPhanListAll = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();//.GetBoPhanListBy_All();
            BoPhan boPhan_ChonTatCa = BoPhan.NewBoPhan();
            boPhan_ChonTatCa.TenBoPhan = "<<Tất cả>>";
            boPhan_ChonTatCa.MaBoPhanQL = "<<Tất cả>>";
            _boPhanListAll.Insert(0, boPhan_ChonTatCa);
            boPhanListAllBindingSource.DataSource = _boPhanListAll;
        }

        #region Function
        private void initForm()
        {
            boPhanListAllBindingSource.DataSource = typeof(BoPhanList);
            hangHoaBQVTListBindingSource.DataSource = typeof(HangHoaBQ_VTList);
            grdLUBoPhan.Properties.DataSource = boPhanListAllBindingSource;
            grdLUHangHoa.Properties.DataSource = hangHoaBQVTListBindingSource;
        }

        private void Unlock_LockColumnNguyenGia(bool unlock)
        {
            if (unlock)
            {
                HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "NguyenGia" });
            }
            else
            {
                HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "NguyenGia" });
            }
        }

        private bool GetThongTinSearch()
        {
            if (this.grdLUBoPhan.EditValue != null)
            {
                //
                _maBoPhan = (int)this.grdLUBoPhan.EditValue;
                _maHangHoa = 0;

                if (this.grdLUHangHoa.EditValue != null)
                    _maHangHoa = (int)this.grdLUHangHoa.EditValue;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bộ phận trước khi tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void LoadData()
        {
            _cCDCList = CCDCList.NewCongCuDungCuList();
            _cCDCList = CCDCList.GetCongCuDungCuListForInMaVach(_maBoPhan, _maHangHoa);

            congCuDungCuListBindingSource.DataSource = _cCDCList;
        }


        private void DesignGridView_HDBQ()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "Chon", "MaQuanLy", "TenHangHoa", "NgayBDHoatDong", "NguyenGia", "PhongBanHienTai", "DaIn" },
                                new string[] { "Chọn in", "Mã CCDC", "Tên CCDC", "Ngày hoạt động", "Nguyên giá", "Bộ phận hiện tại", "Đã In" },
                                             new int[] { 60, 100, 200, 80, 80, 150, 80 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Chon", "MaQuanLy", "TenHangHoa", "NgayBDHoatDong", "NguyenGia", "PhongBanHienTai", "DaIn" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "NguyenGia" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "NguyenGia" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "MaQuanLy", "TenHangHoa", "NgayBDHoatDong", "NguyenGia", "PhongBanHienTai", "DaIn" });

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            ////
            //RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            //LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            //LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            //LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            //HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien"}, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150}, true);
            //HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            //LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            //HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            //gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private void DesignGrdLuBoPhan()
        {
            grdLUBoPhan.Properties.ValueMember = "MaBoPhan";
            grdLUBoPhan.Properties.DisplayMember = "TenBoPhan";
            grdLUBoPhan.Properties.NullText = "";
            HamDungChung.InitGridLookUpDev(grdLUBoPhan, true, DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor);
            HamDungChung.ShowFieldGridLookUpDev(grdLUBoPhan, new string[] { "MaBoPhanQL", "TenBoPhan" }, new string[] { "Mã bộ phận", "Tên bộ phận" }, new int[] { 80, 200 });
            this.grdLUBoPhan.EditValueChanged += new System.EventHandler(this.grdLUBoPhan_EditValueChanged);
        }

        private void DesignGrdLuHangHoa()
        {
            grdLUHangHoa.Properties.ValueMember = "MaHangHoa";
            grdLUHangHoa.Properties.DisplayMember = "TenHangHoa";
            grdLUHangHoa.Properties.NullText = "";
            HamDungChung.InitGridLookUpDev(grdLUHangHoa, true, DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor);
            HamDungChung.ShowFieldGridLookUpDev(grdLUHangHoa, new string[] { "MaQuanLy", "TenHangHoa" }, new string[] { "Mã", "Tên nhóm CCDC" }, new int[] { 80, 200 });

        }

        private bool KiemTraChonCCDCRow()
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn công cụ dụng cụ cần xem!");
                return false;
            }
            return true;
        }

        private void ChangeFocus()
        {
            this.textBoxFocus.Focus();

        }


        public bool MeThod_InMaVachCCDC()
        {
            dataSet = new DataSet();
            DataTable dtmain = new DataTable();
            dtmain.TableName = "MainData";
            dtmain.Columns.Add("MaQLCCDC", typeof(string));
            dtmain.Columns.Add("TenCCDC", typeof(string));
            dtmain.Columns.Add("TenBoPhan", typeof(string));
            dtmain.Columns.Add("NgayHoatDong", typeof(string));
            dtmain.Columns.Add("NguyenGia", typeof(decimal));
            foreach (CCDC cc in _cCDCList)
            {
                if (cc.Chon) cc.DaIn = true;
                dtmain.Rows.Add(cc.MaQuanLy, cc.TenHangHoa, cc.PhongBanHienTai, cc.NgayBDHoatDong, cc.NguyenGia);
            }
            dataSet.Tables.Add(dtmain);
            //using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            //{

            //    cn.Open();
            //    //
            //    using (SqlCommand cm = cn.CreateCommand())
            //    {
            //        cm.CommandType = CommandType.StoredProcedure;
            //        cm.CommandText = "spd_InVachCCDC";//xài chung store với ChiTietPhanBoChiPhiCCDCChuyenTuTaiSan
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        dt.TableName = "MainData";
            //        dataSet.Tables.Add(dt);
            //    }
            //    //tao bang_REPORT_ReportHeader 
            //    using (SqlCommand cm = cn.CreateCommand())
            //    {
            //        cm.CommandType = CommandType.StoredProcedure;
            //        cm.CommandText = "spd_ReportHeaderAndFooter";
            //        cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        dt.TableName = "spd_ReportHeaderAndFooter";
            //        dataSet.Tables.Add(dt);
            //    }

            //}
            return true;
        }

        public bool MeThod_InMaVachBoPhanCCDC()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayDSBoPhanKeCaBoPhanMoRong";//xài chung store với ChiTietPhanBoChiPhiCCDCChuyenTuTaiSan
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }

            }
            return true;
        }

        private bool KiemTraCheck()
        {
            foreach (CCDC cc in _cCDCList)
            {
                if (cc.Chon) return true;
            }
            return false;
        }
        #endregion

        #region Event
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            checkBoxALL.Checked = false;
            this.ChangeFocus();
            if (GetThongTinSearch())
                LoadData();
            if (_cCDCList.Count == 0)//M
                MessageBox.Show("Danh Sách CCDC rỗng!");
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

        }

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

        private void FrmInMaVachCCDC_Load(object sender, EventArgs e)
        {
            grdLUBoPhan.EditValue = 0;
            //PSC_ERP_Common.GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.gridView1,);
        }


        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                congCuDungCuListBindingSource.EndEdit();
                _cCDCList.ApplyEdit();
                _cCDCList.Save();
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #endregion

        #region EventHandle
        private void grdLUBoPhan_EditValueChanged(object sender, EventArgs e)
        {
            int maBoPhan = 0;
            if (grdLUBoPhan.EditValue != null)
                maBoPhan = (int)grdLUBoPhan.EditValue;

            _hangHoaList = HangHoaBQ_VTList.GetHangHoaBQ_VTList_BoPhanDangSuDung(maBoPhan);
            HangHoaBQ_VT hangHoa_ChonTatCa = HangHoaBQ_VT.NewHangHoaBQ_VT();
            hangHoa_ChonTatCa.MaQuanLy = "<<Tất cả>>";
            hangHoa_ChonTatCa.TenHangHoa = "<<Tất cả>>";
            _hangHoaList.Insert(0, hangHoa_ChonTatCa);
            hangHoaBQVTListBindingSource.DataSource = _hangHoaList;
            grdLUHangHoa.EditValue = 0;
        }
        #endregion //EventHandle

        private void btnInMaVachCCDC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (KiemTraCheck())
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_InMaVachCCDC");
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
                MessageBox.Show("Hãy chọn các Công cụ dụng cụ cần in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBoxALL_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CCDC cc in _cCDCList)
            {
                cc.Chon = checkBoxALL.Checked;
            }
            congCuDungCuListBindingSource.DataSource = _cCDCList;
            gridControl1.RefreshDataSource();
        }

        private void btnInMaVachBoPhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_InMaVachBoPhanCCDC");
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
}