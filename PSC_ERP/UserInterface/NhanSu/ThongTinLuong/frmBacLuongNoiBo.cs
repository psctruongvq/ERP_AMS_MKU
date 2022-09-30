using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
namespace PSC_ERP
{
    public partial class frmBacLuongNoiBo : Form
    {
        NhomNgachLuongBaoHiemList _nhomNgachLuongBaoHiemList;
        NgachLuongNoiBoList _ngachLuongNoiBoList;
        BacLuongNoiBoList _BacLuongNoiBoList;
        Util _Util = new Util();
        public delegate void PassData(BacLuongNoiBoList value);
        public PassData getData;
        public frmBacLuongNoiBo()
        {
            InitializeComponent();
        }

        private void frmBacLuongNoiBo_Load(object sender, EventArgs e)
        {
            _nhomNgachLuongBaoHiemList = NhomNgachLuongBaoHiemList.GetNhomNgachLuongBaoHiemList();
            this.bindingSource1_NhomNgachLuongBH.DataSource = _nhomNgachLuongBaoHiemList;
            _ngachLuongNoiBoList = NgachLuongNoiBoList.GetNgachLuongNoiBoList();
            this.bindingSource1_NgachLuongNoiBo.DataSource = _ngachLuongNoiBoList;
            _BacLuongNoiBoList = BacLuongNoiBoList.NewBacLuongNoiBoList();
            this.bindingSource1_BacLuongNoiBo.DataSource = _BacLuongNoiBoList;
        }

       

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
             try
            {
                for (int i = 0; i < _BacLuongNoiBoList.Count; i++)
                {
                    _BacLuongNoiBoList[i].MaNgachLuongNoiBo = Convert.ToInt32(ultraCombo1.Value);
                    //_BacLuongNoiBoList[i].MaNhom = Convert.ToInt32(ultraCombo1.Value);
                    if (_BacLuongNoiBoList[i].MaQuanLy == "")
                    {
                        MessageBox.Show(this, _Util.vuilongnhapbacluong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (_BacLuongNoiBoList[i].HeSoLuong <= 0 || _BacLuongNoiBoList[i].HeSoLuong > 99)
                    {
                        MessageBox.Show(this, "Hệ Số Lương chưa đúng", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (_BacLuongNoiBoList[i].MaNgachLuongNoiBo == 0)
                    {
                        MessageBox.Show(this, _Util.vuilongchonngachluong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
               //if (KiemTraMaQuanLy() == true)
               // {
                    grdu_BacLuongCoBan.UpdateData();
                    _BacLuongNoiBoList.ApplyEdit();
                    _BacLuongNoiBoList.Save();
                    MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (getData != null)
                    {
                        getData(_BacLuongNoiBoList);
                    }
                //}
                }
                catch (ApplicationException)
                {
                }
        }

        private void grdu_BacLuongCoBan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            
        }

        private void ultraCombo1_ValueChanged(object sender, EventArgs e)
        {
            _BacLuongNoiBoList = BacLuongNoiBoList.GetBacLuongNoiBoList(Convert.ToInt32(ultraCombo1.Value));
            this.bindingSource1_BacLuongNoiBo.DataSource = _BacLuongNoiBoList;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _BacLuongNoiBoList = BacLuongNoiBoList.GetBacLuongNoiBoList(Convert.ToInt32(ultraCombo1.Value));
            this.bindingSource1_BacLuongNoiBo.DataSource = _BacLuongNoiBoList;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_BacLuongCoBan.Selected.Rows.Count == 0)
            {
                MessageBox.Show(_Util.chodongcanxoa, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            grdu_BacLuongCoBan.DeleteSelectedRows();
        }

        private void grdu_BacLuongCoBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // grdu_BacLuongCoBan.UpdateData();
            }
        }

        private void ultraCombo1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ultraCombo1.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = ultraCombo1.Width;
        }

        private void cbNhomNgachLuong_ValueChanged(object sender, EventArgs e)
        {
            _ngachLuongNoiBoList = NgachLuongNoiBoList.GetNgachLuongNoiBoListByNhomNgach(Convert.ToInt32( cbNhomNgachLuong.Value));
            this.bindingSource1_NgachLuongNoiBo.DataSource = _ngachLuongNoiBoList;
        }
    }
}