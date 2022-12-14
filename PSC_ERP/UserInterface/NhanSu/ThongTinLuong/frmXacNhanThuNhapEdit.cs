using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmXacNhanThuNhapEdit : Form
    {
        private bool OK = false;
        private ERP_Library.XacNhanThuNhapList _list;
        private ERP_Library.XacNhanThuNhap _data;

        public frmXacNhanThuNhapEdit()
        {
            InitializeComponent();
            grdData.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(grdData_BeforeRowsDeleted);
        }

        void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa xác nhận Tháng lương này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            OK = false;
            this.Close();
        }

        private void frmXacNhanThuNhapEdit_Load(object sender, EventArgs e)
        {
            foreach (ERP_Library.KyTinhLuong item in ERP_Library.KyTinhLuongList.GetKyTinhLuongList())
                grdData.DisplayLayout.ValueLists["KyLuong"].ValueListItems.Add(item.MaKy, item.TenKy);
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
        }

        public void EditData(ERP_Library.XacNhanThuNhap Data, ERP_Library.XacNhanThuNhapList List)
        {
            _list = List;
            _data = Data;
            Data.BeginEdit();
            bdData.DataSource = Data;
            this.ShowDialog();
            if (OK)
            {
                try
                {
                    Data.ApplyEdit();
                    List.Save();
                }
                catch (Exception ex)
                {
                    frmThongBaoLoiDuLieu.ThongBaoLoi(ex, Data);
                }
            }
            else
                Data.CancelEdit();
        }

        public void NewData(ERP_Library.XacNhanThuNhapList List)
        {
            _list = List;
            ERP_Library.XacNhanThuNhap Data = List.AddNew();
            _data = Data;
            bdData.DataSource = Data;
            this.ShowDialog();
            if (OK)
            {
                try
                {
                    List.Save();
                }
                catch (Exception ex)
                {
                    frmThongBaoLoiDuLieu.ThongBaoLoi(ex, Data);
                }
            }
            else
                List.Remove(Data);
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            bdData.EndEdit();
            OK = true;
            if (!_data.IsValid)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(null, _data);
                return;
            }
            if (cmbNhanVien.Value != null && !KiemTraTrungNhanVien(Convert.ToInt64(cmbNhanVien.Value)))
                return;
            this.Close();
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.Value != null)
                cmbNhanVien.LoadDataByBoPhan((int)cmbBoPhan.Value);
            else
                cmbNhanVien.LoadData();
        }

        private bool KiemTraTrungNhanVien(long MaNhanVien)
        {
            bool hl = true;
            foreach (ERP_Library.XacNhanThuNhap item in _list)
                if (item != _data && item.MaNhanVien == MaNhanVien && !item.DaThanhLy)
                {
                    hl = false;
                    break;
                }
            if (!hl)
                return MessageBox.Show("Nhân viên này đã có xác nhận rồi. Bạn có muốn tiếp tục không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
            else
                return true;

        }

        private void cmbNhanVien_Validating(object sender, CancelEventArgs e)
        {
            if (cmbNhanVien.Value != null)
                e.Cancel = !KiemTraTrungNhanVien(Convert.ToInt64(cmbNhanVien.Value));
        }
    }
}