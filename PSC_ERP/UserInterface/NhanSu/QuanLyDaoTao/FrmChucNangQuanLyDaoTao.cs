using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
//05_08_2014
namespace PSC_ERP
{
    public partial class FrmChucNangQuanLyDaoTao : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        #region TabPage1
        DataTable _tableSourcePage1;
        DataTable _tableSourcePage2;
        private int _maTruongDaoTao = 0;
        private int _loaiVanBang = 0;
        private int _maQuocGiaCap = 0;
        private int _maChuyenNganhDaoTao = 0;
        private int _maDonViDaoTao = 0;
        #endregion//TabPage1

        #endregion//Properties

        #region TabPage2
        private int _maBoPhanTab2 = 0;
        #endregion//TabPage2

        public FrmChucNangQuanLyDaoTao()
        {
            InitializeComponent();
            KhoiTao();

        }

        private void KhoiTao()
        {
            BoPhanList _boPhanList = BoPhanList.GetBoPhanList();
            BoPhan bp = BoPhan.NewBoPhan("<<Tất cả>>");
            _boPhanList.Insert(0, bp);
            boPhanListBindingSource.DataSource = _boPhanList;
            _tableSourcePage1 = new DataTable();
            _tableSourcePage2 = new DataTable();
        }
        #region Function
        private void GetThongTinSearchPage1()
        {

            if (TruongDaoTaoTabQuanLyDiHocGLU.EditValue != null)
            {
                _maTruongDaoTao = (int)TruongDaoTaoTabQuanLyDiHocGLU.EditValue;
            }
            else
            {
                _maTruongDaoTao = 0;
            }
            if (LoaiVanBangTabQuanLyDiHocGLU.EditValue != null)
            {
                _loaiVanBang = (int)LoaiVanBangTabQuanLyDiHocGLU.EditValue;
            }
            else
            {
                _loaiVanBang = 0;
            }
            if (QuocGiaCapTabQuanLyDiHocGLU.EditValue != null)
            {
                _maQuocGiaCap = (int)QuocGiaCapTabQuanLyDiHocGLU.EditValue;
            }
            else
            {
                _maQuocGiaCap = 0;
            }
            if (ChuyenNganhDaoTaoTabQuanLyDiHocGLU.EditValue != null)
            {
                _maChuyenNganhDaoTao = (int)ChuyenNganhDaoTaoTabQuanLyDiHocGLU.EditValue;
            }
            else
            {
                _maChuyenNganhDaoTao = 0;
            }
            
            int tryintMaDV;
            if (int.TryParse(DonViDaoTaoGrLUTabQuanLyDiHoc.EditValue.ToString(), out tryintMaDV))
            {
                _maDonViDaoTao = tryintMaDV;
            }
            else _maDonViDaoTao = 0;

        }

