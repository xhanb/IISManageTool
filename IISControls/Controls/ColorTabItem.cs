/* ==============================
*
* Author: 高海波
* Time：2015/8/26 8:43:52
* FileName：CTabControl
* 说明:
* ===============================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IISControls.Controls
{
    public class ColorTabItem : TabItem
    {


        public Brush EnterBrush
        {
            get { return (Brush)GetValue(EnterBrushProperty); }
            set { SetValue(EnterBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnterBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnterBrushProperty;


        static ColorTabItem()
        {
            EnterBrushProperty = DependencyProperty.Register("EnterBrush", typeof(Brush), typeof(ColorTabItem));
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorTabItem), new FrameworkPropertyMetadata(typeof(ColorTabItem)));
        }
    }
}
