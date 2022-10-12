using WindowsFormsAero.TaskDialog;

namespace Bluepill.UI.Aero
{
    public class Aero : BluepillProgressInterface
    {
        TaskDialog dlg;

        public void Close()
        {
            TaskDialog newDlg = new TaskDialog("Cài đặt thành công.", "V7Tool", "Tháo đĩa cài đặt V7Tool khỏi máy tính của bạn và khởi động lại. Ma thuật thần kì sẽ xuất hiện sau khi bạn khởi động lại PC! Cảm ơn bạn đã tin tưởng sử dụng sản phẩm này");
            newDlg.CustomButtons = new CustomButton[]
            {
                        new CustomButton(CommonButtonResult.Cancel, "Close")
            };
            dlg.Navigate(newDlg);
        }

        public void Initialize()
        {
            dlg = new TaskDialog("Đang cài đặt V7Tool", "V7Tool");
            dlg.AllowDialogCancellation = false;
            dlg.ShowProgressBar = true;
            dlg.ProgressBarMaxRange = 100;
            dlg.CustomButtons = new CustomButton[]
            {
                new CustomButton(CommonButtonResult.Cancel, "Hủy bỏ")
            };
            dlg.EnableButton(2, false);
        }

        public void ReportProgress(int ProgressPercentage, string StatusMessage)
        {
            dlg.Content = StatusMessage;
            dlg.ProgressBarPosition = ProgressPercentage;
            dlg.SetMarqueeProgressBar(ProgressPercentage == 0);
        }

        public void Show()
        {
            dlg.Show();
        }
    }
}
