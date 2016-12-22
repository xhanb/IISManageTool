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

namespace IISControls.Controls
{
  public  class CTabControl : TabControl
    {
      static CTabControl()
		{
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CTabControl), new FrameworkPropertyMetadata(typeof(CTabControl)));
		}
    }
}
 