using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;
using System.Data.OleDb;
using PSC_ERP_Common;
using PSC_ERP.UserInterface.NhanSu.TongHopThuLao;
using System.IO;

namespace PSC_ERP
{
    public partial class frmNhanVienNgoaiDai : DevExpress.XtraEditors.XtraForm
    {
        #region
        NhanVienNgoaiDaiList _nhanVienList;
        NganHangList _nganHangList;
        BoPhanList boPhanList;
        QuocGiaList _quocGiaList;
        NhanVienNgoaiDai _nhanVienNgoaiDai;
        private FilterCombo fBoPhan;
        private FilterCombo fNganHang;
        int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        NhanVienNgoaiDaiList _nhanVienNgoaiDaiImportList;
        #endregion

        public frmNhanVienNgoaiDai()
        {
            InitializeComponent();
        }

        private void LoadForm()
        {
            try
            {
                //Phân quyền from
                PhanQuyenForm();

                boPhanList = BoPhanList.GetBoPhanListBy_All();
                this.BoPhan_BindingSource.DataSource = boPhanList;

                _nganHangList = NganHangList.GetNganHangList();
                this.BindingSource_NganHang.DataSource = _nganHangList;

                _quocGiaList = QuocGiaList.GetQuocGiaList();
                QuocGia_BindingSource.DataSource = _quocGiaList;

                _nhanVienList = ERP_Library.NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiListBySuDung(false);
                NhanVien_BindingSource.DataSource = _nhanVienList;
            }
            catch (ApplicationException)
            {

            }
        }

        private void KhoiTao()
        {
            _nhanVienList = ERP_Library.NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiListBySuDung(false);

            _nhanVienNgoaiDai = NhanVienNgoaiDai.NewNhanVienNgoaiDai();
            NhanVien_BindingSource.DataSource = _nhanVienNgoaiDai;

            //Cài đặc giá trị mới
            checkBox_SuDung.Checked = false;
            checkBox_CaNhanCuTru.Checked = true;
        }

