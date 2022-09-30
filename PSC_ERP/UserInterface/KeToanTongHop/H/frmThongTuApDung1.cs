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
    public partial class frmThongTuApDung1 : DevExpress.XtraEditors.XtraForm
    {
        ThongTuApDung1List _thongTuADList;
        int _loaiBieuMau = 0;
        private int coppy = 0;
        internal DialogResult _checkOK;
        internal int _TT = 0;
        public frmThongTuApDung1()
        {
            InitializeComponent();
            _loaiBieuMau = 1;
            this.btnXem.Click += btnXem_Click;
            this.btnTaoMoi.Click += btnTaoMoi_Click;
            
            Ini();
        }

        void btnTaoMoi_Click(object sender, EventArgs e)
        {
            frmTaoMoiThongTuH _frmTaoMoiThongTuH = new frmTaoMoiThongTuH();
            _frmTaoMoiThongTuH.ShowDialog();
        }
        public void ShowMauBangCDKT()
        {
            _loaiBieuMau = 1;
            Ini();
            this.Show();
        }
        public frmThongTuApDung1(byte copy)
        {
            InitializeComponent();
            coppy = copy;
            btnTaoMoi.Visible = false;
            btnXem.Text = "Sao chép";
            this.btnXem.Click += btnXem_Click;
            this.btnTaoMoi.Click += btnTaoMoi_Click;
            Ini();
        }
        public void ShowMauBangKQHDKD()
        {
            _loaiBieuMau = 2;
            Ini();
            this.Show();
        }
        public void ShowMauBaoCaoLCTT()
        {
            _loaiBieuMau = 3;
            Ini();
            this.Show();
        }

        void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (coppy == 0)
                {
                    if (_loaiBieuMau == 1)
                    {
                        //frmBangCanDoiKeToanChoThongTu _frmBangCanDoiKeToanChoThongTu = new frmBangCanDoiKeToanChoThongTu(Convert.ToInt32(lueThongTu.EditValue.ToString()));
                        //_frmBangCanDoiKeToanChoThongTu.Show();
                        frmCongThucBangCanDoiKeToan _frmBangCanDoiKeToanChoThongTu = new frmCongThucBangCanDoiKeToan(Convert.ToInt32(lueThongTu.EditValue.ToString()));
                        //_frmBangCanDoiKeToanChoThongTu.ShowDialog();
                        _frmBangCanDoiKeToanChoThongTu.Show();
                    }
                    else if (_loaiBieuMau == 2)
                    {
                        //frmBangKQHDKD _frmBangKQHDKD = new frmBangKQHDKD(Convert.ToInt32(lueThongTu.EditValue.ToString()), _loaiBieuMau);
                        //_frmBangKQHDKD.ShowDialog();
                        frmCongThucBangKQHDKD _frmBangKQHDKD = new frmCongThucBangKQHDKD(Convert.ToInt32(lueThongTu.EditValue.ToString()), _loaiBieuMau);
                        //_frmBangKQHDKD.ShowDialog();
                        _frmBangKQHDKD.Show();
                    }
                    else if (_loaiBieuMau == 3)
                    {
                        //frmBangLCTT _frmBangLCTT = new frmBangLCTT(Convert.ToInt32(lueThongTu.EditValue.ToString()), _loaiBieuMau);
                        //_frmBangLCTT.ShowDialog();
                        frmCongThucBangLCTT _frmBangLCTT = new frmCongThucBangLCTT(Convert.ToInt32(lueThongTu.EditValue.ToString()), _loaiBieuMau);
                        //_frmBangLCTT.ShowDialog();
                        _frmBangLCTT.Show();
                    }
                    //this.Close();
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
                    if (_loaiBieuMau == 1)
                    {
                        frmBangCanDoiKeToanChoThongTu _frmBangCanDoiKeToanChoThongTu = new frmBangCanDoiKeToanChoThongTu(Convert.ToInt32(lueThongTu.EditValue.ToString()));
                        _frmBangCanDoiKeToanChoThongTu.Show();                  
                    }
                    else if (_loaiBieuMau == 2)
                    {
                        frmBangKQHDKD _frmBangKQHDKD = new frmBangKQHDKD(Convert.ToInt32(lueThongTu.EditValue.ToString()), _loaiBieuMau);
                        _frmBangKQHDKD.Show();
                    }
                    else if (_loaiBieuMau == 3)
                    {
                        frmBangLCTT _frmBangLCTT = new frmBangLCTT(Convert.ToInt32(lueThongTu.EditValue.ToString()), _loaiBieuMau);
                        _frmBangLCTT.Show();
                    }
                    //this.Close();
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
