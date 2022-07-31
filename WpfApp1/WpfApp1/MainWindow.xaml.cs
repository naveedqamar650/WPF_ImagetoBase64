using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnChargerImage.Click += new RoutedEventHandler(btnChargerImage_Click);
            btnOuvrirImage.Click += new RoutedEventHandler(btnOuvrirImage_Click);
        }
        void btnChargerImage_Click(object sender, RoutedEventArgs e)
        {
            if (tbBytes.Text != null && tbBytes.Text.Length > 0)
            {
                // Convert TextBox in a Byte array
                byte[] imgStr = Convert.FromBase64String(tbBytes.Text);
                imgImage.Source = ByteImageConverter.ByteToImage(imgStr);
            }
        }

        void btnOuvrirImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Title = "Select an image";
            ofg.Filter = "Images (.jpg, .jpeg, .png, .gif, .bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofg.Multiselect = false;

            if (ofg.ShowDialog() == true)
            {
                if (ofg.FileName != null && ofg.FileName.Length > 0)
                {
                    ofg.OpenFile();
                    FileStream fs = new FileStream(ofg.FileName, FileMode.Open, FileAccess.Read);
                    tbBytes.Text = ByteImageConverter.ImageToByte(fs);

                    byte[] imgStr = Convert.FromBase64String(tbBytes.Text);
                    imgImage.Source = ByteImageConverter.ByteToImage(imgStr);
                }
            }
        }
    }
}