        private void PhanQuyenForm()
        {
            if ((ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9 && ERP_Library.Security.CurrentUser.Info.MaCongTy == 1) || ERP_Library.Security.CurrentUser.Info.MaCongTy != 1)
            {
                btnThemMoi.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = true;
                btnImport.Enabled = true;
            }
            else
            {
                btnThemMoi.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
                btnImport.Enabled = false;
            }
        }
        private void FrmNganHang_New_Load(object sender, EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Office 2007 Blue";

            gridView_NhanVienNgoaiDai.OptionsBehavior.Editable = false;
            Utils.GridUtils.SetSTTForGridView(gridView_NhanVienNgoaiDai, 35);
            LoadForm();
        }


        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTao();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
        }
        private int KiemTraMaQuanLy(string MaQuanLy, long MaNganHang)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraMaQuanLyNganHang";
                        if (MaQuanLy.Length > 0)
                            cm.Parameters.AddWithValue("@MaQuanLy", MaQuanLy);
                        else
                            cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);

                        cm.Parameters.AddWithValue("@MaNganHang", MaNganHang);

                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }

        private bool KiemTraChungMinhNhanDanKhiImport(string soChungMinh)
        {
            Boolean kq = false;

            foreach(NhanVienNgoaiDai item in _nhanVienNgoaiDaiImportList)
            {
                if (item.Cmnd == soChungMinh)
                {
                    kq = true;
                }
            }
            return kq;   
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Lưu dữ liệu
            SaveData();
        }

        private void SaveData()
        {
            txtFocus.Focus();//Focus vào đây để tránh mất dữ liệu
            try
            {
                this.NhanVien_BindingSource.EndEdit();
                _nhanVienNgoaiDai = NhanVien_BindingSource.Current as NhanVienNgoaiDai;

                if (KiemTraTruocKhiLuu() == true)
                {
                    if (_nhanVienNgoaiDai.IsNew)// Đối tượng mới
                    {
                        _nhanVienList.Add(_nhanVienNgoaiDai);
                        _nhanVienList.ApplyEdit();
                        _nhanVienList.Save();
                        MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadForm();
                    }
                    else // Đối tượng cũ
                    {
                        _nhanVienList.ApplyEdit();
                        _nhanVienList.Save();
                        MessageBox.Show("Cập nhật dữ liệu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView_NhanVienNgoaiDai.SelectedRowsCount == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                gridView_NhanVienNgoaiDai.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
        }



        public static int KiemTraCMNDDuyNhat(string CMND, long MaNhanVien)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraCMNDDuyNhat_CongTacVien";
                        if (CMND.Length > 0)
                            cm.Parameters.AddWithValue("@CMND", CMND);
                        else
                            cm.Parameters.AddWithValue("@CMND", DBNull.Value);

                        cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);

                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        public static int KiemTraMaSoThueDuyNhat(string MaSoThue, long MaNhanVien)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraMaSoThueDuyNhat_CongTacVien";
                        if (MaSoThue.Length > 0)
                            cm.Parameters.AddWithValue("@MaSoThue", MaSoThue);
                        else
                            cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);

                        cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);

                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }

        private bool KiemTraKyTuTrang(string chuoi)
        {
            Boolean kq = true;
            for (int i = 0; i < chuoi.Length; i++)
            {
                if (char.IsWhiteSpace(chuoi[i]))
                {
                    kq = false;
                    return kq;
                }
            }
            return kq;
        }
        private bool KiemTraTruocKhiLuu()
        {
            Boolean kq = true;
            //Tên nhân viên
            if (_nhanVienNgoaiDai.TenNhanVien == "")
            {
                MessageBox.Show("Tên nhân viên không được trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenNhanVien.Focus();
                return kq = false;
            }
            if (HamDungChung.KiemTraKyTuDacBiet(_nhanVienNgoaiDai.TenNhanVien) == false)
            {
                MessageBox.Show("Tên nhân viên không sử dụng kí tự đặc biệt.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenNhanVien.Focus();
                return kq = false;
            }
            //Cmnd/Hộ chiếu
            if (Convert.ToString(_nhanVienNgoaiDai.Cmnd).CompareTo("") == 0)
            {
                MessageBox.Show("Chứng minh không được trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ChungMinh.Focus();
                return kq = false;
            }
            if (HamDungChung.KiemTraKyTuDacBiet(_nhanVienNgoaiDai.Cmnd) == false)
            {
                MessageBox.Show("Chứng minh/Hộ chiếu không sử dụng kí tự đặc biệt.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenNhanVien.Focus();
                return kq = false;
            }

            if (KiemTraKyTuTrang(_nhanVienNgoaiDai.Cmnd) == false)
            {
                MessageBox.Show("Vui lòng kiểm tra Chứng minh/Hộ chiếu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ChungMinh.Focus();
                return kq = false;
            }
            //if ((_nhanVienNgoaiDai.Cmnd.Length != 11 && _nhanVienNgoaiDai.Cmnd.Length != 9) || KiemTraKyTuTrang(_nhanVienNgoaiDai.Cmnd) == false)
            //{
            //    MessageBox.Show("Vui lòng kiểm tra Chứng minh/Hộ chiếu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_ChungMinh.Focus();
            //    return kq = false;
            //}

            //if (_nhanVienNgoaiDai.Cmnd.Trim().Length == 9 && HamDungChung.KiemTraLaSo(_nhanVienNgoaiDai.Cmnd) == false)
            //{
            //    MessageBox.Show("Chứng minh phải là số.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txt_ChungMinh.Focus();
            //    return kq = false;
            //}

            if (KiemTraCMNDDuyNhat(_nhanVienNgoaiDai.Cmnd, _nhanVienNgoaiDai.MaNhanVien) > 0)
            {
                MessageBox.Show("Chứng minh này đã có người dùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ChungMinh.Focus();
                return kq = false;
            }
            //Mst
            if (_nhanVienNgoaiDai.Mst != "")
            {
                if (HamDungChung.KiemTraLaSo(_nhanVienNgoaiDai.Mst) == false)
                {
                    MessageBox.Show("Mã số thuế phải là số.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_MaSoThue.Focus();
                    return kq = false;
                }
                if (_nhanVienNgoaiDai.Mst.Trim().Length != 10 || KiemTraKyTuTrang(_nhanVienNgoaiDai.Mst) == false)
                {
                    MessageBox.Show("Vui lòng kiểm tra Mã số thuế.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_MaSoThue.Focus();
                    return kq = false;
                }

                //if (KiemTraMaSoThueDuyNhat(_nhanVienNgoaiDai.Mst, _nhanVienNgoaiDai.MaNhanVien) > 0)
                //{
                //    MessageBox.Show("Mã số thuế này đã có người dùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txt_MaSoThue.Focus();
                //    return kq = false;
                //}
            }
            //Bộ phận
            if (_nhanVienNgoaiDai.MaBoPhan == 0)
            {
                MessageBox.Show("Tên bộ phận không được trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_BoPhan.Focus();
                return kq = false;
            }
            //Ngân hàng
            //if (_nhanVienNgoaiDai.MaNganHang == 0)
            //{
            //    MessageBox.Show("Ngân hàng không được trống.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbu_NganHang.Focus();
            //    return kq = false;
            //}
            //Số tài khoản
            if (_nhanVienNgoaiDai.SoTaiKhoan != "")
            {
                if (HamDungChung.KiemTraKyTuDacBiet(_nhanVienNgoaiDai.SoTaiKhoan) == false)
                {
                    MessageBox.Show("Số tài khoản không sử dụng ký tự đặc biệt.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SoTaiKhoan.Focus();
                    return kq = false;
                }
                if (KiemTraKyTuTrang(_nhanVienNgoaiDai.SoTaiKhoan) == false)
                {
                    MessageBox.Show("Vui lòng kiểm tra Số tài khoản.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SoTaiKhoan.Focus();
                    return kq = false;
                }
            }
            //Điện thoại
            if (_nhanVienNgoaiDai.DienThoai != "")
            {
                if (HamDungChung.KiemTraLaSo(_nhanVienNgoaiDai.DienThoai) == false)
                {
                    MessageBox.Show("Điện thoại phải là số.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_DienThoai.Focus();
                    return kq = false;
                }
                if (KiemTraKyTuTrang(_nhanVienNgoaiDai.DienThoai) == false)
                {
                    MessageBox.Show("Vui lòng kiểm tra Điện thoại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_DienThoai.Focus();
                    return kq = false;
                }
            }

            return kq;
        }

        private void txt_ChungMinh_Leave(object sender, EventArgs e)
        {
            if (txt_ChungMinh.Text != "")
            {

                if (KiemTraCMNDDuyNhat(txt_ChungMinh.Text, _nhanVienNgoaiDai.MaNhanVien) > 0)
                {
                    MessageBox.Show("Chứng minh này đã có người dùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_ChungMinh.Focus();
                    return;
                }
            }
        }


        private void txt_MaSoThue_Leave(object sender, EventArgs e)
        {
            if (txt_MaSoThue.Text != "")
            {
                if (KiemTraMaSoThueDuyNhat(txt_MaSoThue.Text, _nhanVienNgoaiDai.MaNhanVien) > 0)
                {
                    MessageBox.Show("Mã số thuế này đã có người dùng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_MaSoThue.Focus();
                }
            }
        }

        private void frmNhanVienNgoaiDai_FormClosed(object sender, FormClosedEventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = " DevExpress Style";
        }

        private void NhanVien_BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (NhanVien_BindingSource != null)
                _nhanVienNgoaiDai = (NhanVienNgoaiDai)NhanVien_BindingSource.Current;

        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HamDungChung.ExportToExcelFromGridViewDev(gridView_NhanVienNgoaiDai);
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            frmChonDuLieuImport frm = new frmChonDuLieuImport();
            frm.ShowDialog(this);
            if (frm.MaBoPhan != 0 && frm.MaQuocGia != 0)
            {
                try
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string cnnExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName + ";Extended Properties='Excel 8.0;HDR=NO'";
                        OleDbDataAdapter daExcel = new OleDbDataAdapter("Select * From [NhanVienNgoaiDai$A2:L] ", cnnExcel);
                        DataTable tblExcel = new DataTable("Import");
                        daExcel.Fill(tblExcel);

                        daExcel.UpdateCommand = new OleDbCommand("Update [NhanVienNgoaiDai$A2:L] Set F12=? Where F1=? and F2=? and F4=? ", daExcel.SelectCommand.Connection);
                        daExcel.UpdateCommand.Parameters.Add("p1", OleDbType.WChar, 8, "F12");
                        daExcel.UpdateCommand.Parameters.Add("p2", OleDbType.WChar, 20, "F1");
                        daExcel.UpdateCommand.Parameters.Add("p3", OleDbType.WChar, 20, "F2");
                        daExcel.UpdateCommand.Parameters.Add("p4", OleDbType.WChar, 20, "F4");

                        //thêm dữ liệu vào object và save lại
                        NhanVienNgoaiDai objNew;
                        bool ok;
                        bool duLieuSai = false;
                        _nhanVienNgoaiDaiImportList = NhanVienNgoaiDaiList.NewNhanVienNgoaiDaiList();

                        foreach (DataRow row in tblExcel.Rows)
                        {
                            ok = true;
                            duLieuSai = false;

                            if (row.IsNull("F1") && duLieuSai == false)
                            {
                                DialogUtil.ShowWarning("Không có tên nhân viên. Chương trình sẽ loại bỏ dòng này.");
                                duLieuSai = true;
                            }
                            if (row.IsNull("F2") && duLieuSai == false)
                            {
                                DialogUtil.ShowWarning("[" + row["F1"] + "] không có chứng minh. Chương trình sẽ loại bỏ những dòng này.");
                                duLieuSai = true;
                            }
                            if (row.IsNull("F3") && duLieuSai == false)
                            {
                                DialogUtil.ShowWarning("[" + row["F1"] + "] không có ngày cấp. Chương trình sẽ loại bỏ những dòng này.");
                                duLieuSai = true;
                            }
                            if (row.IsNull("F4") && duLieuSai == false)
                            {
                                DialogUtil.ShowWarning("[" + row["F1"] + "] không có nơi cấp. Chương trình sẽ loại bỏ những dòng này.");
                                duLieuSai = true;
                            }
                            if (row.IsNull("F1") || row.IsNull("F2") || row.IsNull("F3") || row.IsNull("F4")) continue;
                            if (ok)
                            {
                                objNew = NhanVienNgoaiDai.NewNhanVienNgoaiDai();

                                if (!string.IsNullOrEmpty((row["F1"].ToString())))
                                {
                                    objNew.TenNhanVien = row["F1"].ToString();
                                }
                                if (!string.IsNullOrEmpty((row["F2"].ToString())))
                                {
                                    objNew.Cmnd = row["F2"].ToString();
                                }
                                if (!string.IsNullOrEmpty((row["F3"].ToString())))
                                {
                                    objNew.NgayCap = Convert.ToDateTime(row["F3"].ToString());
                                }
                                if (!string.IsNullOrEmpty((row["F4"].ToString())))
                                {
                                    objNew.NoiCap = row["F4"].ToString();
                                }
                                if (!string.IsNullOrEmpty((row["F5"].ToString())))
                                {
                                    objNew.Mst = row["F5"].ToString();
                                }
                                if (!string.IsNullOrEmpty((row["F6"].ToString())))
                                {
                                    if (HamDungChung.KiemTraLaSo(row["F6"].ToString()))
                                    {
                                        objNew.MaNganHang = Convert.ToInt32(row["F6"]);
                                    }
                                }
                                if (!string.IsNullOrEmpty((row["F7"].ToString())))
                                {
                                    objNew.SoTaiKhoan = row["F7"].ToString();
                                }
                                if (!string.IsNullOrEmpty((row["F8"].ToString())))
                                {
                                    objNew.DiaChi = row["F8"].ToString();
                                }
                                if (!string.IsNullOrEmpty((row["F9"].ToString())))
                                {
                                    objNew.DienThoai = row["F9"].ToString();
                                }
                                if (!string.IsNullOrEmpty((row["F10"].ToString())))
                                {
                                    objNew.GhiChu = row["F10"].ToString();
                                }
                                if (!string.IsNullOrEmpty((row["F11"].ToString())))
                                {
                                    objNew.CaNhanCuTru = Convert.ToBoolean(row["F11"]);
                                }
                                objNew.MaBoPhan = frm.MaBoPhan;
                                objNew.MaQuocGia = frm.MaQuocGia;

                                if (!String.IsNullOrEmpty(objNew.TenNhanVien) || !String.IsNullOrEmpty(objNew.Cmnd) || objNew.NgayCap != null || !String.IsNullOrEmpty(objNew.NoiCap))
                                {
                                    if (KiemTraCMNDDuyNhat(objNew.Cmnd, objNew.MaNhanVien) > 0)//Kiểm tra chứng minh có trong database
                                    {
                                        MessageBox.Show("Số chứng minh thư của [" + objNew .TenNhanVien + "] đã có sẵn. Chương trình sẽ tự động loại bỏ người này.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else if (KiemTraChungMinhNhanDanKhiImport(objNew.Cmnd)) //Kiểm tra chứng minh trong file excel
                                    {
                                        MessageBox.Show("Số chứng minh thư của [" + objNew.TenNhanVien + "] trong file excel bị trùng. Chương trình sẽ tự động loại bỏ người này.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);                      
                                    }
                                    else
                                    {
                                        _nhanVienList.Add(objNew);

                                        //Đưa vào tạm để bắt lỗi khi lưu dữ liệu
                                        _nhanVienNgoaiDaiImportList.Add(objNew);
                                        row["F12"] = "OK";
                                    }
                                }
                            }
                        }
                        daExcel.Update(tblExcel);
                        DialogUtil.ShowInfo("Import dữ liệu thành công.");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void btnExportMau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.Filter = "Excel|*.xls|All file|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //tạo file template
                    FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fs.Write(Properties.Resources.DanhSachNhanVienNgoaiDai, 0, Properties.Resources.DanhSachNhanVienNgoaiDai.Length);
                    fs.Close();

                    MessageBox.Show("Đã xuất dữ liệu thành công.", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}