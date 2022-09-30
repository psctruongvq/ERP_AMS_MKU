using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;

namespace PSC_ERP.UserInterface.KeToanTongHop
{
    public partial class frmKiemTraSoLieu : Form
    {

        BoPhanList _boPhanList;
        HeThongTaiKhoan1List _heThongTaiKhoan1List;
        ChungTuList _chungTuList;

        public frmKiemTraSoLieu()
        {
            InitializeComponent();
            KhoiTao();
        }
        public void KhoiTao()
        {
            _boPhanList = BoPhanList.GetBoPhanListByAll();
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0, itemBoPhan);
            BoPhanList_bindingSource.DataSource = _boPhanList;

            _heThongTaiKhoan1List = HeThongTaiKhoan1List.GetHeThongTaiKhoan1List();
            HeThongTaiKhoan1 hethongtaikhoan = HeThongTaiKhoan1.NewHeThongTaiKhoan1("Tất Cả");
            _heThongTaiKhoan1List.Insert(0,hethongtaikhoan);
            TaiKhoanList_bindingSource.DataSource = _heThongTaiKhoan1List;
            


        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            _chungTuList = ChungTuList.GetChungTuListByQuanTri(dtp_TuNgay.Value.Date, dtp_DenNgay.Value.Date, cbu_SoHieuTK.Value.ToString(), Convert.ToInt32(cmbu_Bophan.Value));
            ChungTuList_bindingSource.DataSource = _chungTuList;
        }
    }
}
