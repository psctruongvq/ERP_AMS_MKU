using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERP_Core;
using DevExpress.XtraGrid.Views.Grid;

namespace PSC_ERP.Main
{
    public partial class frmDialogTimChonTaiSanCoDinhCaBiet : XtraForm
    {
        //Private Static Field
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        //Private Member field
        #region Private Member field
        List<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList = null;
        List<Int32> _taiSanCoDinhCaBietThuocProjectList = null;
        Boolean _daLoadXong = false;
        List<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietDuocChonList = new List<tblTaiSanCoDinhCaBiet>();
        #endregion

        //Public Member field
        #region Public Member field

        #endregion

        //Public Member Property
        #region Public Member Property
        public List<tblTaiSanCoDinhCaBiet> TaiSanCoDinhCaBietDuocChonList
        {
            get { return _taiSanCoDinhCaBietDuocChonList; }
        }
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDialogTimChonTaiSanCoDinhCaBiet()
        {
            InitializeComponent();
        }
        public frmDialogTimChonTaiSanCoDinhCaBiet(List<Int32> taiSanCoDinhCaBietList)
        {
            InitializeComponent();
            //Lấy danh sách tài sản cố định cá biệt thuộc project
            _taiSanCoDinhCaBietThuocProjectList = taiSanCoDinhCaBietList;
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private void  LoadData()
        {
            {//Bộ phận

                List<tblBoPhanERPNew> boPhanList = BoPhanERPNew_Factory.New().GetAll().ToList();
                tblBoPhanERPNew boPhan_chonTatCa = new tblBoPhanERPNew() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
                boPhanList.Insert(0, boPhan_chonTatCa);

                tblBoPhanERPNewBindingSource.DataSource = boPhanList;
                //
                this.cbPhongBan.EditValue = -1;
                this.cbPhongBan.EditValue = 0;
            }
        }
        private void TimTaiSanCoDinhCaBiet()
        {
            using (DialogUtil.Wait(this))
            {
                int maNhomTaiSan = Convert.ToInt32(cbNhomTaiSan.EditValue);
                int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);
                int maLoaiTaiSan = Convert.ToInt32(cbLoaiTaiSan.EditValue);
                int maTaiSanCoDinh = Convert.ToInt32(cbTaiSanCD.EditValue);
                DateTime tuNgay;
                if (chkChonTuNgay.Checked)
                    tuNgay = Convert.ToDateTime(dteTuNgay.EditValue);
                else
                    tuNgay = DateTime.MinValue;
                DateTime denNgay = Convert.ToDateTime(dteDenNgay.EditValue);

                //Lấy tài sản cố định cá biệt
                _taiSanCoDinhCaBietList = TaiSanCoDinhCaBiet_Factory.New().Get_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaPhongBanAndMaNhomTSAndMaLoaiTSAndMaTSCD(maPhongBan, maNhomTaiSan, maLoaiTaiSan, maTaiSanCoDinh, tuNgay, denNgay).ToList();
                
                //Bỏ những tài sản đã thêm vào project ra khỏi danh sách tìm
                RemoveTaiSanCoDinhRaKhoiDanhSachCanTim(_taiSanCoDinhCaBietList);

                //Gán BindingSource
                tblTaiSanCoDinhCaBietBindingSource.DataSource = _taiSanCoDinhCaBietList;
            }
        }
        private void RemoveTaiSanCoDinhRaKhoiDanhSachCanTim(List<tblTaiSanCoDinhCaBiet> taiSanCoDinhCaBietList)
        {
            foreach (var item in _taiSanCoDinhCaBietThuocProjectList)
            {
                    tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet = (from o in taiSanCoDinhCaBietList
                                                                where o.MaTSCDCaBiet == item
                                                                select o).FirstOrDefault();
                    if (taiSanCoDinhCaBiet != null)
                    {
                        taiSanCoDinhCaBietList.Remove(taiSanCoDinhCaBiet);
                    }
            }
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmDialogTaiSanCoDinhCaBiet_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //Load dữ liệu
                LoadData();

                // Đưa checkbox lên lưới
                PSC_ERP_Common.GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewTSCDCaBiet, colChon);

