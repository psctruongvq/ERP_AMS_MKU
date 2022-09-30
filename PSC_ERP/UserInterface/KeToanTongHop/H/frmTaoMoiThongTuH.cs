using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid;

namespace PSC_ERP
{
    public partial class frmTaoMoiThongTuH : DevExpress.XtraEditors.XtraForm
    {
        ThongTuApDung1 _thongTuApDung;
        ThongTuApDung1List _thongTuApDungList;

        BangCanDoiKeToanH _bangCanDoi;
        BangCanDoiKeToanListH _bangCanDoiList;
        KyList _kyList;

        private bool indicatorIcon = true;
        private int _TT = 0;


 
        public frmTaoMoiThongTuH()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += frmTaoMoiThongTuH_Load;
            this.btnThemMoi.ItemClick += btnThemMoi_ItemClick;
            this.btnXoa.ItemClick += btnXoa_ItemClick;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.btnThoat.ItemClick += btnThoat_ItemClick;
            this.gvThongTuNew1.MouseDown += gvThongTuNew1_MouseDown;
            this.gvThongTuNew1.CustomDrawRowIndicator += gvThongTuNew1_CustomDrawRowIndicator;
            this.gvThongTuNew1.RowCountChanged += gvThongTuNew1_RowCountChanged;
        }

        void gvThongTuNew1_RowCountChanged(object sender, EventArgs e)
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
            { }
        }
        void gvThongTuNew1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            //if (e.Info.IsRowIndicator) 
            //    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            //gvThongTuNew1.IndicatorWidth = 50;

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

        void gvThongTuNew1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                GridHitInfo hi = view.CalcHitInfo(e.Location);
                if (hi.RowHandle >= 0)
                {
                    string a = gvThongTuNew1.GetRowCellValue(hi.RowHandle,"Id").ToString();
                    _TT = Convert.ToInt32(a);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _thongTuApDungList.ApplyEdit();
                tblThongTuNew.EndEdit();
                _thongTuApDungList.Save();
                MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không thể lưu");
            }
        }

        void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gvThongTuNew1.GetFocusedRow() != null)
                {
                    BangCanDoiKeToanListH _Check = BangCanDoiKeToanListH.GetBangCanDoiKeToanListH(_TT);
                    BangKQHDKDHList _Check1 = BangKQHDKDHList.GetBangKQHDKDHListByTT(_TT);
                    if (_Check.Count != 0 || _Check1.Count != 0)
                    {
                        DialogResult result = MessageBox.Show(this, "Thông tư có dữ liệu?? !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                            //gvThongTuNew1.DeleteSelectedRows();
                        //else
                            return;
                    }
                    else
                        gvThongTuNew1.DeleteSelectedRows();
                }
                else
                {
                    MessageBox.Show("Vui Lòng chọn dòng cần xóa!");
                }
            }
            catch { }
        }

        void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _thongTuApDung = ThongTuApDung1.NewThongTuApDung1();
                //_thongTuApDung.NgayApDung = DateTime.Now;
                _thongTuApDungList.Insert(0, _thongTuApDung);
                tblThongTuNew.DataSource = _thongTuApDungList;
                gcThongTuNew1.DataSource = tblThongTuNew;
                gvThongTuNew1.MoveFirst();
                lueMaKy.Focus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void frmTaoMoiThongTuH_Load(object sender, EventArgs e)
        {
            _kyList = KyList.GetKyList();
            tblKy.DataSource = _kyList;

            gvThongTuNew1.OptionsBehavior.ReadOnly = true;
            _thongTuApDungList = ThongTuApDung1List.GetThongTuApDung1List();
            tblThongTuNew.DataSource = _thongTuApDungList;
        }

    }
}