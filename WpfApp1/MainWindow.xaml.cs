using MetadataExtractor;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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

///string[] wantedMetadata = { "File Size", "File Name", "File Modified Date", "Detected File Type Name", "Image Width", "Image Height" };

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>

    ///string[] wantedMetadata = { "text1", "testtest", "test1test2", "test2text1" };
    public partial class MainWindow : Window
    {
        Mediatheque mediat = new Mediatheque();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAddMedia_Click(object sender, RoutedEventArgs e)
        {
            //Mediatheque media = new Mediatheque();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);

            }

            foreach (var media in mediat.getMedias())
            {
                ListMedia.Items.Add(media.getFileName());
            }

        }

        private void BtnDelMedia_Click(object sender, RoutedEventArgs e)
        {
            Uri resourceUri = new Uri("/Images/white_bengal_tiger.jpg", UriKind.Relative);
            imgDynamic.Source = new BitmapImage(resourceUri);
        }
    }
}
