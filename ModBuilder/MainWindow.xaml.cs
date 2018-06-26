using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;



namespace ModBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Mod selectedMod;
        public string modFolderPath;

        public MainWindow()
        {
          
            InitializeComponent();

        }


        private void SetMod_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SetModFolder_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                modFolderPath = dialog.FileName;
            }
                
        }


    }
}
