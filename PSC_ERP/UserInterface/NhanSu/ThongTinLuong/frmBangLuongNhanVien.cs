using ERP_Library.Security;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmBangLuongNhanVien : Form
    {
        int userID = CurrentUser.Info.UserID;
        public frmBangLuongNhanVien()
        {
            InitializeComponent();
        }

        private void frmBangLuongNhanVien_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            boPhanListBindingSource.DataSource = ERP_Library.BoPhanList.GetBoPhanListAll(userID);
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbBoPhan.Value = 0;
            txtNgayThamNien.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                ERP_Library.KyTinhLuong i = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
                if (i.KhoaSoKy1)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên không thể tính lại bảng lương", "Tính lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn thực hiện tính lương cho tất cả nhân viên không?", "Tính lương", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    i.KhoaSoKy1 = true;
                    i.Save();
                    ERP_Library.TinhLuongNhanVien t = new ERP_Library.TinhLuongNhanVien(i);
                    long MaNhanVien = 0;
                    int MaBoPhan = (int)cmbBoPhan.Value;                    

                    if (cmbNhanVien.Value != null) MaNhanVien = (long)cmbNhanVien.Value;
                    
                    t.GetListData(MaBoPhan, MaNhanVien,0);
                    t._NgayTinhThamNien = txtNgayThamNien.DateTime;
                    frmWaitProcess.Wait(TinhLuongDot1, t);
                }
            }
        }

        private void TinhLuongDot1(object sender, DoWorkEventArgs e)
        {
            //chú ý đang chạy trên thread khác, chỉ sử dụng các biến sender, e

            ERP_Library.TinhLuongNhanVien t = e.Argument as ERP_Library.TinhLuongNhanVien;
            t.Begin();
            t.XoaDuLieuCu_TinhLuongKy1();
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
                    t.TinhLuongDot1(t.List[i]);
                    worker.ReportProgress(i * 100 / t.List.Count);
                }
            }
            t.CapNhatNganHangLuongDot1();
           
            //
            //t.TinhThueTNCNKy1();
            
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

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                ERP_Library.KyTinhLuong i = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
                txtTuNgay.Value = i.NgayBatDau.ToString("dd/MM/yyyy");
                txtDenNgay.Value = i.NgayKetThuc.ToString("dd/MM/yyyy");
                dtNgayBDTinh.Value = i.NgayBatDau;
                dtNgayKTTinh.Value = i.NgayKetThuc;
            }
            else
            {
                txtTuNgay.Value = "";
                txtDenNgay.Value = "";
            }
        }

        private void btnTinhLuongDot2_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                ERP_Library.KyTinhLuong i = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
                if (i.KhoaSoKy2)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên không thể tính lại bảng lương", "Tính lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
               
                if (MessageBox.Show("Bạn có muốn thực hiện tính lương cho tất cả nhân viên không?", "Tính lương", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                 
                    ERP_Library.TinhLuongNhanVien t = new ERP_Library.TinhLuongNhanVien(i);
                    t.NgayBDTinhLuong = dtNgayBDTinh.Value;
                    t.NgayKTTinhLuong = dtNgayKTTinh.Value;
                    long MaNhanVien = 0;
                    int MaBoPhan = (int)cmbBoPhan.Value;
                   
                    
                    if (cmbNhanVien.Value != null) MaNhanVien = (long)cmbNhanVien.Value;
                    
                    
                    t.GetListData(MaBoPhan, MaNhanVien,0);
                    t._NgayTinhThamNien = txtNgayThamNien.DateTime;

                    frmWaitProcess.Wait(TinhLuongDot2, t);
                }
            }

        }

        private void TinhLuongDot2(object sender, DoWorkEventArgs e)
        {
            //chú ý đang chạy trên thread khác, chỉ sử dụng các biến sender, e

            ERP_Library.TinhLuongNhanVien t = e.Argument as ERP_Library.TinhLuongNhanVien;
            t.Loai = 0;
            t.Begin();
            t.XoaDuLieuCu_TinhLuongKy2();
            
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
                    t.TinhLuongDot2(t.List[i]);
                    worker.ReportProgress(i * 100 / t.List.Count);
                }
            }
            t.TinhTongThuNhapKy2();
            t.End();
        }

   }
}