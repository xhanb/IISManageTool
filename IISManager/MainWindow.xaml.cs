using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using IISHelpLib;

namespace IISManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public delegate void ShowMsgEventHandler(string msg, int type);
        public MainWindow()
        {
            InitializeComponent();
            LbSysInfo.Content = "系统版本：" + SysInfo.GetSystemInfo();//系统信息
            LbNetFrameWorkInfo.Content = "已安装.NET Framework版本：" + SysInfo.GetDotNetVersions();
            LbiisInfo.Content = "IIS版本：" + IISManagement.GetIIsVersion();//IIS版本
            ShowMsgEventHandler showMsgEvent = ShowMsg;
            SitePublishGrid.Children.Add(new SitePublishUserControl(showMsgEvent));
            GridSiteManage.Children.Add(new SiteManage());
        }
        public void ShowMsg(string msg, int type)
        {
            var winMsg = new WinMsg(msg, type) { Owner = this, Topmost = true };
            winMsg.Show();
        }


        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }

        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {

            WindowState = WindowState.Minimized;
        }



        private void BtnOption_Click(object sender, RoutedEventArgs e)
        {
            PopupControl.IsOpen = !PopupControl.IsOpen;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainGrid.Background = new SolidColorBrush(Colors.Blue);
        }
    }
}
