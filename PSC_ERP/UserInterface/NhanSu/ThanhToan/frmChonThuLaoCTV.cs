using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP.ThanhToan
{
    public partial class frmChonThuLaoCTV : frmChungTuGocCTV
    {
        private bool IsLoaded = false;
        private PSC_ERP.FilterCombo fChuongTrinh;
        private ERP_Library.NganHangList _nganHangList;
        private ERP_Library.BoPhanList _boPhanList;
        public string _boPhanString = "";
        public string _tenNganHangChuyen = "";

        public frmChonThuLaoCTV()
        {
            InitializeComponent();
            ((ICheckedItemList)this.cbBoPhan).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(frmChonThuLaoCTV_CheckStateChanged); 
          

           // ((ICheckedItemList)this.cbBoPhan).CheckStateChanged += new EditorCheckedListSettings.CheckStateChangedHandler(frmButToan_ChiPhiHoatDong_CheckStateChanged);
         
        }

        void frmChonThuLaoCTV_CheckStateChanged(object sender, EditorCheckedListSettings.CheckStateChangedEventArgs e)
        {
            _boPhanString = string.Empty;
            string boPhanString = string.Empty;
            if (cbBoPhan.ActiveRow != null)
            {
                for (int i = 0; i < cbBoPhan.CheckedRows.Count; i++)
                {
                    string s = cbBoPhan.CheckedRows[i].Cells["MaBoPhan"].Value.ToString();
                    if (s == "")
                    {
                        ICheckedItemList itemList = (ICheckedItemList)this.cbBoPhan;
                        for (int j = 1; j < this.cbBoPhan.Rows.Count; j++)
                            itemList.SetCheckState(j, CheckState.Unchecked);
                    }
                    boPhanString += s + ",";
                }

                if (boPhanString.Length > 0)
                {
                    _boPhanString = boPhanString.Substring(0, boPhanString.Length - 1);
                }
                else
                    _boPhanString = "";
            }
            cmbKyLuong_ValueChanged(null, null);
        }
        int Loai;
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
            if (cmbKyLuong.Value != null)
            {
               
                if (_loaichungtu.TenLoai == "Thù lao CTV")
                {
                    Loai= Convert.ToInt32(0);
                }
                else if (_loaichungtu.TenLoai == "Khen Thưởng CTV")
                {
                   Loai= Convert.ToInt32(1);
                }
                else if (_loaichungtu.TenLoai == "Tác Quyền CTV")
                {
                    Loai =Convert.ToInt32(2);
                }
                else if (_loaichungtu.TenLoai == "Khác CTV")
                {
                   Loai= Convert.ToInt32(3);
                }
                _nganHangList = NganHangList.GetNganHangListByCTV((Int32)cmbKyLuong.Value, 0, txtTuNgay.DateTime, txtDenNgay.DateTime, ERP_Library.Security.CurrentUser.Info.UserID, (int)cmbChuongTrinh.Value, _boPhanString, frmPhieuDeNghiChuyenKhoan_EditCTV.tenNganHangChuyen, Loai);
                bdNganHang.DataSource = _nganHangList;
                foreach (NganHang oj in _nganHangList)
                {
                    oj.Chon = true;
                }
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
            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            bdBoPhanList.DataSource = _boPhanList;

            ERP_Library.ChuongTrinhList ct = ERP_Library.ChuongTrinhList.GetChuongTrinhList(true);
            ERP_Library.ChuongTrinh ctall = ERP_Library.ChuongTrinh.NewChuongTrinh("Tất cả");
            ct.Insert(0, ctall);
            bdChuongTrinh.DataSource = ct;
            fChuongTrinh = new FilterCombo(cmbChuongTrinh, "TenChuongTrinh");
            // khuc này them ngan hang vao
           
            //
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

            DataRow dr;
            foreach (NganHang nh in _nganHangList)
            {
                if (nh.Chon == true)
                {
                    dr = _dataset.Tables["ChonThuLao"].NewRow();
                    dr["MaKyTinhLuong"] = cmbKyLuong.Value;
                    dr["MaNganHang"] = nh.MaNganHang;
                    dr["TuNgay"] = txtTuNgay.DateTime.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = txtDenNgay.DateTime.ToString("dd/MM/yyyy");
                    dr["MaChuongTrinh"] = cmbChuongTrinh.Value;
                    dr["MaDatabaseGui"] = _denghi.MaDatabaseGui;
                    dr["MaDatabaseNhan"] = _denghi.MaDatabaseNhan;

                    _dataset.Tables["ChonThuLao"].Rows.Add(dr);

                    //_dataset.Tables["ChonThuLao"].Rows[nh.MaNganHang]["MaKyTinhLuong"] = cmbKyLuong.Value;
                    //_dataset.Tables["ChonThuLao"].Rows[nh.MaNganHang]["MaNganHang"] = nh.MaNganHang;
                    //_dataset.Tables["ChonThuLao"].Rows[nh.MaNganHang]["TuNgay"] = txtTuNgay.DateTime.ToString("dd/MM/yyyy");
                    //_dataset.Tables["ChonThuLao"].Rows[nh.MaNganHang]["DenNgay"] = txtDenNgay.DateTime.ToString("dd/MM/yyyy");
                    //_dataset.Tables["ChonThuLao"].Rows[nh.MaNganHang]["MaChuongTrinh"] = cmbChuongTrinh.Value;
                    //_dataset.Tables["ChonThuLao"].Rows[nh.MaNganHang]["MaDatabaseGui"] = _denghi.MaDatabaseGui;
                    //_dataset.Tables["ChonThuLao"].Rows[nh.MaNganHang]["MaDatabaseNhan"] = _denghi.MaDatabaseNhan;
                }
            }
            //_dataset.Tables["ChonThuLao"].Rows[0]["MaKyTinhLuong"] = cmbKyLuong.Value;
            //_dataset.Tables["ChonThuLao"].Rows[0]["MaNganHang"] = manganhang;
            //_dataset.Tables["ChonThuLao"].Rows[0]["TuNgay"] = txtTuNgay.DateTime.ToString("dd/MM/yyyy");
            //_dataset.Tables["ChonThuLao"].Rows[0]["DenNgay"] = txtDenNgay.DateTime.ToString("dd/MM/yyyy");
            //_dataset.Tables["ChonThuLao"].Rows[0]["MaChuongTrinh"] = cmbChuongTrinh.Value;
            //_dataset.Tables["ChonThuLao"].Rows[0]["MaDatabaseGui"] = _denghi.MaDatabaseGui;
            //_dataset.Tables["ChonThuLao"].Rows[0]["MaDatabaseNhan"] = _denghi.MaDatabaseNhan;

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
        string manganhang = string.Empty;
        string nganhang = string.Empty;

        private void CapNhatChungTuGoc()
        {
            if (IsLoaded)
            {
                txtDienGiai.Text = string.Empty;
                manganhang = string.Empty;
                nganhang = string.Empty;
                txtDienGiai.Text = _loaichungtu.TenLoai + " " + cmbKyLuong.Text + " từ " + txtTuNgay.DateTime.ToString("dd/MM/yy") + " đến " + txtDenNgay.DateTime.ToString("dd/MM/yy");
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
                if (nganhang != "" || manganhang!="")
                {
                    nganhang = nganhang.Substring(0, nganhang.Length - 1);
                    manganhang = manganhang.Substring(0, manganhang.Length - 1);
                }
                txtDienGiai.Text += ", ngân hàng " + nganhang;
                //lấy số tiền 
                using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    System.Data.SqlClient.SqlCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChungTuGoc_ChonThuLaoCTV";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", (int)cmbKyLuong.Value);
                    cm.Parameters.AddWithValue("@MaNganHang", manganhang);
                    cm.Parameters.AddWithValue("@TuNgay", txtTuNgay.DateTime);
                    cm.Parameters.AddWithValue("@DenNgay", txtDenNgay.DateTime);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", _boPhanString);
                    if (_loaichungtu.TenLoai == "Thù lao CTV")
                    {
                        cm.Parameters.AddWithValue("@Loai", Convert.ToInt32( 0));
                    }
                    else if (_loaichungtu.TenLoai == "Khen Thưởng CTV")
                    {
                        cm.Parameters.AddWithValue("@Loai", Convert.ToInt32(1));
                    }
                    else if (_loaichungtu.TenLoai == "Tác Quyền CTV")
                    {
                        cm.Parameters.AddWithValue("@Loai", Convert.ToInt32(2));
                    }
                    else if (_loaichungtu.TenLoai == "Khác CTV")
                    {
                        cm.Parameters.AddWithValue("@Loai", Convert.ToInt32(3));
                    }
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

        private void grdNganHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdNganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {                   
                    col.Format = "#,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
            grdNganHang.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            grdNganHang.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grdNganHang.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdNganHang.DisplayLayout.Bands[0].Columns["Chon"].Width = 50;

            grdNganHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            grdNganHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Ngân Hàng";
            grdNganHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            grdNganHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 60;

            grdNganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Hidden = false;
            grdNganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";
            grdNganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.VisiblePosition = 2;
            grdNganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Width = 250;

            grdNganHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = false;
            grdNganHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            grdNganHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 3;
            grdNganHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Width = 60;

            grdNganHang.DisplayLayout.Bands[0].Columns["TenChiNhanh"].Hidden = false;
            grdNganHang.DisplayLayout.Bands[0].Columns["TenChiNhanh"].Header.Caption = "Tên Chi Nhánh";
            grdNganHang.DisplayLayout.Bands[0].Columns["TenChiNhanh"].Header.VisiblePosition = 4;
            grdNganHang.DisplayLayout.Bands[0].Columns["TenChiNhanh"].Width = 80;

            grdNganHang.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Hidden = false;
            grdNganHang.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tỉnh Thành";
            grdNganHang.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.VisiblePosition = 5                ;
            grdNganHang.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Width = 80;

        }

        private void grdNganHang_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Row.IsDataRow)
            {
                string t = e.Cell.Column.Key;
                if (t == "Chon")
                {
                    CapNhatChungTuGoc();
                }
              
            }
        }

        private void cbBoPhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            HamDungChung h = new HamDungChung();
            FilterCombo f = new FilterCombo(cbBoPhan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cbBoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            cbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbBoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 300;
            cbBoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;

            cbBoPhan.CheckedListSettings.EditorValueSource = EditorWithComboValueSource.SelectedItem;
            UltraGridColumn checkColumn = this.cbBoPhan.DisplayLayout.Bands[0].Columns.Add("Check");
            checkColumn.DataType = typeof(bool);
            checkColumn.Header.VisiblePosition = 0;
            this.cbBoPhan.CheckedListSettings.CheckStateMember = checkColumn.Key;
        }

        private void pnlData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cbBoPhan.Value != null)
                CapNhatChungTuGoc();
        }

       
    }
}