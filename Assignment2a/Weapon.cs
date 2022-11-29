﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2a
{
    public enum WeaponType { Sword, Polearm, Claymore, Catalyst, Bow, None };

    public class Weapon
    {
        // Name,Type,Rarity,BaseAttack

        public string Name { get; set; }
        public WeaponType Type { get; set; }
        public int Rarity { get; set; }
        public int BaseAttack { get; set; }
        public string Image { get; set; }
        public string SecondaryStat { get; set; }
        public string Passive { get; set; }

        /// <summary>
        /// The Comparator function to check for name
        /// </summary>
        /// <param name="left">Left side Weapon</param>
        /// <param name="right">Right side Weapon</param>
        /// <returns> -1 (or any other negative value) for "less than", 0 for "equals", or 1 (or any other positive value) for "greater than"</returns>
        public static int CompareByName(Weapon left, Weapon right)
        {
            return left.Name.CompareTo(right.Name);
        }

        // TODO: add sort for each property:
        // CompareByType
        public static int CompareByType(Weapon left, Weapon right)
        {
            return left.Type.CompareTo(right.Type);
        }
        // CompareByRarity\
        public static int CompareByRarity(Weapon left, Weapon right)
        {
            return left.Rarity.CompareTo(right.Rarity);
        }
        // CompareByBaseAttack
        public static int CompareByAttack(Weapon left, Weapon right)
        {
            return left.BaseAttack.CompareTo(right.BaseAttack);
        }

        /// <summary>
        /// The Weapon string with all the properties
        /// </summary>
        /// <returns>The Weapon formated string</returns>
        public override string ToString()
        {
            // TODO: construct a comma seperated value string
            // Name,Type,Rarity,BaseAttack
            return $"{Name},{Type},{Rarity},{BaseAttack}";
        }

        public static bool TryParse(string line, out Weapon weapon)
        {
            string[] values = line.Split(',');
            weapon = new Weapon();
            if (values.Length == 7)
            {
                weapon.Name = values[0];
                int num = 0;
                switch (values[1])
                {
                    case "Sword":
                        num = 0;
                        break;
                    case "Polearm":
                        num = 1;
                        break;
                    case "Claymore":
                        num = 2;
                        break;
                    case "Catalyst":
                        num = 3;
                        break;
                    case "Bow":
                        num = 4;
                        break;
                    case "None":
                        num = 5;
                        break;
                    default:
                        break;
                }
                weapon.Type = (WeaponType)num;
                weapon.Image = values[2];
                weapon.Rarity = int.Parse(values[3]);
                weapon.BaseAttack = int.Parse(values[4]);
                weapon.SecondaryStat = values[5];
                weapon.Passive = values[6];
            }
            return true;
        }
    }
}
