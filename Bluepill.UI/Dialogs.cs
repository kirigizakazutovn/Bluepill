using System;
using System.Diagnostics;
using WindowsFormsAero.TaskDialog;

namespace Bluepill.UI
{
    public static class Dialogs
    {
        public static void ShowExceptionDialog(Exception ex)
        {
            var dlg = new TaskDialog("Có lỗi đã xảy ra trong lúc chạy V7Tool", "V7Tool", "Có lỗi đã xảy ra và V7Tool không thể xử lý được. Nếu máy tính của bạn đang ở Chế độ Setup, máy tính của bạn sẽ khởi động lại ở chế độ bình thường. Nếu bạn đã mở OOBE trong/trước Setup, bạn sẽ phải cài đặt lại Windows.", CommonButton.Close, CommonIcon.Stop);
            dlg.ShowExpandedInfoInFooter = true;
            dlg.ExpandedControlText = "Details";
            dlg.ExpandedInformation = ex.ToString();

            dlg.Show();
        }

        public enum Choices
        {
            Install,
            Uninstall,
            ViewStatus,
            Close
        }

        public static Choices ShowChoiceDialog()
        {
            TaskDialog dlg = new TaskDialog("Bạn đang muốn làm gì dợ?", "V7Tool");
            dlg.CommonIcon = CommonIcon.None;
            dlg.Content = "Vui lòng chọn 1 lựa chọn bạn muốn";
            dlg.UseCommandLinks = true;
            dlg.EnableHyperlinks = true;
            dlg.AllowDialogCancellation = false;
            dlg.CustomButtons = new CustomButton[] {
                new CustomButton(9, "Cài đặt V7Tool"),
                new CustomButton(10, "Gỡ cài đặt V7Tool"),
                new CustomButton(11, "Xem trạng thái của V7Tool"),
                new CustomButton(CommonButtonResult.Cancel, "Thoát V7Tool")
            };

            TaskDialogResult results = dlg.Show();

            switch (results.ButtonID)
            {
                case 9:
                    {
                        return Choices.Install;
                    }
                case 10:
                    {
                        return Choices.Uninstall;
                    }
                case 11:
                    {
                        return Choices.ViewStatus;
                    }
                default:
                    {
                        return Choices.Close;
                    }
            }
        }
    }
}
