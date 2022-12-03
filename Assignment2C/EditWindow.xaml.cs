using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using WeaponLib;
using static Assignment2C.ListControl;


namespace Assignment2C
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        System.Random random = new System.Random();
        public EditWindow()
        {
            InitializeComponent();
            //sortedList[SelectedWeaponIndex].Name = NameBox.Text;
            //Enum.TryParse(TypeList.SelectedItem.ToString(), out WeaponType type);
            //sortedList[SelectedWeaponIndex].Type = type;
            //sortedList[SelectedWeaponIndex].Image = URLBox.Text;
            //sortedList[SelectedWeaponIndex].Rarity = int.Parse(RarityList.SelectedItem.ToString());
            //sortedList[SelectedWeaponIndex].BaseAttack = int.Parse(AttackBox.Text);
            //sortedList[SelectedWeaponIndex].SecondaryStat = (SecondaryBox.Text);
            //sortedList[SelectedWeaponIndex].Passive = PassiveBox.Text;
            int count = SelectedWeaponIndex;
            NameBox.Text = sortedList[SelectedWeaponIndex].Name;
            switch (sortedList[SelectedWeaponIndex].Type)
            {
                case WeaponType.Sword:
                    TypeList.SelectedItem = Sword;
                    break;
                case WeaponType.Claymore:
                    TypeList.SelectedItem = Claymore;
                    break;
                case WeaponType.Polearm:
                    TypeList.SelectedItem = Polearm;
                    break;
                case WeaponType.Bow:
                    TypeList.SelectedItem = Bow;
                    break;
                case WeaponType.Catalyst:
                    TypeList.SelectedItem = Catalyst;
                    break;
            }
            URLBox.Text = sortedList[SelectedWeaponIndex].Image;
            BitmapImage bi = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.
            bi.BeginInit();
            bi.UriSource = new Uri(URLBox.Text, UriKind.RelativeOrAbsolute);
            bi.EndInit();
            // Set the image source.
            Image.Source = bi;
            switch (sortedList[SelectedWeaponIndex].Rarity)
            {
                case 1:
                    RarityList.SelectedItem = Rarity1;
                    break;
                case 2:
                    RarityList.SelectedItem = Rarity2;
                    break;
                case 3:
                    RarityList.SelectedItem = Rarity3;
                    break;
                case 4:
                    RarityList.SelectedItem = Rarity4;
                    break;
                case 5:
                    RarityList.SelectedItem = Rarity5;
                    break;
            }
            if (sortedList[SelectedWeaponIndex].BaseAttack != 0)
            {
                AttackBox.Text = sortedList[SelectedWeaponIndex].BaseAttack.ToString();
            }
            SecondaryBox.Text = sortedList[SelectedWeaponIndex].SecondaryStat;
            PassiveBox.Text = sortedList[SelectedWeaponIndex].Passive;

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Cancel_Button_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Clicked(object sender, RoutedEventArgs e)
        {
            sortedList[SelectedWeaponIndex].Name = NameBox.Text;
            Enum.TryParse(TypeList.Text, out WeaponType type);
            sortedList[SelectedWeaponIndex].Type = type;
            sortedList[SelectedWeaponIndex].Image = URLBox.Text;
            sortedList[SelectedWeaponIndex].Rarity = int.Parse(RarityList.Text);
            sortedList[SelectedWeaponIndex].BaseAttack = int.Parse(AttackBox.Text);
            sortedList[SelectedWeaponIndex].SecondaryStat = (SecondaryBox.Text);
            sortedList[SelectedWeaponIndex].Passive = PassiveBox.Text;

            fullList.Clear();
            for(int i =0;i<sortedList.Count;i++)
            {
                fullList.Add(sortedList[i]);
            }
            this.Close();
        }

        private void URL_Changed(object sender, TextChangedEventArgs e)
        {
            BitmapImage bi = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.
            bi.BeginInit();
            bi.UriSource = new Uri(URLBox.Text, UriKind.RelativeOrAbsolute);
            bi.EndInit();
            // Set the image source.
            Image.Source = bi;
        }

        private void Generate_Clicked(object sender, RoutedEventArgs e)
        {
            int ran = random.Next(1,5);
            switch (ran)
            {
                case 1:
                    TypeList.SelectedItem = Sword;
                    break;
                case 2:
                    TypeList.SelectedItem = Claymore;
                    break;
                case 3:
                    TypeList.SelectedItem = Polearm;
                    break;
                case 4:
                    TypeList.SelectedItem = Bow;
                    break;
                case 5:
                    TypeList.SelectedItem = Catalyst;
                    break;
            }
            int ran2 = random.Next(1,5);
            switch (ran)
            {
                case 1:
                    RarityList.SelectedItem = Rarity1;
                    break;
                case 2:
                    RarityList.SelectedItem = Rarity2;
                    break;
                case 3:
                    RarityList.SelectedItem = Rarity3;
                    break;
                case 4:
                    RarityList.SelectedItem = Rarity4;
                    break;
                case 5:
                    RarityList.SelectedItem = Rarity5;
                    break;
            }
            AttackBox.Text = random.Next(1, 50).ToString();
        }
    }
}
