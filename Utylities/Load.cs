using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PixelArtEdytor.Utylities
{
    public class Load
    {
        public static Bitmap loadedImage;

        public delegate void Del();
        private static List<Del> liseners = new List<Del>();
        public static void RegisterLisener(Del d)
        {
            liseners.Add(d);
        }
        public static void LoadImage()
        {
            Thread t1 = new Thread(()=> {
                OpenFileDialog dial = new OpenFileDialog();
                if (dial.ShowDialog() == true)
                {
                    loadedImage = new Bitmap(dial.FileName);
                    if (loadedImage.Width > 1200 || loadedImage.Height > 1200)
                    {
                        MessageBox.Show("File max size 1200[px] X 1200[px]");

                        loadedImage = null;
                    }
                    foreach(Del d in liseners)
                    {
                        d.Invoke();
                    }
                }
            });
            t1.Start();
            
        }
        





    }
}
