using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;

namespace PSC_ERP.ThanhToan
{
    public partial class frmChonPhuCapCTV : frmChungTuGocCTV
    {

        private ERP_Library.NganHangList _nganHangList;
        public frmChonPhuCapCTV()
        {
            InitializeComponent();
        }

        private void frmChonPhuCap_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            foreach (ERP_Library.NganHang nh in ERP_Library.NganHangList.GetNganHangList())
                cmbNganHang.Items.ValueList.ValueListItems.Add(nh.MaNganHang, nh.TenNganHang);
            cmbNganHang.Value = 0;
            cmbNhomPC.DataSource = ERP_Library.NhomPhuCapList.GetNhomPhuCapList();

            if (IsNew)
            {
                if (cmbKyLuong.Items.Count > 0)
                    cmbKyLuong.SelectedItem = cmbKyLuong.Items[0];
                if (_denghi != null && _denghi.MaTaiKhoanChuyen.HasValue)
                    cmbNganHang.Value = ERP_Library.CongTy_NganHang.GetCongTy_NganHang(_denghi.MaTaiKhoanChuyen.Value).MaNganHang;
                else
                    cmbNganHang.Value = 0;
                cmbKyPC.Value = 0;
                IsLoaded = true;
                CapNhatChungTuGoc();
            }
            else
            {
                cmbKyLuong.Value = _dataset.Tables["ChonPhuCap"].Rows[0]["MaKyTinhLuong"];
                cmbKyPC.Value = _dataset.Tables["ChonPhuCap"].Rows[0]["MaKyPhuCap"];
                cmbNganHang.Value = _dataset.Tables["ChonPhuCap"].Rows[0]["MaNganHang"];
                cmbNhomPC.Value = _dataset.Tables["ChonPhuCap"].Rows[0]["MaNhomPhuCap"];
                cmbPhuCap.Value = _dataset.Tables["ChonPhuCap"].Rows[0]["MaLoaiPhuCap"];
            }
            IsLoaded = true;
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                cmbKyPC.Items.Clear();
                cmbKyPC.Items.Add(0, "Tất cả");
                foreach (ERP_Library.KyTinhLuong item in ERP_Library.KyTinhLuongList.GetKyTinhPhuCap((int)cmbKyLuong.Value))
                    cmbKyPC.Items.Add(item.MaKy, item.TenKy);
                cmbKyPC.Value = 0;

