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
    public partial class frmChiTietQuyHoachList : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private ChiTietQuyHoachList _chiTietQuyHoachList;
        private QuyHoachList _quyHoachList;

        private int _nam = 0;

        private bool _laDSQuyHoach = true;

        #endregion

        #region Functions
        private void AnHienGridConTrolTheoYeuCau()
        {
            if (_laDSQuyHoach)
            {
                QuyHoachListGrdC.Visible = true;
                if (QuyHoachListGrdV.Columns.Count == 0)
                    DesignGrid_QuyHoachList();
                CTQuyHoachListGrdC.Visible = false;
            }
            else
            {
                QuyHoachListGrdC.Visible = false;
                CTQuyHoachListGrdC.Visible = true;
                if (CTQuyHoachListGrdV.Columns.Count == 0)
                    DesignGrid_CTQuyHoachList();
            }
        }

        private bool KiemTraChonQuyHoachRow()
        {
            if (QuyHoachListGrdV.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn Quy hoạch cần thực hiện!");
                return false;
            }
            return true;
        }

        private void LoadData()
        {
            GetDieuKienTim();
            AnHienGridConTrolTheoYeuCau();
            if(_laDSQuyHoach)
            {
                _quyHoachList = QuyHoachList.GetQuyHoachListWithOutChild(_nam);//.GetChiTietQuyHoachListbySearch(_nam, true);
                bsQuyHoachList.DataSource = _quyHoachList;
            }
            else
            {
                _chiTietQuyHoachList = ChiTietQuyHoachList.GetChiTietQuyHoachListbySearch(_nam, true);
                bsCTQuyHoach.DataSource = _chiTietQuyHoachList;
            }
        }

        private void FormatForm()
        {
            if(_laDSQuyHoach)
            {
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnTroVeDSQuyHoach.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnTroVeDSQuyHoach.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

        private void LoadDataBindingSource()
        {
            FormatForm();
            AnHienGridConTrolTheoYeuCau();
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

        private void DesignGrid_CTQuyHoachList()
        {
            CTQuyHoachListGrdC.Dock = DockStyle.Fill;

            CTQuyHoachListGrdC.DataSource = bsCTQuyHoach;
            HamDungChung.InitGridViewDev(CTQuyHoachListGrdV, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(CTQuyHoachListGrdV, new string[] { "MaQLNhanVien", "TenNhanVien", "BoPhanNhanVien", "ChucVuQuyHoach", "NgayQuyHoach", "GhiChu" },
                                new string[] { "Mã nhân viên", "Tên nhân viên", "Thuộc bộ phận", "Chức vụ quy hoạch", "Ngày quy hoạch", "Ghi chú" },
                                             new int[] { 150, 200, 200, 200, 150, 300 });
            HamDungChung.AlignHeaderColumnGridViewDev(CTQuyHoachListGrdV, new string[] { "MaQLNhanVien", "TenNhanVien", "BoPhanNhanVien", "ChucVuQuyHoach", "NgayQuyHoach", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);

            Utils.GridUtils.SetSTTForGridView(CTQuyHoachListGrdV, 50);//M
            HamDungChung.ReadOnlyColumnGridViewDev(CTQuyHoachListGrdV);
            //CTQuyHoachListGrdV.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);

            CTQuyHoachListGrdV.OptionsView.ShowGroupPanel = true;
            CTQuyHoachListGrdV.GroupPanelText = "Danh Sách Nhân Viên Thuộc Diện Quy Hoạch";

        }

        private void DesignGrid_QuyHoachList()
        {
            QuyHoachListGrdC.Dock = DockStyle.Fill;

            QuyHoachListGrdC.DataSource = bsQuyHoachList;
            HamDungChung.InitGridViewDev(QuyHoachListGrdV, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(QuyHoachListGrdV, new string[] { "NgayQuyHoach", "DienGiai", "SoNguoiQuyHoach" },
                                new string[] { "Ngày quy hoạch", "Diễn giải","Số người quy hoạch" },
                                             new int[] { 150, 300, 150},true);
            HamDungChung.AlignHeaderColumnGridViewDev(QuyHoachListGrdV, new string[] { "NgayQuyHoach", "DienGiai", "SoNguoiQuyHoach" }, DevExpress.Utils.HorzAlignment.Center);

            Utils.GridUtils.SetSTTForGridView(QuyHoachListGrdV, 50);//M
            HamDungChung.ReadOnlyColumnGridViewDev(QuyHoachListGrdV);
            QuyHoachListGrdV.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);

            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(QuyHoachListGrdV, new string[] { "SoNguoiQuyHoach" }, "{0:#,###.#}");

            QuyHoachListGrdV.OptionsView.ShowGroupPanel = true;
            QuyHoachListGrdV.GroupPanelText = "Danh Sách Quy Hoạch";
            QuyHoachListGrdC.ContextMenuStrip = QuyHoach_contextMenuStrip;
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
            if (QuyHoachListGrdV.GetFocusedRow() != null)
            {
                QuyHoach qH = QuyHoachListGrdV.GetFocusedRow() as QuyHoach;
                if (qH != null)
                {
                    QuyHoach quyHoach = QuyHoach.GetQuyHoach(qH.MaQuyHoach);

                    frmQuyHoach frm = new frmQuyHoach();
                    frm.LoadData(quyHoach);
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();

                    }//New
                }
            }

            //if (CTQuyHoachListGrdV.GetFocusedRow() != null)
            //{
            //    ChiTietQuyHoach ctQuyHoach = CTQuyHoachListGrdV.GetFocusedRow() as ChiTietQuyHoach;
            //    if (ctQuyHoach != null)
            //    {
            //        QuyHoach quyHoach = QuyHoach.GetQuyHoach(ctQuyHoach.MaQuyHoach);

            //        frmQuyHoach frm = new frmQuyHoach();
            //        frm.LoadData(quyHoach);
            //        if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //        {
            //            LoadData();

            //        }//New
            //    }
            //}
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
                if(_laDSQuyHoach)
                {
                    QuyHoachListGrdV.ExportToXls(dlg.FileName);
                }
                else
                {
                    CTQuyHoachListGrdV.ExportToXls(dlg.FileName); 
                }
                OpenFile(dlg.FileName);
            }
        }

        private void btnTroVeDSQuyHoach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _laDSQuyHoach = true;
            FormatForm();
            LoadData();
        }

        private void XemChiTietDSNhanVienQuyHoachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonQuyHoachRow())
            {
                _laDSQuyHoach = false;
                QuyHoach quyhoach = QuyHoachListGrdV.GetFocusedRow() as QuyHoach;
                if (quyhoach != null)
                {
                    FormatForm();
                    AnHienGridConTrolTheoYeuCau();
                    _chiTietQuyHoachList = ChiTietQuyHoachList.GetChiTietQuyHoachList(quyhoach.MaQuyHoach);
                    bsCTQuyHoach.DataSource = _chiTietQuyHoachList;
                }
            }
        }

        #endregion
        public frmChiTietQuyHoachList()
        {
            InitializeComponent();
            LoadDataBindingSource();
            //LoadData();

        }

        

        
    }
}