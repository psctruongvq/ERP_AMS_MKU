using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP.Utils;

namespace PSC_ERPNew.Main
{
    public partial class frmTongHopTrichKhauHao_TichHopFAST : DevExpress.XtraEditors.XtraForm
    {
        List<spd_TongHopTrichKhauHao_TichHopFAST_Result> _tichHopFAST_Result = null;
        NghiepVuKhauHaoHaoMon_Factory _factory = NghiepVuKhauHaoHaoMon_Factory.New();
        internal int maKy;
        internal int maCongTy;

        public frmTongHopTrichKhauHao_TichHopFAST()
        {
            InitializeComponent();
        }
        public frmTongHopTrichKhauHao_TichHopFAST(object _tichHop, int _maKy, int _maCongTy)
        {
            InitializeComponent();
            if (_tichHop is List<spd_TongHopTrichKhauHao_TichHopFAST_Result>)
            {
                this._tichHopFAST_Result = (List<spd_TongHopTrichKhauHao_TichHopFAST_Result>)_tichHop;
            }

            this.maKy = _maKy;
            this.maCongTy = _maCongTy;
        }
        private void frmTongHopTrichKhauHao_TichHopFAST_Load(object sender, EventArgs e)
        {
            gridC_TichHopFast.DataSource = _tichHopFAST_Result;
        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            this.Dispose();
        }

        private void btnThucHienTichHop_Fast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string kiemTra = ERP_Library.PublicClass.KiemTraTichHopFast(maKy, maCongTy);
            if (kiemTra == "DaTichHop")
            {
                MessageBox.Show("Đã tồn tại dữ liệu tích hợp thành công. Không thể thực hiện thao tác!");
                return;
            }
            else if (kiemTra == "ChuaTichHop")
            {
                if (MessageBox.Show("Đã có dữ liệu trung gian, bạn có muốn thực hiện đẩy dữ liệu lại?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            _factory.Context.spd_TongHopTrichKhauHao_TichHopFAST(flag: "action", tuKy: maKy, maCongTy: maCongTy);
            XtraMessageBox.Show(this,
                                 $"<b>Đã tích hợp xong!</b>",
                                 "Tích hợp dữ liệu với Fast!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Question,
                                 DevExpress.Utils.DefaultBoolean.True);

            //if (XtraMessageBox.Show(this,
            //                    $"<b>Bạn có chắc chắn thực hiện thao tác tích hợp!</b>",
            //                    "Tích hợp dữ liệu với Fast!",
            //                    MessageBoxButtons.YesNo,
            //                    MessageBoxIcon.Question,
            //                    DevExpress.Utils.DefaultBoolean.True) == DialogResult.Yes)
            //{
            //     _factory.Context.spd_TongHopTrichKhauHao_TichHopFAST(flag: "action", tuKy: maKy, maCongTy: maCongTy);
            //    XtraMessageBox.Show(this,
            //                         $"<b>Đã tích hợp xong!</b>",
            //                         "Tích hợp dữ liệu với Fast!",
            //                         MessageBoxButtons.OK,
            //                         MessageBoxIcon.Question,
            //                         DevExpress.Utils.DefaultBoolean.True);
            //};


        }//end method

        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERP.HamDungChung.ExportToExcelFromGridViewDev(gridV_TichHopFast);
        }
    }
}