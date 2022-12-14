using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.ThanhToan
{
    public partial class frmChonKyLuong : frmChungTuGoc
    {
        public frmChonKyLuong()
        {
            InitializeComponent();
        }

        private void frmChonKyLuong_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            foreach (ERP_Library.NganHang item in ERP_Library.NganHangList.GetNganHangList())
            {
                cmbNganHang.Items.Add(item.MaNganHang, item.TenNganHang);
            }
            cmbKyLuong.Value = _dataset.Tables["ChonKyLuong"].Rows[0]["MaKyTinhLuong"];
            cmbNganHang.Value = _dataset.Tables["ChonKyLuong"].Rows[0]["MaNganHang"];

            if (IsNew)
            {
                if (cmbKyLuong.Items.Count > 0)
                    cmbKyLuong.SelectedItem = cmbKyLuong.Items[0];
                if (_denghi != null && _denghi.MaTaiKhoanChuyen.HasValue)
                    cmbNganHang.Value = ERP_Library.CongTy_NganHang.GetCongTy_NganHang(_denghi.MaTaiKhoanChuyen.Value).MaNganHang;
                else
                    cmbNganHang.Value = 0;
                IsLoaded = true; 
                CapNhatChungTuGoc(this, null);
            }
            IsLoaded = true;
        }

        private void frmChonKyLuong_CreateXMLData(object sender, EventArgs e)
        {
            DataTable tbl = _dataset.Tables.Add("ChonKyLuong");
            tbl.Columns.Add("MaKyTinhLuong", typeof(int));
            tbl.Columns.Add("MaNganHang", typeof(int));
            tbl.Rows.Add(0, 0);
        }

        private void frmChonKyLuong_SaveXMLData(object sender, CancelEventArgs e)
        {
            if (cmbKyLuong.Value == null)
            {
                e.Cancel = true;
                return;
            }
            _dataset.Tables["ChonKyLuong"].Rows[0]["MaKyTinhLuong"] = cmbKyLuong.Value;
            _dataset.Tables["ChonKyLuong"].Rows[0]["MaNganHang"] = cmbNganHang.Value;
        }

        private void CapNhatChungTuGoc(object sender, EventArgs e)
        {
            if (IsLoaded)
            {
                txtDienGiai.Text = _loaichungtu.TenLoai + " " + cmbKyLuong.Text;
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
                    cm.CommandText = "spd_ChungTuGoc_ChonKyLuong";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", (int)cmbKyLuong.Value);
                    cm.Parameters.AddWithValue("@MaNganHang", (int)cmbNganHang.Value);
                    cm.Parameters.AddWithValue("@MaLoaiChungTu", _loaichungtu.MaLoaiChungTu);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    txtSoTien.Value = cm.ExecuteScalar();
                    cn.Close();
                }
            }
        }
    }
}