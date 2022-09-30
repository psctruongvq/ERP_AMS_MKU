using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using PSC_ERP.UserInterface.NhanSu.Thu_Lao;
using Infragistics.Win;
using System.Data.SqlClient;
namespace PSC_ERP
{
    public partial class frmDanhSachNhapPhanBoThuLao : Form
    {
        PhanBoThuLaoList _phanBoThuLaoList = PhanBoThuLaoList.NewPhanBoThuLaoList();
        int maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;

        public frmDanhSachNhapPhanBoThuLao()
        {
            InitializeComponent();

        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            DialogResult _DialogResult = MessageBox.Show("Bạn thật sự muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public int KiemTraPhanBoThuLao(int maPhanBoThuLao)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraPhanBoThuLaoByMaPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                    cm.Parameters.AddWithValue("@GiaTri", gt);
                    cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    gt = Convert.ToInt32(cm.Parameters["@GiaTri"].Value);
                }
            }//using
            return gt;


        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {           
                _phanBoThuLaoList.ApplyEdit();
                PhanBoThuLao_BindingSource.EndEdit();
                _phanBoThuLaoList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw;
            }
                      
        }
        public bool KiemTraKetChuyenThuLao(int maPhanBo)
        {
            Boolean kq = false;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraKetChuyenThuLaoChuongTrinh";
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBo);
                    cm.Parameters.AddWithValue("@Bien", 1);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@KetQua", SqlDbType.Bit, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);

                    cm.ExecuteNonQuery();
                    kq = Convert.ToBoolean(cm.Parameters["@KetQua"].Value);
                }
            }//using
            return kq;
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_PhanBoThuLao.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTraPhanBoThuLao(Convert.ToInt32(grdu_PhanBoThuLao.ActiveRow.Cells["MaPhanBoThuLao"].Value)) == 1)
            {
                MessageBox.Show("Mã chi tiết đã phân bổ không thể xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            grdu_PhanBoThuLao.DeleteSelectedRows();
        }



        private void grdu_PhanBoThuLao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Hidden = false;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Hidden = false;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaGiayXacNhanChuongTrinh"].Hidden = false;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].EditorComponent = cmbu_ChuongTrinh;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaGiayXacNhanChuongTrinh"].EditorComponent = cmbu_GiayXacNhan;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].CellActivation = Activation.NoEdit;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaGiayXacNhanChuongTrinh"].CellActivation = Activation.NoEdit;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 3;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Header.VisiblePosition = 0;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 1;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 5;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.VisiblePosition = 4;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaGiayXacNhanChuongTrinh"].Header.VisiblePosition = 2;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Header.Caption = "Mã Phân Bổ ";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Diễn Giải";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.Caption = "Chương Trình";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaGiayXacNhanChuongTrinh"].Header.Caption = "Giấy Xác Nhận";

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Width = 160;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Width = 150;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Width = 180;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaGiayXacNhanChuongTrinh"].Width = 150;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 180;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 120;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';
        
        }

        private void grdu_PhanBoThuLao_DoubleClick(object sender, EventArgs e)
        {
            if (grdu_PhanBoThuLao.ActiveRow != null)
            {
                if (grdu_PhanBoThuLao.ActiveRow.IsFilterRow != true)
                {
                    int maPhanBoThuLao = Convert.ToInt32(grdu_PhanBoThuLao.ActiveRow.Cells["MaPhanBoThuLao"].Value);
                    frmPhanBoThuLao f = new frmPhanBoThuLao(maPhanBoThuLao);
                    f.ShowDialog();        
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            _phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoListByNgayLap_MaPhanBoThuLao(Convert.ToDateTime(dateTuNgay.Value), Convert.ToDateTime(dateDenNgay.Value),maBoPhan);
            if (_phanBoThuLaoList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _phanBoThuLaoList = PhanBoThuLaoList.NewPhanBoThuLaoList();
            }
            this.PhanBoThuLao_BindingSource.DataSource = _phanBoThuLaoList;
            ChuongTrinh_BindingSource.DataSource = ChuongTrinhList.GetChuongTrinhList() ;
            GiayXacNhan_bindingSource.DataSource = GiayXacNhanTongHopList.GetGiayXacNhanTongHopList(maBoPhan);
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {

        }


    }
}