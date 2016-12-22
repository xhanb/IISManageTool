/* ==============================
*
* Author: 高海波
* Time：2015/9/1 16:39:12
* FileName：CComboBox
* 说明:
* ===============================
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IISControls.Controls
{
    public class CComboBox : ComboBox
    {
        static CComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CComboBox), new FrameworkPropertyMetadata(typeof(CComboBox)));
        }

        #region 属性

        [Category("自定义属性"), DescriptionAttribute("获取或设置控件背景图片")]
        public ImageSource NormalImgae
        {
            get { return (ImageSource)GetValue(NormalImgaeProperty); }
            set { SetValue(NormalImgaeProperty, value); }
        }

        [CategoryAttribute("自定义属性"), DescriptionAttribute("获取或设置控件背景图片")]
        public static readonly DependencyProperty NormalImgaeProperty =
            DependencyProperty.Register("NormalImgae", typeof(ImageSource), typeof(CComboBox));



        [CategoryAttribute("自定义属性"), DescriptionAttribute("获取或设置控件鼠标悬停时背景图片")]
        public ImageSource MouseOverImage
        {
            get { return (ImageSource)GetValue(MouseOverImageProperty); }
            set { SetValue(MouseOverImageProperty, value); }
        }
        [CategoryAttribute("自定义属性"), DescriptionAttribute("获取或设置控件鼠标悬停时背景图片")]
        public static readonly DependencyProperty MouseOverImageProperty =
            DependencyProperty.Register("MouseOverImage", typeof(ImageSource), typeof(CComboBox));



        [CategoryAttribute("自定义属性"), DescriptionAttribute("获取或设置控件按下时背景图片")]
        public ImageSource PressedImage
        {
            get { return (ImageSource)GetValue(PressedImageProperty); }
            set { SetValue(PressedImageProperty, value); }
        }

        [CategoryAttribute("自定义属性"), DescriptionAttribute("获取或设置控件按下时背景图片")]
        public static readonly DependencyProperty PressedImageProperty =
            DependencyProperty.Register("PressedImage", typeof(ImageSource), typeof(CComboBox));



        [CategoryAttribute("自定义属性"), DescriptionAttribute("获取或设置控件背景图片九宫格切图")]
        public Thickness NineGrid
        {
            get { return (Thickness)GetValue(NineGridProperty); }
            set { SetValue(NineGridProperty, value); }
        }

        [CategoryAttribute("自定义属性"), DescriptionAttribute("获取或设置控件背景图片九宫格切图")]
        public static readonly DependencyProperty NineGridProperty =
            DependencyProperty.Register("NineGrid", typeof(Thickness), typeof(CComboBox), new PropertyMetadata(new Thickness(0)));


        #endregion

    }
}
