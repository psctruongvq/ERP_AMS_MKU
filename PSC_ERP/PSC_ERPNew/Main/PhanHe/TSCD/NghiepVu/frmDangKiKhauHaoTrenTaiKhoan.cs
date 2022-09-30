using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Model;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using DevExpress.XtraEditors;

namespace PSC_ERPNew.Main
{
    public partial class frmDangKiKhauHaoTrenTaiKhoan : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDangKiKhauHaoTrenTaiKhoan singleton_ = null;
        public static frmDangKiKhauHaoTrenTaiKhoan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDangKiKhauHaoTrenTaiKhoan();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }
        #endregion

        //Private Member field
        #region Private Member field
        List<tblTiLeKhauHaoTheoTaiKhoan> _tiLeKhauHaoTheoTaiKhoanList = null;
        TiLeKhauHaoTheoTaiKhoan_Factory _tiLeKhauHaoTheoTaiKhoan_Factory = null;
        int _userID = PSC_ERP_Global.Main.UserID;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDangKiKhauHaoTrenTaiKhoan()
        {
            InitializeComponent();
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            if (grdViewDangKiKhauHaoTheoTaiKhoan.RowCount == 0)
            {
                // DialogUtil.ShowWarning("Chưa có dữ liệu.");
                // duocPhepLuu = false;
            }
            return duocPhepLuu;
        }

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }
        private bool Save()
        {
            this.ChangeFocus();

            //kiểm tra dữ liệu trước khi lưu
            if (DuocPhepLuu())
            {
                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {
                        //Lưu tỉ lệ khấu hao theo tài khoản
                        _tiLeKhauHaoTheoTaiKhoan_Factory.SaveChangesWithoutTrackingLog();
                        //_tiLeKhauHaoTheoTaiKhoan_Factory.SaveChanges(BusinessCodeEnum.TSCD_DangKyTiLeKHHMTheoTaiKhoan.ToString());
                    }
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (System.Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful(ex.Message);

                }

            }
            return false;
        }

        #endregion

        //Event Method
        #region Event Method

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void frmKiemKeTaiSan_Load(object sender, EventArgs e)
        {
            //Khởi tạo factory
            _tiLeKhauHaoTheoTaiKhoan_Factory = TiLeKhauHaoTheoTaiKhoan_Factory.New();
            //Set số thứ tự cho lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(grdViewDangKiKhauHaoTheoTaiKhoan);
            //Set giá trị cho năm
            spinNam.EditValue = app_users_Factory.New().SystemDate.Year;
        }

        private void spinNam_EditValueChanged(object sender, EventArgs e)
        {

            //Set cột phần trăm trên lưới là false (cho phép sửa)
            grdViewDangKiKhauHaoTheoTaiKhoan.Columns[tblTiLeKhauHaoTheoTaiKhoan.PhanTram_PropertyName].OptionsColumn.ReadOnly = false;

            //Khởi tạo lại factory
            _tiLeKhauHaoTheoTaiKhoan_Factory = TiLeKhauHaoTheoTaiKhoan_Factory.New();
            _tiLeKhauHaoTheoTaiKhoanList = new List<tblTiLeKhauHaoTheoTaiKhoan>();
            //Lấy giá trị của năm
            int year = Convert.ToInt32(spinNam.EditValue);

            //Lấy tỉ lệ khấu hao theo năm
            _tiLeKhauHaoTheoTaiKhoanList = _tiLeKhauHaoTheoTaiKhoan_Factory.Get_DanhSachTiLeKhauHaoTheoTaiKhoan_ByNam(year).ToList();
            //lấy ngày hiệu lực đưa lên form
            if (_tiLeKhauHaoTheoTaiKhoanList != null && _tiLeKhauHaoTheoTaiKhoanList.Count > 0)
            {

                dteNgayHieuLuc.DateTime = (_tiLeKhauHaoTheoTaiKhoanList[0].NgayHieuLuc ?? app_users_Factory.New().SystemDate);
            }
            else
            {
                dteNgayHieuLuc.DateTime = app_users_Factory.New().SystemDate;
                //dteNgayHieuLuc.DateTime = Convert.ToDateTime("01/01/" + year); //app_users_Factory.New().SystemDate;
            }
            //
            if (_tiLeKhauHaoTheoTaiKhoanList != null && _tiLeKhauHaoTheoTaiKhoanList.Count == 0)
            {
                if (DialogResult.Yes == DialogUtil.ShowYesNo("Năm " + year.ToString() + " chưa đăng ký tỉ lệ KHHM. Bạn có muốn tạo đăng ký mới không?"))
                {
                    //Lấy tất cả tài khoản có trong tài sản cố định cá biệt theo năm khấu hao
                    List<tblTaiKhoan> taiKhoanList = TaiKhoan_Factory.New().Get_DanhSachTaiKhoanCoTrongTaiSanCoDinhCaBiet().ToList();

                    if (taiKhoanList != null && taiKhoanList.Count != 0)
                    {
                        foreach (tblTaiKhoan taiKhoan in taiKhoanList)
                        {
                            decimal nguyenGiaTon = 0;
                            ///////////Lấy tỉ lệ phần trăm khấu khao của năm trước dựa vào số hiệu tài khoản//
                            tblTiLeKhauHaoTheoTaiKhoan tiLeKhauHaoTheoTaiKhoanCu = TiLeKhauHaoTheoTaiKhoan_Factory.New().Get_TiLeKhauHaoTheoTaiKhoan_BySoHieuTaiKhoanAndNam(taiKhoan.SoHieuTK, year - 1);
                            ///////////Lấy nguyên giá tồn đầu năm///////////////////////////////////////////// 
                            DateTime ngayChot = dteNgayHieuLuc.DateTime.AddDays(-1).Date;
                            //nguyenGiaTon = TaiSanCoDinhCaBiet_Factory.New().Get_TongNguyenGiaCuaTaiSanCaBiet_BySoHieuTaiKhoanAndNgayChot(ngayChot, taiKhoan.SoHieuTK);
                                nguyenGiaTon = TaiSanCoDinhCaBiet_Factory.New().Get_TongNguyenGiaCuaTaiSanCaBiet_BySoHieuTaiKhoanAndNamKhauHao(ngayChot.Year, taiKhoan.SoHieuTK);

                            ////////////Khởi tạo tỉ lệ khấu hao theo tài khoản///////////////////////////////
                            tblTiLeKhauHaoTheoTaiKhoan tiLeKhauHaoTheoTaiKhoanNew = _tiLeKhauHaoTheoTaiKhoan_Factory.CreateManagedObject();

                            //Thông tin tài khoản
                            tiLeKhauHaoTheoTaiKhoanNew.SoHieuTK = taiKhoan.SoHieuTK;
                            tiLeKhauHaoTheoTaiKhoanNew.TenTaiKhoan = taiKhoan.TenTaiKhoan;

                            // Tỉ lệ khấu hao
                            if (tiLeKhauHaoTheoTaiKhoanCu != null)
                            {
                                tiLeKhauHaoTheoTaiKhoanNew.PhanTram = tiLeKhauHaoTheoTaiKhoanCu.PhanTram;
                            }
                            else
                            {
                                tiLeKhauHaoTheoTaiKhoanNew.PhanTram = 0;
                            }
                            //
                            tiLeKhauHaoTheoTaiKhoanNew.UserID = _userID;
                            //
                            tiLeKhauHaoTheoTaiKhoanNew.Nam = year;

                            //Nguyên giá tồn đầu năm
                            tiLeKhauHaoTheoTaiKhoanNew.NguyenGiaTon = nguyenGiaTon;//
                            //ngày hiệu lực
                            //tiLeKhauHaoTheoTaiKhoanNew.NgayHieuLuc = dteNgayHieuLuc.DateTime.Date;
                            tiLeKhauHaoTheoTaiKhoanNew.NgayHieuLuc = Convert.ToDateTime("01/01/" + year);
                            ////////////////////////////////////--End--//////////////////////////////////////////

                            //Đưa vào trong list
                            _tiLeKhauHaoTheoTaiKhoanList.Add(tiLeKhauHaoTheoTaiKhoanNew);
                        }
                        DialogUtil.ShowInfo("Bấm nút [" + btnLuu.Caption + "] để hoàn tất.");
                    }
                    else
                    {
                        DialogUtil.ShowOK("Không có tài khoản đối ứng trong dữ liệu tài sản.");
                    }
                }
            }
            //Đưa vào bindingSource
            tblTiLeKhauHaoTheoTaiKhoanBindingSource.DataSource = _tiLeKhauHaoTheoTaiKhoanList;

            //Phân quyền cột phần trăm
            grdViewDangKiKhauHaoTheoTaiKhoan.Columns[tblTiLeKhauHaoTheoTaiKhoan.PhanTram_PropertyName].OptionsColumn.ReadOnly = false;
            foreach (tblTiLeKhauHaoTheoTaiKhoan item in _tiLeKhauHaoTheoTaiKhoanList)
            {
                Boolean choPhepThayDoiTiLe = TiLeKhauHaoTheoTaiKhoan_Factory.New().CheckSoHieuTaiKhoanContainInNghiepVuKHHM(item.SoHieuTK, year);

                if (choPhepThayDoiTiLe == true) //Có trong nghiệp vụ khấu hao hao mòn
                {
                    //Không cho sửa cột phần trăm
                    grdViewDangKiKhauHaoTheoTaiKhoan.Columns[tblTiLeKhauHaoTheoTaiKhoan.PhanTram_PropertyName].OptionsColumn.ReadOnly = true;
                    break;
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn muốn xóa bảng đăng ký tỉ lệ KHHM theo tài khoản của năm " + spinNam.Text))
            {
                try
                {     //Xóa
                    TiLeKhauHaoTheoTaiKhoan_Factory.FullDelete(_tiLeKhauHaoTheoTaiKhoan_Factory.Context, _tiLeKhauHaoTheoTaiKhoanList.ToList<Object>());//_tiLeKhauHaoTheoTaiKhoan_Factory.DeleteObjectList(_tiLeKhauHaoTheoTaiKhoanList);
                    //Xóa list
                    _tiLeKhauHaoTheoTaiKhoanList.Clear();
                    //Gán bindingSource
                    tblTiLeKhauHaoTheoTaiKhoanBindingSource.DataSource = _tiLeKhauHaoTheoTaiKhoanList;
                    grdViewDangKiKhauHaoTheoTaiKhoan.RefreshData();
                    _tiLeKhauHaoTheoTaiKhoan_Factory.SaveChangesWithoutTrackingLog();
                    //_tiLeKhauHaoTheoTaiKhoan_Factory.SaveChanges();
                    DialogUtil.ShowDeleteSuccessful();
                }
                catch (System.Exception ex)
                {
                    DialogUtil.ShowNotDeleteSuccessful();
                }


                //DialogUtil.ShowInfo("Bấm nút [" + btnLuu.Caption + "] để hoàn tất");
            }
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int namKhauHao = Convert.ToInt32(spinNam.EditValue);

            ReportHelper.ShowReport("BangDangKiPhuongPhapTrichKhauHaoTaiSanCoDinh", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BangDangKiPhuongPhapTrichKhauHaoTaiSanCoDinh", "@Nam", namKhauHao);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtNam = new DataTable();
                dtNam.Columns.Add("Nam", typeof(Int32));
                dtNam.Columns.Add("NamNguyenGia", typeof(Int32));
                //Add dòng 1
                DataRow dr = dtNam.NewRow();
                dr["Nam"] = namKhauHao;
                dr["NamNguyenGia"] = namKhauHao - 1;
                dtNam.Rows.Add(dr);
                dtNam.TableName = "SubInfo";
                dataSet.Tables.Add(dtNam);
                #endregion
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }
        private void dteNgayHieuLuc_EditValueChanged(object sender, EventArgs e)
        {
            if (_tiLeKhauHaoTheoTaiKhoanList != null)
            {
                foreach (var item in _tiLeKhauHaoTheoTaiKhoanList)
                {
                    if (item.NgayHieuLuc == null || item.NgayHieuLuc.Value != dteNgayHieuLuc.DateTime.Date)
                    {
                        item.NgayHieuLuc = dteNgayHieuLuc.DateTime.Date;
                        DateTime ngayChot = dteNgayHieuLuc.DateTime.AddDays(-1).Date;
                        item.NguyenGiaTon = TaiSanCoDinhCaBiet_Factory.New().Get_TongNguyenGiaCuaTaiSanCaBiet_BySoHieuTaiKhoanAndNgayChot(ngayChot, item.SoHieuTK);
                    }

                }

            }
        }
        private void dteNgayHieuLuc_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        #endregion

        private void frmDangKiKhauHaoTrenTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_tiLeKhauHaoTheoTaiKhoan_Factory.IsDirty)
            {
                DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    if (false == this.Save())
                        e.Cancel = true;
                }
                else if (DialogResult.No == dlgResult)
                {
                    //không làm gì cả
                }
                else if (DialogResult.Cancel == dlgResult)
                {
                    e.Cancel = true;
                }
            }
        }




    }
}
