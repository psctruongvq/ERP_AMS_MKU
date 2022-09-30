using ERP_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmTheHienBaoTheoThongTu : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        ThongTuApDung1List _thongTuADList;
        byte _loaiBieuMau = 0;
        private int coppy = 0;
        internal DialogResult _checkOK;
        internal int _TT = 0;

        bool _isModify = false;
        #endregion Properties

        #region Constructors
        public frmTheHienBaoTheoThongTu()
        {
            InitializeComponent();
            _loaiBieuMau = 1;
            this.btnXem.Click += btnXem_Click;
            this.btnTaoMoi.Click += btnTaoMoi_Click;

            Ini();
        }
        public frmTheHienBaoTheoThongTu(byte copy)
        {
            InitializeComponent();
            coppy = copy;
            btnTaoMoi.Visible = false;
            btnXem.Text = "Sao chép";
            this.btnXem.Click += btnXem_Click;
            this.btnTaoMoi.Click += btnTaoMoi_Click;
            Ini();
        }
        public void ShowMauBangCDKT()
        {
            _loaiBieuMau = 1;
            Ini();
            this.Show();
        }
        public void ShowMauBangKQHDKD()
        {
            _loaiBieuMau = 2;
            Ini();
            this.Show();
        }
        public void ShowMauBaoCaoQuyetToanKinhPhiHoatDongB01BCQT()
        {
            _loaiBieuMau = 8;
            Ini();
            this.Show();
        }

        public void ShowMauBaoCaoLCTT()
        {
            _loaiBieuMau = 3;
            Ini();
            this.Show();
        }

        public void ShowThuyetMinhBCTC()
        {
            _loaiBieuMau = 10;
            Ini();
            this.Show();
        }
        #endregion Constructors

        void btnTaoMoi_Click(object sender, EventArgs e)
        {
            frmTaoMoiThongTuH _frmTaoMoiThongTuH = new frmTaoMoiThongTuH();
            _frmTaoMoiThongTuH.ShowDialog();
        }

        void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (coppy == 0)
                {
                    #region Old
                    //if (_loaiBieuMau == 8)
                    //{
                    //    frmCongThucMauBieuBaoCao _frm = new frmCongThucMauBieuBaoCao(Convert.ToInt32(lueThongTu.EditValue.ToString()), _loaiBieuMau);
                    //    _frm.ShowDialog();
                    //}
                    ////this.Close(); 
                    #endregion Old

                    #region Modify
                    frmDanhMucCongThucMauBieuBaoCao _frm = new frmDanhMucCongThucMauBieuBaoCao(_loaiBieuMau, Convert.ToInt32(lueThongTu.EditValue.ToString()));
                    _frm.WindowState = FormWindowState.Maximized;
                    _frm.ShowDialog();
                    #endregion Modify
                }
                else 
                {
                    _checkOK = MessageBox.Show(this, "Bạn có chắc chắn muốn copy thông tư này..!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (_checkOK == DialogResult.OK)
                    {
                        int _iD = Convert.ToInt32(lueThongTu.EditValue.ToString());
                        _TT = _iD;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void Ini()
        {
            _thongTuADList = ThongTuApDung1List.GetThongTuApDung1List();
            bs_ThongTuAD.DataSource = _thongTuADList;

            lueThongTu.EditValue = 1;
        }

        void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (coppy == 0)
                {
                    #region Old
                    //if (_loaiBieuMau == 8)
                    //{
                    //    frmCongThucMauBieuBaoCao _frmBangLCTT = new frmCongThucMauBieuBaoCao(Convert.ToInt32(lueThongTu.EditValue.ToString()), _loaiBieuMau);
                    //    _frmBangLCTT.Show();
                    //}
                    ////this.Close(); 
                    #endregion Old

                    #region Modify
                    frmDanhMucCongThucMauBieuBaoCao _frm = new frmDanhMucCongThucMauBieuBaoCao(_loaiBieuMau, Convert.ToInt32(lueThongTu.EditValue.ToString()));
                    _frm.WindowState = FormWindowState.Maximized;
                    _frm.ShowDialog();
                    #endregion Modify
                }
                else
                {
                    _checkOK = MessageBox.Show(this, "Bạn có chắc chắn muốn copy thông tư này..!!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (_checkOK == DialogResult.OK)
                    {
                        int _iD = Convert.ToInt32(lueThongTu.EditValue.ToString());
                        _TT = _iD;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXem_Click_1(object sender, EventArgs e)
        {

        }
     

    }
}
