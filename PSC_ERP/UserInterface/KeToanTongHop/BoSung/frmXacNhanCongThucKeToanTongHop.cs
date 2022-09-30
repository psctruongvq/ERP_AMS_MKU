using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmXacNhanCongThucKeToanTongHop : Form
    {
        #region Properties
        private int _maCongThuc = 0;
        private byte _loai = 0;//1: Mẫu Bảng Cân Đối Kế Toán; 2: Báo cáo kết quả hoạt động Kinh doanh; 3: Báo cáo lưu chuyển tiền tệ; 4:  Mau Bao Cáo KQHDKD Chi Tiết; 5: Mẫu báo cáo ước tính doanh thu chi phí; 6: Chi phí HĐ đề nghị quyết toán
        private bool _isCopy = false;

        public bool XacNhan = false;

        public int MaCongThuc
        { get { return _maCongThuc; } }
        #endregion//Properties

        CongThucApDungKeToanTongHopRootList _CongThucApDungCongThucTongHopList = CongThucApDungKeToanTongHopRootList.NewCongThucApDungKeToanTongHopRootList();
        CongThucApDungKeToanTongHop _Congthuc = CongThucApDungKeToanTongHop.NewCongThucApDungKeToanTongHop();

        #region Contructors

        public frmXacNhanCongThucKeToanTongHop()
        {
            InitializeComponent();
            //KhoiTao();
        }

        public frmXacNhanCongThucKeToanTongHop(bool isCopy,byte loaimaubaocao)
        {
            InitializeComponent();
            _isCopy = isCopy;
            _loai = loaimaubaocao;
            FormatForm();
            KhoiTao();
        }

        public void ShowCongThucMauBangBaoCaoCanDoiKeToan()
        {
            _loai = 1;
            this.Text = "Công Thức Áp Dụng Cho Mẫu Bảng Cân Đối Kế Toán";
            KhoiTao();
            this.Show();
        }

        public void ShowCongThucMauBangBaoCaoKQHDKD()
        {
            _loai = 2;
            this.Text = "Công Thức Áp Dụng Cho Mẫu Bảng Báo Cáo KQHĐKD";
            KhoiTao();
            this.Show();
        }
        public void ShowCongThucMauBangBaoCaoLuuChuyenTienTe()
        {
            _loai = 3;
            this.Text = "Công Thức Áp Dụng Cho Mẫu Bảng Báo Cáo Lưu Chuyển Tiền Tệ";
            KhoiTao();
            this.Show();
        }
        public void ShowCongThucMauBangBaoCaoCTKQHDKD()
        {
            _loai = 4;
            this.Text = "Công Thức Áp Dụng Cho Mẫu Bảng Báo Cáo Chi Tiết KQHĐKD";
            KhoiTao();
            this.Show();
        }
        public void ShowCongThucMauBangBaoCaoUocTinhDoanhThuChiPhi()
        {
            _loai = 5;
            this.Text = "Công Thức Áp Dụng Cho Mẫu Bảng Báo Cáo Ước Tính Doanh Thu Chi Phí";
            KhoiTao();
            this.Show();
        }
        public void ShowCongThucMauBangBaoCaoChiPhiHDDeNghiThanhToan()
        {
            _loai = 6;
            this.Text = "Công Thức Áp Dụng Cho Mẫu Bảng Báo Cáo Chi Phí HĐ Đề Nghị Thanh Toán";
            KhoiTao();
            this.Show();
        }

        #endregion 

        #region Khởi Tạo
        private void KhoiTao()
        {
            _CongThucApDungCongThucTongHopList = CongThucApDungKeToanTongHopRootList.GetCongThucApDungKeToanTongHopRootListByLoaiMauBaoCao(_loai);
            CongThucApDungKeToanTongHop congthuc = CongThucApDungKeToanTongHop.NewCongThucApDungKeToanTongHop("Công thức cũ");
            _CongThucApDungCongThucTongHopList.Insert(0, congthuc);
            CongThucApDungKeToanTongHopbindingSource.DataSource = _CongThucApDungCongThucTongHopList; 
        }
        #endregion

        #region Functions
        private bool GetThongTin()
        {
            int macongthucOut=0;
                if(!int.TryParse(cmbu_CongThucApDungKeToanTongHop.Value.ToString(),out macongthucOut))
                {
                    MessageBox.Show("Vui lòng chọn Công thức để thực hiện", "Yêu Cầu");
                    return false;
                }
                else
                {
                    _maCongThuc = macongthucOut;
                }
                return true;
        }

        private void FormatForm()
        {
            if (_isCopy)
            {
                btnXem.Text = "Sao chép theo công thức này";
            }
            else
            {
                btnXem.Text = "Xem Mẫu";
            }
        }
        #endregion //Functions


        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
           
        }
        #endregion 

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 



        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
        }
        #endregion 

        private void cmbu_CongThucApDungKeToanTongHop_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_CongThucApDungKeToanTongHop, "NoiDung");
            foreach (UltraGridColumn col in this.cmbu_CongThucApDungKeToanTongHop.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_CongThucApDungKeToanTongHop.DisplayLayout.Bands[0].Columns["NoiDung"].Hidden = false;
            cmbu_CongThucApDungKeToanTongHop.DisplayLayout.Bands[0].Columns["NoiDung"].Header.Caption = "Nội dung";
            cmbu_CongThucApDungKeToanTongHop.DisplayLayout.Bands[0].Columns["NoiDung"].Header.VisiblePosition = 0;
            cmbu_CongThucApDungKeToanTongHop.DisplayLayout.Bands[0].Columns["NoiDung"].Width = cmbu_CongThucApDungKeToanTongHop.Width;
            cmbu_CongThucApDungKeToanTongHop.DisplayLayout.Bands[0].Columns["LoaiString"].Hidden = false;
            cmbu_CongThucApDungKeToanTongHop.DisplayLayout.Bands[0].Columns["LoaiString"].Header.Caption = "Thuộc Báo cáo";
            cmbu_CongThucApDungKeToanTongHop.DisplayLayout.Bands[0].Columns["LoaiString"].Header.VisiblePosition = 1;
            cmbu_CongThucApDungKeToanTongHop.DisplayLayout.Bands[0].Columns["NgayApDung"].Hidden = false;
            cmbu_CongThucApDungKeToanTongHop.DisplayLayout.Bands[0].Columns["NgayApDung"].Header.Caption = "Ngày áp dụng";
            cmbu_CongThucApDungKeToanTongHop.DisplayLayout.Bands[0].Columns["NgayApDung"].Header.VisiblePosition = 2;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (GetThongTin())
            {
                //_Congthuc = CongThucApDungKeToanTongHop.GetCongThucApDungKeToanTongHop(_maCongThuc);
                //_loai = _Congthuc.Loai;
            }
            else return;
            if (!_isCopy)
            {
                if (_loai == 2)//Báo cáo kết quả hoạt động Kinh doanh
                {
                    frmMauBCKQHoatDongKinhDoanh_theoCongThuc frm = new frmMauBCKQHoatDongKinhDoanh_theoCongThuc(_maCongThuc);
                    frm.Show();
                }
                else if (_loai == 4)//Mau Bao Cáo KQHDKD Chi Tiết
                {
                    frmMauCTBCKQHoatDongKinhDoanh_theoCongThuc frm = new frmMauCTBCKQHoatDongKinhDoanh_theoCongThuc(_maCongThuc);
                    frm.Show();
                }
            }
            else
            {
                this.Close();
                XacNhan = true;
            }
        }


      

    }
}