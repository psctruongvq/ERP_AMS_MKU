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
    public partial class frmDanhSachPhanBoThuLaoTrongDai : Form
    {
        PhanBoThuLaoList _phanBoThuLaoList = PhanBoThuLaoList.NewPhanBoThuLaoList();

        int maPhanBoThuLao = 0;
        int xoaKetChuyen = 0;
        int userID = ERP_Library.Security.CurrentUser.Info.UserID;
        string _duLieu = "";
        public frmDanhSachPhanBoThuLaoTrongDai()
        {
            InitializeComponent();
            this.PhanBoThuLao_BindingSource.DataSource = typeof(PhanBoThuLaoList);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            DialogResult _DialogResult = MessageBox.Show("Bạn thật sự muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            dateTuNgay.Focus();
            PhanBoThuLao_BindingSource.EndEdit();
            //Duyệt qua tất cả các dòng dữ liệu trên lưới
            foreach (PhanBoThuLao item in _phanBoThuLaoList)
            {
                //Tiến hành cập nhật trạng thái duyệt
                CapNhatTrangThaiDuyet(item.MaPhanBoThuLao, item.MaGiayXacNhanChuongTrinh, item.NgayLap, item.DaDuyet);
            }

            MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CapNhatTrangThaiDuyet(long maPhanBoThuLao, long maChiTietPhanBoThuLao, DateTime ngayLap, Boolean daDuyet)
        {
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CapNhatTrangThaiDuyet_PhanBoThuLaoNhanVien";
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                    cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", maChiTietPhanBoThuLao);
                    cm.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cm.Parameters.AddWithValue("@DaDuyet", daDuyet);

                    cm.ExecuteNonQuery();
                }
            }//using
        }
        private bool KiemTraGiayPhanBoDaDuyetChua(long maPhanBoThuLao , long maChiTietPhanBoThuLao ,DateTime ngayLap)
        {
            Boolean kq = false;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraGiayPhanBoDaDuyetChua";
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                    cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", maChiTietPhanBoThuLao);
                    cm.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cm.Parameters.AddWithValue("@Bien", 1);
                    cm.Parameters.AddWithValue("@KetQua", kq);
                    cm.Parameters["@KetQua"].Direction = ParameterDirection.Output;

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

            else
            {
                DialogResult _DialogResult = MessageBox.Show("Bạn thật sự muốn xóa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (_DialogResult == DialogResult.Yes)
                {
                    maPhanBoThuLao = Convert.ToInt32(grdu_PhanBoThuLao.ActiveRow.Cells["MaPhanBoThuLao"].Value);
                    long maChiTietPhanBoThuLao = Convert.ToInt32(grdu_PhanBoThuLao.ActiveRow.Cells["MaGiayXacNhanChuongTrinh"].Value);
                    DateTime ngayLap = Convert.ToDateTime(grdu_PhanBoThuLao.ActiveRow.Cells["NgayLap"].Value);

                    if (KiemTraGiayPhanBoDaDuyetChua(maPhanBoThuLao,maChiTietPhanBoThuLao,ngayLap))
                    {
                        MessageBox.Show("Giấy phân bổ này đã duyệt không thể xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (maPhanBoThuLao != 0)
                    {
                        using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                        {
                            cn.Open();
                            using (SqlCommand cm = cn.CreateCommand())
                            {
                                cm.CommandType = CommandType.StoredProcedure;
                                cm.CommandText = "Spd_DeletetblnsPhanBoThuLaoChuongTrinhByMaPhanBoThuLao";
                                cm.Parameters.AddWithValue("@MaPhanBoThuLao", maPhanBoThuLao);
                                cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", maChiTietPhanBoThuLao);
                                cm.Parameters.AddWithValue("@NgayLap", ngayLap);

                                cm.ExecuteNonQuery();
                            }
                        }//using        
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        PhanBoThuLaoList phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoListByNgayLap(Convert.ToDateTime(dateTuNgay.Value), Convert.ToDateTime(dateDenNgay.Value), userID, 1);
                        PhanBoThuLao_BindingSource.DataSource = phanBoThuLaoList;
                    }
                }
            }
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
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDi"].Hidden = false;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["DaDuyet"].Hidden = false;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].EditorComponent = cmbu_ChuongTrinh;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDi"].EditorComponent = cmbu_BoPhan;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].CellActivation = Activation.NoEdit;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDi"].CellActivation = Activation.NoEdit;     
      
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Header.VisiblePosition = 0;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 1;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDi"].Header.VisiblePosition = 2;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 3;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.VisiblePosition = 4;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 5;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["DaDuyet"].Header.VisiblePosition = 6;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Header.Caption = "Mã Phân Bổ ";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Diễn Giải";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.Caption = "Chương Trình";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDi"].Header.Caption = "Bộ Phận";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["DaDuyet"].Header.Caption = "Duyệt";

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Width = 120;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Width = 150;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Width = 180;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 200;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 120;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaBoPhanDi"].Width = 150;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["DaDuyet"].Width = 80;

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
                    long maChiTietPhanBoThuLao = Convert.ToInt64(grdu_PhanBoThuLao.ActiveRow.Cells["MaGiayXacNhanChuongTrinh"].Value);
                    DateTime ngayLap = Convert.ToDateTime(grdu_PhanBoThuLao.ActiveRow.Cells["NgayLap"].Value);
                    Boolean  daDuyet = Convert.ToBoolean(grdu_PhanBoThuLao.ActiveRow.Cells["DaDuyet"].Value);

                    frmPhanBoThuLao_NhanVien f = new frmPhanBoThuLao_NhanVien(maPhanBoThuLao,maChiTietPhanBoThuLao, ngayLap, daDuyet);
                    f.ShowDialog(); 
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            _phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoListByNgayLap(Convert.ToDateTime(dateTuNgay.Value), Convert.ToDateTime(dateDenNgay.Value),userID,1);
            if (_phanBoThuLaoList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _phanBoThuLaoList = PhanBoThuLaoList.NewPhanBoThuLaoList();
            }
            this.PhanBoThuLao_BindingSource.DataSource = _phanBoThuLaoList;
            ChuongTrinh_BindingSource.DataSource = ChuongTrinhList.GetChuongTrinhList();
            BoPhan_BindingSource.DataSource = BoPhanList.GetBoPhanListBy_All();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {

        }
        private void check_TatCa_CheckedChanged(object sender, EventArgs e)
        {
             if (_duLieu.Trim().CompareTo("") != 0 && _duLieu.Trim().CompareTo("(NonBlanks)") !=0)
            {
                if (check_TatCa.Checked == true)
                {
                    for (int i = 0; i < grdu_PhanBoThuLao.Rows.Count; i++)
                    {
                        if (!grdu_PhanBoThuLao.Rows[i].Hidden == true && (grdu_PhanBoThuLao.Rows[i].Cells["TenChuongTrinh"].Value.ToString().Trim() ==_duLieu.Trim() || grdu_PhanBoThuLao.Rows[i].Cells["TenBoPhan"].Value.ToString().Trim() ==_duLieu.Trim() || grdu_PhanBoThuLao.Rows[i].Cells["MaPhanBoThuLaoQL"].Value.ToString().Trim() ==_duLieu.Trim() || grdu_PhanBoThuLao.Rows[i].Cells["DaDuyet"].Value.ToString().Trim() ==_duLieu.Trim() || grdu_PhanBoThuLao.Rows[i].Cells["NgayLap"].Value.ToString().Trim() ==_duLieu.Trim()))
                        {
                            grdu_PhanBoThuLao.Rows[i].Cells["DaDuyet"].Value = (object)true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdu_PhanBoThuLao.Rows.Count; i++)
                    {
                        grdu_PhanBoThuLao.Rows[i].Cells["DaDuyet"].Value = (object)false;
                    }
                }

                _duLieu = "";
            }
            else
            {

                if (check_TatCa.Checked == true)
                {
                    for (int i = 0; i < grdu_PhanBoThuLao.Rows.Count; i++)
                    {
                        if (!grdu_PhanBoThuLao.Rows[i].Hidden == true)
                        {
                            grdu_PhanBoThuLao.Rows[i].Cells["DaDuyet"].Value = (object)true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdu_PhanBoThuLao.Rows.Count; i++)
                    {
                        grdu_PhanBoThuLao.Rows[i].Cells["DaDuyet"].Value = (object)false;
                    }
                }
            }
        }

        private void grdu_PhanBoThuLao_FilterCellValueChanged(object sender, FilterCellValueChangedEventArgs e)
        {
            _duLieu = "";
            UltraGridFilterCell filterCell = e.FilterCell;
            EmbeddableEditorBase editor = filterCell.EditorResolved;

            if (filterCell.Value != null && editor.IsValid)
            {
                _duLieu = editor.Value.ToString();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_PhanBoThuLao);
        }


    }
}