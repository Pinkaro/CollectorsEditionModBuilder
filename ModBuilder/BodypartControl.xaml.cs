using System;
using System.Linq;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ModBuilder
{
    /// <summary>
    /// Interaction logic for Bodypart.xaml
    /// </summary>
    public partial class BodypartControl : UserControl
    {
        MainWindow parentWindow;
        public BodypartControl()
        {
            InitializeComponent();
            parentWindow = Application.Current.MainWindow as MainWindow;

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
                InputIdleUpAnimationPath.Text = openFileDialog.FileName;
        }
        private void IdleDownAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputIdleDownAnimationPath.Text = openFileDialog.FileName;
        }
        private void IdleSideAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputIdleSideAnimationPath.Text = openFileDialog.FileName;
        }
        #endregion

        #region WalkAnimation
        private void WalkUpAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputWalkUpAnimationPath.Text = openFileDialog.FileName;
        }
        private void WalkDownAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputWalkDownAnimationPath.Text = openFileDialog.FileName;
        }
        private void WalkSideAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputWalkSideAnimationPath.Text = openFileDialog.FileName;
        }
        #endregion

        #region AttackAnimation
        private void AttackUpAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputAttackUpAnimationPath.Text = openFileDialog.FileName;
        }
        private void AttackDownAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputAttackDownAnimationPath.Text = openFileDialog.FileName;
        }
        private void AttackSideAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputAttackSideAnimationPath.Text = openFileDialog.FileName;
        }
        #endregion

        #region MagicAnimation
        private void MagicUpAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputMagicUpAnimationPath.Text = openFileDialog.FileName;
        }
        private void MagicDownAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputMagicDownAnimationPath.Text = openFileDialog.FileName;
        }
        private void MagicSideAnimationPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputMagicSideAnimationPath.Text = openFileDialog.FileName;
        }
        #endregion

        public string TrimPath(string path)
        {
            string[] newPath;
            newPath = path.Split('\\');
            return newPath.Last();
        }

        private void IconPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                InputMagicSideAnimationPath.Text = openFileDialog.FileName;
        }


        private void ExportBodypart_Click(object sender, RoutedEventArgs e)
        {



            string id = InputModname.Text + "_" + InputBodypartName.Text;
            if (string.IsNullOrWhiteSpace(InputModname.Text))
            {
                LabelStatus.Content = "Export failed! Please fill out the Modname.";
                return;
            }
            if (string.IsNullOrWhiteSpace(InputBodypartName.Text))
            {
                LabelStatus.Content = "Export failed! Please fill out the Bodypartname.";
                return;
            }
            string path;


            string bodytype = selectedBodytype.SelectedItem.ToString();
            string color = selectedColor.SelectedItem.ToString();
            string race = selectedRace.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(parentWindow.modFolderPath))
            {
                path = System.AppDomain.CurrentDomain.BaseDirectory + "Exported\\";
            }
            else
            {
                path = parentWindow.modFolderPath + "\\";
            }




            string bodypart = (selectedBodypart.SelectedItem as ComboBoxItem).Content as string;

            Int32.TryParse(InputCharisma.Text, out int charisma);
            Int32.TryParse(InputConstitution.Text, out int constitution);
            Int32.TryParse(InputDexterity.Text, out int dexterity);
            Int32.TryParse(InputIntelligence.Text, out int intelligence);
            Int32.TryParse(InputStrength.Text, out int strength);
            Int32.TryParse(InputWisdom.Text, out int wisdom);


            path += InputModname.Text + "\\Bodyparts\\" + race + "\\" + bodypart + "s\\";

            Int32.TryParse(InputHealthpoints.Text, out int maxHP);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

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

            CopyFile(InputIconPath.Text, path);
            b.iconPath = TrimPath(InputIconPath.Text);

            CopyFile(InputIdleDownAnimationPath.Text, path);
            b.idleDownAnimation = TrimPath(InputIdleDownAnimationPath.Text);
            CopyFile(InputIdleUpAnimationPath.Text, path);
            b.idleUpAnimation = TrimPath(InputIdleUpAnimationPath.Text);
            CopyFile(InputIdleSideAnimationPath.Text, path);
            b.idleSideAnimation = TrimPath(InputIdleSideAnimationPath.Text);

            CopyFile(InputWalkDownAnimationPath.Text, path);
            b.walkDownAnimation = TrimPath(InputWalkDownAnimationPath.Text);
            CopyFile(InputWalkUpAnimationPath.Text, path);
            b.walkUpAnimation = TrimPath(InputWalkUpAnimationPath.Text);
            CopyFile(InputWalkSideAnimationPath.Text, path);
            b.walkSideAnimation = TrimPath(InputWalkSideAnimationPath.Text);

            CopyFile(InputAttackDownAnimationPath.Text, path);
            b.attackDownAnimation = TrimPath(InputAttackDownAnimationPath.Text);
            CopyFile(InputAttackUpAnimationPath.Text, path);
            b.attackUpAnimation = TrimPath(InputAttackUpAnimationPath.Text);
            CopyFile(InputAttackSideAnimationPath.Text, path);
            b.attackSideAnimation = TrimPath(InputAttackSideAnimationPath.Text);

            CopyFile(InputMagicDownAnimationPath.Text, path);
            b.magicDownAnimation = TrimPath(InputMagicDownAnimationPath.Text);
            CopyFile(InputMagicUpAnimationPath.Text, path);
            b.magicUpAnimation = TrimPath(InputMagicUpAnimationPath.Text);
            CopyFile(InputMagicSideAnimationPath.Text, path);
            b.magicSideAnimation = TrimPath(InputMagicSideAnimationPath.Text);



            switch (bodypart)
            {
                case "Head":
                    Head h = b as Head;
                    h.skillIDs = new string[3] { InputSkill1.Text, InputSkill2.Text, InputSkill3.Text };
                    XMLManager.Save(path + id, h);
                    break;
                case "Torso":
                    Torso t = b as Torso;
                    t.skillIDs = new string[2] { InputSkill1.Text, InputSkill2.Text };
                    XMLManager.Save(path + id, t);
                    break;
                case "Right Arm":
                    RightArm ra = b as RightArm;
                    ra.skillIDs = new string[2] { InputSkill1.Text, InputSkill2.Text };
                    XMLManager.Save(path + id, ra);
                    break;
                case "Left Arm":
                    LeftArm la = b as LeftArm;
                    la.skillIDs = new string[2] { InputSkill1.Text, InputSkill2.Text };
                    XMLManager.Save(path + id, la);
                    break;
                case "Right Leg":
                    RightLeg rl = b as RightLeg;
                    rl.skillIDs = new string[1] { InputSkill1.Text };
                    XMLManager.Save(path + id, rl);
                    break;
                case "Left Leg":
                    LeftLeg ll = b as LeftLeg;
                    ll.skillIDs = new string[1] { InputSkill1.Text };
                    XMLManager.Save(path + id, ll);
                    break;
            }

            LabelStatus.Content = "Export successful.";
        }

        public void CopyFile(string oldPath, string newPath)
        {
            if (string.IsNullOrWhiteSpace(oldPath)) return;
            if (oldPath.Contains(newPath))
            {
                return;
            }
            else
            {
                try
                {
                    File.Copy(oldPath, newPath + TrimPath(oldPath));
                }
                catch (IOException e)
                {

                }

            }
        }
    }
}
