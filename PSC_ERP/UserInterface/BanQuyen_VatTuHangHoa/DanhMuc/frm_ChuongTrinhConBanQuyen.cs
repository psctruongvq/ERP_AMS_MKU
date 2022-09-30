using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.Data;
//3_04_13

namespace PSC_ERP
{
    public partial class frm_ChuongTrinhConBanQuyen : DevExpress.XtraEditors.XtraForm
    {
        //event update lookupedit
        #region Properties and Methods
        HangHoaBQ_VTList _hangHoaBQ_VTList;
        QuocGiaBQ_VTList _quocGiaList;
        ChuongTrinhBanQuyenConList _chuongTrinhBanQuyenConList;
        ChuongTrinhBanQuyenCon _chuongTrinhBanQuyenCon;
        int _maHangHoa = 0;
        string _maQLHangHoa = string.Empty;
        int _maChuongTrinhCon;
        bool _tuPhieu = false;
        public int MaChuongTrinhCon
        {
            get
            {
                return _maChuongTrinhCon;
            }
        }
        #endregion //Properties and Methods

        private void LoadForm()
        {
            bs_DSHangHoaListAll.DataSource = typeof(HangHoaBQ_VTList);
            bs_ChuongTrinhConBanQuyenList.DataSource = typeof(ChuongTrinhBanQuyenConList);

            _hangHoaBQ_VTList = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
            bs_DSHangHoaListAll.DataSource = _hangHoaBQ_VTList;
            _chuongTrinhBanQuyenConList = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList(_maHangHoa);
            bs_ChuongTrinhConBanQuyenList.DataSource = _chuongTrinhBanQuyenConList;
            _quocGiaList = QuocGiaBQ_VTList.GetQuocGiaBQ_VTList();
            QuocGiaBQ_VT qg = QuocGiaBQ_VT.NewQuocGiaBQ_VT("<<Không chọn>>");
            _quocGiaList.Insert(0, qg);
            bs_QuocGiaList.DataSource = _quocGiaList;
            bs_QuocGiaList1.DataSource = QuocGiaBQ_VTList.GetQuocGiaBQ_VTList();
            //
            lookUpEdit_MaHangHoa.EditValue = (object)_maHangHoa;
            lookUpEdit_MaHangHoa.Properties.ReadOnly = true;
        }


