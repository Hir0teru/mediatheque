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
                Media newMedia = new Media(openFileDialog.FileName);
                mediat.addMedia(newMedia);
            }

            listMedia.Items.Clear();

            foreach (var media in mediat.getMedias())
            {
                listMedia.Items.Add(media.getFileName());
            }

        }

        private void listMedia_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (listMedia.SelectedItem != null)
            {
                listProperties.Items.Clear();
                Media selected_media = mediat.getMedias()[listMedia.SelectedIndex];
                listProperties.Items.Add(selected_media.getFileName());
                listProperties.Items.Add(selected_media.getSize());
                listProperties.Items.Add(selected_media.getDetectedFileTypeName ());
                listProperties.Items.Add(selected_media.getFileModifiedDate());
            }
        }

        private void BtnDelMedia_Click(object sender, RoutedEventArgs e)
        {
            if (listMedia.SelectedItem != null)
            {
                mediat.removeMedia(listMedia.SelectedIndex);
                listMedia.Items.Clear();

                foreach (var media in mediat.getMedias())
                {
                    listMedia.Items.Add(media.getFileName());
                }
            }
        }
    }
}
