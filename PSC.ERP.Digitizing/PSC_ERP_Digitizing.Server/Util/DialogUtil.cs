using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraSplashScreen;
//using ERP_Common.CustomDiaglog;
using System.Threading;

namespace PSC_ERP_Digitizing.Server.Util
{
    public static class DialogUtil
    {


        public static AutoWaitForm Wait()
        {
            //return new WaitDialogForm("Đang xử lý...", "Vui lòng chờ!");
            return new AutoWaitForm("Đang xử lý...", "Vui lòng chờ!");
        }

        public static AutoWaitForm Wait(Form parentForm)
        {//
            return new AutoWaitForm(parentForm, "Đang xử lý...", "Vui lòng chờ!");
        }
        public static AutoWaitForm Wait(String message, String title)
        {
            return new AutoWaitForm(message, title);
        }
        public static AutoWaitForm Wait(Form parentForm, String message, String title)
        {//
            return new AutoWaitForm(parentForm, message, title);
        }



        public static AutoWaitForm WaitForSave(String message = "")
        {
            return new AutoWaitForm(String.Format("Đang lưu {0}...", message), "Vui lòng chờ!");
        }

        public static AutoWaitForm WaitForSave(Form parentForm, String message = "")
        {//
            return new AutoWaitForm(parentForm, String.Format("Đang lưu {0}...", message), "Vui lòng chờ!");
        }

        public static AutoWaitForm WaitForDelete(String message = "")
        {
            return new AutoWaitForm(String.Format("Đang xóa {0}...", message), "Vui lòng chờ!");
        }
        public static AutoWaitForm WaitForDelete(Form parentForm, String message = "")
        {//
            return new AutoWaitForm(parentForm, String.Format("Đang xóa {0}...", message), "Vui lòng chờ!");
        }

        public static DialogResult ShowYesNo(String message, String title = "Hỏi ý kiến")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowOk(String message, String title = "Thông tin")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowOkCancel(String message, String title = "Hỏi ý kiến")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowYesNoCancel(String message, String title = "Hỏi ý kiến")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowInfo(String message, String title = "Thông tin")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowWarning(String message, String title = "Cảnh báo")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowError(String message, String title = "Thông báo lỗi")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowNotExistChungTu()
        {
            return ShowError("Chứng từ không tồn tại");
        }
        public static DialogResult ShowEmptyListInfo()
        {
            return ShowInfo("Danh sách rỗng");
        }
        public static DialogResult ShowDaKhoaSoTSCD(DateTime ngay)
        {
            return ShowError(String.Format("Ngày {0} nằm trong giai đoạn khóa sổ TSCĐ", ngay.ToString("dd/MM/yyyy")));
        }public static DialogResult ShowSaveSuccessful(String message = "Lưu thành công")
        {
            return ShowInfo(message);
        }

        public static DialogResult ShowNotSaveSuccessful(String message = "Không lưu được")
        {
            return ShowError(message);
        }

        public static DialogResult ShowDataIsNotValid(String message = "Dữ liệu không hợp lệ!")
        {
            return ShowError(message);
        }
        public static DialogResult ShowDelete(Form owner, String message = "Bạn muốn xóa [{0}]?")
        {
            return ShowYesNoCancel(String.Format(message, owner.Text));
        }

        public static DialogResult ShowDeleteSuccessful(String message = "Đã xóa thành công")
        {
            return ShowInfo(message);
        }
        public static DialogResult ShowNotDeleteSuccessful(String message = "Không xóa được")
        {
            return ShowError(message);
        }
        public static DialogResult ShowSaveRequireOptions(Form owner, String message = "Bạn cần lưu [{0}]?")
        {
            return ShowYesNoCancel(String.Format(message, owner.Text));
        }
        public static DialogResult ShowSaveRequireOptionsOnFormClosing(Form owner, String message = "Bạn cần lưu [{0}] trước khi đóng?")
        {
            return ShowYesNoCancel(String.Format(message, owner.Text));
        }

        public static void OpenFilePrompt(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở tập tin '{0}'?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

    }
}
