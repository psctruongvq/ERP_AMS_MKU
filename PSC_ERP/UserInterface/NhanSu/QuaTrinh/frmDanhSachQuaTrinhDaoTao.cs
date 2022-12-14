
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmDanhSachQuaTrinhDaoTao : Form
    {
        BoPhanList _boPhanList;
      
       
        private ERP_Library.QuaTrinhDaoTaoList _Data;

        int tuNam = 1990;
        int denNam = 2030;
        TTNhanVienRutGonList _nhanVienList;
        public frmDanhSachQuaTrinhDaoTao()
        {
          
            InitializeComponent();
        }
        private void ComboChanged()
        {

            _Data = ERP_Library.QuaTrinhDaoTaoList.GetQuaTrinhDaoTaoMoiList(tuNam, denNam);
            bdQuaTrinhDaoTao.DataSource = _Data;
        }
        private void frmDaoTaoNgoaiList_Load(object sender, EventArgs e)
        {
            _boPhanList = BoPhanList.GetBoPhanListByAll();
           
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListAll();         
            this.bindingSource2_nhanVien.DataSource = _nhanVienList;
           


            _Data = ERP_Library.QuaTrinhDaoTaoList.GetQuaTrinhDaoTaoMoiList(tuNam, denNam);
            bdQuaTrinhDaoTao.DataSource = _Data;
            TruongDaoTaoList _truongDaoTaoList = TruongDaoTaoList.GetTruongDaoTaoList();
            TruongDaoTao itemAdd = TruongDaoTao.NewTruongDaoTao("Không Có");
            _truongDaoTaoList.Insert(0, itemAdd);
            this.bindingSource1_TruongDaoTao.DataSource = _truongDaoTaoList;
        
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in gridData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                col.Hidden = true;
            }
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            gridData.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["TenvanbangChungchi"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["SovanbangChungchi"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["VanbangChungchi"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["XepLoai"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["NamTotNghiep"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["NgayCap"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["NguoiKy"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["DaNopBang"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["MaTruongDaoTao"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["ChuyenTTNhanVien"].Hidden = false;
            gridData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.Caption = "Tên Nhân Viên";
            gridData.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            gridData.DisplayLayout.Bands[0].Columns["TenvanbangChungchi"].Header.Caption = "Tên Văn Bằng/Chứng Chỉ";
            gridData.DisplayLayout.Bands[0].Columns["SovanbangChungchi"].Header.Caption = "Số VB/CC";
            gridData.DisplayLayout.Bands[0].Columns["VanbangChungchi"].Header.Caption = "Loại";
            gridData.DisplayLayout.Bands[0].Columns["XepLoai"].Header.Caption = "Xếp Loại";
            gridData.DisplayLayout.Bands[0].Columns["NamTotNghiep"].Header.Caption = "Năm TN";
            gridData.DisplayLayout.Bands[0].Columns["MaTruongDaoTao"].Header.Caption = "Trường Tốt Nghiệp";
            gridData.DisplayLayout.Bands[0].Columns["NgayCap"].Header.Caption = "Ngày Cấp";
            gridData.DisplayLayout.Bands[0].Columns["NguoiKy"].Header.Caption = "Người Ký";
            gridData.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            gridData.DisplayLayout.Bands[0].Columns["DaNopBang"].Header.Caption = "Nộp bằng";
            gridData.DisplayLayout.Bands[0].Columns["ChuyenTTNhanVien"].Header.Caption = "Đã chuyển";
            gridData.DisplayLayout.Bands[0].Columns["SovanbangChungchi"].Width = 60;
            gridData.DisplayLayout.Bands[0].Columns["VanbangChungchi"].Width = 70;
            gridData.DisplayLayout.Bands[0].Columns["NamTotNghiep"].Width = 55;
            gridData.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 250;
            gridData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Width = 200;
            gridData.DisplayLayout.Bands[0].Columns["XepLoai"].Width = 70;
            gridData.DisplayLayout.Bands[0].Columns["NgayCap"].Width = 70;
            gridData.DisplayLayout.Bands[0].Columns["DaNopBang"].Width = 60;
            gridData.DisplayLayout.Bands[0].Columns["ChuyenTTNhanVien"].Width = 60;
            gridData.DisplayLayout.Bands[0].Columns["MaTruongDaoTao"].Width = cbTruongDaoTao.Width;
            gridData.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            gridData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.VisiblePosition = 1;
            gridData.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;
            gridData.DisplayLayout.Bands[0].Columns["TenvanbangChungchi"].Header.VisiblePosition = 3;
            gridData.DisplayLayout.Bands[0].Columns["SovanbangChungchi"].Header.VisiblePosition = 4;
            gridData.DisplayLayout.Bands[0].Columns["VanbangChungchi"].Header.VisiblePosition = 5;
            gridData.DisplayLayout.Bands[0].Columns["NamTotNghiep"].Header.VisiblePosition =6;
            gridData.DisplayLayout.Bands[0].Columns["MaTruongDaoTao"].Header.VisiblePosition = 7;
            gridData.DisplayLayout.Bands[0].Columns["XepLoai"].Header.VisiblePosition = 8;
            gridData.DisplayLayout.Bands[0].Columns["NgayCap"].Header.VisiblePosition =9;
            gridData.DisplayLayout.Bands[0].Columns["NguoiKy"].Header.VisiblePosition = 10;
            gridData.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 11;
            gridData.DisplayLayout.Bands[0].Columns["ChuyenTTNhanVien"].Header.VisiblePosition = 12;
            gridData.DisplayLayout.Bands[0].Columns["MaNhanVien"].EditorComponent = cbNhanVien;
            gridData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Width = cbNhanVien.Width;
            gridData.DisplayLayout.Bands[0].Columns["VanbangChungchi"].EditorComponent = cmbu_Loai;
            gridData.DisplayLayout.Bands[0].Columns["XepLoai"].EditorComponent = cmbu_XepLoai;
            gridData.DisplayLayout.Bands[0].Columns["MaTruongDaoTao"].EditorComponent = cbTruongDaoTao;
            gridData.DisplayLayout.Bands[0].Columns["VanbangChungchi"].Width = cmbu_Loai.Width;
          
        }

        private void cbNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbNhanVien, "TenNhanVien");
        }


        private void Save()
        {
            this.bdQuaTrinhDaoTao.EndEdit();
            this.gridData.UpdateData();
            _Data.ApplyEdit();
            _Data.Save();
            MessageBox.Show("Cập nhật thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
     

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
           
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            ComboChanged();
        }

        private void tlslblThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gridData);
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gridData);
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                _nhanVienList = TTNhanVienRutGonList.GetNhanVienListBoPhan(Convert.ToInt32(cmbu_Bophan.Value));
                this.bindingSource2_nhanVien.DataSource = _nhanVienList;
            }
        }

        private void tbTuNam_ValueChanged(object sender, EventArgs e)
        {
            tuNam = Convert.ToInt32(tbTuNam.Value);
            ComboChanged();
        }

        private void tbDenNam_ValueChanged(object sender, EventArgs e)
        {
            denNam = Convert.ToInt32(tbDenNam.Value);
            ComboChanged();
        }
        private bool KiemTraVanBanChungChiDaTonTai(string tenVanBangChungChi, long maNhanVien)
        {
            NhanVien_ChungChiList nv_ccList = NhanVien_ChungChiList.GetNhanVien_ChungChiList(maNhanVien);
            foreach (NhanVien_ChungChi cc in nv_ccList)
            {
                if (cc.TenChungChi == tenVanBangChungChi)
                    return true;
            }
            return false;
        }
        private void ultraButton2_Click(object sender, EventArgs e)
        {
           
            TTNhanVienRutGonList _ttNVList = TTNhanVienRutGonList.GetNhanVienListAll();
            try
            {
                DialogResult result = MessageBox.Show("Bạn có muốn chuyển thông tin đào tạo vào thông tin Nhân Viên ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    for (int i = 0; i < gridData.Rows.Count; i++)
                    {

                        if ((Convert.ToBoolean(gridData.Rows[i].Cells["Check"].Value) == true))
                        {

                            if (Convert.ToBoolean(gridData.Rows[i].Cells["ChuyenTTNhanVien"].Value) == false)
                            {
                                int maQuaTrinhDaoTao = Convert.ToInt32(gridData.Rows[i].Cells["MaQuaTrinhDaoTao"].Value);
                                long maNhanVien = Convert.ToInt64(gridData.Rows[i].Cells["MaNhanVien"].Value);
                                string tenChungChi = Convert.ToString(gridData.Rows[i].Cells["TenvanbangChungchi"].Value);
                                DateTime ngayCap = Convert.ToDateTime(gridData.Rows[i].Cells["NgayCap"].Value).Date;
                                int maTruongDaoTao = Convert.ToInt32(gridData.Rows[i].Cells["MaTruongDaoTao"].Value);
                                TruongDaoTao trDT = TruongDaoTao.GetTruongDaoTao(maTruongDaoTao);
                                    if (!KiemTraVanBanChungChiDaTonTai(tenChungChi, maNhanVien))
                                    {
                                        NhanVien nv = NhanVien.GetNhanVien(maNhanVien);
                                        nv.NhanVienChungChiList = NhanVien_ChungChiList.NewNhanVien_ChungChiList();
                                        NhanVien_ChungChi nv_cc = NhanVien_ChungChi.NewNhanVien_ChungChi();
                                        nv_cc.MaNhanVien = maNhanVien;
                                        nv_cc.TenChungChi = tenChungChi;
                                        nv_cc.NgayCap = ngayCap;
                                        nv_cc.NoiCap = trDT.TenTruongDaoTao;
                                        nv.NhanVienChungChiList.Add(nv_cc);
                                        nv.Save();

                                    }
                                    QuaTrinhDaoTao dt = QuaTrinhDaoTao.GetQuaTrinhDaoTaoMoi(maQuaTrinhDaoTao);
                                    dt.ChuyenTTNhanVien = true;
                                    dt.ApplyEdit();
                                    dt.Save(true);
                                                              
                            }
                        }
                      
                    }
                    MessageBox.Show("Chuyển dữ liệu thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
  
                
                }//
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    if (!gridData.Rows[i].Hidden == true && gridData.Rows[i].IsFilteredOut==false)
                    {
                        gridData.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    gridData.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void frmDanhSachQuaTrinhDaoTao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {

                Save();

            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                ComboChanged();
            }
           
        }

       
    }
}