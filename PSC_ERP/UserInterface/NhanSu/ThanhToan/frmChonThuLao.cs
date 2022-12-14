using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.ThanhToan
{
    public partial class frmChonThuLao : frmChungTuGoc
    {
        private bool IsLoaded = false;
        private PSC_ERP.FilterCombo fChuongTrinh;

        public frmChonThuLao()
        {
            InitializeComponent();
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                Nullable<DateTime> d = ((ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject).NgayKhoaThuLao;
                if (d.HasValue)
                    txtTuNgay.Value = d.Value.AddDays(1);
                else
                    txtTuNgay.Value = ((ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject).NgayBatDau;
            }
            CapNhatChungTuGoc();
        }

        private void frmChonThuLao_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            foreach (ERP_Library.NganHang item in ERP_Library.NganHangList.GetNganHangList())
            {
                cmbNganHang.Items.Add(item.MaNganHang, item.TenNganHang);
            }
            ERP_Library.ChuongTrinhList ct = ERP_Library.ChuongTrinhList.GetChuongTrinhList(true);
            ERP_Library.ChuongTrinh ctall = ERP_Library.ChuongTrinh.NewChuongTrinh("Tất cả");
            ct.Insert(0, ctall);
            bdChuongTrinh.DataSource = ct;
            fChuongTrinh = new FilterCombo(cmbChuongTrinh, "TenChuongTrinh");

            cmbKyLuong.Value = _dataset.Tables["ChonThuLao"].Rows[0]["MaKyTinhLuong"];
            cmbNganHang.Value = _dataset.Tables["ChonThuLao"].Rows[0]["MaNganHang"];
            txtTuNgay.DateTime = DateTime.ParseExact(_dataset.Tables["ChonThuLao"].Rows[0]["TuNgay"].ToString(), "dd/MM/yyyy", null);
            txtDenNgay.DateTime = DateTime.ParseExact(_dataset.Tables["ChonThuLao"].Rows[0]["DenNgay"].ToString(), "dd/MM/yyyy", null); ;
            cmbChuongTrinh.Value = _dataset.Tables["ChonThuLao"].Rows[0]["MaChuongTrinh"];

            if (IsNew)
            {
                if (cmbKyLuong.Items.Count > 0)
                    cmbKyLuong.SelectedItem = cmbKyLuong.Items[0];
                if (_denghi != null && _denghi.MaTaiKhoanChuyen.HasValue)
                    cmbNganHang.Value = ERP_Library.CongTy_NganHang.GetCongTy_NganHang(_denghi.MaTaiKhoanChuyen.Value).MaNganHang;
                else
                    cmbNganHang.Value = 0;
                IsLoaded = true;
                CapNhatChungTuGoc();
            }
            IsLoaded = true;
        }

        private void frmChonThuLao_CreateXMLData(object sender, EventArgs e)
        {
            DataTable tbl = _dataset.Tables.Add("ChonThuLao");
            tbl.Columns.Add("MaKyTinhLuong", typeof(int));
            tbl.Columns.Add("MaNganHang", typeof(int));
            tbl.Columns.Add("TuNgay", typeof(string));
            tbl.Columns.Add("DenNgay", typeof(string));
            tbl.Columns.Add("MaChuongTrinh", typeof(int));
            tbl.Columns.Add("MaDatabaseGui", typeof(int));
            tbl.Columns.Add("MaDatabaseNhan", typeof(int));
            tbl.Rows.Add(0, 0, DateTime.Today.ToString("dd/MM/yyyy"), DateTime.Today.ToString("dd/MM/yyyy"), 0);
        }

        private void frmChonThuLao_SaveXMLData(object sender, CancelEventArgs e)
        {
            if (cmbKyLuong.Value == null)
            {
                e.Cancel = true;
                return;
            }
            if (KiemTraNgayKhoaSo(txtTuNgay.DateTime))
            {
                if (!KiemTraNgayKhoaSo(txtDenNgay.DateTime))
                {
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                e.Cancel = true;
                return;
            }

            _dataset.Tables["ChonThuLao"].Rows[0]["MaKyTinhLuong"] = cmbKyLuong.Value;
            _dataset.Tables["ChonThuLao"].Rows[0]["MaNganHang"] = cmbNganHang.Value;
            _dataset.Tables["ChonThuLao"].Rows[0]["TuNgay"] = txtTuNgay.DateTime.ToString("dd/MM/yyyy");
            _dataset.Tables["ChonThuLao"].Rows[0]["DenNgay"] = txtDenNgay.DateTime.ToString("dd/MM/yyyy");
            _dataset.Tables["ChonThuLao"].Rows[0]["MaChuongTrinh"] = cmbChuongTrinh.Value;
            _dataset.Tables["ChonThuLao"].Rows[0]["MaDatabaseGui"] = _denghi.MaDatabaseGui;
            _dataset.Tables["ChonThuLao"].Rows[0]["MaDatabaseNhan"] = _denghi.MaDatabaseNhan;

            //cập nhật ngày khóa thù lao
            //using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ERP_Library.Database.ERP_Connection))
            //{
            //    cn.Open();
            //    System.Data.SqlClient.SqlCommand cm = cn.CreateCommand();
            //    cm.CommandType = CommandType.StoredProcedure;
            //    cm.CommandText = "spd_Update_NgayKhoaThuLao";
            //    cm.Parameters.AddWithValue("@MaKyTinhLuong", cmbKyLuong.Value);
            //    cm.Parameters.AddWithValue("@Ngay", txtDenNgay.Value);
            //    cm.ExecuteNonQuery();
            //    cn.Close();
            //}
        }


        private void CapNhatChungTuGoc()
        {
            if (IsLoaded)
            {
                txtDienGiai.Text = _loaichungtu.TenLoai + " " + cmbKyLuong.Text + " từ " + txtTuNgay.DateTime.ToString("dd/MM/yy") + " đến " + txtDenNgay.DateTime.ToString("dd/MM/yy");
                if (cmbNganHang.Value != null && (int)cmbNganHang.Value != 0)
                    txtDienGiai.Text += ", ngân hàng " + cmbNganHang.Text;
                else
                    txtDienGiai.Text += ", tiền mặt";

                //lấy số tiền 
                using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    System.Data.SqlClient.SqlCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 0;
                    cm.CommandText = "spd_ChungTuGoc_ChonThuLao";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", (int)cmbKyLuong.Value);
                    cm.Parameters.AddWithValue("@MaNganHang", (int)cmbNganHang.Value);
                    cm.Parameters.AddWithValue("@TuNgay", txtTuNgay.DateTime);
                    cm.Parameters.AddWithValue("@DenNgay", txtDenNgay.DateTime);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    if (_denghi != null)
                    {
                        cm.Parameters.AddWithValue("@MaDatabaseGui", _denghi.MaDatabaseGui);
                        cm.Parameters.AddWithValue("@MaDatabaseNhan", _denghi.MaDatabaseNhan);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@MaDatabaseGui", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                        cm.Parameters.AddWithValue("@MaDatabaseNhan", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    }
                    if (cmbChuongTrinh.ActiveRow != null)
                    {

                        cm.Parameters.AddWithValue("@MaChuongTrinh", cmbChuongTrinh.ActiveRow.Cells["MaChuongTrinh"].Value);
                        txtSoTien.Value = cm.ExecuteScalar();
                        cn.Close();
                    }
                    else
                    {
                        txtSoTien.Value = 0;
                    }
                }

            }
        }

        private void cmbNganHang_ValueChanged(object sender, EventArgs e)
        {
            CapNhatChungTuGoc();
        }

        private void txtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            CapNhatChungTuGoc();
        }

        private void txtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            CapNhatChungTuGoc();
        }

        private void txtTuNgay_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !KiemTraNgayKhoaSo(txtTuNgay.DateTime);
        }

        private void txtDenNgay_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !KiemTraNgayKhoaSo(txtDenNgay.DateTime);
        }

        private bool KiemTraNgayKhoaSo(DateTime ngay)
        {
            if (cmbKyLuong.Value != null)
            {
                ERP_Library.KyTinhLuong ky = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
                if (ky.NgayKhoaThuLao.HasValue)
                    if (ngay <= ky.NgayKhoaThuLao.Value)
                    {
                        MessageBox.Show("Thù lao đã khóa ngày này do đã chuyển khoản", "Khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
            }
            return true;
        }

        private void cmbChuongTrinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbChuongTrinh.Value != null)
                CapNhatChungTuGoc();
        }
    }
}