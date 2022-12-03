using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeaponLib;
using static Assignment2C.ListControl;
public enum SortMode { Name, Atttack, Secondary, Passive, Rarity };
public enum FilterMode {Sword,Polearm,Claymore,Catalyst,Bow,None };

namespace Assignment2C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();



        }
        private void Load_Button_Clicked(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.FileName = "Document"; // Default file name
            //dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "All File Types|*.csv;*.json;*.XML;"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string fileName = dlg.FileName;
                //LoadList()
                if (fullList.Count <= 0)
                {
                    fullList.Clear();
                }
                fullList.Load(fileName);

            }
            Sort();
            FillListBox();
            Add_Button.IsEnabled = true;
        }
        private void Save_Button_Clicked(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "OutputFile"; // Default file name
            //dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "All File Types|*.csv;*.json;*.XML;"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string fileName = dlg.FileName;
                fullList.Save(fileName, false);

            }
        }
        public void FillListBox(){
            if (WeaponList != null)
            {
                WeaponList.Items.Clear();
                WeaponList.ItemsSource = null;
            }
            int num = sortedList.Count();
            for (int i = 0; i < sortedList.Count(); i++)
            {
                WeaponList.Items.Add(sortedList[i]);

            }
        }

        private void Name_Sort_Checked(object sender, RoutedEventArgs e)
        {
            currentSort = SortMode.Name;
            Sort();
            FillListBox();
        }
        private void Passive_Sort_Checked(object sender, RoutedEventArgs e)
        {
            currentSort = SortMode.Passive;
            Sort();
            FillListBox();
        }
        private void Attack_Sort_Checked(object sender, RoutedEventArgs e)
        {
            currentSort = SortMode.Atttack;
            Sort();
            FillListBox();
        }
        private void Secondary_Sort_Checked(object sender, RoutedEventArgs e)
        {
            currentSort = SortMode.Secondary;
            Sort();
            FillListBox();
        }
        private void Rarity_Sort_Checked(object sender, RoutedEventArgs e)
        {
            currentSort = SortMode.Rarity;
            Sort();
            FillListBox();
        }

        private void Delete_Pressed(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<fullList.Count();i++) {
                if (fullList[i] == WeaponList.SelectedItem)
                {
                    fullList.RemoveAt(i);
                }
            }
            //sortedList.RemoveAt(WeaponList.Items.IndexOf(WeaponList.SelectedItem));
            Sort();
            FillListBox();
        }

        private void Sword_Filter_Selected(object sender, RoutedEventArgs e)
        {
            currentFilter = FilterMode.Sword;
            Sort();
            FillListBox();
        }
        private void None_Filter_Selected(object sender, RoutedEventArgs e)
        {
            currentFilter = FilterMode.None;
            Sort();
            FillListBox();
        }

        private void Polearm_Filter_Selected(object sender, RoutedEventArgs e)
        {
            currentFilter = FilterMode.Polearm;
            Sort();
            FillListBox();
        }

        private void Claymore_Filter_Selected(object sender, RoutedEventArgs e)
        {
            currentFilter = FilterMode.Claymore;
            Sort();
            FillListBox();
        }

        private void Catalayst_Filter_Selected(object sender, RoutedEventArgs e)
        {
            currentFilter = FilterMode.Catalyst;
            Sort();
            FillListBox();
        }

        private void Bow_Filter_Selected(object sender, RoutedEventArgs e)
        {
            currentFilter = FilterMode.Bow;
            Sort();
            FillListBox();
        }

        private void Edit_Button_Pressed(object sender, RoutedEventArgs e)
        {
            SelectedWeaponIndex = WeaponList.Items.IndexOf(WeaponList.SelectedItem);
            EditWindow newEdit = new EditWindow();
            newEdit.ShowDialog();
            FillListBox();
        }

        private void Filter_Text_Changed(object sender, TextChangedEventArgs e)
        {

            FilterText = FilterTextBox.Text;
            Sort();
            FillListBox();
        }

        private void List_Box_Selected(object sender, RoutedEventArgs e)
        {
            Edit_Button.IsEnabled = true;
            Remove_Button.IsEnabled = true;

        }

        private void Add_Button_Clicked(object sender, RoutedEventArgs e)
        {
            Weapon newWeapon = new Weapon();
            sortedList.Add(newWeapon);
            WeaponList.Items.Add(newWeapon);
            //int count = WeaponList.Items.Count;
            SelectedWeaponIndex = WeaponList.Items.Count-1;
            EditWindow newAdd = new EditWindow();
            newAdd.ShowDialog();
        }
    }
}
