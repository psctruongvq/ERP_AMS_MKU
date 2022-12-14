using ERP_Library.Security;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmTinhPhuCap : Form
    {
        int userID = CurrentUser.Info.UserID;
        public frmTinhPhuCap()
        {
            InitializeComponent();
        }

        private void frmTinhPhuCap_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            cmbKyPC.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            boPhanListBindingSource.DataSource = ERP_Library.BoPhanList.GetBoPhanListAll(userID);
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbBoPhan.Value = 0;
            foreach (ERP_Library.NhomPhuCap item in ERP_Library.NhomPhuCapList.GetNhomPhuCapList())
                cmbPhuCap.Items.Add(item.MaNhom, item.Ten);

            txtNgayThamNien.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);
            cmbPhuCap.Value = 0;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTinhPhuCap_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                ERP_Library.KyTinhLuong i = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
                if (i.KhoaSoKy2)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên không thể tính lại phụ cấp", "Tính lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cmbKyPC.SelectedItem == null)
                {
                    MessageBox.Show("Bạn chưa chọn kỳ tính phụ cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Bạn có muốn thực hiện tính phụ cấp cho tất cả nhân viên không?", "Tính lương", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ERP_Library.TinhPhuCapNhanVien t = new ERP_Library.TinhPhuCapNhanVien(i, (ERP_Library.KyTinhLuong)cmbKyPC.SelectedItem.ListObject, (int)cmbPhuCap.Value, (int)cmbLoaiPC.Value);

                    if (cmbNhanVien.Value == null)
                        t.GetListData((int)cmbBoPhan.Value, 0);
                    else
                        t.GetListData((int)cmbBoPhan.Value, (long)cmbNhanVien.Value);
                    frmWaitProcess.Wait(TinhPhuCap, t);
                  //  t.CapNhatThanhToanChoPhuCap(i,(ERP_Library.KyTinhLuong)cmbKyPC.SelectedItem.ListObject, (int)cmbLoaiPC.Value);
                  
                }
            }
        }

        private void TinhPhuCap(object sender, DoWorkEventArgs e)
        {
            //chú ý đang chạy trên thread khác, chỉ sử dụng các biến sender, e
            
            //đổi định dạng english để sử dụng công thức dấu có dấu . thập phân
            
            System.Globalization.CultureInfo cul = new System.Globalization.CultureInfo("en-US");
            cul.NumberFormat.NumberDecimalSeparator = ".";
            cul.NumberFormat.NumberGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture = cul;

            ERP_Library.TinhPhuCapNhanVien t = e.Argument as ERP_Library.TinhPhuCapNhanVien;
            t.Begin();
            t.XoaDuLieuCu();
            t.CapNhatTinhTrangChamNgoaiGio();
            t._NgayTinhThamNien = txtNgayThamNien.DateTime;
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < t.List.Count; i++)
            {
                if (worker.CancellationPending)
                {
                    t.Cancel();
                    e.Cancel = true;
                    return;
                }
                else
                {
                    t.TinhPhuCap(t.List[i]);
                    worker.ReportProgress(i * 100 / t.List.Count);
                }
            }
            t.End();
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.Value == null)
                cmbNhanVien.LoadDataByBoPhan(0);
            else
                cmbNhanVien.LoadDataByBoPhan((int)cmbBoPhan.Value);
            cmbNhanVien.Value = null;
        }

        private void cmbPhuCap_ValueChanged(object sender, EventArgs e)
        {
            if (cmbPhuCap.Value != null)
            {
                cmbLoaiPC.Items.Clear();
                cmbLoaiPC.Items.Add(0, "Tất cả");
                foreach (ERP_Library.LoaiPhuCapChild item in ERP_Library.LoaiPhuCapList.GetLoaiPhuCapByMaNhom((int)cmbPhuCap.Value))
                {
                    cmbLoaiPC.Items.Add(item.MaLoaiPhuCap, item.TenLoaiPhuCap);
                }
                cmbLoaiPC.Value = 0;
            }
        }
   }
}