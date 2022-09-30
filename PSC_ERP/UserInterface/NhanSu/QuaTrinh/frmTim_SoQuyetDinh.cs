using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Shared;
using Csla;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmQuyetDinhBoNhiem_Tim : Form
    {
        #region Properties
        Util util = new Util();
        private static int _maQuyetDinh;
        QuyetDinhDaoTao _QuyetDinhDaoTao;
        QuyetDinhDaoTaoList _QuyetDinhDaoTaoList;
        #endregion

        #region Events
        public frmQuyetDinhBoNhiem_Tim()
        {
            InitializeComponent();
            this.Load_Form();

            tlslblUndo.Visible = false;
            toolStripSeparator4.Visible = false;
        }

        private void Load_Form()
        {
            _QuyetDinhDaoTaoList = QuyetDinhDaoTaoList.GetQuyetDinhDaoTaoList();
            QuyetDinhDaoTao_bindingSource.DataSource = _QuyetDinhDaoTaoList;
        }

        private void grdu_QuyetDinhDaoTao_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            _maQuyetDinh = ((QuyetDinhDaoTao)QuyetDinhDaoTao_bindingSource.Current).MaQuyetDinh;
            _QuyetDinhDaoTao = QuyetDinhDaoTao.GetQuyetDinhDaoTao(_maQuyetDinh);
            frmQuyetDinhDaoTao frm_QDDT = new frmQuyetDinhDaoTao(_QuyetDinhDaoTao);
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_QuyetDinhDaoTao.UpdateData();
            if (grdu_QuyetDinhDaoTao.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdu_QuyetDinhDaoTao.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Form();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _QuyetDinhDaoTaoList.ApplyEdit();
                _QuyetDinhDaoTaoList.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ultraGrid1_InitializeLayout
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[1].Hidden = true;

            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[0].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[1].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[2].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[3].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[4].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[5].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[6].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[7].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[8].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[9].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[10].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[11].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[12].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[13].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[14].CellActivation = Activation.NoEdit;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns[15].CellActivation = Activation.NoEdit;

            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["MaQuyetDinh"].Hidden = true;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["MaHinhThucDaoTao"].Hidden = true;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["MaTruongDaoTao"].Hidden = true;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["MaChuyenNganhDaoTao"].Hidden = true;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["MaTacDongDen"].Hidden = true;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["MaTrinhDoChuyenMon"].Hidden = true;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = true;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["NguoiKy"].Hidden = true;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["NgayKy"].Hidden = true;

            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["ThoiGianBD"].Header.Caption = "Thời Gian BĐ";
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["ThoiGianKT"].Header.Caption = "Thời Gian KT";
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["ThoiGianHoc"].Header.Caption = "Thời Gian Học";
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["TongChiPhi"].Header.Caption = "Tổng Chi Phí";

            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Width = 100;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["TongChiPhi"].Width = 100;

            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 0;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["ThoiGianBD"].Header.VisiblePosition = 1;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["ThoiGianKT"].Header.VisiblePosition = 2;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["ThoiGianHoc"].Header.VisiblePosition = 3;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["TongChiPhi"].Header.VisiblePosition = 4;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["NguoiKy"].Header.VisiblePosition = 5;
            grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns["NgayKy"].Header.VisiblePosition = 6;

            //grdu_QuyetDinhDaoTao.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //this.grdu_QuyetDinhDaoTao.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_QuyetDinhDaoTao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###";
                }
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
        }
        #endregion
    }
}   