using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmDinhDangFile_DuLieuTho : Form
    {
        private string _formatText = "2@3@4@dd-MM-yyyy@HH:mm:ss@'@";

        /// <summary>
        /// chuoi dinh dang
        /// </summary>
        public string FormatText
        {
            get
            {
                return this.txt_KetQua.Text;
            }
            set
            {
                if (_formatText != value)
                {
                    if (KiemTraDinhDang(value))
                        _formatText = value;
                }
            }
        }

        public frmDinhDangFile_DuLieuTho()
        {
            InitializeComponent();
        }

        public frmDinhDangFile_DuLieuTho(string format)
        {
            InitializeComponent();
            if (KiemTraDinhDang(format))
                this._formatText = format;
        }

        private bool KiemTraDinhDang(string format)
        {
            int vtNgay = 0;
            int vtGio = 0;
            int vtCardId = 0;
            string ddNgay = string.Empty;
            string ddGio = string.Empty;
            string ddCardId = string.Empty;
            int i = 0;
            int j = 0;

            try
            {
                for (int k = 0; k < 6; k++)
                {
                    j = format.IndexOf('@', i);
                    if (j <= 0)
                        return false;
                    switch (k)
                    {
                        case 0:
                            vtNgay = int.Parse(format.Substring(i, j - i));
                            break;
                        case 1:
                            vtGio = int.Parse(format.Substring(i, j - i));
                            break;
                        case 2:
                            vtCardId = int.Parse(format.Substring(i, j - i));
                            break;
                        case 3:
                            ddNgay = format.Substring(i, j - i);
                            break;
                        case 4:
                            ddGio = format.Substring(i, j - i);
                            break;
                        case 5:
                            ddCardId = format.Substring(i, j - i);
                            break;
                        default:
                            break;
                    }
                    i = j + 1;
                }

                frt_Ngay.Text = vtNgay.ToString();
                frt_Gio.Text = vtGio.ToString();
                frt_CardID.Text = vtCardId.ToString();
                txt_NgayFormat.Text = ddNgay.ToString();
                txt_GioFormat.Text = ddGio.ToString();
                txt_CardIdFormat.Text = ddCardId.ToString();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void frt_Ngay_TextChanged(object sender, EventArgs e)
        {
            this.txt_KetQua.Text = frt_Ngay.Text + "@" + frt_Gio.Text + "@" + frt_CardID.Text + "@" +
                txt_NgayFormat.Text + "@" + txt_GioFormat.Text + "@" + txt_CardIdFormat.Text + "@";
        }

        private void frt_Gio_TextChanged(object sender, EventArgs e)
        {
            this.txt_KetQua.Text = frt_Ngay.Text + "@" + frt_Gio.Text + "@" + frt_CardID.Text + "@" +
                txt_NgayFormat.Text + "@" + txt_GioFormat.Text + "@" + txt_CardIdFormat.Text + "@";
        }

        private void frt_CardID_TextChanged(object sender, EventArgs e)
        {
            this.txt_KetQua.Text = frt_Ngay.Text + "@" + frt_Gio.Text + "@" + frt_CardID.Text + "@" +
                txt_NgayFormat.Text + "@" + txt_GioFormat.Text + "@" + txt_CardIdFormat.Text + "@";
        }

        private void txt_NgayFormat_TextChanged(object sender, EventArgs e)
        {
            this.txt_KetQua.Text = frt_Ngay.Text + "@" + frt_Gio.Text + "@" + frt_CardID.Text + "@" +
                txt_NgayFormat.Text + "@" + txt_GioFormat.Text + "@" + txt_CardIdFormat.Text + "@";
        }

        private void txt_GioFormat_TextChanged(object sender, EventArgs e)
        {
            this.txt_KetQua.Text = frt_Ngay.Text + "@" + frt_Gio.Text + "@" + frt_CardID.Text + "@" +
                txt_NgayFormat.Text + "@" + txt_GioFormat.Text + "@" + txt_CardIdFormat.Text + "@";
        }

        private void txt_CardIdFormat_TextChanged(object sender, EventArgs e)
        {
            this.txt_KetQua.Text = frt_Ngay.Text + "@" + frt_Gio.Text + "@" + frt_CardID.Text + "@" +
                txt_NgayFormat.Text + "@" + txt_GioFormat.Text + "@" + txt_CardIdFormat.Text + "@";
        }

        private void frt_Ngay_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}