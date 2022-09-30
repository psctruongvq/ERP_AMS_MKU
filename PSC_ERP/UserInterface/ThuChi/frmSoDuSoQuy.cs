using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
//long

namespace PSC_ERP.UserInterface.ThuChi
{
    public partial class frmSoDuSoQuy : Form
    {
        #region -  FIELDS  -
        private ERP_Library.Util util = new Util();
        private SoDuSoQuyList soDuSoQuyList = SoDuSoQuyList.NewSoDuSoQuyList();
        private SoDuSoQuy soDuSoQuy = SoDuSoQuy.NewSoDuSoQuy();
        private SoQuyList soQuyList = SoQuyList.NewSoQuyList();
        private bool isStatus = false;
        #endregion

        #region -  CONSTRUCTOR  -
        public frmSoDuSoQuy()
        {
            InitializeComponent();
        }
        #endregion

        #region -  METHODS  -
        // form load
        private void frmSoDuSoQuy_Load(object sender, EventArgs e)
        {
            //binding source
            this.soQuyList = SoQuyList.GetSoQuyList();
            this.bsrcSoQuyList.DataSource = this.soQuyList;

            this.Xem(DateTime.Now.Year);
            this.cbxSoQuyList.Enabled = false;
            this.cbxHide.Enabled = false;
        }


        //format grid
        private void gridSoDuSoQuyList_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung hdc = new HamDungChung();
            hdc.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            //hide all bands
            foreach (UltraGridBand band in this.gridSoDuSoQuyList.DisplayLayout.Bands)
            {
                band.Hidden = true;
            }

            //show SoDuSoQuy band
            this.gridSoDuSoQuyList.DisplayLayout.Bands["SoDuSoQuy"].Hidden = false;

            //hide all columns
            foreach (UltraGridColumn col in this.gridSoDuSoQuyList.DisplayLayout.Bands["SoDuSoQuy"].Columns)
            {
                col.Hidden = true;
                
            }

            //deny edit TenSoQuy column 
            this.gridSoDuSoQuyList.DisplayLayout.Bands["SoDuSoQuy"].Columns["MaSoQuy"].CellActivation = Activation.NoEdit;
            

            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["MaSoQuy"].Header.Caption = "Tên sổ quỹ";
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["MaSoQuy"].Width = 150;
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["MaSoQuy"].Hidden = false;
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["MaSoQuy"].EditorComponent = this.cbxHide;
            

            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["SoDuNo"].Header.Caption = "Số dư nợ";
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["SoDuNo"].Format = "#,###";
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["SoDuNo"].Hidden = false;
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["SoDuNo"].Width = 120;
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["SoDuNo"].EditorComponent = this.uneTemplate;

            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["SoDuCo"].Header.Caption = "Số dư có";
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["SoDuCo"].Format = "#,###";
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["SoDuCo"].Hidden = false;
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["SoDuCo"].Width = 120;
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["SoDuCo"].EditorComponent = this.uneTemplate;

            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["LuyKeNo"].Header.Caption = "Lũy kế nợ";
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["LuyKeNo"].Format = "#,###";
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["LuyKeNo"].Hidden = false;
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["LuyKeNo"].Width = 120;
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["LuyKeNo"].EditorComponent = this.uneTemplate;

            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["LuyKeCo"].Header.Caption = "Lũy kế có";
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["LuyKeCo"].Format = "#,###";
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["LuyKeCo"].Hidden = false;
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["LuyKeCo"].Width = 120;
            this.gridSoDuSoQuyList.DisplayLayout.Bands[0].Columns["LuyKeCo"].EditorComponent = this.uneTemplate;
        }

        //them click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            this.soDuSoQuy = SoDuSoQuy.NewSoDuSoQuy((int)this.tbxNam.Value);

            this.soDuSoQuyList.Add(this.soDuSoQuy);
            this.gridSoDuSoQuyList.ActiveRow = this.gridSoDuSoQuyList.Rows[this.soDuSoQuyList.Count - 1];