                _nganHangList = NganHangList.GetNganHangListByCTVPhuCap((Int32)cmbKyLuong.Value, 0, (Int32)cmbKyPC.Value, ERP_Library.Security.CurrentUser.Info.UserID);
                bdNganHang.DataSource = _nganHangList;
                foreach (NganHang oj in _nganHangList)
                {
                    oj.Chon = true;
                }
            }
            CapNhatChungTuGoc();
        }

        private void cmbNhomPC_ValueChanged(object sender, EventArgs e)
        {
            cmbPhuCap.Items.Clear();
            cmbPhuCap.Items.Add(0, "Tất cả");
            foreach (ERP_Library.LoaiPhuCapChild item in ERP_Library.LoaiPhuCapList.GetLoaiPhuCapByMaNhom((int)cmbNhomPC.Value))
            {
                cmbPhuCap.Items.Add(item.MaLoaiPhuCap, item.TenLoaiPhuCap);
            }
            cmbPhuCap.Value = 0;
            CapNhatChungTuGoc();
        }

        private void frmChonPhuCap_CreateXMLData(object sender, EventArgs e)
        {
            DataTable tbl = _dataset.Tables.Add("ChonPhuCap");
            tbl.Columns.Add("MaKyTinhLuong", typeof(int));
            tbl.Columns.Add("MaKyPhuCap", typeof(int));
            tbl.Columns.Add("MaNganHang", typeof(int));
            tbl.Columns.Add("MaNhomPhuCap", typeof(int));
            tbl.Columns.Add("MaLoaiPhuCap", typeof(int));
            tbl.Rows.Add(0, 0, 0, 0, 0);
        }

        private void frmChonPhuCap_SaveXMLData(object sender, CancelEventArgs e)
        {
            if (cmbKyLuong.Value == null || cmbKyPC.Value == null || cmbNganHang.Value == null || cmbNhomPC.Value == null || cmbPhuCap.Value == null)
            {
                e.Cancel = true;
                return;
            }

            DataRow dr;
            foreach (NganHang nh in _nganHangList)
            {
                if (nh.Chon == true)
                {
                    dr = _dataset.Tables["ChonPhuCap"].NewRow();
                    dr["MaKyTinhLuong"] = cmbKyLuong.Value;
                    dr["MaKyPhuCap"] = cmbKyPC.Value;
                    dr["MaNganHang"] = nh.MaNganHang;
                    dr["MaNhomPhuCap"] = cmbNhomPC.Value;
                    dr["MaLoaiPhuCap"] = cmbPhuCap.Value;
                    _dataset.Tables["ChonPhuCap"].Rows.Add(dr);
                }
            }

            //_dataset.Tables["ChonPhuCap"].Rows[0]["MaKyTinhLuong"] = cmbKyLuong.Value;
            //_dataset.Tables["ChonPhuCap"].Rows[0]["MaKyPhuCap"] = cmbKyPC.Value;
            //_dataset.Tables["ChonPhuCap"].Rows[0]["MaNganHang"] = cmbNganHang.Value;
            //_dataset.Tables["ChonPhuCap"].Rows[0]["MaNhomPhuCap"] = cmbNhomPC.Value;
            //_dataset.Tables["ChonPhuCap"].Rows[0]["MaLoaiPhuCap"] = cmbPhuCap.Value;
        }

        string manganhang = string.Empty;
        string nganhang = string.Empty;

        private void CapNhatChungTuGoc()
        {
            if (IsLoaded && cmbKyLuong.Value != null && cmbKyPC.Value != null && cmbNganHang.Value != null && cmbNhomPC.Value != null && cmbPhuCap.Value != null)
            {
                txtDienGiai.Text = _loaichungtu.TenLoai + " " + cmbKyLuong.Text;
                //if (cmbNganHang.Value != null && (int)cmbNganHang.Value != 0)
                //    txtDienGiai.Text += ", ngân hàng " + cmbNganHang.Text;
                //else
                //    txtDienGiai.Text += ", tiền mặt";

                foreach (NganHang oj in _nganHangList)
                {
                    if (oj.Chon == true)
                    {
                        nganhang += oj.TenNganHang + ",";
                        manganhang += oj.MaNganHang + ",";
                    }
                }
                if (nganhang != "")
                {
                    nganhang = nganhang.Substring(0, nganhang.Length - 1);
                    manganhang = manganhang.Substring(0, manganhang.Length - 1);
                }
                txtDienGiai.Text += ", ngân hàng " + nganhang;

                if (cmbPhuCap.Value is int && (int)cmbPhuCap.Value != 0)
                    txtDienGiai.Text += ", " + cmbPhuCap.Text;
                else
                    txtDienGiai.Text += ", " + cmbNhomPC.Text;

                //tính số tiền
                using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    System.Data.SqlClient.SqlCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChungTuGoc_ChonPhuCapCTV";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", (int)cmbKyLuong.Value);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", (int)cmbKyPC.Value);
                    cm.Parameters.AddWithValue("@MaNganHang", manganhang);
                    cm.Parameters.AddWithValue("@MaNhomPhuCap", (int)cmbNhomPC.Value);
                    cm.Parameters.AddWithValue("@MaLoaiPhuCap", (int)cmbPhuCap.Value);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    txtSoTien.Value = cm.ExecuteScalar();
                    cn.Close();
                }
            }
        }

        private void cmbKyPC_ValueChanged(object sender, EventArgs e)
        {
            CapNhatChungTuGoc();
        }

        private void cmbPhuCap_ValueChanged(object sender, EventArgs e)
        {
            CapNhatChungTuGoc();
        }

        private void cmbNganHang_ValueChanged(object sender, EventArgs e)
        {
            CapNhatChungTuGoc();
        }
    }
}