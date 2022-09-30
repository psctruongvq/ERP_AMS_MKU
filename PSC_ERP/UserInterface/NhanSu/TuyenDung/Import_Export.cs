using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Diagnostics;
namespace PSC_ERP
{
    //
    public partial class Import_Export : Form
    {
       
        Infragistics.Win.UltraWinGrid.UltraGrid gridExport = new Infragistics.Win.UltraWinGrid.UltraGrid();
        ExportNhanVienList listNV;
        object list;
        public Import_Export()
        {
            InitializeComponent();
        }

        private void Import_Export_Load(object sender, EventArgs e)
        {
            BoPhanList bpl = BoPhanList.GetBoPhanListByAll();
            for (int i = 0; i < bpl.Count; i++)
            {
                treeTables.Nodes[0].Nodes["NhanVien"].Nodes.Add(bpl[i].MaBoPhan.ToString(), bpl[i].TenBoPhan);
            }
            treeTables.CollapseAll();

        }
        private void ExportToExcel( Infragistics.Documents.Excel.Workbook workBook,Object list,BindingSource bindingSource,Infragistics.Win.UltraWinGrid.UltraGrid grid,Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter exporter)
        {
            workBook.Worksheets.Add(list.ToString());
            bindingSource.DataSource = list;
            grid.DataSource = bindingSource;
            exporter.Export(grid, workBook.Worksheets[list.ToString()]);
            
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog opf = new SaveFileDialog();
            opf.Filter = "excel files (*.xls)|*.xls|All files (*.*)|*.*";
            opf.ShowDialog();
          
                string filePath = opf.FileName;
                if (filePath.Length > 0)
                {
                    Export(filePath);
                    MessageBox.Show("Export dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(filePath);
                }
            
           
        }
        private void Export(string filePath)
        {
            
            Infragistics.Documents.Excel.Workbook workBook = new Infragistics.Documents.Excel.Workbook();
            int[] bp = new int[BoPhanList.GetBoPhanListByAll().Count];
            for (int i = 0; i < treeTables.Nodes[0].Nodes["NhanVien"].Nodes.Count; i++)
            {
                if (treeTables.Nodes[0].Nodes["NhanVien"].Nodes[i].Checked == true)
                {
                    bp[i] = Convert.ToInt32(treeTables.Nodes[0].Nodes["NhanVien"].Nodes[i].Name);
                }
            }
            listNV = ExportNhanVienList.NewNhanVienList();
            listNV.Clear();
            ExportNhanVienList _nvL = ExportNhanVienList.GetNhanVienListByChild(false);

            for (int i = 0; i < _nvL.Count; i++)
            {
                for (int j = 0; j < bp.Length; j++)
                {
                    if (_nvL[i].MaBoPhan == bp[j])
                    {
                        listNV.Add(_nvL[i]);
                    }
                }
            }
            if (treeTables.Nodes[0].Nodes["NhanVien"].Nodes[0].Checked == true)
            {
               // list = ExportNhanVienList.GetNhanVienListByChild(false);
                ExportToExcel(workBook, listNV, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
        
            if (treeTables.Nodes[0].Nodes["LoaiNhanVien"].Checked == true)
            {
                list = LoaiNhanVienList.GetLoaiNhanVienList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["QuocGia"].Checked == true)
            {
                list = QuocGiaList.GetQuocGiaList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["KhuVuc"].Checked == true)
            {
                list = KhuVucList.GetKhuVucList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["TinhThanh"].Checked == true)
            {
                list = TinhThanhList.GetTinhThanhList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["QuanHuyen"].Checked == true)
            {
                list = QuanHuyenList.GetQuanHuyenList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["TonGiao"].Checked == true)
            {
                list = TonGiaoList.GetTonGiaoList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["DanToc"].Checked == true)
            {
                list = DanToc_NVList.GetDanToc_NVList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }

            if (treeTables.Nodes[0].Nodes["ChucVu"].Checked == true)
            {
                list = ChucVuList.GetChucVuList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["ThanhPhanGiaDinh"].Checked == true)
            {
                list = ThanhPhanGiaDinhClassList.GetThanhPhanGiaDinhClassList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["UuTienBanthan"].Checked == true)
            {
                list = UuTienBanThanList.GetUuTienBanThanList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["GiamTruGiaCanh"].Checked == true)
            {
                list = GiamTruGiaCanhList.GetGiamTruGiaCanhList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["TrinhDoHocVan"].Checked == true)
            {
                list = TrinhDoHocVanClassList.GetTrinhDoHocVanClassList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["ChuyenNganhDaoTao"].Checked == true)
            {
                list = ChuyenNganhDaoTaoClassList.GetChuyenNganhDaoTaoClassList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["NgoaiNgu"].Checked == true)
            {
                list = NgoaiNguList.GetNgoaiNguList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["TrinhDoNgoaiNgu"].Checked == true)
            {
                list = TrinhDoNgoaiNguClassList.GetTrinhDoNgoaiNguClassList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["LoaiDangVien"].Checked == true)
            {
                list = LoaiDangVienList.GetLoaiDangVienList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["NhanVien_NgoaiNgu"].Checked == true)
            {
                list = NhanVien_NgoaiNguList.GetNhanVien_NgoaiNguList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["TrinhDoTinHoc"].Checked == true)
            {
                list = TrinhDoTinHocClassList.GetTrinhDoTinHocClassList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["QuanLyNhaNuoc"].Checked == true)
            {
                list = QuanLyNhaNuocList.GetQuanLyNhaNuocList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["QuanLyKinhTe"].Checked == true)
            {
                list = QuanLyKinhTeList.GetQuanLyKinhTeList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["NhanVien_TrinhDoQuanLy"].Checked == true)
            {
                list = NhanVien_TrinhDoQuanLyList.GetNhanVien_TrinhDoQuanLyList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["NhanVien_HoatDongXaHoi"].Checked == true)
            {
                list = HoatDongXaHoiList.GetHoatDongXaHoiList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["QuanHeGiaDinh"].Checked == true)
            {
                list = QuanHeGiaDinhList.GetQuanHeGiaDinhList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["NhanVien_GiamTruGiaCanh"].Checked == true)
            {
                list = NhanVienGiaCanhList.GetNhanVienGiaCanh();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["QuyetDinhNangLuong"].Checked == true)
            {
                list = QuyetDinhNangLuongList.GetQuyetDinhNangLuongList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["BoPhan"].Checked == true)
            {
                list = BoPhanList.GetBoPhanListByAll();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["NganHang"].Checked == true)
            {
                list = NganHangList.GetNganHangList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["NhomNgachLuong"].Checked == true)
            {
                list = NhomNgachLuongCoBanList.GetNhomNgachLuongCoBanListAll();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["NgachLuong"].Checked == true)
            {
                list = NgachLuongCoBanList.GetNgachLuongCoBanList();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            if (treeTables.Nodes[0].Nodes["BacLuong"].Checked == true)
            {
                list = BacLuongCoBanList.GetBacLuongCoBanListAll();
                ExportToExcel(workBook, list, this.bindingSource1, ultragrdImportExport, ultraGridExcelExporter1);
            }
            workBook.Save(filePath);

        }

        private void treeTables_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void treeTables_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked == true)
                CheckedParentNode(e.Node);
            if (e.Node.Nodes.Count > 0)
                CheckedChildNode(e.Node, e.Node.Checked);
        }
        private void CheckedParentNode(TreeNode node)
        {
            if (node.Parent != null && !node.Parent.Checked)
            {
                //node.Parent.Checked = true;
                CheckedParentNode(node.Parent);
            }
        }
        private void CheckedChildNode(TreeNode node, bool check)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = check;
                if (item.Nodes.Count > 0)
                    CheckedChildNode(item, check);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
