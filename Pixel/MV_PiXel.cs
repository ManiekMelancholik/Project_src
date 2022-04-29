

namespace PixelArtEdytor.Pixel
{
    using PixelArtEdytor.Edytor;
    using System.Drawing;
    using System.Windows.Controls;
    using System.Windows.Input;
    class MV_PiXel
    {
        private PiXel pixel;

        #region CONSTRUCTORS
        public MV_PiXel() { }
        public MV_PiXel(int row, int column)
        {
            pixel = new PiXel();
            Grid.SetRow(pixel, row);
            Grid.SetColumn(pixel, column);

            pixel.MouseLeftButtonDown += new MouseButtonEventHandler((object o, MouseButtonEventArgs e)=> { pixel.Background = MV_Edytor.colors1[MV_Edytor.selected1].Fill; });

            pixel.MouseRightButtonDown += new MouseButtonEventHandler((object o, MouseButtonEventArgs e) => { pixel.Background = MV_Edytor.colors2[MV_Edytor.selected2].Fill; });
        }
        #endregion
        public void SetInitColor(Color c)
        {
            pixel.Background = new System.Windows.Media.SolidColorBrush(
            System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B));
        }
        public PiXel GetView()
        {
            return pixel;
        }


    }
}
