/* ==============================
*
* Author: 高海波
* Time：2015/8/26 8:46:08
* FileName：CWindow
* 说明:
* ===============================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using IISControls.Util;

namespace IISControls.Controls
{
    public class CWindow : Window
    {
        public CWindow()
        {
            this.DefaultStyleKey = typeof(CWindow);

            ////缩放，最大化修复
            //var wh = new WindowBehaviorHelper(this);
            //wh.RepairBehavior();

            MouseLeftButtonDown += DazzleWindow_MouseLeftButtonDown;
        }

        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);
        //    AeroGlass.ExtendGlassFrame(this, new Thickness(-1));
        //}

        void DazzleWindow_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
