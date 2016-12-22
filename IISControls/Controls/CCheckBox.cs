using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IISControls.Controls
{
    public class CCheckBox : CheckBox
    {
        static CCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CCheckBox), new FrameworkPropertyMetadata(typeof(CCheckBox)));
        }


        #region 属性


        [Category("自定义属性"), Description("获取或设置图片宽度")]
        public double ImageWidth
        {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }
        [Category("自定义属性"), Description("获取或设置图片宽度")]
        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register("ImageWidth", typeof(double), typeof(CCheckBox), new PropertyMetadata(0D));



        [Category("自定义属性"), Description("获取或设置图片高度")]
        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }
        [Category("自定义属性"), Description("获取或设置图片高度")]
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight", typeof(double), typeof(CCheckBox), new PropertyMetadata(0D));



        [Category("自定义属性"), Description("获取或设置控件默认背景图片")]
        public ImageSource NormalImgae
        {
            get { return ( ImageSource)GetValue(NormalImgaeProperty); }
            set { SetValue(NormalImgaeProperty, value); }
        }
        [Category("自定义属性"), Description("获取或设置控件默认背景图片")]
        public static readonly DependencyProperty NormalImgaeProperty =
            DependencyProperty.Register("NormalImgae", typeof(ImageSource), typeof(CCheckBox));


        [Category("自定义属性"), Description("获取或设置控件鼠标悬停时背景图片")]
        public ImageSource MouseOverImage
        {
            get { return (ImageSource)GetValue(MouseOverImageProperty); }
            set { SetValue(MouseOverImageProperty, value); }
        }
        [Category("自定义属性"), Description("获取或设置控件鼠标悬停时背景图片")]
        public static readonly DependencyProperty MouseOverImageProperty =
            DependencyProperty.Register("MouseOverImage", typeof(ImageSource), typeof(CCheckBox));



        [Category("自定义属性"), Description("获取或设置控件按下时背景图片")]
        public ImageSource PressedImage
        {
            get { return (ImageSource)GetValue(PressedImageProperty); }
            set { SetValue(PressedImageProperty, value); }
        }

        [Category("自定义属性"), Description("获取或设置控件按下时背景图片")]
        public static readonly DependencyProperty PressedImageProperty =
            DependencyProperty.Register("PressedImage", typeof(ImageSource), typeof(CCheckBox));



        [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public ImageSource CheckImage
        {
            get { return ( ImageSource)GetValue(CheckImageProperty); }
            set { SetValue(CheckImageProperty, value); }
        }

        [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public static readonly DependencyProperty CheckImageProperty =
            DependencyProperty.Register("CheckImage", typeof(ImageSource), typeof(CCheckBox));



        [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public ImageSource CheckMouseOver
        {
            get { return (ImageSource)GetValue(CheckMouseOverProperty); }
            set { SetValue(CheckMouseOverProperty, value); }
        }

        [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public static readonly DependencyProperty CheckMouseOverProperty =
            DependencyProperty.Register("CheckMouseOver", typeof(ImageSource), typeof(CCheckBox));


        [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public ImageSource CheckPressed
        {
            get { return (ImageSource)GetValue(CheckPressedProperty); }
            set { SetValue(CheckPressedProperty, value); }
        }

       [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public static readonly DependencyProperty CheckPressedProperty =
            DependencyProperty.Register("CheckPressed", typeof(ImageSource), typeof(CCheckBox));




        [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public ImageSource ThreeState
        {
            get { return (ImageSource)GetValue(ThreeStateProperty); }
            set { SetValue(ThreeStateProperty, value); }
        }

        [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public static readonly DependencyProperty ThreeStateProperty =
            DependencyProperty.Register("ThreeState", typeof(ImageSource), typeof(CCheckBox));



        [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public ImageSource ThreeMouseOver
        {
            get { return (ImageSource)GetValue(ThreeMouseOverProperty); }
            set { SetValue(ThreeMouseOverProperty, value); }
        }

        [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public static readonly DependencyProperty ThreeMouseOverProperty =
            DependencyProperty.Register("ThreeMouseOver", typeof(ImageSource), typeof(CCheckBox));


        [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public ImageSource ThreePressed
        {
            get { return (ImageSource)GetValue(ThreePressedProperty); }
            set { SetValue(ThreePressedProperty, value); }
        }

        [Category("自定义属性"), Description("获取或设置控件选中时背景图片")]
        public static readonly DependencyProperty ThreePressedProperty =
            DependencyProperty.Register("ThreePressed", typeof(ImageSource), typeof(CCheckBox));

        

        



        #endregion
    }
}
