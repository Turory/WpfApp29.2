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

namespace WpfApp29._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NameDecoding();
            PortraitDecoding();
        }

        private void NameDecoding()
        {
            WriteableBitmap wb = new WriteableBitmap(new BitmapImage(new Uri("C:\\Users\\Пользователь\\source\\repos\\WpfApp29.2\\img\\clue.bmp", UriKind.Relative)));

            int stride = wb.PixelWidth * 4;
            byte[] pixels = new byte[wb.PixelHeight * stride];

            wb.CopyPixels(pixels, stride, 0);

            for (int y = 0; y < wb.PixelHeight; y++)
            {
                for (int x = 0; x < wb.PixelWidth; x++)
                {
                    int index = y * stride + x * 4;

                    byte blue = pixels[index];
                    byte green = pixels[index + 1];
                    byte red = pixels[index + 2];

                    if (red >= 240)
                    {
                        pixels[index] = 0;
                        pixels[index + 1] = 0;
                        pixels[index + 2] = 0;
                    }
                }
            }

            wb.WritePixels(new Int32Rect(0, 0, wb.PixelWidth, wb.PixelHeight), pixels, stride, 0);
            NameImg.Source = wb;
        }

        private void PortraitDecoding()
        {
            WriteableBitmap wb = new WriteableBitmap(new BitmapImage(new Uri("img\\accomplice.bmp", UriKind.Relative)));

            int stride = wb.PixelWidth * 4;
            byte[] pixels = new byte[wb.PixelHeight * stride];

            wb.CopyPixels(pixels, stride, 0);

            for (int y = 0; y < wb.PixelHeight; y++)
            {
                for (int x = 0; x < wb.PixelWidth; x++)
                {
                    int index = y * stride + x * 4;

                    byte blue = pixels[index];
                    byte green = pixels[index + 1];
                    byte red = pixels[index + 2];

                    if (red >= 240)
                    {
                        pixels[index] = 0;
                        pixels[index + 1] = 0;
                        pixels[index + 2] = 0;
                    }
                }
            }

            wb.WritePixels(new Int32Rect(0, 0, wb.PixelWidth, wb.PixelHeight), pixels, stride, 0);
            PortImg.Source = wb;
        }
    }
}