                //Cấu hình lưới
                GridUtil.ConfigGridView1(true, false, false, true, false, grdViewTSCDCaBiet);

                // Set mặc định ngày kiểm kê
                //dteTuNgay.EditValue = AppUser_Factory.New().SystemDate;
                dteTuNgay.EditValue = new DateTime(1998,1,1);
                dteDenNgay.EditValue = app_users_Factory.New().SystemDate;
                //dteDenNgay.EditValue = DateTime.Now;

                //Ghi nhận đã load xong form
                _daLoadXong = true;
            };
        }
        private void btnDuaDuLieuVeTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            //lấy những dòng được chọn
            if (_taiSanCoDinhCaBietList != null)
                _taiSanCoDinhCaBietDuocChonList = (from o in _taiSanCoDinhCaBietList.ToList()
                                                   where o.Chon == true
                                                   select o).ToList();
            //
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void cbPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);

                //gan nhom thanh 0
                cbNhomTaiSan.EditValue = -1;
                cbNhomTaiSan.EditValue = 0;
                if (maPhongBan >= 0)
                {
                    //lay nhom theo phong ban
                    List<tblDanhMucTSCD> nhomTaiSanList = DanhMucTSCD_Factory.New().Get_DanhSachNhomTaiSan_CuaTaiSanChuaThanhLy_ByMaPhongBan(maPhongBan).ToList();
                    tblDanhMucTSCD nts_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                    nhomTaiSanList.Insert(0, nts_chonTatCa);

                    nhomTSCDBindingSource.DataSource = nhomTaiSanList;
                }
            }
        }
        private void cbNhomTaiSan_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                int maNhomTaiSan = Convert.ToInt32(cbNhomTaiSan.EditValue);
                int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);

                //gan loai thanh 0
                cbLoaiTaiSan.EditValue = -1;
                cbLoaiTaiSan.EditValue = 0;
                if (maNhomTaiSan >= 0)
                {
                    //lay loai
                    List<tblDanhMucTSCD> loaiTaiSanList = DanhMucTSCD_Factory.New().Get_DanhSachLoaiTaiSan_CuaTaiSanChuaThanhLy_ByMaPhongBanAndMaNhomTS(maPhongBan, maNhomTaiSan).ToList();
                    tblDanhMucTSCD lts_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                    loaiTaiSanList.Insert(0, lts_chonTatCa);

                    loaiTSCDBindingSource.DataSource = loaiTaiSanList;
                }
            }
        }
        private void cbLoaiTaiSan_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                int maNhomTaiSan = Convert.ToInt32(cbNhomTaiSan.EditValue);
                int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);
                int maLoaiTaiSan = Convert.ToInt32(cbLoaiTaiSan.EditValue);
                //gan tscd thanh 0;
                cbTaiSanCD.EditValue = -1;
                cbTaiSanCD.EditValue = 0;

                if (maLoaiTaiSan >= 0)
                {
                    //lay tai san
                    List<tblDanhMucTSCD> taiSanCoDinhList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_CuaTaiSanChuaThanhLy_ByMaPhongBanAndMaNhomTSAndMaLoaiTS(maPhongBan, maNhomTaiSan, maLoaiTaiSan).ToList();
                    tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                    taiSanCoDinhList.Insert(0, tscd_chonTatCa);

                    taiSanCoDinhBindingSource.DataSource = taiSanCoDinhList;
                }
            }
        }
        private void chkChonTuNgay_CheckedChanged(object sender, EventArgs e)
        {
            dteTuNgay.Enabled = chkChonTuNgay.Checked;
        }
        private void btnTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Tìm tài sản cố định cá biệt
            TimTaiSanCoDinhCaBiet();
        }
        #endregion
    }
}