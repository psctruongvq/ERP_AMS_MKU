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

namespace PSC_ERP.UserInterface.NhanSu.QuanLyDaoTao
{
    public partial class frmDonViDaoTaoList : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        private int _MaDonViDaoTao=0;
        private DonViDaoTaoList _donViDaoTaoList;

        private bool _tuUsercontrol = false;

        private DonViDaoTao _donViDaoTao;

        public DonViDaoTao DVDaoTao
        {
            get
            {
                return _donViDaoTao;
            }
        }

        
        public int MaDonViDaoTao
        {
        	get	{ return _MaDonViDaoTao; }
        }
        
#endregion

        #region Functions

        private void LoadData()
        {
            GetDieuKienTim();
            _donViDaoTaoList = DonViDaoTaoList.GetDonViDaoTaoList();
            bsDonViDaoTaoList.DataSource = _donViDaoTaoList;
        }

        private void FormatForm()
        {
            if(_tuUsercontrol)
            {
                //btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void LoadDataBindingSource()
        {
            FormatForm();
            DesignGrid();

        }

        private void GetDieuKienTim()
        {

        }

        private void DesignGrid()
        {

            gridControl1.DataSource = bsDonViDaoTaoList;
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(gridView1, new string[] { "MaQuanLy", "TenDonViDaoTao" },
                                new string[] { "Mã Quản Lý", "Tên Đơn vị tổ chức đào tạo" },
                                             new int[] { 100, 250 },true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaQuanLy", "TenDonViDaoTao" }, DevExpress.Utils.HorzAlignment.Center);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);

            //gridView1.MouseEnter += new System.EventHandler(this.gridView1_MouseEnter);
            
        }
        #endregion

        #region Event
        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                DonViDaoTao donViDaoTao = gridView1.GetFocusedRow() as DonViDaoTao;
                if(donViDaoTao!=null)
                {
                    _donViDaoTao = DonViDaoTao.GetDonViDaoTao(donViDaoTao.MaDonViDaoTao);
                    if (_tuUsercontrol)
                    {
                        _MaDonViDaoTao = _donViDaoTao.MaDonViDaoTao;
                        this.Close();
                    }
                    else
                    {
                        frmDonViDaoTao frm = new frmDonViDaoTao();
                        frm.LoadData(_donViDaoTao);
                        if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        {
                            LoadData();

                        }//New

                    }   
                }
                

            }
        }


        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDonViDaoTao frm = new frmDonViDaoTao();
            frm.LoadData(null);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                LoadData();

            }//New
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion
        public frmDonViDaoTaoList()
        {
            InitializeComponent();
            LoadDataBindingSource();
            LoadData();

        }
        public frmDonViDaoTaoList(bool tuUsercontrol)
        {
            InitializeComponent();
            _tuUsercontrol = tuUsercontrol;
            LoadDataBindingSource();
            LoadData();

        }

        

        

        

    }
}