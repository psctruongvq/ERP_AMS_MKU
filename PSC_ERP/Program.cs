using System;
using System.Windows.Forms;
using Infragistics.Shared;
using System.Globalization;
//using System.Globalization.CultureInfo;
using ERP_Library;

namespace PSC_ERP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.tjtyjtjsds
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //System.Diagnostics.Debug.Assert(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //Application.CurrentCulture = Format_VN();
            Application.CurrentCulture = Format_VN();
            //Thread.CurrentThread.CurrentUICulture = Format_VN();
            SetUltragridResouce();
            Application.Run(new Main.frmMainTongHop());
            //Application.Run(new PSC_ERP.Main.frmTongHop());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //throw new NotImplementedException();
            //frmThongBaoLoiDuLieu frmthongbaoloi=new frmThongBaoLoiDuLieu();
            //frmthongbaoloi.Show();
        }
        public static void SetUltragridResouce()
        {
            Util util = new Util();
            ResourceCustomizer rc = Infragistics.Win.UltraWinGrid.Resources.Customizer;
            rc.SetCustomizedString("DeleteSingleRowMessageTitle", util.thongbao);
            rc.SetCustomizedString("DeleteRowsMessageTitle", util.thongbao);
            rc.SetCustomizedString("DeleteSingleRowPrompt", util.dongyxoacacdong);
            rc.SetCustomizedString("DeleteMultipleRowsPrompt", util.dongyxoa + " {0} " + util.dongnaykhong);
        }
        static CultureInfo Format_VN()
        {
            CultureInfo _formatculture = new CultureInfo("vi-VN");
            _formatculture.DateTimeFormat.DateSeparator = "/";
            _formatculture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            _formatculture.DateTimeFormat.LongDatePattern = "dddd, 'Ngày' dd 'tháng' MM 'năm' yyyy";

            _formatculture.DateTimeFormat.AbbreviatedDayNames = new string[] { "CN", "T2", "T3", "T4", "T5", "T6", "T7" };
            _formatculture.DateTimeFormat.ShortestDayNames = new string[] { "CN", "T2", "T3", "T4", "T5", "T6", "T7" };
            _formatculture.DateTimeFormat.DayNames = new string[] { "Chủ Nhật", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" };
            _formatculture.DateTimeFormat.AbbreviatedMonthGenitiveNames = new string[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12", "" };
            _formatculture.DateTimeFormat.MonthGenitiveNames = _formatculture.DateTimeFormat.AbbreviatedMonthNames;
            _formatculture.DateTimeFormat.MonthGenitiveNames = _formatculture.DateTimeFormat.AbbreviatedMonthNames;
            _formatculture.DateTimeFormat.MonthNames = _formatculture.DateTimeFormat.AbbreviatedMonthNames;
            _formatculture.DateTimeFormat.YearMonthPattern = "MMMM / 'năm' yyyy";
            //format số
            _formatculture.NumberFormat.NumberDecimalDigits = 0;
            _formatculture.NumberFormat.NumberDecimalSeparator = ",";
            _formatculture.NumberFormat.NumberGroupSeparator = ".";

            _formatculture.NumberFormat.CurrencyDecimalDigits = 0;
            _formatculture.NumberFormat.CurrencyDecimalSeparator = ",";
            _formatculture.NumberFormat.CurrencyGroupSeparator = ".";
            _formatculture.NumberFormat.CurrencySymbol = "";


            //-->
            return _formatculture;
        }

    }
}
