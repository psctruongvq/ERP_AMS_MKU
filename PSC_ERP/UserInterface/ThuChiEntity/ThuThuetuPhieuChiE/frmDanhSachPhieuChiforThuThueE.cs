using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Model.Context;
using System.Linq;
using System.Data.Objects.DataClasses;


//04/04/2013
namespace PSC_ERP.ThuChiEntity
{
    public partial class frmDanhSachPhieuChiforThuThueE : DevExpress.XtraEditors.XtraForm
    {
        //private ChungTuThuChi_DerivedFactory _factory = null;
        Entities _context = null;
        tblChungTu _chungtu = null;
        long _maDoiTac;
        List<spd_SelectChungTuPhieuChiListforLapPhieuThu_Result> _ChungTuPhieuChiforLapPhieuThuList = new List<spd_SelectChungTuPhieuChiListforLapPhieuThu_Result>();
        List<tblPhieuThutuPhieuChi> _phieuThutuPhieuChiList = new List<tblPhieuThutuPhieuChi>();
        //List<tblPhieuThutuPhieuChi> _phieuThutuPhieuChiSelectedList = new List<tblPhieuThutuPhieuChi>();
        List<tblPhieuThutuPhieuChi> _PhieuThutuPhieuChiListDelete = null;

        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        private string _soChungtuPhieuChiString = string.Empty;
        bool _lockPhieuChi = false;
        public bool _trangThai = false;
        public decimal _tongTien = 0;
        private void LockPhieuChi()
        {
            grdv_ThongTinPhieuChi.Columns["Check"].OptionsColumn.AllowEdit = false;

        }
        void UnLockHopDong()
        {
            grdv_ThongTinPhieuChi.Columns["Check"].OptionsColumn.AllowEdit = true;
        }

        //public EntityCollection<tblPhieuThutuPhieuChi> PhieuThutuPhieuChiSelectedList
        //{
        //    get { return _chungtu.tblPhieuThutuPhieuChis; }
        //}//

        public List<tblPhieuThutuPhieuChi> PhieuThutuPhieuChiListDelete
        { get { return _PhieuThutuPhieuChiListDelete; } }

        public string SoChungtuPhieuChiString
        {
            get { return _soChungtuPhieuChiString; }
        }//

        public bool TrangThai { get { return _trangThai; } }

        public decimal TongTienChon { get { return _tongTien; } }

