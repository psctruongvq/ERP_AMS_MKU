using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;

//2018.08.03
namespace PSC_ERP
{
    public partial class frmChonDoiTuong : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        string strTenPhuongThuc;
        DataSet dsReport;
        HeThongTaiKhoan1List lstTaiKhoan;
        DoiTuongAllList _DoiTuongThuChiList;
        public string strMaDoiTuong = "";

        #endregion Events

        public frmChonDoiTuong()
        {
            InitializeComponent();
        }

        #region event FormLoad
        private void frmChonDoiTuong_Load(object sender, EventArgs e)
        {
            
            bdTaiKhoan.DataSource = lstTaiKhoan;
            int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            _DoiTuongThuChiList = DoiTuongAllList.GetDoiTuongAllList_TimDoiTac("", _maCongTy, 0);
            bdDoiTuong.DataSource = _DoiTuongThuChiList;
           
        }
        #endregion
        

        #region event btn
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnExportDataExcell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               
                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(dlg.FileName);
            }
        }
        #endregion
           

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtFocus.Focus();
            strMaDoiTuong = "";
            foreach (DoiTuongAll obj in _DoiTuongThuChiList)
            {
                if (obj.Check == true)
                    strMaDoiTuong = strMaDoiTuong + obj.MaDoiTuong + ",";
            }
            if (strMaDoiTuong.Length > 0)
            {
                strMaDoiTuong = strMaDoiTuong.Substring(0, strMaDoiTuong.Length - 1);
            }
            this.Close();
        }






    }
}