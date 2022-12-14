using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmDuLieuTho_ChamCong : Form
    {
        DuLieuTho duLieuTho;
        frmDinhDangFile_DuLieuTho newFormDinhDang = new frmDinhDangFile_DuLieuTho();

        public frmDuLieuTho_ChamCong()
        {
            InitializeComponent();
            //this.txt_DinhDang.Text = newFormDinhDang.FormatText;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_TenFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnDocDuLieu_Click(object sender, EventArgs e)
        {
            bool loiDocFile = true;

            if (txt_TenFile.Text.Length == 0)
                MessageBox.Show("Bạn chưa chọn file!");
            else
                if (!new FileInfo(txt_TenFile.Text).Exists)
                {
                    MessageBox.Show("File không tồn tại. Hãy chọn lại file!");
                    txt_TenFile.Text = "";
                }
                else
                {
                    try
                    {
                        if(duLieuTho ==null)
                            duLieuTho = new DuLieuTho(txt_TenFile.Text, txt_DinhDang.Text);
                        else if (duLieuTho.DuongDan != txt_TenFile.Text || duLieuTho.DinhDang != txt_DinhDang.Text)
                        {
                            duLieuTho = new DuLieuTho(txt_TenFile.Text, txt_DinhDang.Text);
                        }

                        loiDocFile = false;
                        duLieuTho.Save();
                        MessageBox.Show("Đã đọc và lưu CSDL xong!");

                    }
                    catch (Exception ex)
                    {
                        if (loiDocFile)
                            MessageBox.Show("Có lỗi đọc file!");
                        else
                            MessageBox.Show("Có lỗi lưu CSDL!");
                        throw ex;
                    }
                }
        }

        private void btn_DoiDinhDang_Click(object sender, EventArgs e)
        {
            newFormDinhDang.FormatText = this.txt_DinhDang.Text;
            newFormDinhDang.ShowDialog();
            this.txt_DinhDang.Text = newFormDinhDang.FormatText;
        }
    }
}