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
    public partial class frmBangLCTT : Form
    {
        BangKQHDKDH _bangKQ;
        BangKQHDKDHList _bangKQList;
        private int _loaiBM = 0;
        private int _thongTu = 0;
        private byte _checkUpdateMucCha = 0;
        private int _mMTK = 0;
        private bool indicatorIcon = true;

        public frmBangLCTT(int tt,int loai)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += frmBangLCTT_Load;
            this.btnThemMoi.ItemClick += btnThemMoi_ItemClick;
            this.btnXoa.ItemClick += btnXoa_ItemClick;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.btnThemChiTiet.Click += btnThemChiTiet_Click;
            this.lueLoaiMuc.TextChanged += lueLoaiMuc_TextChanged;
            this.lueMucCha.TextChanged += lueMucCha_TextChanged;
            _loaiBM = loai;
            _thongTu = tt;
            this.btnCopy.ItemClick += btnCopy_ItemClick;
            this.btnThoat.ItemClick += btnThoat_ItemClick;
            this.gvBangLCTT.MouseDown += gvBangLCTT_MouseDown;
            this.gvBangLCTT.CustomDrawRowIndicator +=gvBangLCTT_CustomDrawRowIndicator;
            this.gvBangLCTT.RowCountChanged += gvBangLCTT_RowCountChanged;
        }

        void gvBangLCTT_RowCountChanged(object sender, EventArgs e)
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

        void gvBangLCTT_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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


        void gvBangLCTT_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hi = view.CalcHitInfo(e.Location);
            if (hi.RowHandle >= 0)
            {
                string a = gvBangLCTT.GetRowCellValue(hi.RowHandle, "MaMuc").ToString();
                _mMTK = Convert.ToInt32(a);
            }
        }

        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThongTuApDung1 _frmThongTuApDung1 = new frmThongTuApDung1(Convert.ToByte(1));
            _frmThongTuApDung1.ShowDialog();
            if (_frmThongTuApDung1._checkOK == DialogResult.OK)
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
                
                BangKQHDKDH bangLCTT = BangKQHDKDH.NewBangKQHDKDH();
                _bangKQList = BangKQHDKDHList.GetBCKQHoatDongKinhDoanhListforLCTT(Convert.ToByte(_loaiBM), _thongTu);
                tblMucCha.DataSource = _bangKQList;
                lueMucCha.Properties.DataSource = tblMucCha;

                gvBangLCTT.OptionsBehavior.ReadOnly = true;
                _bangKQList = BangKQHDKDHList.GetBCKQHoatDongKinhDoanhListforLCTT(Convert.ToByte(_loaiBM), _thongTu);
                tblBangKQKDHD.DataSource = _bangKQList;
                gcBangLCTT.DataSource = tblBangKQKDHD;

                bCKQHoatDongKinhDoanhListBindingSource1.DataSource = _bangKQList;

            }
        }

        void lueMucCha_TextChanged(object sender, EventArgs e)
        {
            txtCol2.Text = lueMucCha.Text;
        }

        void lueLoaiMuc_TextChanged(object sender, EventArgs e)
        {
            txtCol1.Text = lueLoaiMuc.Text;
        }

        void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            frmCT_BangCanDoiKeToan1 dlg = new frmCT_BangCanDoiKeToan1((BangKQHDKDH)(tblBangKQKDHD.Current));
            dlg.ShowDialog();
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

        void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _bangKQList.ApplyEdit();
                tblBangKQKDHD.EndEdit();
                _bangKQList.Save();

                if (_checkUpdateMucCha == 1)
                {
                    _bangKQList.UpdateMucChaLCTT(_thongTu, _loaiBM);
                    btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                BangKQHDKDH bangLCTT = BangKQHDKDH.NewBangKQHDKDH();
                _bangKQList = BangKQHDKDHList.GetBCKQHoatDongKinhDoanhListforLCTT(Convert.ToByte(_loaiBM), _thongTu);
                _bangKQList.Insert(0, bangLCTT);
                tblMucCha.DataSource = _bangKQList;
                lueMucCha.Properties.DataSource = tblMucCha;

                _bangKQList = BangKQHDKDHList.GetBCKQHoatDongKinhDoanhListforLCTT(Convert.ToByte(_loaiBM), _thongTu);
                tblBangKQKDHD.DataSource = _bangKQList;
                gcBangLCTT.DataSource = tblBangKQKDHD;

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
                if (gvBangLCTT.GetFocusedRow() != null)
                {
                    BangKQHDKDHList _bangKQListCheckXoaCha = BangKQHDKDHList.GetBCKQHoatDongKinhDoanhListCheckCha(_mMTK, _thongTu, Convert.ToByte(_loaiBM));
                    if (_bangKQListCheckXoaCha.Count != 0)
                    {
                        DialogResult result = MessageBox.Show(this, "Tài khoản có tài khoản con đang sử dụng ?? !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                            //gvBangCanDoi.DeleteSelectedRows();
                            //else
                            return;
                    }
                    else
                        gvBangLCTT.DeleteSelectedRows();
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
                tblBangKQKDHD.DataSource = _bangKQList;
                gcBangLCTT.DataSource = tblBangKQKDHD;
                gvBangLCTT.MoveFirst();
                txtMaSo.Focus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void frmBangLCTT_Load(object sender, EventArgs e)
        {
            try
            {
                tblLoaiMuc.DataSource = DTLoaiMuc();

                lueLoaiMuc.Properties.DataSource = tblLoaiMuc;
                lueLoaiMuc.Properties.ValueMember = "Ma";
                lueLoaiMuc.Properties.DisplayMember = "Ten";

                BangKQHDKDH bangLCTT = BangKQHDKDH.NewBangKQHDKDH();
                _bangKQList = BangKQHDKDHList.GetBCKQHoatDongKinhDoanhListforLCTT(Convert.ToByte(_loaiBM), _thongTu);
                _bangKQList.Insert(0, bangLCTT);
                tblMucCha.DataSource = _bangKQList;
                lueMucCha.Properties.DataSource = tblMucCha;

                btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                //_bangKQList = BangKQHDKDHList.GetBCKQHoatDongKinhDoanhListforLCTT(Convert.ToByte(_loaiBM), _thongTu);
                //tblMucCha.DataSource = _bangKQList;

                gvBangLCTT.OptionsBehavior.ReadOnly = true;
                _bangKQList = BangKQHDKDHList.GetBCKQHoatDongKinhDoanhListforLCTT(Convert.ToByte(_loaiBM), _thongTu);
                tblBangKQKDHD.DataSource = _bangKQList;
                gcBangLCTT.DataSource = tblBangKQKDHD;

                if (tblBangKQKDHD.Count == 0)
                {
                    btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    _checkUpdateMucCha = 1;
                    lueLoaiMuc.ItemIndex = 0;
                    lueMucCha.EditValue = 1;
                }

                //_bangKQList = BangKQHDKDHList.GetBangKQHDKDHList(Convert.ToByte(_loaiBM), _thongTu);
                bCKQHoatDongKinhDoanhListBindingSource1.DataSource = _bangKQList;

                //gvBangLCTT.Columns["LoaiBaoCao"].Visible = false;
                //gvBangLCTT.Columns["MaMucCha"].Visible = false;
                //gvBangLCTT.Columns["isNHNN"].Visible = false;
                gvBangLCTT.Columns["MaThongTu"].Visible = false;

                gvBangLCTT.Columns["MaSo"].Caption = "Mã số";
                gvBangLCTT.Columns["TenMuc"].Caption = "Tên mục";
                gvBangLCTT.Columns["ThuyetMinh"].Caption = "Thuyết minh";
                gvBangLCTT.Columns["Loai"].Caption = "Loại";
                //gvBangLCTT.Columns["STTTinh"].Caption = "STTTinh";
                gvBangLCTT.Columns["DienGiai"].Caption = "Diễn giải";


                repositoryItemGridLookUpEdit2.DataSource = tblLoaiMuc;
                repositoryItemGridLookUpEdit2.ValueMember = "Ma";
                repositoryItemGridLookUpEdit2.DisplayMember = "Ten";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
