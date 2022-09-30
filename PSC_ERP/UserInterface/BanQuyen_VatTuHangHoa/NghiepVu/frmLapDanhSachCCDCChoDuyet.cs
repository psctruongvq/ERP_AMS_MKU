using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using ERP_Library.Security;
namespace PSC_ERP
{
    public partial class frmLapDanhSachCCDCChoDuyet : DevExpress.XtraEditors.XtraForm
    {
        #region Field
        BoPhanList _boPhanListAll = null;
        HangHoaBQ_VTList _hangHoaList = null;
        List<CCDCHienOPhongBan> _congCuDungCuList_Find = null;
        CongCuDungCuList _congCuDungCuList_dangChoDuyet = null;
        List<CCDCHienOPhongBan> _congCuDungCuList_vuaChon = null;
        #endregion
        #region Constructor

        public frmLapDanhSachCCDCChoDuyet()
        {
            InitializeComponent();
            InitForm();
            this.deNgayLap.DateTime = DateTime.Now.Date;
            this.LoadData();
        }
        #endregion

        #region Useful Method

        private void LoadData()
        {


            //danh sach hang hoa rong
            _hangHoaList = HangHoaBQ_VTList.NewHangHoaBQ_VTList();
            hangHoaBQVTListBindingSource_forCombo.DataSource = _hangHoaList;

            _boPhanListAll = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();//.GetBoPhanListBy_All();
            BoPhan boPhan_ChonTatCa = BoPhan.NewBoPhan();
            boPhan_ChonTatCa.TenBoPhan = "<<Tất cả>>";
            boPhan_ChonTatCa.MaBoPhanQL = "<<Tất cả>>";
            _boPhanListAll.Insert(0, boPhan_ChonTatCa);
            boPhanListAllBindingSource_forCombo.DataSource = _boPhanListAll;
        }
        public void ChangeFocus()
        {
            this.txtBlackHole1.Focus();
            this.txtBlackHole2.Focus();

        }

        private void TimDanhSachCCDCChoDuyet()
        {
            if (this.barEditItem_BoPhan.EditValue != null)//(repositoryItemGridLookUpEdit_BoPhan.Tag != null)
            {
                //
                int maBoPhan = (int)this.barEditItem_BoPhan.EditValue;//this.repositoryItemGridLookUpEdit_BoPhan.Tag;
                int maHangHoa = 0;

                if (this.barEditItem_HangHoa.EditValue != null) //(repositoryItemGridLookUpEdit_HangHoa.Tag != null)
                    maHangHoa = (int)this.barEditItem_HangHoa.EditValue;

                _congCuDungCuList_Find = CCDCHienOPhongBan.CreatCCDCHienOPhongBanList(maBoPhan, maHangHoa, this.deNgayLap.DateTime.Date);

                //RemoveCongCuDungCuDangChoDuyetRaKhoiDanhSachTim();

                this.bindingSource_CCDCHienOPhongBan.DataSource = _congCuDungCuList_Find;
                if (_congCuDungCuList_Find.Count == 0)
                {
                    MessageBox.Show("Danh sách rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn bộ phận trước khi tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, true, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "Check", "MaQLCCDC", "NgayNhan","SoChungTu", "TenCCDC", "NamHoatDong", "SoSerial", "NguyenGia", "TenBoPhan" },
                                new string[] { "Chọn", "Mã CCDC","Ngày nhận","Số chứng từ", "Tên công cụ dụng cụ ","Năm hoạt động", "Số serial", "Nguyên giá", "Bộ phhận" },
                                             new int[] { 80, 100,80,100, 150,90, 80, 100, 120 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "MaQLCCDC", "NgayNhan", "SoChungTu", "TenCCDC", "NamHoatDong", "SoSerial", "NguyenGia", "TenBoPhan" }, DevExpress.Utils.HorzAlignment.Center);
            gridView1.GroupPanelText = "Danh Sách Công Cụ Dụng Cụ Cần Thao Tác";

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            HamDungChung.FormatNumberTypeofColumnGridViewDev(gridView1, new string[] { "NguyenGia" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "NguyenGia" }, "#,###.#");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "MaQLCCDC", "TenCCDC", "SoSerial", "NguyenGia", "TenBoPhan" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "Check" });
            //this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView_ButToan_RowCellClick);
            //this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_ButToan_CellValueChanged);
            //this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_ButToan_KeyDown);
            //this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_ButToan_InitNewRow);
        }

        private void InitForm()
        {
            bindingSource_CCDCHienOPhongBan.DataSource = typeof(CCDCHienOPhongBan);
            gridControl1.DataSource = bindingSource_CCDCHienOPhongBan;
            DesignGridView();
        }

        #endregion

        #region Event Method

        private void repositoryItemGridLookUpEdit_BoPhan_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lookupEdit = sender as GridLookUpEdit;
            int maBoPhan = (int)lookupEdit.EditValue;

            this.barEditItem_HangHoa.EditValue = 0;
            //

            _hangHoaList = HangHoaBQ_VTList.GetHangHoaBQ_VTList_BoPhanDangSuDung(maBoPhan);
            HangHoaBQ_VT hangHoa_ChonTatCa = HangHoaBQ_VT.NewHangHoaBQ_VT();
            hangHoa_ChonTatCa.MaQuanLy = "<<Tất cả>>";
            hangHoa_ChonTatCa.TenHangHoa = "<<Tất cả>>";
            _hangHoaList.Insert(0, hangHoa_ChonTatCa);
            hangHoaBQVTListBindingSource_forCombo.DataSource = _hangHoaList;





        }

