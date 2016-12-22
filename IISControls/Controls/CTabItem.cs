/* ==============================
*
* Author: 高海波
* Time：2015/8/26 8:45:15
* FileName：CTabItem
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
    public class CTabItem : TabItem
    {
        public static readonly DependencyProperty MyMoverBrushProperty;
        public static readonly DependencyProperty MyEnterBrushProperty;
        public Brush MyMoverBrush
        {
            get
            {
                return base.GetValue(MyMoverBrushProperty) as Brush;
            }
            set
            {
                base.SetValue(MyMoverBrushProperty, value);
            }
        }
        public Brush MyEnterBrush
        {
            get
            {
                return base.GetValue(MyEnterBrushProperty) as Brush;
            }
            set
            {
                base.SetValue(MyEnterBrushProperty, value);
            }
        }
        static CTabItem()
        {
            MyMoverBrushProperty = DependencyProperty.Register("MyMoverBrush", typeof(Brush), typeof(CTabItem), new PropertyMetadata(null));
            MyEnterBrushProperty = DependencyProperty.Register("MyEnterBrush", typeof(Brush), typeof(CTabItem), new PropertyMetadata(null));
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CTabItem), new FrameworkPropertyMetadata(typeof(CTabItem)));
        }
        public CTabItem()
        {
            base.Header = "测试按钮";
            base.Background = Brushes.Blue;
        }
    }
}
