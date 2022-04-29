using PixelArtEdytor.Edytor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PixelArtEdytor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void Start(object o, StartupEventArgs e)
        {
            MV_Edytor mv = new MV_Edytor(false);
            
        }
    }
}