        private void repositoryItemGridLookUpEdit_HangHoa_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lookupEdit = sender as GridLookUpEdit;
            int maBoPhan = (int)lookupEdit.EditValue;

        }




        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ChangeFocus();
            TimDanhSachCCDCChoDuyet();
        }

        private void RemoveCongCuDungCuDangChoDuyetRaKhoiDanhSachTim()
        {
            ////can lay danh sach dang cho duyet da luu vao database
            //_congCuDungCuList_dangChoDuyet = CongCuDungCuList.GetCongCuDungCuList_DangChoDuyet();
            //foreach (CongCuDungCu item in _congCuDungCuList_dangChoDuyet)
            //{
            //    if(item.MaCongCuDungCu==
            //    _congCuDungCuList_Find.Remove(item);
            //}

        }

        private void RemoveCongCuDungCuVuaChonRaKhoiDanhSachTim()
        {
            foreach (CCDCHienOPhongBan item in _congCuDungCuList_vuaChon)
            {
                _congCuDungCuList_Find.Remove(item);
            }
        }


        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn lưu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.ChangeFocus();
                this.Save();

            }

        }
        private bool Save()
        {

            this.ChangeFocus();

            //kiem tra da dien du du lieu can thiet hay chua
            if (this.KiemTraDuDieuKienTruocKhiLuu() == false)
            {
                return false;
            }
            try
            {
                _congCuDungCuList_vuaChon = new List<CCDCHienOPhongBan>();
                DuyetCongCuDungCuList duyetList = DuyetCongCuDungCuList.NewDuyetCongCuDungCuList();
                foreach (CCDCHienOPhongBan ccdc in _congCuDungCuList_Find)
                {
                    if (ccdc.Check == true)
                    {
                        _congCuDungCuList_vuaChon.Add(ccdc);

                        DuyetCongCuDungCu duyet = DuyetCongCuDungCu.NewDuyetCongCuDungCu();
                        duyet.MaCongCuDungCu = ccdc.MaCCDC;
                        duyet.LoaiNghiepVu = (byte)this.radioGroupLoaiNghiepVu.EditValue;
                        duyet.MaUserLap = CurrentUser.Info.UserID;
                        duyet.NgayLap = this.deNgayLap.DateTime.Date;
                        duyetList.Add(duyet);
                    }
                }
                duyetList.Save();
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    this.RemoveCongCuDungCuVuaChonRaKhoiDanhSachTim();
                }
                catch (System.Exception ex)
                {

                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool KiemTraDuDieuKienTruocKhiLuu()
        {
            bool hopLe = true;

            if (this.radioGroupLoaiNghiepVu.EditValue == null || (byte)this.radioGroupLoaiNghiepVu.EditValue == 0)
            {
                MessageBox.Show("Vui lòng chọn loại nghiệp vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hopLe = false;
                return hopLe;
            }
            //
            {


                bool coCheckCCDC = false;
                foreach (CCDCHienOPhongBan ccdc in _congCuDungCuList_Find)
                {
                    if (ccdc.Check == true)
                    {
                        coCheckCCDC = true;
                        break;
                    }
                }
                if (coCheckCCDC == false)
                {
                    MessageBox.Show("Chưa chọn công cụ dụng cụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hopLe = false;
                    //ket thuc
                    return hopLe;
                }
            }

            return hopLe;
        }
        #endregion

        private void frmLapDanhSachCCDCChoDuyet_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ChangeFocus();
            bool coChon = false;
            if (_congCuDungCuList_Find != null)
            {
                foreach (CCDCHienOPhongBan item in _congCuDungCuList_Find)
                {
                    if (item.Check == true)
                    {
                        coChon = true;
                        break;
                    }
                }
            }
            if (_congCuDungCuList_Find != null && coChon == true)
            {
                bool coCheckChon = false;

                foreach (CCDCHienOPhongBan item in _congCuDungCuList_Find)
                {
                    if (item.Check == true)
                    {
                        coCheckChon = true;
                        break;
                    }

                }

                if (coCheckChon == true)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn lưu trước khi thoát?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (DialogResult.Yes == result)
                    {

                        if (this.Save() == false)
                            e.Cancel = true;
                    }
                    else if (DialogResult.No == result)
                    {

                    }
                    else if (DialogResult.Cancel == result)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void frmLapDanhSachCCDCChoDuyet_Load(object sender, EventArgs e)
        {
            //Utils.GridUtils.ConfigGridView(gridView_CongCuDungCuList
            //             , setSTT: true//
            //             , initCopyCell: false
            //             , multiSelectCell: false
            //             , multiSelectRow: false
            //             , initNewRowOnTop: false);

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void radioGroupLoaiNghiepVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool coChon = false;
            if (_congCuDungCuList_Find != null)
            {
                foreach (CCDCHienOPhongBan item in _congCuDungCuList_Find)
                {
                    if (item.Check == true)
                    {
                        coChon = true;
                        break;
                    }
                }
            }
            if (coChon)
            {
                this.btnTim.PerformClick();
            }

        }

        private void deNgayLap_Leave(object sender, EventArgs e)
        {
            if (deNgayLap.OldEditValue != deNgayLap.EditValue)
            {
                TimDanhSachCCDCChoDuyet();
            }
        }

        private void CheckAll_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CCDCHienOPhongBan ccdcC in _congCuDungCuList_Find)
            {
                ccdcC.Check = CheckAll_checkBox.Checked;
            }
            gridView1.RefreshData();
        }//end function



    }
}