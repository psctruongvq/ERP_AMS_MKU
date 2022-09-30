using System;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmDanhSachHTV : Form
    {
        BoPhanList _BoPhanList; int maBophan = 0; long maNhanVien = 0; int maChucVu = 0;
        ExportNhanVienList NVList;
        int userID = CurrentUser.Info.UserID;
        public frmDanhSachHTV()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _BoPhanList = BoPhanList.GetBoPhanListAll(userID);           
            BindS_BoPhan.DataSource = _BoPhanList;
            ChucVuList _chucVuList = ChucVuList.GetChucVuListAll();
            ChucVu itemCV = ChucVu.NewChucVu(0, "Tất Cả");
            _chucVuList.Insert(0, itemCV);
            this.bindingSource2.DataSource = _chucVuList;
             NVList = ExportNhanVienList.GetNhanVienList();
            this.bindingSource1.DataSource = NVList;
            lbTongSo.Text = "Tổng Số: "+NVList.Count.ToString();
             
        }
        public frmDanhSachHTV(object list)
        {
            InitializeComponent();
            this.bindingSource1.DataSource = list;
            this.ultragrdImportExport.DataSource = bindingSource1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdImportExport);
        }

        private void ultragrdImportExport_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                maBophan = Convert.ToInt32(cmbu_Bophan.Value);
               
            }
            ComboChanged();
        }
        private void ComboChanged()
        {
            NVList = ExportNhanVienList.GetNhanVienListBoPhanChucVu(maBophan, maChucVu);
            this.bindingSource1.DataSource = NVList;
            lbTongSo.Text = "Tổng Số: " + NVList.Count.ToString();
        }

        private void ultraCombo1_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCombo1.Value != null)
            {
                maChucVu = Convert.ToInt32(ultraCombo1.Value);

            } 
            ComboChanged();
        }
    }
}