        public frm_ChuongTrinhConBanQuyen()
        {
            InitializeComponent();
            bs_QuocGiaList.DataSource = typeof(QuocGiaBQ_VTList);

        }
        public frm_ChuongTrinhConBanQuyen(int maHangHoa, string maQLHangHoa, bool tuPhieu)
        {
            InitializeComponent();
            _maHangHoa = maHangHoa;
            _maQLHangHoa = maQLHangHoa;
            _tuPhieu = tuPhieu;
            LoadForm();
            if (bs_ChuongTrinhConBanQuyenList.Count == 0)
            {
                btnThemMoi.PerformClick();
            }
        }


        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_maHangHoa != 0)
            {
                try
                {

                    _chuongTrinhBanQuyenCon = ChuongTrinhBanQuyenCon.NewChuongTrinhBanQuyenCon();
                    _chuongTrinhBanQuyenConList.Insert(0, _chuongTrinhBanQuyenCon);
                    _chuongTrinhBanQuyenCon.MaHangHoa = _maHangHoa;
                    _chuongTrinhBanQuyenCon.MaQLChuongTrinhCon = ChuongTrinhBanQuyenCon.SetMaQuanLyChuongTrinhCon(_maHangHoa, _maQLHangHoa);
                    txtDev_MaQLChuongTrinhCon.Focus();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            string _maQuanLy = "";
            if (txtDev_MaQLChuongTrinhCon.EditValue != null)
                _maQuanLy = txtDev_MaQLChuongTrinhCon.EditValue.ToString().Trim();
            int _lengthMaQL = _maQuanLy.Length;
            int _stt;
            bool _continue = false;
            if (gridView_ChuongTrinhBanQuyenCon.GetFocusedRow() != null)
            {
                if (_lengthMaQL >= 3 && int.TryParse(_maQuanLy.Substring(_lengthMaQL - 3, 3), out _stt))//IF 2
                {
                    _continue = true;
                }
                else
                {
                    _continue = false;
                    MessageBox.Show("Mã Chương Trình Không Hợp Lệ! 3 ký tự cuối phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDev_MaQLChuongTrinhCon.Focus();
                    return;
                }
            }
            else
            {
                _continue = true;
            }
            if (_continue)
            {
                bool ktphieutrung = true;
                if (_chuongTrinhBanQuyenCon.IsNew)
                {
                    ktphieutrung = ChuongTrinhBanQuyenCon.CheckMaQuanLyChuongTrinhKhongTrung(_chuongTrinhBanQuyenCon.MaChuongTrinhCon, _chuongTrinhBanQuyenCon.MaQLChuongTrinhCon, true);
                }
                else//k phai IS NEW
                {
                    ktphieutrung = ChuongTrinhBanQuyenCon.CheckMaQuanLyChuongTrinhKhongTrung(_chuongTrinhBanQuyenCon.MaChuongTrinhCon, _chuongTrinhBanQuyenCon.MaQLChuongTrinhCon, false);
                }

                if (ktphieutrung)//IF 5
                {
                    //GH
                    //B
                    try
                    {
                        _chuongTrinhBanQuyenConList.ApplyEdit();
                        bs_ChuongTrinhConBanQuyenList.EndEdit();
                        _chuongTrinhBanQuyenConList.Save();
                        MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //

                        //
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Không thể lưu");
                    }
                    //E
                }//END IF 5
                else
                {
                    MessageBox.Show("Trùng Mã Chương Trình ! Không Thể Lưu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDev_MaQLChuongTrinhCon.Focus();
                }
            }//END IF 2



        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                gridView_ChuongTrinhBanQuyenCon.DeleteSelectedRows();
            }
            catch
            {
                MessageBox.Show("Nhấn nút Refesh trước khi thực hiện thao tác Xóa");
            }

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            this.Close();

        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _chuongTrinhBanQuyenConList = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList(_maHangHoa);
            bs_ChuongTrinhConBanQuyenList.DataSource = _chuongTrinhBanQuyenConList;
            grd_ChuongTrinhBanQuyenCon.DataSource = bs_ChuongTrinhConBanQuyenList;
        }

        private void frm_ChuongTrinhConBanQuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (_chuongTrinhBanQuyenCon.IsDirty)
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn lưu sự chuyển đổi?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (kq == DialogResult.Yes)
                {
                    btnLuu.PerformClick();
                }
                else
                    if (kq == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
            }
        }

        private void frm_ChuongTrinhConBanQuyen_Load(object sender, EventArgs e)
        {
            if (bs_ChuongTrinhConBanQuyenList.Current != null)
            {
                _chuongTrinhBanQuyenCon = bs_ChuongTrinhConBanQuyenList.Current as ChuongTrinhBanQuyenCon;
            }
            else
            {
                _chuongTrinhBanQuyenCon = ChuongTrinhBanQuyenCon.NewChuongTrinhBanQuyenCon();
            }
            Utils.GridUtils.SetSTTForGridView(gridView_ChuongTrinhBanQuyenCon, 35);
        }

        private void gridView_ChuongTrinhBanQuyenCon_GotFocus(object sender, EventArgs e)
        {
            if (bs_ChuongTrinhConBanQuyenList.Current != null)
            {
                _chuongTrinhBanQuyenCon = bs_ChuongTrinhConBanQuyenList.Current as ChuongTrinhBanQuyenCon;
            }
        }

        private void QuocGiaList_repositoryItemGridLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void frm_ChuongTrinhConBanQuyen_Load_1(object sender, EventArgs e)
        {
            if (_tuPhieu)
            {
                btn_velaiCTCha.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btn_velaiCTCha.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void btn_velaiCTCha_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_tuPhieu)
            {
                if (bs_ChuongTrinhConBanQuyenList.Current != null)
                {
                    ChuongTrinhBanQuyenCon ct = bs_ChuongTrinhConBanQuyenList.Current as ChuongTrinhBanQuyenCon;
                    _maChuongTrinhCon = ct.MaChuongTrinhCon;
                }
                this.Close();
            }
        }


    }
}