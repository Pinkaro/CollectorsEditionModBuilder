using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Assets;



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
            selectedRace.ItemsSource = SuspiciousnessCalculator.Instance.possibleRaces;
            selectedRace.SelectedIndex = 0;

            selectedColor.ItemsSource = SuspiciousnessCalculator.Instance.possibleColors;
            selectedColor.SelectedIndex = 0;

            selectedBodytype.ItemsSource = SuspiciousnessCalculator.Instance.possibleBodytypes;
            selectedBodytype.SelectedIndex = 0;
            ActivateFittingStatInputs((selectedBodypart.SelectedItem as ComboBoxItem).Content as string);
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
            string bodypart = (selectedBodypart.SelectedItem as ComboBoxItem).Content as string;
            ActivateFittingStatInputs(bodypart);
            ActivateFittingSkillInputs(bodypart);
        }
        public void ActivateFittingSkillInputs(string bodypart)
        {
            switch (bodypart)
            {
                case "Head":
                    Skill1.IsEnabled = true;
                    Skill2.IsEnabled = true;
                    Skill3.IsEnabled = true;
                    break;
                case "Torso":
                case "Right Arm":
                case "Left Arm":
                    Skill1.IsEnabled = true;
                    Skill2.IsEnabled = true;
                    Skill3.IsEnabled = false;
                    InputSkill3.Text = "";
                    break;
                case "Right Leg":
                case "Left Leg":
                    Skill1.IsEnabled = true;
                    Skill2.IsEnabled = false;
                    InputSkill2.Text = "";
                    Skill3.IsEnabled = false;
                    InputSkill3.Text = "";
                    break;
            }

        }

        public void ActivateFittingStatInputs(string bodypart)
        {
            switch (bodypart)
            {
                case "Head":
                    Constitution.IsEnabled = true;
                    Intelligence.IsEnabled = true;
                    Wisdom.IsEnabled = true;
                    Charisma.IsEnabled = true;
                    Strength.IsEnabled = false;
                    InputStrength.Text = "";
                    Dexterity.IsEnabled = false;
                    InputDexterity.Text = "";
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
                    Intelligence.IsEnabled = false;
                    InputIntelligence.Text = "";
                    Wisdom.IsEnabled = false;
                    InputWisdom.Text = "";
                    break;
            }

        }

        #region IdleAnimation
        private void IdleUpAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputIdleUpAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        private void IdleDownAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputIdleDownAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        private void IdleSideAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputIdleSideAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        #endregion

        #region WalkAnimation
        private void WalkUpAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputWalkUpAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        private void WalkDownAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputWalkDownAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        private void WalkSideAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputWalkSideAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        #endregion

        #region AttackAnimation
        private void AttackUpAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputAttackUpAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        private void AttackDownAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputAttackDownAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        private void AttackSideAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputAttackSideAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        #endregion

        #region MagicAnimation
        private void MagicUpAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputMagicUpAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        private void MagicDownAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputMagicDownAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        private void MagicSideAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputMagicSideAnimationPath.Text = TrimPath(openFileDialog.FileName);
        }
        #endregion

        public string TrimPath(string path)
        {
            string[] newPath;
            newPath = path.Split('\\');
            return newPath.Last();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            string id = InputModname.Text + "_" + InputBodypartName.Text;
            string path = System.AppDomain.CurrentDomain.BaseDirectory+"\\Exported\\"+id;

            if(!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\Exported\\"))
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\Exported\\");
            }

            string bodypart = (selectedBodypart.SelectedItem as ComboBoxItem).Content as string;

            Int32.TryParse(InputCharisma.Text, out int charisma);
            Int32.TryParse(InputConstitution.Text, out int constitution);
            Int32.TryParse(InputDexterity.Text, out int dexterity);
            Int32.TryParse(InputIntelligence.Text, out int intelligence);
            Int32.TryParse(InputStrength.Text, out int strength);
            Int32.TryParse(InputWisdom.Text, out int wisdom);


            string bodytype = selectedBodytype.SelectedItem.ToString();
            string color = selectedColor.SelectedItem.ToString();
            string race = selectedRace.SelectedItem.ToString();

            Int32.TryParse(InputHealthpoints.Text, out int maxHP);

            Bodypart b = null;

            switch (bodypart)
            {
                case "Head":
                    b = new Head(constitution, intelligence, wisdom, charisma, color, bodytype, race);
                    break;
                case "Torso":
                    b = new Torso(constitution, strength, dexterity, charisma, color, bodytype, race);
                    break;
                case "Right Arm":
                    b = new RightArm(constitution, strength, dexterity, charisma, color, bodytype, race);
                    break;
                case "Left Arm":
                    b = new LeftArm(constitution, strength, dexterity, charisma, color, bodytype, race);
                    break;
                case "Right Leg":
                    b = new RightLeg(constitution, strength, dexterity, charisma, color, bodytype, race);
                    break;
                case "Left Leg":
                    b = new LeftLeg(constitution, strength, dexterity, charisma, color, bodytype, race);
                    break;
            }
            
            b.id = id;
            b.MaxHP = maxHP;

            b.idleDownAnimation = InputIdleDownAnimationPath.Text;
            b.idleUpAnimation = InputIdleUpAnimationPath.Text;
            b.idleSideAnimation = InputIdleSideAnimationPath.Text;

            b.walkDownAnimation = InputWalkDownAnimationPath.Text;
            b.walkUpAnimation = InputWalkUpAnimationPath.Text;
            b.walkSideAnimation = InputWalkSideAnimationPath.Text;

            b.attackDownAnimation = InputAttackDownAnimationPath.Text;
            b.attackUpAnimation = InputAttackUpAnimationPath.Text;
            b.attackSideAnimation = InputAttackSideAnimationPath.Text;

            b.magicDownAnimation = InputMagicDownAnimationPath.Text;
            b.magicUpAnimation = InputMagicUpAnimationPath.Text;
            b.magicSideAnimation = InputMagicSideAnimationPath.Text;



            switch (bodypart)
            {
                case "Head":
                    Head h = b as Head;
                    h.skillIDs = new string[3] { InputSkill1.Text, InputSkill2.Text, InputSkill3.Text };
                    XMLManager.Save(path,h);
                    break;
                case "Torso":
                    Torso t = b as Torso;
                    t.skillIDs = new string[2] { InputSkill1.Text, InputSkill2.Text };
                    XMLManager.Save(path, t);
                    break;
                case "Right Arm":
                    RightArm ra = b as RightArm;
                    ra.skillIDs = new string[2] { InputSkill1.Text, InputSkill2.Text };
                    XMLManager.Save(path, ra);
                    break;
                case "Left Arm":
                    LeftArm la = b as LeftArm;
                    la.skillIDs = new string[2] { InputSkill1.Text, InputSkill2.Text };
                    XMLManager.Save(path, la);
                    break;
                case "Right Leg":
                    RightLeg rl = b as RightLeg;
                    rl.skillIDs = new string[1] { InputSkill1.Text};
                    XMLManager.Save(path, rl);
                    break;
                case "Left Leg":
                    LeftLeg ll = b as LeftLeg;
                    ll.skillIDs = new string[1] { InputSkill1.Text };
                    XMLManager.Save(path, ll);
                    break;
            }
        }


    }
}
