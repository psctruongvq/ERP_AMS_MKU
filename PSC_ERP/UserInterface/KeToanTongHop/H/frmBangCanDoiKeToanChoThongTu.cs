using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ERP_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmBangCanDoiKeToanChoThongTu : DevExpress.XtraEditors.XtraForm
    {
        int _iD = 0;
        int _maMucTaikhoan = 0;

        CT_MauBangBaoCaoH CT_BangCanDoi1;
        CT_MauBangBaoCaoListH CT_BangCanDoi1List;

        BangCanDoiKeToanListH _bangCanDoiList;
        BangCanDoiKeToanH _bangCanDoi;
        CT_MauBangBaoCaoListH _CTBangCanDoiList;

        private byte _checkUpdateMucCha = 0;
        private bool indicatorIcon = true;

        public frmBangCanDoiKeToanChoThongTu(int id)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _iD = id;
            this.Load += frmBangCanDoiKeToanChoThongTu_Load;
            this.btnThemMoi.ItemClick += btnThemMoi_ItemClick;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.btnXoa.ItemClick += btnXoa_ItemClick;
            this.btnThemChiTiet.Click += btnThemChiTiet_Click;
            this.btnThoat.ItemClick += btnThoat_ItemClick;
            this.btnCopy.ItemClick += btnCopy_ItemClick;
            gvBangCanDoi.FocusedRowChanged += gvBangCanDoi_FocusedRowChanged;
            gvBangCanDoi.MouseDown += gvBangCanDoi_MouseDown;
            this.gvBangCanDoi.CustomDrawRowIndicator +=gvBangCanDoi_CustomDrawRowIndicator;
            this.gvBangCanDoi.RowCountChanged += gvBangCanDoi_RowCountChanged;
        }

        void gvBangCanDoi_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                GridView gridview = ((GridView)sender);
                if (!gridview.GridControl.IsHandleCreated) return;
                Graphics gr = Graphics.FromHwnd(gridview.GridControl.Handle);
                SizeF size = gr.MeasureString(gridview.RowCount.ToString(), gridview.PaintAppearance.Row.GetFont());
                gridview.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 14;
            }
            catch
            { 
            
            }
        }

        void gvBangCanDoi_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    string sText = (e.RowHandle + 1).ToString();
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString(sText, e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    e.Info.DisplayText = sText;
                }
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;

                if (e.RowHandle == GridControl.InvalidRowHandle)
                {
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString("STT", e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = "STT";
                    e.Info.Appearance.Font = new Font(e.Info.Appearance.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
            }
        }

        void gvBangCanDoi_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hi= view.CalcHitInfo(e.Location);
            if (hi.RowHandle >= 0)
            {
                string a = gvBangCanDoi.GetRowCellValue(hi.RowHandle,"MaMucTaiKhoan").ToString();
                _maMucTaikhoan = Convert.ToInt32(a);
            }
        }

        void gvBangCanDoi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (e.FocusedRowHandle >= 0)
            //{
            //    string a = gvBangCanDoi.GetFocusedRowCellValue("MaMucTaiKhoan").ToString();
            //    _maMucTaikhoan = Convert.ToInt32(a);
            //}
        }

        void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThongTuApDung1 _frmThongTuApDung1 = new frmThongTuApDung1(Convert.ToByte(1));
            _frmThongTuApDung1.ShowDialog();
            if (_frmThongTuApDung1._checkOK == DialogResult.OK)
            {

                _bangCanDoiList = BangCanDoiKeToanListH.NewBangCanDoiKeToanListH();
                BangCanDoiKeToanListH listForCopy = BangCanDoiKeToanListH.GetBangCanDoiKeToanListH(_frmThongTuApDung1._TT);

                foreach(BangCanDoiKeToanH bangCopy in listForCopy)
                {
                    BangCanDoiKeToanH bangCanDoiKeToan = BangCanDoiKeToanH.NewBangCanDoiKeToanChildH(bangCopy);
                    //if (_isNHNN == 1)
                    //{
                    //    bangCanDoiKeToan.isNHNN = DBNull.Value;
                    //}
                    //else if (_isNHNN == 0)
                    //{
                    //    bangCanDoiKeToan.isNHNN = 0;
                    //}
                    bangCanDoiKeToan.MaThongTu = _iD;
                    _bangCanDoiList.Add(bangCanDoiKeToan);
                }
                tblBangCanDoi.DataSource = _bangCanDoiList;

                BangCanDoiKeToanH bangCDKTCha = BangCanDoiKeToanH.NewBangCanDoiKeToanH();
                BangCanDoiKeToanListH _bangCanDoiListCha = BangCanDoiKeToanListH.NewBangCanDoiKeToanListHLoadMucCha(_frmThongTuApDung1._TT);
                _bangCanDoiListCha.Insert(0, bangCDKTCha);
                tblMucCha.DataSource = _bangCanDoiListCha;
                lueTaiKhoanCha.Properties.DataSource = tblMucCha;

                glue_MaTaiKhoanCha.DataSource = tblMucCha;
                glue_MaTaiKhoanCha.DisplayMember = "TenMucTaiKhoan";
                glue_MaTaiKhoanCha.ValueMember = "MaMucTaiKhoan";

                btnLuu_ItemClick(sender, e);

            }


        }


        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            frmCT_BangCanDoiKeToan1 dlg = new frmCT_BangCanDoiKeToan1((BangCanDoiKeToanH)(tblBangCanDoi.Current));
            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }

        void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gvBangCanDoi.GetFocusedRow() != null)
                {
                    //BangCanDoiKeToanListH _checkChaBCD = BangCanDoiKeToanListH.GetBangCanDoiKeToanListHCheckCha(_maMucTaikhoan);
                    //if (_checkChaBCD.Count == 0)
                    //{
                        BangCanDoiKeToanListH _bangCanDoiListCheck = BangCanDoiKeToanListH.GetBangCanDoiKeToanListHCheckChild(_maMucTaikhoan);
                        if (_bangCanDoiListCheck.Count != 0)
                        {
                            DialogResult result = MessageBox.Show(this, "Tài khoản có tài khoản con đang sử dụng ?? !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (result == DialogResult.OK)
                                //gvBangCanDoi.DeleteSelectedRows();
                            //else
                                return;
                        }
                        else
                            gvBangCanDoi.DeleteSelectedRows();
                    //}
                }
                else
                {
                    MessageBox.Show("Vui Lòng chọn dòng cần xóa!");
                }
            }
            catch { }
        }

        void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                _bangCanDoiList.ApplyEdit();
                tblBangCanDoi.EndEdit();
                _bangCanDoiList.Save();

                if (_checkUpdateMucCha == 1)
                {
                    _bangCanDoiList.UpdateMucCha(_iD);
                    btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

                LoadMucCha();
                _bangCanDoiList = BangCanDoiKeToanListH.GetBangCanDoiKeToanListH(_iD);
                tblBangCanDoi.DataSource = _bangCanDoiList;
                gcBangCanDoi.DataSource = tblBangCanDoi;

                MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không thể lưu");
            }
        }

        void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //_bangCanDoi = BangCanDoiKeToanH.NewBangCanDoiKeToanH();
                _bangCanDoi = BangCanDoiKeToanH.NewBangCanDoiKeToanHChild();
                _bangCanDoi.MaThongTu = _iD;
                _bangCanDoiList.Insert(0, _bangCanDoi);
                tblBangCanDoi.DataSource = _bangCanDoiList;
                gcBangCanDoi.DataSource = tblBangCanDoi;
                gvBangCanDoi.MoveFirst();
                txtMaSo.Focus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboSPGrid()
        {
            var editor = (RepositoryItemGridLookUpEdit)gcBangCanDoi.RepositoryItems.Add("GridLookUpEdit");
            editor.DataSource = tblBangCanDoi;
            editor.ValueMember = "MaMucTaiKhoanCha";
            editor.DisplayMember = "TenMucTaiKhoanCha";

            gvBangCanDoi.Columns["TenMucTaiKhoanCha"].ColumnEdit = editor;
            //gridView1.Columns["MaSP"].Visible = false;
        }

        private void LoadMucCha()
        {
            BangCanDoiKeToanH bangCDKTCha = BangCanDoiKeToanH.NewBangCanDoiKeToanH();
            BangCanDoiKeToanListH _bangCanDoiListCha = BangCanDoiKeToanListH.NewBangCanDoiKeToanListHLoadMucCha(_iD);
            _bangCanDoiListCha.Insert(0, bangCDKTCha);
            tblMucCha.DataSource = _bangCanDoiListCha;
            lueTaiKhoanCha.Properties.DataSource = tblMucCha;
        }

        void frmBangCanDoiKeToanChoThongTu_Load(object sender, EventArgs e)
        {
            //int loaiChungTu = 0;
            //long maChungTu = 0;
            //bool isShowFromReport = true;
            //switch (loaiChungTu)
            //{
            //    case 2:
            //        PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu, isShowFromReport);
            //        frm.WindowState = FormWindowState.Maximized;
            //        frm.ShowDialog();
            //        break;
            //    default:
            //        MessageBox.Show("Không tìm thấy Form chứng từ");
            //        break;
            //}

            try
            {
                LoadMucCha();
                gvBangCanDoi.OptionsBehavior.ReadOnly = true;
                btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                _bangCanDoiList = BangCanDoiKeToanListH.GetBangCanDoiKeToanListH(_iD);
                tblBangCanDoi.DataSource = _bangCanDoiList;
                gcBangCanDoi.DataSource = tblBangCanDoi;
                if (tblBangCanDoi.Count == 0)
                {
                    btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    _checkUpdateMucCha = 1;
                    lueTaiKhoanCha.EditValue = 1;
                }


                gvBangCanDoi.Columns["MaSo"].Caption = "Mã số";
                gvBangCanDoi.Columns["TenMucTaiKhoan"].Caption = "Tên mục tài khoản";
                gvBangCanDoi.Columns["ThuyetMinh"].Caption = "Thuyết minh";
                gvBangCanDoi.Columns["TenMucTaiKhoanCha"].Caption = "Tên mục tài khoản cha";
                gvBangCanDoi.Columns["TenTaiKhoan"].Caption = "Tên tài khoản";
                gvBangCanDoi.Columns["CapMuc"].Caption = "Cấp";
                gvBangCanDoi.Columns["MaMucTaiKhoanCha"].Caption = "Mã mục tài khoản cha";

                //cboSPGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            

        }

        private void btnThemChiTiet_Click_1(object sender, EventArgs e)
        {

        }


    }
}
