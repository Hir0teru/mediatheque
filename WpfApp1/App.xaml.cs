using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfTutorialSamples
{
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            WpfApp1.MainWindow wnd = new WpfApp1.MainWindow();
///            if (e.Args.Length == 1)
///                MessageBox.Show("Now opening file: \n\n" + e.Args[0]);
            wnd.Show();
        }
    }
}