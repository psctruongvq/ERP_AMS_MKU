using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
namespace PSC_ERP.Main
{
    public partial class frmMain : Form
    {
        #region Các cài đặt của form main
        public frmMain()
        {
            InitializeComponent();            
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //thay đổi định dạng
            System.Globalization.CultureInfo cul = new System.Globalization.CultureInfo("vi-VN");
            Application.CurrentCulture = cul;
            this.WindowState = FormWindowState.Normal;
            #region Old
            //if (!ERP_Library.Security.CurrentUser.IsLogIn)
            //    DangNhap();
            #endregion//Old

            #region Modify
            LoadPhanQuyen();
            #endregion//Modify
        }

        private void DangNhap()
        {
            frmDangNhap f = new frmDangNhap();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                //OpenPhanHe(6000);
                LoadPhanQuyen();
                lblUser.Text = "Người sử dụng : " + ERP_Library.Security.CurrentUser.Info.TenDangNhap;
            }
            else
                if (!ERP_Library.Security.CurrentUser.IsLogIn)
                    this.Close();
        }
        
        private void OpenPhanHe(int id)
        {
            Form f = FormPhanHe(id);
            if (f != null)
            {
                f.FormClosed += new FormClosedEventHandler(f_FormClosed);
                f.Show();
                this.Hide();
            }
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        #endregion

        private void LoadPhanQuyen()
        {
            lblHeThong.Enabled = ERP_Library.Security.CurrentUser.CanOpen(1);
            btnMuaBan.Enabled = ERP_Library.Security.CurrentUser.CanOpen(2000);
            btnCongNo.Enabled = ERP_Library.Security.CurrentUser.CanOpen(3000);
            btnNhanSu.Enabled = ERP_Library.Security.CurrentUser.CanOpen(1000);
            //btnTaiSan.Enabled = ERP_Library.Security.CurrentUser.CanOpen(4000);
            bt_KeToanTongHop.Enabled = ERP_Library.Security.CurrentUser.CanOpen(6000);
            bt_CMTL.Enabled = ERP_Library.Security.CurrentUser.CanOpen(8000);
        }

        private Form FormPhanHe(int id)
        {
            switch (id)
            {
                case 1:
                    return new frmHeThong();
                case 1000:
                    return new frmNhanSu();
                case 2000:
                    return new frmMuaBan();
                case 3000:
                    return new frmCongNo();
                case 6000:
                    return new frmTongHop();
                case 7000:
                    return new frmMainThue();
                case 8000:
                    return new frmQuyChungMotTamLong();
                default:
                    break;
            }
            return null;
        }

        private void lblUser_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void lblHeThong_Click(object sender, EventArgs e)
        {
            OpenPhanHe(1);
        }

        private void btnMuaBan_Click(object sender, EventArgs e)
        {
            OpenPhanHe(2000);
        }

        void dlgMuaBan_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btnCongNo_Click(object sender, EventArgs e)
        {
            OpenPhanHe(3000);
        }

        private void btnNhanSu_Click(object sender, EventArgs e)
        {
            OpenPhanHe(1000);
        }

        private void btnTaiSan_Click(object sender, EventArgs e)
        {
            //OpenPhanHe(4000);
            this.Hide();
            PSC_ERPNew.Main.PhanHe.TSCD.frmPhanHeTSCD frm = new PSC_ERPNew.Main.PhanHe.TSCD.frmPhanHeTSCD();
            frm.ShowDialog();
            this.Show();
        }
        private void btnDigitizingModule_Click(object sender, EventArgs e)
        {
            this.Hide();
            PSC_ERPNew.Main.PhanHe.DIGITIZING.frmDigitizingModule frm = new PSC_ERPNew.Main.PhanHe.DIGITIZING.frmDigitizingModule();
            frm.ShowDialog();
            this.Show();
        }

        public static void LoadHelp(Form control, string indexing, string fileName)
        {
            if (indexing == string.Empty)
                Help.ShowHelp(control.ParentForm, fileName);
            else
            {
                Help.ShowHelp(control.ParentForm, fileName, HelpNavigator.KeywordIndex, indexing);
                Help.ShowHelp(control.ParentForm, fileName, HelpNavigator.Index, indexing);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void bt_KeToanTongHop_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //frmMainTongHop dlgMainTongHop = new frmMainTongHop();
            //dlgMainTongHop.FormClosed += new FormClosedEventHandler(dlgMainTongHop_FormClosed);
            //dlgMainTongHop.Show();

            OpenPhanHe(6000);
        }

        void dlgMainTongHop_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void bt_Thue_Click(object sender, EventArgs e)
        {
            OpenPhanHe(7000);
        }

        private void bt_CMTL_Click(object sender, EventArgs e)
        {
            OpenPhanHe(8000);
        }

       
    }
}
