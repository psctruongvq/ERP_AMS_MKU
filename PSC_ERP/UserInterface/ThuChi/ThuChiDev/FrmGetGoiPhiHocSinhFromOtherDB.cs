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
//13/04/2013
namespace PSC_ERP
{
    public partial class FrmGetGoiPhiHocSinhFromOtherDB : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        List<GoiPhiThamGiaHocSinhFromOtherDB> _goiphithamgiaList = new List<GoiPhiThamGiaHocSinhFromOtherDB>();
        List<GoiPhiThamGiaHocSinhFromOtherDB> _goiphithamgiaListSelected = new List<GoiPhiThamGiaHocSinhFromOtherDB>();
        BindingSource DSGoiPhiThamGia_BindingSource = new BindingSource();
        public int intMaKy = 0;
        public List<GoiPhiThamGiaHocSinhFromOtherDB> GoiPhiThamGiaListSelected
        {
            get { return _goiphithamgiaListSelected; }

        }
        #endregion//Properties

        #region Function

        private void FormatForm()
        {
        }

        private void DesignGridView()
        {
            #region Design Gridview
            gridControl1.DataSource = DSGoiPhiThamGia_BindingSource;

            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            //     NULL AS MaDoiTuong,doitacERp.MaDoiTuong AS MaDoiTuongInt
            //,viewdata.MaHocSinh AS MaQLDoiTuong,viewdata.Ten AS TenDoiTuong
            //,viewdata.NamHoc,viewdata.MaGoi AS MaGoiPhi,viewdata.TenGoi AS TenGoiPhi
            //,viewdata.SoTienCuaGoi,viewdata.PhaiThu,viewdata.DaDong
            //,viewdata.ConNo AS SoTienConLai
            //,viewdata.TenLop, viewdata.TenKhoi, viewdata.TenHe, viewdata.TenTruong
            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "Check", "MaQLDoiTuong", "TenDoiTuong", "NamHoc", "MaGoiPhi", "TenGoiPhi", "SoTienCuaGoi", "PhaiThu", "DaDong", "SoTienConLai", "TenTruong", "TenKhoi", "TenLop" },
                                new string[] { "Chọn", "Mã học sinh", "Tên học sinh", "Năm học", "Mã gói phí", "Tên gói phí", "Tổng giá trị", "Số tiền tăng trong năm", "Số tiền đã thu", "Số tiền còn nợ", "Trường", "Khối", "Lớp" },
                                             new int[] {80 , 90,120, 80, 100, 120, 100, 100, 100, 100, 110, 100, 100}, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "MaQLDoiTuong", "TenDoiTuong", "NamHoc", "MaGoiPhi", "TenGoiPhi", "SoTienCuaGoi", "PhaiThu", "DaDong", "SoTienConLai", "TenTruong", "TenKhoi", "TenLop" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoTienCuaGoi", "PhaiThu", "DaDong", "SoTienConLai" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoTienCuaGoi", "PhaiThu", "DaDong", "SoTienConLai" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] {"MaQLDoiTuong", "TenDoiTuong", "NamHoc", "MaGoiPhi", "TenGoiPhi", "SoTienCuaGoi", "PhaiThu", "DaDong", "SoTienConLai", "TenTruong", "TenKhoi", "TenLop" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }

        private void loadForm()
        {
            DSGoiPhiThamGia_BindingSource.DataSource = typeof(GoiPhiThamGiaHocSinhFromOtherDB);
            // chi lay nhung hoa don cua nguoi lap chung tu
            if (intMaKy == 0)
            {
                _goiphithamgiaList = GoiPhiThamGiaHocSinhFromOtherDB.LoadGoiPhiThamGiaHocSinhFromOtherDBList();
            }
            else
            {
                _goiphithamgiaList = GoiPhiThamGiaHocSinhFromOtherDB.LoadGoiPhiThamGiaHocSinhFromOtherDBList_MaKy(intMaKy);
            }           

            DSGoiPhiThamGia_BindingSource.DataSource = _goiphithamgiaList;
            DesignGridView();
        }

        public FrmGetGoiPhiHocSinhFromOtherDB()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            FormatForm();
            loadForm();

        }

        public FrmGetGoiPhiHocSinhFromOtherDB(int _maKy)
        {
            InitializeComponent();
            this.intMaKy = _maKy;
            this.WindowState = FormWindowState.Maximized;
            FormatForm();
            loadForm();

        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }


        #endregion //Function

        #region Events

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FocustextBox1.Focus();
            DSGoiPhiThamGia_BindingSource.EndEdit();
            foreach (GoiPhiThamGiaHocSinhFromOtherDB gptg in _goiphithamgiaList)
            {
                if (gptg.Check == true)
                {
                    _goiphithamgiaListSelected.Add(gptg);
                }
            }
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        private void btnExportDataExcell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        #endregion Events

    }
}