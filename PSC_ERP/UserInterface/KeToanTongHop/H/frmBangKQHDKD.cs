using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
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
    public partial class frmBangKQHDKD : Form
    {
        BangKQHDKDH _bangKQ;
        BangKQHDKDHList _bangKQList;
        private int _thongTu = 0;
        private int _loaiBM = 0;
        private bool indicatorIcon = true;

        public frmBangKQHDKD(int tt,int loaibm)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.btnThemChiTiet.Click += btnThemChiTiet_Click;
            this.btnThemMoi.ItemClick += btnThemMoi_ItemClick;
            this.btnXoa.ItemClick += btnXoa_ItemClick;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.lueLoaiMuc.TextChanged += lueLoaiMuc_TextChanged;
            this.btnCopy.ItemClick += btnCopy_ItemClick;
            this.gvBangKQHDKD.CustomDrawRowIndicator +=gvBangKQHDKD_CustomDrawRowIndicator;
            this.gvBangKQHDKD.RowCountChanged += gvBangKQHDKD_RowCountChanged;
            this.btnThoat.ItemClick += btnThoat_ItemClick;

            _thongTu = tt;
            _loaiBM = loaibm;
            Ini();
        }

        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void gvBangKQHDKD_RowCountChanged(object sender, EventArgs e)
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

        void gvBangKQHDKD_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThongTuApDung1 _frmThongTuApDung1 = new frmThongTuApDung1(Convert.ToByte(1));
            if (_frmThongTuApDung1.ShowDialog() != DialogResult.OK)
            {

                _bangKQList = BangKQHDKDHList.NewBangKQHDKDHList();
                BangKQHDKDHList listForCopy = BangKQHDKDHList.GetBangKQHDKDHList(Convert.ToByte(_loaiBM), _frmThongTuApDung1._TT);

                foreach (BangKQHDKDH bangCopy in listForCopy)
                {
                    BangKQHDKDH bangKQ = BangKQHDKDH.NewBCKQHDKDChildH(bangCopy, Convert.ToByte(_loaiBM));
                    //if (_isNHNN == 1)
                    //{
                    //    bangCanDoiKeToan.isNHNN = DBNull.Value;
                    //}
                    //else if (_isNHNN == 0)
                    //{
                    //    bangCanDoiKeToan.isNHNN = 0;
                    //}
                    bangKQ.MaThongTu = _thongTu;
                    _bangKQList.Add(bangKQ);
                }
                tblBangKQKDHD.DataSource = _bangKQList;
                btnLuu_ItemClick(sender, e);
            }
        }

        void lueLoaiMuc_TextChanged(object sender, EventArgs e)
        {
            label1.Text = lueLoaiMuc.Text;
        }

        void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _bangKQList.ApplyEdit();
                tblBangKQKDHD.EndEdit();
                _bangKQList.Save();

                btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                _bangKQList = BangKQHDKDHList.GetBangKQHDKDHList(Convert.ToByte(_loaiBM), _thongTu);
                tblBangKQKDHD.DataSource = _bangKQList;
                gcBangKQHDKD.DataSource = tblBangKQKDHD;

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
                if (gvBangKQHDKD.GetFocusedRow() != null)
                {
                    gvBangKQHDKD.DeleteSelectedRows();
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
                _bangKQ = BangKQHDKDH.NewBangKQHDKDH();
                _bangKQ.MaThongTu = _thongTu;
                _bangKQ.LoaiBaoCao = Convert.ToByte(_loaiBM);
                _bangKQList.Insert(0, _bangKQ);
                gvBangKQHDKD.MoveFirst();
                txtMaSo.Focus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            frmCT_BangCanDoiKeToan1 dlg = new frmCT_BangCanDoiKeToan1((BangKQHDKDH)(tblBangKQKDHD.Current));
            dlg.ShowDialog();
        }

        private void Ini()
        {
            try
            {
                btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                tblLoaiMuc.DataSource = DTLoaiMuc();


                lueLoaiMuc.Properties.DataSource = tblLoaiMuc;
                lueLoaiMuc.Properties.ValueMember = "Ma";
                lueLoaiMuc.Properties.DisplayMember = "Ten";

                gvBangKQHDKD.OptionsBehavior.ReadOnly = true;
                _bangKQList = BangKQHDKDHList.GetBangKQHDKDHList(Convert.ToByte(_loaiBM), _thongTu);
                tblBangKQKDHD.DataSource = _bangKQList;
                gcBangKQHDKD.DataSource = tblBangKQKDHD;

                if (tblBangKQKDHD.Count == 0)
                {
                    btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    lueLoaiMuc.ItemIndex = 0;
                }

                gvBangKQHDKD.Columns["LoaiBaoCao"].Visible = false;
                gvBangKQHDKD.Columns["MaMucCha"].Visible = false;
                //gvBangKQHDKD.Columns["isNHNN"].Visible = false;
                gvBangKQHDKD.Columns["MaThongTu"].Visible = false;
                gvBangKQHDKD.Columns["MaMucDoiUng"].Visible = false;
                gvBangKQHDKD.Columns["DienGiai"].Visible = false;
                gvBangKQHDKD.Columns["MaMuc"].Visible = false;

                gvBangKQHDKD.Columns["TenMuc"].Caption = "Tên mục";
                gvBangKQHDKD.Columns["ThuyetMinh"].Caption = "Thuyết minh";
                gvBangKQHDKD.Columns["Loai"].Caption = "Loại";
                gvBangKQHDKD.Columns["MaSo"].Caption = "Mã số";


                repositoryItemGridLookUpEdit2.DataSource = tblLoaiMuc;
                repositoryItemGridLookUpEdit2.ValueMember = "Ma";
                repositoryItemGridLookUpEdit2.DisplayMember = "Ten";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        
        }

        public DataTable DTLoaiMuc()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Ma");
            dt.Columns.Add("Ten");
            dt.Rows.Add("0", "Không có");
            dt.Rows.Add("1", "Tính theo mã tài khoản");
            dt.Rows.Add("2", "Tính từ mục khác");
            return dt;
        }



    }
}
