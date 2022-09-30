using DevExpress.XtraEditors;
using PSC_ERP.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmDanhSachTaiSanTaiViTri : Form
    {
       
        #region Singleton
        private static frmDanhSachTaiSanTaiViTri singleton_ = null;
        public static frmDanhSachTaiSanTaiViTri Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDanhSachTaiSanTaiViTri();
                return singleton_;
            }
        }
        #endregion

        private int MaViTri = 0;

        public frmDanhSachTaiSanTaiViTri()
        {
            InitializeComponent();
        }
        public frmDanhSachTaiSanTaiViTri(int maViTri)
        {
            InitializeComponent();
            this.MaViTri = maViTri;
        }

        private void frmDanhSachTaiSanTaiViTri_Load(object sender, EventArgs e)
        {
            grdC_DanhSachTSTaiViTri.DataSource = dt_TSCDCB_TaiViTri(MaViTri);
            GridUtils.SetSTTForGridView(grdV_DanhSachTSTaiViTri);
        }
        #region Đọc danh sách tài sản cố định cá biệt
        public static DataTable dt_TSCDCB_TaiViTri(int maViTri)
        {
            DataTable kq = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandTimeout = 1800;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DanhSachTSTaiViTri";
                        cm.Parameters.AddWithValue("@MaViTri", maViTri);
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        da.Fill(kq);
                    }
                }
                return kq;
            }
            catch (Exception ThongBaoLoi) { XtraMessageBox.Show("<color=red>-Lỗi: </color>" + ThongBaoLoi.ToString(), "ĐÃ XẢY RA LỖI", DevExpress.Utils.DefaultBoolean.True); return kq; }
        }
        #endregion Đọc danh sách tài sản cố định cá biệt
    }
}
