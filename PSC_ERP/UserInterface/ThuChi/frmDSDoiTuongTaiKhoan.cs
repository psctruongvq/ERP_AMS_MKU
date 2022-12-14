using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmDSDoiTuongTaiKhoan : Form
    {
        DoiTuongAllList _DoiTuongAllList;
        DoiTuongTheoDoiList _DoiTuongTaiKhoanList;
        int MaTaiKhoan = -1;
        bool LoaiXem = false; // True la Xem DS cho bao cao, False la load DS de chon
       public string ChuoiDoiTuong = "";
        public frmDSDoiTuongTaiKhoan()
        {
            InitializeComponent();
        }

        public frmDSDoiTuongTaiKhoan(int maTaiKhoan,bool _LoaiXem)
        {
            InitializeComponent();
            this.MaTaiKhoan = maTaiKhoan;
            this.LoaiXem = _LoaiXem;
           
        }
        void LoadDSDoiTuongCoTaiKhoan()
        {
            _DoiTuongTaiKhoanList = DoiTuongTheoDoiList.GetDoiTuongTheoDoiListByTaiKhoan(MaTaiKhoan);
            _DoiTuongAllList = DoiTuongAllList.GetDoiTuongAllList();
            // ket hop voi doi tuong list
            for (int i = 0; i < _DoiTuongTaiKhoanList.Count; i++)
            {
                for (int j = 0; j < _DoiTuongAllList.Count; j++)
                {
                    if (_DoiTuongTaiKhoanList[i].MaDoiTuong == _DoiTuongAllList[j].MaDoiTuong)
                    {
                        _DoiTuongAllList[j].Check = true;
                        _DoiTuongAllList[j].DaCo = true;
                        break;

                    }
                }
            }
            //
            DSKhachHang_BindingSource.DataSource = _DoiTuongAllList;
        }

        private void grdu_DSKhachHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
           
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Check"].Width = 70;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Hidden = false;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.Caption = "Mã Đối Tượng";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Header.VisiblePosition = 1;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].Width = 120;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTuong"].CellActivation = Activation.NoEdit;
            //grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";
            //grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 2;
            //grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 110;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "Tên Đối Tượng";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 2;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 300;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TenDoiTuong"].CellActivation = Activation.NoEdit;

           // grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaDoiTuong"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DaCo"].Hidden = true;
       
            grdu_DSKhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
               
            }
        }

        private void frmDSDoiTuongTaiKhoan_Load(object sender, EventArgs e)
        {
            if (LoaiXem == false)
            {
                LoadDSDoiTuongCoTaiKhoan();

                for (int i = 0; i < grdu_DSKhachHang.Rows.Count; i++)
                {
                    if ((bool)grdu_DSKhachHang.Rows[i].Cells["DaCo"].Value == true)
                        grdu_DSKhachHang.Rows[i].Appearance.BackColor = Color.LightBlue;
                }
            }
            else
            {
                LoadDSDoiTuongBaoCao();
            }
        }
        void LoadDSDoiTuongBaoCao()
        {
            _DoiTuongAllList = DoiTuongAllList.GetDoiTuongAllListByMaTaiKhoan(MaTaiKhoan);
            DSKhachHang_BindingSource.DataSource = _DoiTuongAllList;
        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (LoaiXem == false)
            {
                int sodongcu = _DoiTuongTaiKhoanList.Count;
                _DoiTuongTaiKhoanList.BeginEdit();
                for (int i = 0; i < _DoiTuongAllList.Count; i++)
                {
                    if (_DoiTuongAllList[i].Check == true)
                    {
                        if (_DoiTuongAllList[i].DaCo == false)
                        {
                            _DoiTuongTaiKhoanList.Add(DoiTuongTheoDoi.NewDoiTuongTheoDoi(MaTaiKhoan, _DoiTuongAllList[i].MaDoiTuong));
                        }
                    }
                    else
                    {
                        if (_DoiTuongAllList[i].DaCo == true)// update de cho xoa khach hang cu
                        {
                            for (int j = 0; j < sodongcu; j++)
                            {
                                if (_DoiTuongAllList[i].MaDoiTuong == _DoiTuongTaiKhoanList[j].MaDoiTuong)
                                {
                                    _DoiTuongTaiKhoanList[j].Xoa = true;
                                    _DoiTuongTaiKhoanList[j].MaDoiTuong = 0;
                                    _DoiTuongTaiKhoanList[j].MaTaiKhoan = 0;
                                    break;
                                }
                            }

                        }
                    }

                }
                //
                _DoiTuongTaiKhoanList.ApplyEdit();

                try
                {
                    _DoiTuongTaiKhoanList.Save();
                    MessageBox.Show(this, "Lưu Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Lỗi khi đang Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            else
            {
                ChuoiDoiTuong = "";
                for (int i = 0; i < _DoiTuongAllList.Count; i++)
                {
                    if (_DoiTuongAllList[i].Check == true)
                        ChuoiDoiTuong += _DoiTuongAllList[i].MaDoiTuong.ToString() + ',';
                }
                if (ChuoiDoiTuong != "")
                {
                    ChuoiDoiTuong = ChuoiDoiTuong.Substring(0, ChuoiDoiTuong.Length - 1);
                }
                this.Close();
            }
        }

        private void grdu_DSKhachHang_CellChange(object sender, CellEventArgs e)
        {
            Color mau = grdu_DSKhachHang.ActiveRow.Appearance.BackColor;
            if (grdu_DSKhachHang.ActiveCell == grdu_DSKhachHang.ActiveRow.Cells["Check"])
            {
                DoiTuongAll dt;// = DoiTuongAll.NewDoiTuongAll();
                dt = (DoiTuongAll)(DSKhachHang_BindingSource.Current);
                if (dt.Check == false)
                {
                    dt.Check = true;
                }
                else
                    dt.Check = false;
                if (dt.Check == true)
                    grdu_DSKhachHang.ActiveRow.Appearance.BackColor = Color.LightBlue;
                else
                    grdu_DSKhachHang.ActiveRow.Appearance.BackColor = Color.White;
            }
        }

        private void tlslblChonHet_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdu_DSKhachHang.Rows.Count; i++)
            {

                grdu_DSKhachHang.Rows[i].Cells["Check"].Value = true;
            }
            DSKhachHang_BindingSource.DataSource = _DoiTuongAllList;
        }
    }
}