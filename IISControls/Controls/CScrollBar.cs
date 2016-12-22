/* ==============================
*
* Author: 高海波
* Time：2015/9/2 16:25:04
* FileName：CScrollBar
* 说明:
* ===============================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace IISControls.Controls
{
    public class CScrollBar : ScrollBar
    {
        static CScrollBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CScrollBar), new FrameworkPropertyMetadata(typeof(CScrollBar)));
        }
    }
}
