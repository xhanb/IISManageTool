/* ==============================
*
* Author: 高海波
* Time：2015/8/26 8:42:22
* FileName：CButton
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
    public class CButton : Button
    {
        public static readonly DependencyProperty MyMoverBrushProperty;
        public static readonly DependencyProperty MyEnterBrushProperty;
        public Brush MyMoverBrush
        {
            get
            {
                return base.GetValue(CButton.MyMoverBrushProperty) as Brush;
            }
            set
            {
                base.SetValue(CButton.MyMoverBrushProperty, value);
            }
        }
        public Brush MyEnterBrush
        {
            get
            {
                return base.GetValue(CButton.MyEnterBrushProperty) as Brush;
            }
            set
            {
                base.SetValue(CButton.MyEnterBrushProperty, value);
            }
        }

        
        static CButton()
        {
            CButton.MyMoverBrushProperty = DependencyProperty.Register("MyMoverBrush", typeof(Brush), typeof(CButton), new PropertyMetadata(null));
            CButton.MyEnterBrushProperty = DependencyProperty.Register("MyEnterBrush", typeof(Brush), typeof(CButton), new PropertyMetadata(null));
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CButton), new FrameworkPropertyMetadata(typeof(CButton)));
        }
    }
}
