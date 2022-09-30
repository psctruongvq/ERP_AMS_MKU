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
    public partial class frmPhuCapThuongXuyen : Form
    {
        #region Properties
        LoaiPhuCapTXList _LoaiPhuCapTXList;
        PhuCapThuongXuyenList _PhuCapThuongXuyenList;
        PhuCapThuongXuyen _PhuCapThuongXuyen;
        Util _Util = new Util();
        static ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        static long MaNhanVien;
        #endregion

        #region Events
        public frmPhuCapThuongXuyen()
        {
            InitializeComponent();
            numeu_Nam.Text = Convert.ToString(DateTime.Today.Year);

            toolStripLabel1.Visible = false;
            tlslblIn.Visible = false;
            tlslblThem.Enabled = false;
            tlslblLuu.Enabled = false;
            tlslblUndo.Enabled = false;
            tlslblXoa.Enabled = false;
        }

        public frmPhuCapThuongXuyen(ThongTinNhanVienTongHop thongTinNhanVienTongHop)
        {
            InitializeComponent();
            _ThongTinNhanVienTongHop = thongTinNhanVienTongHop;
        }

        private void LayDuLieuLenLuoi()
        {
            _LoaiPhuCapTXList = LoaiPhuCapTXList.GetLoaiPhuCapTXList();
            LoaiPhuCapTX_BindingSource.DataSource = _LoaiPhuCapTXList;

            tlslblIn.Visible = false;
        }

        private void LayPhuCapThuongXuyen()
        {
            _PhuCapThuongXuyenList = PhuCapThuongXuyenList.GetPhuCapThuongXuyenList(_ThongTinNhanVienTongHop.MaNhanVien);
            PhuCapTX_BindingSource.DataSource = _PhuCapThuongXuyenList;            
        }

        private void frmPhuCapThuongXuyen_Load(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
        }

        private bool KiemTraTruocKhiLuu()
        {
            bool kq = true;
            foreach (Control control in gbx_HoSoPhucapTX.Controls)
            {
                if (errorProvider1.GetError(control) != String.Empty)
                {
                    if (control.Name == cmbu_Thang.Name)
                    {
                        MessageBox.Show(this, _Util.vuilongchonthang, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    else if (control.Name == numeu_Nam.Name)
                    {
                        MessageBox.Show(this, _Util.vuilongchonnam, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    else if (control.Name == crceu_TongTien.Name)
                    {
                        MessageBox.Show(this, _Util.vuilongnhaptongtien, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                }
            }
            return kq;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraTruocKhiLuu() == false)
                {
                    return;
                }
                for (int i = 0; i < _PhuCapThuongXuyenList.Count; i++)
                {
                    _PhuCapThuongXuyen = _PhuCapThuongXuyenList[i];
                    if (_PhuCapThuongXuyen.Nam == 0)
                    {
                        return;
                    }
                }
                MaNhanVien = Convert.ToInt64(txtu_MaNhanVien.Value);
                _PhuCapThuongXuyen = PhuCapThuongXuyen.NewPhuCapThuongXuyen(MaNhanVien);
                _PhuCapThuongXuyenList.Add(_PhuCapThuongXuyen);
                PhuCapTX_BindingSource.DataSource = _PhuCapThuongXuyenList;
                grdu_HoSoPhuCapTX.ActiveRow = grdu_HoSoPhuCapTX.Rows[_PhuCapThuongXuyenList.Count - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraTruocKhiLuu() == false)
                {
                    return;
                }
                else
                {
                    for (int i = 0; i < _PhuCapThuongXuyenList.Count; i++)
                    {
                        if (_PhuCapThuongXuyenList[i].Thang == 0)
                        {
                            MessageBox.Show(this, _Util.vuilongchonthang, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (_PhuCapThuongXuyenList[i].Nam== 0)
                        {
                            MessageBox.Show(this, _Util.vuilongnhapdonvithoigian, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (_PhuCapThuongXuyenList[i].SoTien == 0)
                        {
                            MessageBox.Show(this, _Util.vuilongnhaptongtien, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    grdu_HoSoPhuCapTX.UpdateData();
                    _PhuCapThuongXuyenList.ApplyEdit();
                    _PhuCapThuongXuyenList.Save();
                    MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LayPhuCapThuongXuyen();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_HoSoPhuCapTX.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayPhuCapThuongXuyen();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(3);
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                if (_ThongTinNhanVienTongHop != null)
                {
                    _PhuCapThuongXuyenList = PhuCapThuongXuyenList.GetPhuCapThuongXuyenList(_ThongTinNhanVienTongHop.MaNhanVien);
                    PhuCapTX_BindingSource.DataSource = _PhuCapThuongXuyenList;
                    txtu_TenNhanVien.Text = _ThongTinNhanVienTongHop.TenNhanVien.ToString();
                    txtu_MaNhanVien.Value = _ThongTinNhanVienTongHop.MaNhanVien;
                    txtu_MaNhanVienQL.Text = _ThongTinNhanVienTongHop.MaQLNhanVien.ToString();
                }

                tlslblThem.Enabled = true;
                tlslblLuu.Enabled = true;
                tlslblUndo.Enabled = true;
                tlslblXoa.Enabled = true;
            }
        }
        #endregion

        #region grdu_HoSoPhuCapTX_InitializeLayout
        private void grdu_HoSoPhuCapTX_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["MaPhuCapTX"].Hidden = true;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["MaLoaiPhuCapTX"].Hidden = true;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;

            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenLoaiPhuCapTX"].Header.Caption = "Tên Loại PCTX";
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenLoaiPhuCapTX"].Header.VisiblePosition = 0;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenLoaiPhuCapTX"].Width = 100;

            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["Nam"].Header.Caption = "Năm";
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["Nam"].Header.VisiblePosition = 1;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["Nam"].Width = 80;

            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["Thang"].Header.Caption = "Tháng";
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["Thang"].Header.VisiblePosition = 2;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["Thang"].Width = 70;

            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiến";
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 3;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;

            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 4;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 190;

            
            grdu_HoSoPhuCapTX.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_HoSoPhuCapTX.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###";
                }
            }
        }
        #endregion
    }
}