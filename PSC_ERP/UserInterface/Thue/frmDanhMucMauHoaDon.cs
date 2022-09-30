using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmDanhMucMauHoaDon : Form
    {
        #region properties
        DanhMucMauHoaDonList _danhMucMauHoaDonList;
        Util util = new Util();
        HamDungChung hdc = new HamDungChung();
        
        #endregion

        #region Contructor
        public frmDanhMucMauHoaDon()
        {
            InitializeComponent();         
            KhoiTao();
        }
        #endregion

        #region KhoiTao
        public void KhoiTao()
        {
            _danhMucMauHoaDonList = DanhMucMauHoaDonList.GetDanhMucMauHoaDonList();
            danhMucMauHoaDon_Bingsource.DataSource = _danhMucMauHoaDonList;
        }
        #endregion

     
        private void grdu_KyHan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;

            foreach (UltraGridColumn col in this.grdu_DanhMucMauHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            grdu_DanhMucMauHoaDon.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            grdu_DanhMucMauHoaDon.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Hidden = false;

            grdu_DanhMucMauHoaDon.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            grdu_DanhMucMauHoaDon.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            grdu_DanhMucMauHoaDon.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Header.Caption = "Tên Loại hóa Đơn";
            grdu_DanhMucMauHoaDon.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Header.VisiblePosition = 1;
            grdu_DanhMucMauHoaDon.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Width = 300;



        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            grdu_DanhMucMauHoaDon.UpdateData();
            _danhMucMauHoaDonList.ApplyEdit();

            foreach (DanhMucMauHoaDon item in _danhMucMauHoaDonList)
            {
                
                if (string.IsNullOrEmpty(item.MaQuanLy))
                {
                    MessageBox.Show(this, "Vui lòng nhập mã quản lý hóa đơn.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(item.TenLoaiHoaDon))
                {
                    MessageBox.Show(this, "Vui lòng nhập tên loại hóa đơn.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                item.Chon = true;
                if (KiemTraMaQuanLy(item.MaLoaiHoaDon, item.MaQuanLy))
                {
                    MessageBox.Show(this, "Mã quản lý bị trùng.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    item.Chon = false;
                    return;
                }
                item.Chon = false;
            }

            _danhMucMauHoaDonList.Save();
            MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            KhoiTao();
        
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grdu_DanhMucMauHoaDon.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn dòng cần xóa.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            grdu_DanhMucMauHoaDon.DeleteSelectedRows();
        }

        private void grdu_DanhMucMauHoaDon_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.ToString().Equals("MaQuanLy"))
            { 
                //Lấy mẫu hóa đơn hiện tại
                DanhMucMauHoaDon danhMucMauHoaDonCurrent = danhMucMauHoaDon_Bingsource.Current as DanhMucMauHoaDon;
                if (danhMucMauHoaDonCurrent != null && danhMucMauHoaDonCurrent.MaLoaiHoaDon != 0)
                {
                    if (KiemTraMauHoaDonTrongHoaDon(danhMucMauHoaDonCurrent.MaQuanLy))
                    {
                        MessageBox.Show(this, "Loại hóa đơn này đã lập hóa đơn không thể sữa.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        KhoiTao();
                        return;               
                    }
                }      
            }
        }
        private bool KiemTraMaQuanLy(int maLoaiHoaDon, string maQuanLy)
        {
            _danhMucMauHoaDonList.ApplyEdit();
            Boolean kq = false;
            if (maLoaiHoaDon == 0)
            {
                foreach (DanhMucMauHoaDon item in _danhMucMauHoaDonList)
                {
                    if (item.Chon == false && item.MaQuanLy.Trim() == maQuanLy.Trim())
                    {
                        kq = true;
                    }
                }
            }
            else
            {
                foreach (DanhMucMauHoaDon item in _danhMucMauHoaDonList)
                {
                    if ( item.Chon == false && item.MaQuanLy.Trim() == maQuanLy.Trim() && item.MaLoaiHoaDon != maLoaiHoaDon)
                    {
                        kq = true;
                    }
                }            
            }
            return kq;
        }
        private bool KiemTraMauHoaDonTrongHoaDon(string mauHoaDon)
        {
            Boolean kq = false;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraMauHoaDonTrongHoaDon";
                    cm.Parameters.AddWithValue("@MauHoaDon", mauHoaDon);
                    cm.Parameters.AddWithValue("@KetQua", kq);
                    cm.Parameters["@KetQua"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    kq = Convert.ToBoolean(cm.Parameters["@KetQua"].Value);
                }
            }//using
            return kq;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }
    }
}