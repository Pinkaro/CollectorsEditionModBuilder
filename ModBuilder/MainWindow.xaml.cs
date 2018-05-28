using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ActivateFittingStatInputs("");
        }

        private void TextBox_IsNumeric(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void SelectedBodypart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            ActivateFittingStatInputs(((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string);
        }


        public void ActivateFittingStatInputs(string bodypart)
        {
            Constitution.IsEnabled = false;
            Charisma.IsEnabled = false;
            Dexterity.IsEnabled = false;
            Intelligence.IsEnabled = false;
            Strength.IsEnabled = false;
            Wisdom.IsEnabled = false;
            switch (bodypart)
            {
                case "Head":
                    Constitution.IsEnabled = true;
                    Intelligence.IsEnabled = true;
                    Wisdom.IsEnabled = true;
                    Charisma.IsEnabled = true;
                    break;
                case "Torso":
                case "Right Arm":
                case "Left Arm":
                case "Right Leg":
                case "Left Leg":
                    Constitution.IsEnabled = true;
                    Strength.IsEnabled = true;
                    Dexterity.IsEnabled = true;
                    Charisma.IsEnabled = true;
                    break;
            }

        }
    }
}
