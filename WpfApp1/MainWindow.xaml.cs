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

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imgDynamic.Source = new BitmapImage(fileUri);

                BitmapImage test = new BitmapImage(fileUri);

                ///MessageBox.Show(imgDynamic.Source.Metadata.ToString());


                IEnumerable<Directory> directories = ImageMetadataReader.ReadMetadata(openFileDialog.FileName);
                foreach (var directory in directories)
                {
                    foreach (var tag in directory.Tags)
                        Console.WriteLine($"[{directory.Name}] {tag.Name} = {tag.Description}");

                    if (directory.HasError)
                    {
                        foreach (var error in directory.Errors)
                            Console.WriteLine($"ERROR: {error}");
                    }
                }


                Directory direct = directories.ToList()[0];
                Tag ta = direct.Tags.ToList()[0];
                Console.WriteLine($"[{directories.ToList()[0].Name}] {ta.Name} = {ta.Description}");

                MessageBox.Show(directories.ToList().ToString());
                ///MessageBox.Show(direct.ToString());

            }
        }

        private void BtnLoadFromResource_Click(object sender, RoutedEventArgs e)
        {
            Uri resourceUri = new Uri("/Images/white_bengal_tiger.jpg", UriKind.Relative);
            imgDynamic.Source = new BitmapImage(resourceUri);
        }
    }
}