            this.isStatus = true;
            this.cbxSoQuyList.Enabled = true;
            this.cbxHide.Enabled = true;
            this.cbxSoQuyList.Focus();
        }

        //kiểm tra đã có sổ quỹ trong danh sách chưa
        private bool IsExist(int maSoQuy)
        {
            for (int i = 0; i < this.soDuSoQuyList.Count; i++)
            {
                for (int j = this.soDuSoQuyList.Count - 1; j > 0; j--)
                {
                    if (i != j && this.soDuSoQuyList[i].MaSoQuy == this.soDuSoQuyList[j].MaSoQuy &&
                        this.soDuSoQuyList[i].Nam == this.soDuSoQuyList[j].Nam)
                    {
                        this.soDuSoQuy = this.soDuSoQuyList[i];

                        return true;
                    }
                }
            }
            return false;
        }

        //luu click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                this.ResetActive();

                this.bsrcSoDuSoQuyList.EndEdit();
                //update data in grid
                this.gridSoDuSoQuyList.UpdateData();

                if (!this.IsExist(this.soDuSoQuy.MaSoQuy))
                {
                    if (this.isStatus)
                    {
                        this.cbxSoQuyList.Enabled = false;
                        this.cbxHide.Enabled = false;
                        this.isStatus = false;
                    }

                    this.soDuSoQuyList.ApplyEdit();
                    this.soDuSoQuyList.Save();
                    
                    MessageBox.Show(util.thanhcong, util.thongbao,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Xem((int)this.tbxNam.Value);
                }
                else
                {
                    MessageBox.Show("Sổ Quỹ đã tồn tại trong cơ sở dữ liệu.", util.thongbao,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.ActiveRow();
                }
            }
            catch
            {
            }
        }

        //xoa click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (this.gridSoDuSoQuyList.ActiveRow != null)
            {
                this.gridSoDuSoQuyList.DeleteSelectedRows();
            }
        }

        #region -  Tìm danh sách số dư sổ quỹ theo năm  -
        //Tìm click
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            if (this.tbxNam.Value.ToString() != "")
                this.Xem((int)this.tbxNam.Value);
            else
                this.Xem(DateTime.Now.Year);
        }

        private void Xem(int nam)
        {
            this.soDuSoQuyList = SoDuSoQuyList.GetSoDuSoQuyByNam(ERP_Library.Security.CurrentUser.Info.MaBoPhan, nam);

            this.bsrcSoDuSoQuyList.DataSource = this.soDuSoQuyList;
        } 
        #endregion

        //thoat click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        #region -  Initialize Ultra Combo  -
        private void cbxSoQuyList_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //hide all bands
            foreach (UltraGridBand band in this.cbxSoQuyList.DisplayLayout.Bands)
            {
                band.Hidden = true;
            }

            //show SoQuy band
            this.cbxSoQuyList.DisplayLayout.Bands["SoQuy"].Hidden = false;

            //hide all columns
            foreach (UltraGridColumn col in this.cbxSoQuyList.DisplayLayout.Bands["SoQuy"].Columns)
            {
                col.Hidden = true;
            }

            //show TenSoQuy column
            this.cbxSoQuyList.DisplayLayout.Bands["SoQuy"].Columns["TenSoQuy"].Hidden = false;
            this.cbxSoQuyList.DisplayLayout.Bands["SoQuy"].Columns["TenSoQuy"].Width = 215;
            this.cbxSoQuyList.DisplayLayout.Bands["SoQuy"].Columns["TenSoQuy"].Header.Caption = "Tên Sổ Quỹ";

        }

        private void cbxHide_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //hide all bands
            foreach (UltraGridBand band in this.cbxHide.DisplayLayout.Bands)
            {
                band.Hidden = true;
            }

            //show SoQuy band
            this.cbxHide.DisplayLayout.Bands["SoQuy"].Hidden = false;

            //hide all columns
            foreach (UltraGridColumn col in this.cbxHide.DisplayLayout.Bands["SoQuy"].Columns)
            {
                col.Hidden = true;
            }

            //show TenSoQuy column
            this.cbxHide.DisplayLayout.Bands["SoQuy"].Columns["TenSoQuy"].Hidden = false;
            this.cbxHide.DisplayLayout.Bands["SoQuy"].Columns["TenSoQuy"].Width = 150;
            this.cbxHide.DisplayLayout.Bands["SoQuy"].Columns["TenSoQuy"].Header.Caption = "Tên Sổ Quỹ";
        } 
        #endregion

        #region -  Đổi màu row bị lỗi trên Ultra Grid  -
        private void ActiveRow()
        {
            if (this.soDuSoQuy != null)
            {
                foreach (UltraGridRow row in this.gridSoDuSoQuyList.Rows)
                {
                    if (row.Cells["MaSoQuy"].Value.Equals(this.soDuSoQuy.MaSoQuy))
                        row.Selected = true;
                }
            }
        }

        private void ResetActive()
        {
            foreach (UltraGridRow row in this.gridSoDuSoQuyList.Rows)
            {
                row.Selected = false;
            }
        }
        #endregion

        #region -  Filter Ultra Combo  -
        private void cbxSoQuyList_KeyDown(object sender, KeyEventArgs e)
        {
            FilterCombo fc = new FilterCombo(this.cbxSoQuyList, "TenSoQuy");
        }

        private void cbxHide_KeyDown(object sender, KeyEventArgs e)
        {
            FilterCombo fc = new FilterCombo(this.cbxHide, "TenSoQuy");
        } 
        #endregion        

        private void gridSoDuSoQuyList_ClickCell(object sender, ClickCellEventArgs e)
        {
            this.cbxSoQuyList.Enabled = this.IsEnable((int)this.gridSoDuSoQuyList.ActiveRow.Cells["MaSoQuy"].Value);
        }

        private bool IsEnable(int maSoQuy)
        {
            foreach (SoDuSoQuy item in this.soDuSoQuyList)
            {
                if (item.MaSoQuy == maSoQuy && item.IsNew)
                    return true;
            }
            return false;
        }
    }
}
