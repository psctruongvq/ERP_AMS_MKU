using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using ERP_Library.ThanhToan;


namespace PSC_ERP
{
    public partial class frmUyNhiemChi_HDDV_Edit : Form
    {
        private bool OK = false;
        private ERP_Library.ChungTuNganHang _data;
        private int OldMaTaiKhoan;
        private bool Loai;
        private ERP_Library.ChiTietChungTuNganHangList _ChiTietList;

        public frmUyNhiemChi_HDDV_Edit()
        {
            InitializeComponent();
        }

        public frmUyNhiemChi_HDDV_Edit(bool LoaiTruyen)
        {
            InitializeComponent();
            Loai = LoaiTruyen;
        
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            bdData.EndEdit();
            if (txtDienGiai.Text == "")
            {
                MessageBox.Show("Diễn giải không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTaiKhoan.Value == null || (int)cmbTaiKhoan.Value == 0)
            {
                MessageBox.Show("Ngân hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TinhLai();
            OK = true;
            this.Close();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            OK = false;
            this.Close();
        }

        public bool ShowEdit(ERP_Library.ChungTuNganHang data)
        {
            //Loại Chứng từ Dịch Vụ = 201 (tblLoaiChungTuGoc)
            //Nếu có thay đổi loại thì phải set thay đổi giá trị này - Thành (21/04/2012)
            data.LoaiChungTu = 201;
            //------------------------------------------
            _data = data;
            bdData.DataSource = _data;
            cmbTaiKhoan.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            cmb_LoaiTien.DataSource = LoaiTienList.GetLoaiTienList();
            _ChiTietList = ERP_Library.ChiTietChungTuNganHangList.GetChiTietChungTuNganHangList(_data.MaChungTu);
            bdChiTiet.DataSource = _ChiTietList;
            lblHoanTat.Visible = _data.HoanTat;
            btnDongY.Enabled = !_data.HoanTat;
            OldMaTaiKhoan = _data.MaNganHang;
            this.ShowDialog();
            return OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbTaiKhoan.Value == null || (int)cmbTaiKhoan.Value == 0)
            {
                MessageBox.Show("Ngân hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmUyNhiemChi_HDDV_ChuaDuyet f = new frmUyNhiemChi_HDDV_ChuaDuyet(Loai);
            f._chungtu = _data;
            _data.SoTien = 0;
            _data.SoDeNghi = 0;
            _data.DienGiai = string.Empty;

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (f._chungtu.DeNghi.Count != 0)
                {
                    _ChiTietList = _data.ChiTietChungTuList;
                    //Duyệt qua từng đề nghị một
                    foreach (ChungTuNganHang_DeNghi dn in f._chungtu.DeNghi)
                    {
                        if (dn.IsNew)
                        {
                            //Lấy chi tiết của từng đề nghị add vào danh sách
                            DeNghiChuyenKhoan denghi = DeNghiChuyenKhoan.GetDeNghiChuyenKhoan(dn.MaDeNghi);
                            foreach (DeNghiChuyenKhoan_DichVu i in denghi.DeNghiDichVuList)
                            {
                                ChiTietChungTuNganHang ct = _ChiTietList.AddNew();
                                ct.MaDeNghi = denghi.MaPhieu;
                                ct.SoDeNghi = denghi.So;
                                ct.SoTien = i.SoTien;
                                ct.LoaiTien = i.LoaiTien;
                                ct.TyGia = Convert.ToDecimal(LoaiTien.GetLoaiTien(i.LoaiTien).TiGiaQuyDoi);
                                _data.SoTien += (ct.SoTien * ct.TyGia);

                            }
                            if (_data.DienGiai != string.Empty)
                            {
                                _data.DienGiai += ", " + dn.LyDo;
                            }
                            else
                            {
                                _data.DienGiai += dn.LyDo;
                            }
                            _data.SoDeNghi++;
                        }
                    }
                    bdChiTiet.DataSource = _ChiTietList;
                }
            }
            else
            {
                TinhLai();
            }
        }

        private void TinhLai()
        {
            _data.SoTien = 0;
            _data.SoDeNghi=0;

            foreach (ChiTietChungTuNganHang dn in _data.ChiTietChungTuList)
            {
                _data.SoTien += (dn.SoTien * dn.TyGia);
            }
            foreach (ChungTuNganHang_DeNghi dn in _data.DeNghi)
            {
                _data.SoDeNghi ++;
            }  
        }
        

        private void btnDel_Click(object sender, EventArgs e)
        {
            grd_ChiTiet.DeleteSelectedRows();
            TinhLai();
        }

        private void grdChungTu_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa chuyển khoản đề nghị này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void CapNhatTong()
        {
            int sp = 0;
            decimal tong = 0;
            foreach (ERP_Library.ChungTuNganHang_DeNghi item in _data.DeNghi)
            {
                sp++;
                tong += item.SoTien;
            }
            _data.SoDeNghi = sp;
            _data.SoTien = tong;
        }

        private void frmChungTuNganHang_Edit_Load(object sender, EventArgs e)
        {
            foreach (ERP_Library.DatabaseNumberChild item in ERP_Library.DatabaseNumberList.GetDatabaseNumberList())
            {
                grdChungTu.DisplayLayout.ValueLists["DatabaseNumber"].ValueListItems.Add(item.DatabaseNumber, item.Ten);
            }
        }

        private void cmbTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTaiKhoan.SelectedRow != null)
            {
                txtNganHang.Text = ((ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild)cmbTaiKhoan.SelectedRow.ListObject).TenNganHang;
            }
            else
                txtNganHang.Text = "";
        }

        private void cmbTaiKhoan_Validating(object sender, CancelEventArgs e)
        {
            if (grdChungTu.Rows.Count > 0 && !cmbTaiKhoan.Value.Equals(OldMaTaiKhoan))
            {
                MessageBox.Show("Không thể thay đổi sau khi đã chọn chứng từ gốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            OldMaTaiKhoan = (int)cmbTaiKhoan.Value;
        }

        private void ultraButton_Export_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdChungTu);
        }

        private void grd_ChiTiet_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            string strSoDeNghi = string.Empty;
            int iMaDeNghi = 0;
            
            iMaDeNghi = Convert.ToInt32(grd_ChiTiet.Selected.Rows[0].Cells["MaDeNghi"].Value);
            strSoDeNghi = Convert.ToString(grd_ChiTiet.Selected.Rows[0].Cells["SoDeNghi"].Value);
            if (MessageBox.Show("Bạn có muốn xóa chuyển khoản đề nghị này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show(this, "Thao tác trên sẽ xóa toàn bộ thông tin liên quan đến chứng từ số  "+ strSoDeNghi + ". Bạn có chắc chắn muốn xóa?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < _data.DeNghi.Count; i++)
                    {
                        if (_data.DeNghi[i].MaDeNghi == iMaDeNghi)
                        {
                            _data.DeNghi.RemoveAt(i);
                            i--;
                        }
                    }
                    for (int i = 0; i < _data.ChiTietChungTuList.Count; i++)
                    {
                        if (_data.ChiTietChungTuList[i].MaDeNghi == iMaDeNghi)
                        {
                            _data.ChiTietChungTuList.RemoveAt(i);
                            i--;
                        }
                    }

                    bdChiTiet.DataSource = _data.ChiTietChungTuList;
                    e.Cancel = true;
                }
            }

        }

        private void grd_ChiTiet_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
             grd_ChiTiet.UpdateData();
            bdChiTiet.EndEdit();
            ChiTietChungTuNganHangList list = (ChiTietChungTuNganHangList)bdChiTiet.DataSource;
            _data.ChiTietChungTuList = list;
            TinhLai();
        }
    }
}