
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.Misc;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using DevExpress.XtraEditors;
using PSC_ERP_Common;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmHeThongTaiKhoan : Form
    {
        #region Properties
        HeThongTaiKhoan1 _HeThongTaiKhoan1;
        HeThongTaiKhoan1List _HeThongTaiKhoan1List;
        HeThongTaiKhoan1List _HeThongTaiKhoan1ListCha;
        LoaiTaiKhoanList _LoaiTaiKhoanList;
       // Util _Util = new Util();
        CongTyList _congTyLits;
        #endregion

        #region Events
        public frmHeThongTaiKhoan()
        {
            InitializeComponent();
        }

        private void LayDuLieuLenLuoi()
        {
            _HeThongTaiKhoan1List = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            HeThongTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1List;

            _HeThongTaiKhoan1ListCha = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListCha();
            HeThongTaiKhoanCha_BindingSource.DataSource = _HeThongTaiKhoan1ListCha;

            _LoaiTaiKhoanList = LoaiTaiKhoanList.GetLoaiTaiKhoanList();
            LoaiTaiKhoan_BindingSource.DataSource = _LoaiTaiKhoanList;
            _congTyLits = CongTyList.GetCongTyList();
            bdCongTy.DataSource = _congTyLits;
            toolStripLabel1.Visible = false;

            tlslblIn.Visible = false;
            tlslblTim.Visible = false;

            //tlslblXoa.Visible = false;
        }

        private Boolean KiemTraConTrol()
        {
            Boolean kq = true;
            foreach (Control control in ultraGrid_TaiKhoan.Controls)
            {
                if (errorProvider1.GetError(control) != String.Empty)
                {
                    if (control.Name == utxeditSoHieu.Name)
                    {
                        MessageBox.Show(this, "Vui L??ng Nh???p S??? Hi???u T??i Kho???n", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    else if (control.Name == utxeditTenTaiKhoan.Name)
                    {
                        MessageBox.Show(this, "Vui L??ng Nh???p T??n T??i Kho???n", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    else if (control.Name == ultraCombo_LoaiTaiKhoan.Name)
                    {
                        MessageBox.Show(this, "Vui L??ng Ch???n Lo???i T??i Kho???n", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    else if (control.Name == cmbue_CapTaiKhoan.Name)
                    {
                        MessageBox.Show(this, "Vui L??ng Ch???n C???p T??i Kho???n", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    //else if (control.Name == cbCongTy.Name)
                    //{
                    //    MessageBox.Show(this, "Vui L??ng Ch???n ????n V??? T??i Kho???n", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    control.Focus();
                    //    kq = false;
                    //    return kq;
                    //}
                }
            }
            return kq;
        }

        private void frmHeThongTaiKhoan_Load(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            using (DialogUtil.Wait(this))
                LayDuLieuLenLuoi();
        }

        private void ultraGrid_TaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultraGrid_TaiKhoan.UpdateData();
            }
        }

        private void ultraGrid_TaiKhoan_Click(object sender, EventArgs e)
        {
            ultraGrid_TaiKhoan.Update();
        }

        private void ultraGrid_TaiKhoan_Leave(object sender, EventArgs e)
        {
           // ultraGrid_TaiKhoan.Update();
        }

        private void ultraGrid_TaiKhoan_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            //if (ultraGrid_TaiKhoan.ActiveRow == null)
            //    return;
            //if (ultraGrid_TaiKhoan.ActiveRow.IsFilterRow != true)
            //{           
            //    if (Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value) == true && Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value) == false)
            //    {
            //        uosSoDuBenNo.CheckedIndex = 0;
            //    }
            //    if (Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value) == true && Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value) == false)
            //    {
            //        uosSoDuBenNo.CheckedIndex = 1;
            //    }
            //    if (Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value) == true && (Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value) == true))
            //    {
            //        uosSoDuBenNo.CheckedIndex = 2;

            //    }
            //    else if (Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value) == false && Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value) == false)
            //    {
            //        uosSoDuBenNo.CheckedIndex = 3;
            //    }
            //}
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            string _TenTaiKhoan = ultraGrid_TaiKhoan.ActiveRow.Cells["TenTaiKhoan"].Value + "";
            if (DialogResult.Yes == XtraMessageBox.Show("B???n c?? mu???n x??a t??i kho???n: <color=red>"+_TenTaiKhoan + "</color> kh??ng ??", "Th??ng b??o", MessageBoxButtons.YesNo, MessageBoxIcon.Question,DevExpress.Utils.DefaultBoolean.True))
            {
                int _MaTaiKhoan = Convert.ToInt32(ultraGrid_TaiKhoan.ActiveRow.Cells["MaTaiKhoan"].Value==null?0: ultraGrid_TaiKhoan.ActiveRow.Cells["MaTaiKhoan"].Value);
                //string b = ultraGrid_TaiKhoan.ActiveRow.Cells["TenTaiKhoan"].Value + "";
                try
                {
                    Delete_TK(_MaTaiKhoan);
                    using (DialogUtil.Wait(this))
                        LayDuLieuLenLuoi();
                }
                catch (Exception ex)
                { XtraMessageBox.Show("-L???i: "+ex+"","TH??NG B??O",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            }
        }
        #region X??a TK
        private int Delete_TK(int MaTaiKhoan)
        {
            int kq = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblTaiKhoan";
                cm.Parameters.AddWithValue("@MaTaiKhoan", MaTaiKhoan);
                kq = Convert.ToInt32(cm.ExecuteNonQuery());
            }//using
            return kq;
        }
        #endregion X??a TK
        private void uosSoDuBenNo_ValueChanged(object sender, EventArgs e)
        {   
            if (uosSoDuBenNo.CheckedIndex == 0)
            {
                
                ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value = true;
                ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value = false;                
            }
            else if (uosSoDuBenNo.CheckedIndex == 1)
            {
                
                ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value = true;
                ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value = false;                
            }
            else if (uosSoDuBenNo.CheckedIndex == 2)
            {
                ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value = true;
                ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value = true;
                
            }
            else if (uosSoDuBenNo.CheckedIndex == 3)
            {
                ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value = false;
                ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value = false;                
            }
            else
                return;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            grbHeThongTaiKhoan.Enabled = false;
            for (int i = 0; i < _HeThongTaiKhoan1List.Count; i++)
            {
                _HeThongTaiKhoan1 = _HeThongTaiKhoan1List[i];
                if (_HeThongTaiKhoan1.SoHieuTK == "")
                {
                    return;
                }
            }
            _HeThongTaiKhoan1 = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            _HeThongTaiKhoan1.CapTaiKhoan = 1;
            _HeThongTaiKhoan1List.Add(_HeThongTaiKhoan1);
            HeThongTaiKhoan_BindingSource.DataSource = _HeThongTaiKhoan1List;
            ultraGrid_TaiKhoan.ActiveRow = ultraGrid_TaiKhoan.Rows[_HeThongTaiKhoan1List.Count - 1];
            utxeditSoHieu.Focus();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            int capTaiKhoan = 0;
            int loaiTaiKhoan = 0;
            int loaiTaiKhoanCha = 0;
            try
            {
                capTaiKhoan = Convert.ToInt32(cmbue_CapTaiKhoan.Value);
                loaiTaiKhoan = Convert.ToInt32(ultraCombo_LoaiTaiKhoan.Value);
                loaiTaiKhoanCha = Convert.ToInt32(cmbu_TaiKhoanCha.Value);
                if (KiemTraConTrol() == false)
                    return;
                if (utxeditSoHieu.Text.Trim() == "")
                {
                    XtraMessageBox.Show("B???n ch??a nh???p" +"<color=red> S??? hi???u t??i kho???n"+"</color>, vui l??ng nh???p ?????y ????? th??ng tin!","TH??NG B??O", MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);
                    utxeditSoHieu.Focus();
                    return;
                }
                if (utxeditTenTaiKhoan.Text.Trim() == "")
                {
                    XtraMessageBox.Show("B???n ch??a nh???p" + "<color=red> T??n t??i kho???n" + "</color>, vui l??ng nh???p ?????y ????? th??ng tin!", "TH??NG B??O", MessageBoxButtons.OK, MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);
                    utxeditTenTaiKhoan.Focus();
                    return;
                }
                if (loaiTaiKhoan == 0)
                {
                    MessageBox.Show(this, "Vui L??ng Ch???n Lo???i T??i Kho???n", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ultraCombo_LoaiTaiKhoan.Focus();
                    return;
                }
                if (capTaiKhoan == 0)
                {
                    MessageBox.Show(this, "Vui L??ng Ch???n C???p T??i Kho???n", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbue_CapTaiKhoan.Focus();
                    return;
                }
                if (capTaiKhoan != 1 && loaiTaiKhoanCha == 0)
                {
                    MessageBox.Show(this, "Vui L??ng Ch???n Lo???i T??i Kho???n Cha", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbu_TaiKhoanCha.Focus();
                    return;
                }
                if (uosSoDuBenNo.CheckedIndex == -1)
                {
                    MessageBox.Show(this, "Vui L??ng Ch???n Ki???u S??? D??", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uosSoDuBenNo.Focus();
                    return;
                }
                //if (cbCongTy.ActiveRow ==null)
                //{
                //    MessageBox.Show(this, "Vui L??ng Ch???n ????n V??? T??i Kho???n", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    uosSoDuBenNo.Focus();
                //    return;
                //}
                ultraGrid_TaiKhoan.UpdateData();
                _HeThongTaiKhoan1List.ApplyEdit();
                using (DialogUtil.Wait())
                    _HeThongTaiKhoan1List.Save();
                MessageBox.Show(this, "L??u th??nh c??ng", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LayDuLieuLenLuoi();
                this.strStatus = "KHOA";
                this.ReadOnlyConTrolByStatus(this.strStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chkTheoDoiChiTietTungDoiTuong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ultraGrid_TaiKhoan.ActiveRow == null)
                    return;
                if (chkTheoDoiChiTietTungDoiTuong.Checked == true)
                {
                    ultraGrid_TaiKhoan.ActiveRow.Cells["CoDoiTuongTheoDoi"].Value = true;
                }
                else if (chkTheoDoiChiTietTungDoiTuong.Checked == false)
                {
                    ultraGrid_TaiKhoan.ActiveRow.Cells["CoDoiTuongTheoDoi"].Value = false;
                }
            }
            catch { }
        }

        private void cmbue_CapTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbue_CapTaiKhoan.Value!= null && int.Parse(cmbue_CapTaiKhoan.Value+"") != 1)
            {
                lbTaiKhoanCha.Enabled = true;
                cmbu_TaiKhoanCha.Enabled = true;
            }
            else
            {
                lbTaiKhoanCha.Enabled = false;
                cmbu_TaiKhoanCha.Enabled = false;
            }
        }

        private void utxeditSoHieu_Leave(object sender, EventArgs e)
        {
            
            //string SoHieuTK = string.Empty;
            //SoHieuTK = utxeditSoHieu.Value.ToString();
            //if (ERP_Library.HamDungChung.KiemTraLaSo(SoHieuTK) == false)
            //{
            //    MessageBox.Show(this, "Vui L??ng Nh???p S???", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    utxeditSoHieu.Focus();
            //    return;
            //}
            //if (SoHieuTK.Length != 7)
            //{
            //    MessageBox.Show(this, "Vui L??ng Nh???p ????ng 7 S???", "Th??ng b??o", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    utxeditSoHieu.Focus();
            //    return;
            //}
        }

        #endregion

        #region InitializeLayout
        private void ultraGrid_TaiKhoan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ultraGrid_TaiKhoan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultraGrid_TaiKhoan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = true;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaTaiKhoanCha"].Hidden = true;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuCo"].Header.Caption = "D?? C??";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuCo"].Width = 60;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuCo"].Header.VisiblePosition = 3;

            
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuNo"].Header.Caption = "D?? N???";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuNo"].Header.VisiblePosition = 4;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["LoaiSoDuNo"].Width = 60;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["SoDuNoDauNam"].Hidden = true;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["SoDuCoDauNam"].Hidden = true;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaLoaiTaiKhoan"].Hidden = true;

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "S??? Hi???u TK";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "T??n T??i Kho???n";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 275;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["CapTaiKhoan"].Header.Caption = "C???p T??i Kho???n";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["CapTaiKhoan"].Header.VisiblePosition = 2;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["CapTaiKhoan"].Width = 95;

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["CoDoiTuongTheoDoi"].Hidden = true;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["CoDoiTuongTheoDoi"].Header.Caption = "C?? ?????i T?????ng Theo D??i";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["CoDoiTuongTheoDoi"].Header.VisiblePosition = 3;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["CoDoiTuongTheoDoi"].Width = 142;

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaCongTy"].Hidden = false;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaCongTy"].Header.Caption = "????n V???";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaCongTy"].Header.VisiblePosition = 4;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaCongTy"].EditorComponent = cbCongTy;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["MaCongTy"].Width = 142;

            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["DungChung"].Hidden = false;
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["DungChung"].Header.Caption = "D??ng Chung";
            ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns["DungChung"].Header.VisiblePosition = 5;
            
            

            foreach (UltraGridColumn col in ultraGrid_TaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void cmbu_TaiKhoanCha_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_TaiKhoanCha.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            cmbu_TaiKhoanCha.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = true;
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["MaTaiKhoanCha"].Hidden = true;
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["CoDoiTuongTheoDoi"].Hidden = true;
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["LoaiSoDuCo"].Hidden = true;
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["LoaiSoDuNo"].Hidden = true;
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["SoDuNoDauNam"].Hidden = true;
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["SoDuCoDauNam"].Hidden = true;
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["MaLoaiTaiKhoan"].Hidden = true;
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["CapTaiKhoan"].Hidden = true;

            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "S??? Hi???u TK";
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 80;
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "T??n T??i Kho???n";
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
            cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 127;

            foreach (UltraGridColumn col in cmbu_TaiKhoanCha.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void ultraCombo_LoaiTaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraCombo_LoaiTaiKhoan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultraCombo_LoaiTaiKhoan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultraCombo_LoaiTaiKhoan.DisplayLayout.Bands[0].Columns["MaLoaiTK"].Hidden = true;

            ultraCombo_LoaiTaiKhoan.DisplayLayout.Bands[0].Columns["MaLoaiTKQL"].Header.Caption = "M?? Lo???i TK";
            ultraCombo_LoaiTaiKhoan.DisplayLayout.Bands[0].Columns["MaLoaiTKQL"].Header.VisiblePosition = 0;
            ultraCombo_LoaiTaiKhoan.DisplayLayout.Bands[0].Columns["MaLoaiTKQL"].Width = 80;
            ultraCombo_LoaiTaiKhoan.DisplayLayout.Bands[0].Columns["TenLoaiTK"].Header.Caption = "T??n Lo???i TK";
            ultraCombo_LoaiTaiKhoan.DisplayLayout.Bands[0].Columns["TenLoaiTK"].Header.VisiblePosition = 1;
            ultraCombo_LoaiTaiKhoan.DisplayLayout.Bands[0].Columns["TenLoaiTK"].Width = 127;

            foreach (UltraGridColumn col in ultraCombo_LoaiTaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        private void ultraGrid_TaiKhoan_DoubleClick(object sender, EventArgs e)
        {
            int maTaiKhoan = 0;
            maTaiKhoan = (int)ultraGrid_TaiKhoan.ActiveRow.Cells["MaTaiKhoan"].Value;
            frmTheoDoiDoiTuong f = new frmTheoDoiDoiTuong(maTaiKhoan);
            // nh???n ph??n quy???n truy???n sang form theo d??i
            f.ThemORSua = fthemOrSua;
            f.ShowDialog();
        }

        private void cbCongTy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in cbCongTy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            cbCongTy.DisplayLayout.Bands[0].Columns["TenCongTy"].Hidden = false;
            cbCongTy.DisplayLayout.Bands[0].Columns["TenCongTy"].Header.Caption = "M?? Lo???i TK";
            cbCongTy.DisplayLayout.Bands[0].Columns["TenCongTy"].Header.VisiblePosition = 0;
            cbCongTy.DisplayLayout.Bands[0].Columns["TenCongTy"].Width = 200;
            
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            this.strStatus = "SUA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            // readonly tr??n l?????i 
            ReadOnlyUlTraGrid(ultraGrid_TaiKhoan, false);
        }
        private void tlSbtnXuatExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultraGrid_TaiKhoan);
        }

        private void chkKhongSuDung_Click(object sender, EventArgs e)
        {
            //if (chkKhongSuDung.CheckState == CheckState.Checked)
            //{
            //    NgayADKhongSD_dtmp.Enabled = true;
            //    NgayADKhongSD_dtmp.DateTime = DateTime.Now;
            //}
            //else
            //    NgayADKhongSD_dtmp.Enabled = false;
        }

        private void ultraGrid_TaiKhoan_AfterCellActivate(object sender, EventArgs e)
        {
            if (ultraGrid_TaiKhoan.ActiveRow == null)
                return;
            if (ultraGrid_TaiKhoan.ActiveRow.IsFilterRow != true)
            {
                if (Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value) == true && Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value) == false)
                {
                    uosSoDuBenNo.CheckedIndex = 0;
                }
                if (Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value) == true && Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value) == false)
                {
                    uosSoDuBenNo.CheckedIndex = 1;
                }
                if (Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value) == true && (Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value) == true))
                {
                    uosSoDuBenNo.CheckedIndex = 2;

                }
                else if (Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuCo"].Value) == false && Convert.ToBoolean(ultraGrid_TaiKhoan.ActiveRow.Cells["LoaiSoDuNo"].Value) == false)
                {
                    uosSoDuBenNo.CheckedIndex = 3;
                }
            }
        }

        // Ph??n quy???n th??m s???a x??a 
        private void ReadOnlyConTrolByStatus(string _strStatus)
        {
            if (_strStatus == "" || _strStatus == "THEM" || _strStatus == "SUA")
            {
                btnSua.Visible = false;
                tlslblThem.Visible = false;
                tlslblLuu.Visible = true;
                tlslblUndo.Visible = true;
                // readonly Group th??ng tin chi ti???t
                utxeditSoHieu.ReadOnly = false;
                utxeditTenTaiKhoan.ReadOnly = false;
                ultraCombo_LoaiTaiKhoan.ReadOnly = false;
                cmbue_CapTaiKhoan.ReadOnly = false;
                cmbu_TaiKhoanCha.ReadOnly = false;
                cbCongTy.ReadOnly = false;
                NgayADKhongSD_dtmp.ReadOnly = false;
                checkBox1.Enabled = true;
                chkKhongSuDung.Enabled = true;
                // Enable group ki???u s??? d??
                uosSoDuBenNo.Enabled = true;
                // Enable d???i t?????ng theo d??i chi ti???t 
                chkTheoDoiChiTietTungDoiTuong.Enabled = true;
                // Enable kho???n m???c chi ph?? theo d??i chi ti???t
                TheoDoiKhoanMucCPcheckBox.Enabled = true;
                // Enable ????n v???/ph??ng ban theo d??i chi ti???t
                TheoDoiDonVicheckBox.Enabled = true;
            }
            else if (_strStatus == "KHOA")
            {
                btnSua.Visible = true;
                tlslblLuu.Visible = false;
                tlslblThem.Visible = true;
                tlslblUndo.Visible = false;
                // readonly tr??n l?????i 
                ReadOnlyUlTraGrid(ultraGrid_TaiKhoan,true);
                // readonly Group th??ng tin chi ti???t
                utxeditSoHieu.ReadOnly = true;
                utxeditTenTaiKhoan.ReadOnly = true;
                ultraCombo_LoaiTaiKhoan.ReadOnly = true;
                cmbue_CapTaiKhoan.ReadOnly = true;
                cmbu_TaiKhoanCha.ReadOnly = true;
                cbCongTy.ReadOnly = true;
                NgayADKhongSD_dtmp.ReadOnly = true;
                checkBox1.Enabled = false;
                chkKhongSuDung.Enabled = false;
                // Enable group ki???u s??? d??
                uosSoDuBenNo.Enabled = false;
                // Enable d???i t?????ng theo d??i chi ti???t 
                chkTheoDoiChiTietTungDoiTuong.Enabled = false;
                // Enable kho???n m???c chi ph?? theo d??i chi ti???t
                TheoDoiKhoanMucCPcheckBox.Enabled = false;
                // Enable ????n v???/ph??ng ban theo d??i chi ti???t
                TheoDoiDonVicheckBox.Enabled = false;
                grbHeThongTaiKhoan.Enabled = true;
            }
            PhanQuyenThemSuaXoa();
        }
        public string strStatus = "KHOA";
        PhanQuyenSuDungForm _phanQuyen = null;
        bool fthemOrSua = false;
        private void PhanQuyenThemSuaXoa()
        {
            _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(ERP_Library.Security.CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            tlslblThem.Enabled = _phanQuyen.Them;
            btnSua.Enabled = _phanQuyen.Sua;
            tlslblXoa.Enabled= _phanQuyen.Xoa;
            fthemOrSua = (_phanQuyen.Them == true || _phanQuyen.Sua == true) ? true : false;
        }
        // true l?? t???t ch???nh s???a tr??n l?????i
        private void ReadOnlyUlTraGrid(UltraGrid ultragrid ,bool Bat = false) 
        {
            for (int i = 0; i < ultragrid.DisplayLayout.Bands.Count; i++)
            {
                foreach (UltraGridColumn col in ultragrid.DisplayLayout.Bands[i].Columns)
                {
                    if (Bat)
                        col.CellActivation = Activation.ActivateOnly;
                    else
                        col.CellActivation = Activation.AllowEdit;
                }
            }
        }

        private void chkKhongSuDung_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhongSuDung.CheckState == CheckState.Checked)
            {
                NgayADKhongSD_dtmp.Enabled = true;
                NgayADKhongSD_dtmp.DateTime = DateTime.Now;
            }
            else
                NgayADKhongSD_dtmp.Enabled = false;
        }

        private void ultraGrid_TaiKhoan_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;       
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.strStatus = "KHOA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            using (DialogUtil.Wait(this))
                LayDuLieuLenLuoi();
        }
    }
}