        private void GetThongTinSearchPage2()
        {
            if (GrdLU_PhongBan_Tab2.EditValue != null)
            {
                _maBoPhanTab2 = (int)GrdLU_PhongBan_Tab2.EditValue;
            }
            else
            {
                _maBoPhanTab2 = 0;
            }
        }
        private DataTable Table_ChucNangQuanLyDaoTao(int maDonViDaoTao, int maChuyenNganhDaoTao,int loaiVanBang,int maTruongDaoTao,int maQuocGiaCap,DateTime tuNgay, DateTime denNgay)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChucNangQuanLyDaoTaoCuaTatCaNhanVien";
                    cm.Parameters.AddWithValue("@MaDonViDaoTao", maDonViDaoTao);
                    cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", maChuyenNganhDaoTao);
                    cm.Parameters.AddWithValue("@LoaiVanBang", loaiVanBang);
                    cm.Parameters.AddWithValue("@MaTruongDaoTao", maTruongDaoTao);
                    cm.Parameters.AddWithValue("@MaQuocGiaCap", maQuocGiaCap);
                    //cm.Parameters.AddWithValue("@TimTheoNgay", timTheoNgay);
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0)
                            kqTbl = ds.Tables[0];
                    }
                }
            }//us
            return kqTbl;
        }
        private DataTable Table_ChucNangQuanLyDaoTaoTabPage2(int maBoPhan)
        {
            DataTable tblresult = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChucNangHoTroInThongTinNhanVien";
                    cm.Parameters.AddWithValue("MaBoPhan", maBoPhan);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0)
                            tblresult = ds.Tables[0];
                    }
                }
            }
            return tblresult;
        }

        private void LoadData()
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                GetThongTinSearchPage1();
                _tableSourcePage1 = Table_ChucNangQuanLyDaoTao(_maDonViDaoTao, _maChuyenNganhDaoTao, _loaiVanBang, _maTruongDaoTao, _maQuocGiaCap, (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date);
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                GetThongTinSearchPage2();
                _tableSourcePage2 = Table_ChucNangQuanLyDaoTaoTabPage2(_maBoPhanTab2);
            }

        }


        private void DesignGridViewPage1()
        {//N
            gridViewPage1.OptionsView.ShowGroupPanel = true;
            gridViewPage1.GroupPanelText = "Thông Tin Đào Tạo Của Nhân Viên";
            gridViewPage1.OptionsView.ShowAutoFilterRow = true;
            gridViewPage1.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < gridViewPage1.Columns.Count; i++)
            {
                gridViewPage1.Columns[i].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                gridViewPage1.Columns[i].OptionsColumn.AllowEdit = false;
                gridViewPage1.Columns[i].OptionsColumn.FixedWidth = false;
                gridViewPage1.Columns[i].BestFit();
                gridViewPage1.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridViewPage1.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            }
            Utils.GridUtils.SetSTTForGridView(gridViewPage1, 40);//M
        }

        private void DesignGridViewPage2()
        {//N
            gridViewTabPage2.OptionsView.ShowGroupPanel = true;
            gridViewTabPage2.GroupPanelText = "Danh Sách Nhân Viên - Thông Tin Theo Yêu Cầu";
            gridViewTabPage2.OptionsView.ShowAutoFilterRow = true;
            gridViewTabPage2.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < gridViewTabPage2.Columns.Count; i++)
            {
                gridViewTabPage2.Columns[i].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                gridViewTabPage2.Columns[i].OptionsColumn.AllowEdit = false;
                gridViewTabPage2.Columns[i].OptionsColumn.FixedWidth = false;
                gridViewTabPage2.Columns[i].BestFit();
                gridViewTabPage2.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridViewTabPage2.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            }
            Utils.GridUtils.SetSTTForGridView(gridViewTabPage2, 40);//M
        }

        #endregion

        #region Event

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                gridViewPage1.Columns.Clear();
                _tableSourcePage1 = new DataTable();
                LoadData();
                gridControl1.DataSource = _tableSourcePage1;
                DesignGridViewPage1();
                if (_tableSourcePage1.Rows.Count == 0)//M
                    MessageBox.Show("Danh Sách Rỗng");
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                gridViewTabPage2.Columns.Clear();
                _tableSourcePage2= new DataTable();
                LoadData();
                gridControl_TabPage2.DataSource = _tableSourcePage2;
                DesignGridViewPage2();
                if (_tableSourcePage2.Rows.Count == 0)//M
                    MessageBox.Show("Danh Sách Rỗng");
            }
        }


        #endregion

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void btn_XuatRaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gridViewPage1.ExportToXls(dlg.FileName);
                    OpenFile(dlg.FileName);
                }
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
                {
                    //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        gridViewTabPage2.ExportToXls(dlg.FileName);
                        OpenFile(dlg.FileName);
                    }
                }
        }





        private void FrmDanhSachHopDongThuChi_Load(object sender, EventArgs e)
        {
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
            GrdLU_PhongBan_Tab2.EditValue = 0;
        }
    }
}