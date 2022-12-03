using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WeaponLib;

namespace Assignment2C
{
    public class ListControl
    {
        public static WeaponCollection fullList = new WeaponCollection();
        public static WeaponCollection sortedList = new WeaponCollection();

        private static ListControl instance = null;
        public static SortMode currentSort { get; set; } = SortMode.Name;
        public static FilterMode currentFilter { get; set; } = FilterMode.None;
        public static string FilterText;
        public static int SelectedWeaponIndex;

        private ListControl(){}
        public static ListControl Instance{
            get
            {
                if (instance == null)
                {
                    instance = new ListControl();
                }
                return instance;
            }
        }
        public static void Sort()
        {
            sortedList.Clear();
            for(int i = 0; i < fullList.Count(); i++)
            {
                sortedList.Add(fullList[i]);
            }
            //sortedList = fullList;
            if (currentFilter != FilterMode.None) {
                sortedList = (WeaponCollection)sortedList.GetAllWeaponsOfType((WeaponType)currentFilter);
            }
            switch (currentSort)
            {
                case SortMode.Name:
                    sortedList.SortBy("Name");
                    break;
                case SortMode.Atttack:
                    sortedList.SortBy("BaseAttack");
                    break;
                case SortMode.Rarity:
                    sortedList.SortBy("Rarity");
                    break;
                case SortMode.Passive:
                    sortedList.SortBy("Passive");
                    break;
                case SortMode.Secondary:
                    sortedList.SortBy("SecondaryStat");
                    break;

            }
            if(FilterText!= null)
            {
                for(int i =0; i < sortedList.Count();i++)
                {
                    if (!sortedList[i].Name.Contains(FilterText, StringComparison.OrdinalIgnoreCase))
                    {
                        sortedList.RemoveAt(i);
                        i--;
                    }
                    
                }
            }
        }
    }
}
