using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IISControls.Controls
{

    public class NineImage : Image
    {

        [Category("Common Properties")]
        public static readonly DependencyProperty NineGridProperty = DependencyProperty.Register("NineGrid", typeof(Thickness), typeof(NineImage), new FrameworkPropertyMetadata(new Thickness(0), FrameworkPropertyMetadataOptions.AffectsRender));

        [Category("Common Properties")]
        public Thickness NineGrid
        {
            get { return (Thickness)GetValue(NineGridProperty); }
            set { SetValue(NineGridProperty, value); }
        }


        protected override void OnRender(DrawingContext dc)
        {
            DrawNineImage(dc);
        }

        private void DrawNineImage(DrawingContext dc)
        {
            if (Source != null && ActualHeight >= NineGrid.Bottom + NineGrid.Top && ActualWidth>=NineGrid.Left+NineGrid.Right)
            {
                BitmapImage im = new BitmapImage();
                im.BeginInit();
                im.UriSource = new Uri(Source.ToString());
                BitmapSource image = im;
                im.EndInit();

                int left = (int)NineGrid.Left;
                int top = (int)NineGrid.Top;
                int right = (int)NineGrid.Right;
                int bottom = (int)NineGrid.Bottom;

                double drawWidth = ActualWidth - left - right;
                double drawHeight = ActualHeight - top - bottom;

                int centerWidth = (int)image.PixelWidth - left - right;
                int centerHeight = (int)image.PixelHeight - top - bottom;

                if (left > 0 && right > 0 && top == 0 && bottom == 0)
                {
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(0, 0, left, (int)image.PixelHeight)), new Rect(0, 0, left, ActualHeight));
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(left, 0, centerWidth, (int)image.PixelHeight)), new Rect(left, 0, drawWidth, ActualHeight));
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(left + centerWidth, 0, right, (int)image.PixelHeight)), new Rect(left + drawWidth, 0, right, ActualHeight));
                }

                else if (top > 0 && bottom > 0 && left == 0 & right == 0)
                {
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(0, 0, (int)image.PixelWidth, top)), new Rect(0, 0, ActualWidth, top));
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(0, top, (int)image.PixelWidth, centerHeight)), new Rect(0, top, ActualWidth, drawHeight));
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(0, top + centerHeight, (int)image.PixelWidth, bottom)), new Rect(0, top + drawHeight, ActualWidth, bottom));
                }

                else if (top > 0 && bottom > 0 && left > 0 & right > 0)
                {
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(0, 0, left, top)), new Rect(0, 0, left, top));
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(left, 0, centerWidth, top)), new Rect(left, 0, drawWidth, top));
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(left + centerWidth, 0, right, top)), new Rect(left + drawWidth, 0, right, top));

                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(0, top, left, centerHeight)), new Rect(0, top, left, drawHeight));
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(left, top, centerWidth, centerHeight)), new Rect(left, top, drawWidth, drawHeight));
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(left + centerWidth, top, right, centerHeight)), new Rect(left + drawWidth, top, right, drawHeight));

                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(0, top + centerHeight, left, bottom)), new Rect(0, top + drawHeight, left, bottom));
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(left, top + centerHeight, centerWidth, bottom)), new Rect(left, top + drawHeight, drawWidth, bottom));
                    dc.DrawImage(new CroppedBitmap(image, new Int32Rect(left + centerWidth, top + centerHeight, right, bottom)), new Rect(left + drawWidth, top + drawHeight, right, bottom));
                }

                else
                {
                    base.OnRender(dc);
                }
            }

            else
            {
                base.OnRender(dc);
            }
        }
    }
}
