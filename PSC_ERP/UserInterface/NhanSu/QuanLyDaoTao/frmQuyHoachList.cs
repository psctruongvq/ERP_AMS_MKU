using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Diagnostics;
using System.IO;

namespace PSC_ERP.UserInterface.NhanSu.QuanLyDaoTao
{
    public partial class frmQuyHoachList : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private int _MaQuyHoach;
        private QuyHoachList _quyHoachList;

        private int _nam = 0;


        public int MaQuyHoach
        {
            get { return _MaQuyHoach; }
            set
            {
                _MaQuyHoach = value;
            }
        }
        

        #endregion

        #region Functions

        private void LoadData()
        {
            GetDieuKienTim();
            _quyHoachList = QuyHoachList.GetQuyHoachListWithOutChild(_nam);//.GetChiTietQuyHoachListbySearch(_nam, true);
            bsQuyHoachList.DataSource = _quyHoachList;
        }

        private void FormatForm()
        {
            btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

        }

        private void LoadDataBindingSource()
        {
            FormatForm();
            DesignGrid();
        }

        private void GetDieuKienTim()
        {
            int tryint;
            if (int.TryParse(txt_nam.Text, out tryint))
            {
                _nam = tryint;
            }
            else
            {
                _nam = 0;
            }
        }

        private void DesignGrid()
        {

            gridControl1.DataSource = bsQuyHoachList;
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "NgayQuyHoach", "DienGiai" },
                                new string[] { "Ngày quy hoạch", "Diễn giải" },
                                             new int[] { 150, 950 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "NgayQuyHoach", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);

            gridView1.OptionsView.ShowGroupPanel = true;
            gridView1.GroupPanelText = "Danh Sách Quy Hoạch";

        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }
        #endregion

        #region Event
        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                QuyHoach quyHoach = gridView1.GetFocusedRow() as QuyHoach;
                if (quyHoach != null)
                {
                    _MaQuyHoach = quyHoach.MaQuyHoach;
                }
            }
            this.Close();
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQuyHoach frm = new frmQuyHoach();
            frm.LoadData(null);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                LoadData();

            }//New
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXuatraExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }
        #endregion
        public frmQuyHoachList()
        {
            InitializeComponent();
            LoadDataBindingSource();
            //LoadData();

        }

        

        
    }
}