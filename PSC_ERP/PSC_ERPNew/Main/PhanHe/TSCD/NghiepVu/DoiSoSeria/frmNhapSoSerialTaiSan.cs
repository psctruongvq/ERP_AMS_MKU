using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using System.Linq;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main.Predefined;

namespace PSC_ERPNew.Main
{
    public partial class frmNhapSoSerialTaiSan : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmNhapSoSerialTaiSan singleton_ = null;
        public static frmNhapSoSerialTaiSan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmNhapSoSerialTaiSan();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner);
        }

        #endregion


        //Private Member field
        #region Private Member field
        tblTaiSanCoDinhCaBiet _taiSanCoDinhCaBiet = null;
        Boolean _dongY = false;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmNhapSoSerialTaiSan()
        {
            InitializeComponent();
        }

        public frmNhapSoSerialTaiSan(tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet)
        {
            InitializeComponent();
            _taiSanCoDinhCaBiet = taiSanCoDinhCaBiet;

            //groupControl1.Text = "Số Serial Tài Sản: " + _taiSanCoDinhCaBiet.tblDanhMucTSCD.Ten.ToString() + " - Model " + _taiSanCoDinhCaBiet.tblDanhMucTSCD.ModelTSCD.ToString();
        }
        #endregion

        //Event Method
        #region Event Method

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion
        private void frmBoPhanNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlack.Focus();
        }

        private void frmNhapSoSerialTaiSan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_dongY)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void btn_DongY_Click(object sender, EventArgs e)
        {
            if (txt_Seria_Moi.Text.Trim() == "")
            {
                DialogUtil.ShowWarning("Bạn Chưa Nhập Số Serial Mới \nVui lòng nhập số serial mới");
                txt_Seria_Moi.Focus();
            }
            else
            {
                _dongY = true;
                this.Close();
            }
        }

        private void btn_HuyBo_Click(object sender, EventArgs e)
        {
            _dongY = false;
            this.Close();
        }

        private void frmNhapSoSerialTaiSan_Load(object sender, EventArgs e)
        {
            txt_Seria_Cu.Text = _taiSanCoDinhCaBiet.Serial;
            groupControl1.Text = "Số Serial Tài Sản: " + _taiSanCoDinhCaBiet.tblDanhMucTSCD.Ten.ToString();// +" - Model " + _taiSanCoDinhCaBiet.tblDanhMucTSCD.ModelTSCD.ToString();

        }


    }

}
