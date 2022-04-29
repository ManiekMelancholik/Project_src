using PixelArtEdytor.Pixel;
using PixelArtEdytor.Utylities;
using System;
using System.Collections.ObjectModel;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PixelArtEdytor.Edytor
{
    class MV_Edytor
    {

        static EdytorWindow view;

        static System.Drawing.Bitmap bm
        {
            get
            {
                return Load.loadedImage;
            }
        }

        #region COLORS

        static byte jump = 30;

        private static Rectangle[] _colors1;
        public static Rectangle[] colors1
        {
            get
            {
                if (_colors1 == null)
                {
                    byte R = 0;
                    byte G = 0;
                    byte B = 0;

                    //byte jump = 30;
                    _colors1 = new Rectangle[((255 / jump) * (255 / jump) * 2) - (255 / jump)];

                    for (int k = 0; k < 255 / jump; k++)//R
                    {

                        G = 0;
                        for (int m = 0; m < 255 / jump; m++)//G
                        {

                            B = 0;
                            for (int n = 0; n < 255 / jump; n++)//B
                            {
                                Rectangle r = new Rectangle();
                                r.Height = 40;
                                r.Width = 90;
                                r.Fill = new SolidColorBrush(Color.FromRgb(R, G, B));

                                _colors1[k * (255 / jump) + m * (255 / jump) + n] = r;

                                B += jump;
                            }
                            G += jump;
                        }
                        R += jump;
                    }
                    Rectangle white = new Rectangle();
                    white.Height = 40;
                    white.Width = 90;
                    white.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    _colors1[_colors1.Length - 1] = white;
                }
                return _colors1;

            }
        }

        public static int selected1 { get; set; }

        private static Rectangle[] _colors2;
        public static Rectangle[] colors2
        {
            get
            {
                if (_colors2 == null)
                {
                    byte R = 0;
                    byte G = 0;
                    byte B = 0;

                    //byte jump = 30;
                    _colors2 = new Rectangle[((255 / jump) * (255 / jump) * 2) - (255 / jump) + 1];

                    for (int k = 0; k < 255 / jump; k++)//R
                    {

                        G = 0;
                        for (int m = 0; m < 255 / jump; m++)//G
                        {

                            B = 0;
                            for (int n = 0; n < 255 / jump; n++)//B
                            {
                                Rectangle r = new Rectangle();
                                r.Height = 40;
                                r.Width = 90;
                                r.Fill = new SolidColorBrush(Color.FromRgb(R, G, B));

                                _colors2[k * (255 / jump) + m * (255 / jump) + n] = r;

                                B += jump;
                            }
                            G += jump;
                        }
                        R += jump;
                    }
                    Rectangle white = new Rectangle();
                    white.Height = 40;
                    white.Width = 90;
                    white.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    _colors2[_colors2.Length - 1] = white;
                }
                return _colors2;

            }
        }

        public static int selected2 { get; set; }

        #endregion

        #region CONSTRUCTORS
        public MV_Edytor() { }

        public MV_Edytor(bool f)
        {
            view = new EdytorWindow();



            view.Show();
        }
        #endregion


        static bool bbbb = false;

        #region METHODS
        private void UpdateGrid()
        {
            view.Dispatcher.Invoke(
                () =>
                {
                    if (bm != null)
                    {
                        view.img.ColumnDefinitions.Clear();
                        view.img.RowDefinitions.Clear();

                        for (int i = 0; i < bm.Height; i++)
                        {
                            ColumnDefinition cd = new ColumnDefinition();
                            cd.Width = new GridLength(20);
                            view.img.ColumnDefinitions.Add(cd);
                        }

                        for (int i = 0; i < bm.Width; i++)
                        {
                            RowDefinition rd = new RowDefinition();
                            rd.Height = new GridLength(20);
                            view.img.RowDefinitions.Add(rd);
                        }

                        for (int i = 0; i < bm.Width; i++)
                        {
                            for (int j = 0; j < bm.Height; j++)
                            {
                                MV_PiXel piXel = new MV_PiXel(i, j);
                                piXel.SetInitColor(bm.GetPixel(i, j));
                                view.img.Children.Add(piXel.GetView());
                            }
                        }
                    }
                });

        }
    
        #endregion


        #region COMMANDS
        private ICommand _newGraphic;


        private ICommand _save;


        private ICommand _load;


        private ICommand _options;

        #region COMMANDS IMPLEMENTATIONS


        public  ICommand newGraphic
        {
            get
            {
                if (_newGraphic == null)
                {
                    Action a1 = new Action(() => { });

                    _newGraphic = new CMM(
                        ex =>
                        {

                            if (bbbb)
                            {

                                for (int i = 0; i < 20; i++)
                                {
                                    view.img.ColumnDefinitions.Add(new ColumnDefinition());
                                    view.img.RowDefinitions.Add(new RowDefinition());
                                }

                                for (int i = 0; i < 20; i++)
                                {
                                    for (int j = 0; j < 20; j++)
                                    {
                                        MV_PiXel piXel = new MV_PiXel(i,j);
                                        view.img.Children.Add(piXel.GetView());
                                    }
                                }
                            }
                            bbbb = true;


                        },
                        cex =>
                        {
                            return true;
                        }
                        );
                }
                return _newGraphic;
            }
        }
        
        public ICommand save
        {
            
            get
            {
                if (_save == null)
                {
                    Action a1 = new Action(() => { });

                    _save = new CMM(
                        ex =>
                        {
                            
                            MessageBox.Show("saving BUTTON");
                        },
                        cex =>
                        {
                            if (bbbb)
                                return true;
                            return false;
                        }
                        );
                }
                return _save;
            }
        }

        public ICommand load
        {
            get
            {
                if (_load == null)
                {
                    Action a1 = new Action(() => { });
                    Load.RegisterLisener(() => { this.UpdateGrid(); });
                    _load = new CMM(
                        ex =>
                        {
                            Load.LoadImage();
                            //System.Drawing.Bitmap bm = Load.LoadImage();
                           
                        },
                        cex =>
                        {
                            return true;
                        }
                        );
                }
                return _load;
            }
        }

        public ICommand options
        {
            get
            {
                if (_options == null)
                {
                    Action a1 = new Action(() => { });

                    _options = new CMM(
                        ex =>
                        {
                            MessageBox.Show("options BUTTON");
                        },
                        cex =>
                        {
                            return true;
                        }
                        );
                }
                return _options;
            }
        }
        #endregion
        #endregion
    }
}
