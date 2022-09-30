using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmXacNhanThongTuMauBaoCao : Form
    {


        ThoiDiemApDungThongTuMauKeToanTongHopList _ThoiDiemApDungThongTuMauKeToanTongHopList;
        Util util = new Util();

        private byte _loaiBieuMau = 0;//1 Mẫu Can Doi Ke Toan; 2 KQHDKD; 3 Luu Chuyen Tien Te; 4 Muc TM Bao Cao Tai Chinh; 5 Thuyet Minh Bao Cao Tai Chinh; 6 TMBCTC-Von Chu So Hua
        private byte _thuocLoai = 0;//0 Thong Tu; 1 NHNN
        private int _maThongTu = 0;
        private string _noiDungThongTu = string.Empty;
        private bool _isCopyBieuMau = false;

        public int MaThongTu
        { get { return _maThongTu; } }

        public frmXacNhanThongTuMauBaoCao()
        {
            InitializeComponent();
            KhoiTao();

        }

        public frmXacNhanThongTuMauBaoCao(byte loaiBieuMau)
        {
            InitializeComponent();
            _loaiBieuMau = loaiBieuMau;
            KhoiTao();

        }

        public frmXacNhanThongTuMauBaoCao(bool isCopyBieuMau)
        {
            InitializeComponent();
            _isCopyBieuMau = isCopyBieuMau;
            groupBox1.Visible = false;
            btnOK.Text = "Sao chép";
            KhoiTao();

        }


        #region KhoiTao()
        private void KhoiTao()
        {
            _ThoiDiemApDungThongTuMauKeToanTongHopList = ThoiDiemApDungThongTuMauKeToanTongHopList.GetThoiDiemApDungThongTuMauKeToanTongHopList();
            if (_isCopyBieuMau)
            {
                ThoiDiemApDungThongTuMauKeToanTongHop thongtu = ThoiDiemApDungThongTuMauKeToanTongHop.NewThoiDiemApDungThongTuMauKeToanTongHop("Thông tư cũ(trước ngày 01/03/2015)");
                _ThoiDiemApDungThongTuMauKeToanTongHopList.Add(thongtu);
            }
            ThoiDiemApDungMauKeToanTongHopbindingSource.DataSource = _ThoiDiemApDungThongTuMauKeToanTongHopList;

        }

        public void ShowMauBangCanDoiKeToan()
        {
            _loaiBieuMau = 1;
            KhoiTao();
            this.Show();
        }

        public void ShowMauBangKQHDKD()
        {
            _loaiBieuMau = 2;
            KhoiTao();
            this.Show();
        }

        public void ShowMauBangLuuChuyenTienTe()
        {
            _loaiBieuMau = 3;
            KhoiTao();
            this.Show();
        }

        public void ShowMucThuyetMinhBCTC()
        {
            _loaiBieuMau = 4;
            KhoiTao();
            this.Show();
        }

        public void ShowThuyetMinhBCTC()
        {
            _loaiBieuMau = 5;
            KhoiTao();
            this.Show();
        }

        public void ShowThuyetMinhBCTCNguonVonChuSoHuu()
        {
            _loaiBieuMau = 6;
            KhoiTao();
            this.Show();
        }

        #endregion
        private void ReLoadData()
        {
            _ThoiDiemApDungThongTuMauKeToanTongHopList = ThoiDiemApDungThongTuMauKeToanTongHopList.GetThoiDiemApDungThongTuMauKeToanTongHopList();
            if (_isCopyBieuMau)
            {
                ThoiDiemApDungThongTuMauKeToanTongHop thongtu = ThoiDiemApDungThongTuMauKeToanTongHop.NewThoiDiemApDungThongTuMauKeToanTongHop("Thông tư cũ(trước ngày 01/03/2015)");
                _ThoiDiemApDungThongTuMauKeToanTongHopList.Add(thongtu);
            }
            ThoiDiemApDungMauKeToanTongHopbindingSource.DataSource = _ThoiDiemApDungThongTuMauKeToanTongHopList;
        }



        private void cbu_ThoiDiemApDungMauKeToanTongHop_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.Hidden = true;
            }

            cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Bands[0].Columns["NoiDung"].Hidden = false;
            cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Bands[0].Columns["NoiDung"].Header.Caption = "Nội dung";
            cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Bands[0].Columns["NoiDung"].Width = 200;
            cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Bands[0].Columns["NoiDung"].Header.VisiblePosition = 1;
            cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Bands[0].Columns["NgayApDung"].Hidden = false;
            cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Bands[0].Columns["NgayApDung"].Header.Caption = "Ngày áp dụng";
            cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Bands[0].Columns["NgayApDung"].Width = 100;
            cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Bands[0].Columns["NgayApDung"].Header.VisiblePosition = 2;
            //this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool hople = true;
            if (cbu_ThoiDiemApDungMauKeToanTongHop.Value != null)
            {
                int mathongtuOut = 0;
                if (int.TryParse(cbu_ThoiDiemApDungMauKeToanTongHop.Value.ToString(), out mathongtuOut))
                {
                    _maThongTu = mathongtuOut;
                    if (radioBtnThongTu.Checked == true)
                    {
                        _thuocLoai = 0;
                    }
                    else if (radioBtnNHNN.Checked == true)
                    {
                        _thuocLoai = 1;
                    }
                }
                else
                {
                    hople = false;
                }
            }
            else
            {
                hople = false;
            }

            if (hople)
            {
                if (_isCopyBieuMau == false)
                {
                    _noiDungThongTu = ThoiDiemApDungThongTuMauKeToanTongHop.GetThoiDiemApDungThongTuMauKeToanTongHop(_maThongTu).NoiDung;
                    if (_loaiBieuMau == 1)
                    {
                        frmMauBangCanDoiKeToan frm = new frmMauBangCanDoiKeToan(_loaiBieuMau, _thuocLoai, _maThongTu, _noiDungThongTu);
                        frm.Show();
                    }
                    else if (_loaiBieuMau == 2)
                    {
                        frmMauBCKQHoatDongKinhDoanh frm = new frmMauBCKQHoatDongKinhDoanh(_loaiBieuMau, _thuocLoai, _maThongTu, _noiDungThongTu);
                        frm.Show();
                    }
                    else if (_loaiBieuMau == 3)
                    {
                        frmMauBaoCaoLuuChuyenTienTe frm = new frmMauBaoCaoLuuChuyenTienTe(_loaiBieuMau, _thuocLoai, _maThongTu, _noiDungThongTu);
                        frm.Show();
                    }
                    else if (_loaiBieuMau == 4)
                    {
                        frmMucTMBCTaiChinh frm = new frmMucTMBCTaiChinh(_thuocLoai, _maThongTu, _noiDungThongTu);
                        frm.Show();
                    }
                    else if (_loaiBieuMau == 5)
                    {
                        frmMauTMBCTaiChinh frm = new frmMauTMBCTaiChinh(_thuocLoai, _maThongTu, _noiDungThongTu);
                        frm.Show();
                    }
                    else if (_loaiBieuMau == 6)
                    {
                        Form frm;
                        //if (_thuocLoai == 1)
                        //    frm = new frmMauTMBCTC_VonChuSoHuu_NHNN(_thuocLoai, _maThongTu, _noiDungThongTu);
                        //else
                            frm = new frmMauTMBCTC_VonChuSoHuu_ThongTu(_thuocLoai, _maThongTu, _noiDungThongTu);
                        frm.Show();
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tư cần xử lý", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}