        private void DesignGrid()
        {
            //_factory = ChungTuThuChi_DerivedFactory.New();
            _ChungTuPhieuChiforLapPhieuThuList = _context.spd_SelectChungTuPhieuChiListforLapPhieuThu(_chungtu.MaChungTu, _maCongTy).ToList<spd_SelectChungTuPhieuChiListforLapPhieuThu_Result>();
            grd_PhieuChi.DataSource = _ChungTuPhieuChiforLapPhieuThuList;
            HamDungChung.InitGridViewDev(grdv_ThongTinPhieuChi, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(grdv_ThongTinPhieuChi, new string[] { "Check", "SoChungTu", "NgayLap", "TienThue" },
                                new string[] { "Chọn", "Số chứng từ", "Ngày lập", "Tiền thuế" },
                                             new int[] { 35, 100, 70, 90 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdv_ThongTinPhieuChi, new string[] { "Check", "SoChungTu", "NgayLap", "TienThue" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdv_ThongTinPhieuChi, new string[] { "TienThue" }, "{0:#,###.###}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(grdv_ThongTinPhieuChi, new string[] { "SoChungTu", "NgayLap" });

            Utils.GridUtils.SetSTTForGridView(grdv_ThongTinPhieuChi, 35);//M
            this.grdv_ThongTinPhieuChi.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdVChiTietThanhToan_CellValueChanged);

        }

        private void CustomizeCheckProperties(List<tblPhieuThutuPhieuChi> selectedList)
        {
            foreach (tblPhieuThutuPhieuChi selectedItem in selectedList)
            {
                int j = -1;
                for (int i = j + 1; i < _ChungTuPhieuChiforLapPhieuThuList.Count; i++)
                {
                    spd_SelectChungTuPhieuChiListforLapPhieuThu_Result ct = _ChungTuPhieuChiforLapPhieuThuList[i];
                    if (ct.MaChungTu == selectedItem.MaPhieuChi)
                    {
                        ct.Check = true;
                        ct.TienThue = selectedItem.SoTien;
                        j = i;
                    }
                }
            }
            grdv_ThongTinPhieuChi.RefreshData();

        }

        private void ProcessData()
        {
            for (int i = 0; i < _chungtu.tblPhieuThutuPhieuChis.ToList().Count; i++)
            {
                tblPhieuThutuPhieuChi itemOld = _chungtu.tblPhieuThutuPhieuChis.ToList().ElementAt<tblPhieuThutuPhieuChi>(i);
                bool notexist = true;
                foreach (tblPhieuThutuPhieuChi itemNew in _phieuThutuPhieuChiList)
                {
                    if (itemNew.MaPhieuChi == itemOld.MaPhieuChi)
                    {
                        notexist = false;
                        break;
                    }
                }
                if (notexist)
                {
                    _PhieuThutuPhieuChiListDelete.Add(itemOld);
                    _chungtu.tblPhieuThutuPhieuChis.Remove(itemOld);
                    i -= 1;
                }

            }
            foreach (tblPhieuThutuPhieuChi itemNew in _phieuThutuPhieuChiList)
            {
                bool notexist = true;
                foreach (tblPhieuThutuPhieuChi itemOld in _chungtu.tblPhieuThutuPhieuChis.ToList())
                {
                    if (itemNew.MaPhieuChi == itemOld.MaPhieuChi)
                    {
                        notexist = false;
                        break;
                    }
                }
                if (notexist)
                {
                    _chungtu.tblPhieuThutuPhieuChis.Add(itemNew);
                }
                   
            }
        }

        private void grdVChiTietThanhToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdv_ThongTinPhieuChi.FocusedColumn.FieldName == "TienThue")
            {
                spd_SelectChungTuPhieuChiListforLapPhieuThu_Result ct = grdv_ThongTinPhieuChi.GetFocusedRow() as spd_SelectChungTuPhieuChiListforLapPhieuThu_Result;
                decimal tienthueconlai = spd_SelectChungTuPhieuChiListforLapPhieuThu_Factory.GetTienThueConLai(ct.MaChungTu, _chungtu.MaChungTu);
                if (ct.TienThue > tienthueconlai)
                {
                    MessageBox.Show("Tiền thuế vượt quá tiền thuế còn lại của phiếu chi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    ct.TienThue = tienthueconlai;
                }
            }
        }
        public frmDanhSachPhieuChiforThuThueE()
        {
            InitializeComponent();
        }//

        public frmDanhSachPhieuChiforThuThueE(Entities context, tblChungTu chungtu, bool Lockphieuchi)
        {
            InitializeComponent();
            _context = context;
            _chungtu = chungtu;
            //_phieuThutuPhieuChiSelectedList = _chungtu.tblPhieuThutuPhieuChis.ToList();
            _lockPhieuChi = Lockphieuchi;
            _PhieuThutuPhieuChiListDelete = new List<tblPhieuThutuPhieuChi>();
            DesignGrid();
            CustomizeCheckProperties(_chungtu.tblPhieuThutuPhieuChis.ToList());
        }//


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _trangThai = false;
            this.Close();
        }//

        private void btn_ThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }//

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit_Focus.Focus();

            _trangThai = true;
            _tongTien = 0;
            for (int i = 0; i < _ChungTuPhieuChiforLapPhieuThuList.Count; i++)
            {
                spd_SelectChungTuPhieuChiListforLapPhieuThu_Result ct = _ChungTuPhieuChiforLapPhieuThuList[i];
                if (ct.Check)
                {
                    tblPhieuThutuPhieuChi pttupc = PhieuThuTuPhieuChi_Factory.New().CreateAloneObject();
                    pttupc.MaPhieuChi = ct.MaChungTu;
                    pttupc.SoChungTuPhieuChi = ct.SoChungTu;
                    pttupc.SoTien = ct.TienThue;
                    //new tblPhieuThutuPhieuChi { MaPhieuChi = ct.MaChungTu, SoChungTuPhieuChi = ct.SoChungTu, SoTien = ct.TienThue };
                    _phieuThutuPhieuChiList.Add(pttupc);
                    _tongTien += ct.TienThue.Value;
                }
            }
            ProcessData();
            _soChungtuPhieuChiString = PhieuThuTuPhieuChi_Factory.GetSoChungTuString(_phieuThutuPhieuChiList);

            this.Close();
        }

        private void CheckEdit_Chon_EditValueChanged(object sender, EventArgs e)
        {
            //HopDongMuaBan _hdmb = (HopDongMuaBan)HopDongMuaBanList_BindingSource.Current;
            //CheckEdit ch = (CheckEdit)sender;
            //_hdmb.Check = (bool)ch.EditValue;
        }

        private void frmChonHopDongLapPhieu_Load(object sender, EventArgs e)
        {
            if (_lockPhieuChi)
            {
                LockPhieuChi();
            }
            else
            {
                UnLockHopDong();
            }
        }//
    }
}