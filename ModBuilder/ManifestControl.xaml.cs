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

namespace ModBuilder
{
    /// <summary>
    /// Interaction logic for Manifest.xaml
    /// </summary>
    public partial class ManifestControl : UserControl
    {
        MainWindow parentWindow;
        public ManifestControl()
        {
            InitializeComponent();
            parentWindow = Application.Current.MainWindow as MainWindow;


        }

        private void IconPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputIconPath.Text = openFileDialog.FileName;
        }
        private void ExportManifest_Click(object sender, RoutedEventArgs e)
        {

            string id = InputModname.Text;
            if (string.IsNullOrWhiteSpace(InputModname.Text))
            {
                LabelStatus.Content = "Export failed! Please fill out the Modname.";
                StatusTimer();
                return;
            }
            if (string.IsNullOrWhiteSpace(InputVersion.Text))
            {
                LabelStatus.Content = "Export failed! Please fill out the Version.";
                StatusTimer();
                return;
            }
            if (string.IsNullOrWhiteSpace(InputAuthors.Text))
            {
                LabelStatus.Content = "Export failed! Please fill out the Author.";
                StatusTimer();
                return;
            }
            string path;
            if (string.IsNullOrWhiteSpace(parentWindow.modFolderPath))
            {
                path = System.AppDomain.CurrentDomain.BaseDirectory + "Exported\\";
            }
            else
            {
                path = parentWindow.modFolderPath + "\\";
            }
            path += InputModname.Text+"\\";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Mod m = new Mod();

            m.id = InputModname.Text;
            m.Name = InputModname.Text;
            m.Version = InputVersion.Text;
            m.Description = InputDescription.Text;
            m.Authors = InputAuthors.Text.Split(';').ToList();
            m.Requirements = InputRequirements.Text.Split(';').ToList();

            parentWindow.CopyFile(InputIconPath.Text, path);
            m.Icon = parentWindow.TrimPath(InputIconPath.Text);

            XMLManager.CreateManifest(path, m);
            LabelStatus.Content = "Export successful.";
            StatusTimer();

        }

        public async void StatusTimer()
        {

            await Task.Delay(5000);
            LabelStatus.Content = "";
        }
    }
}
