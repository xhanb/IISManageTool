using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using IISHelpLib;

namespace IISManager
{
    /// <summary>
    /// SiteManage.xaml 的交互逻辑
    /// </summary>
    public partial class SiteManage
    {
        private readonly DispatcherTimer _dispatcherTimer;
        public SiteManage()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += _dispatcherTimer_Tick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            _dispatcherTimer.Start();
        }
         
        void _dispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.DataContext = new ViewModel();
        }
    }
}
