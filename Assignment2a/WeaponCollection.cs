using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Assignment2a.Weapon;

namespace Assignment2a
{
    internal class WeaponCollection : List<Weapon>, IPersistence
    {
        public int GetHighestBaseAttack() {
            int highest = this[0].BaseAttack;
            for (int i = 0; i < this.Count; i++)
            {
                if (highest < this[i].BaseAttack)
                {
                    highest = this[i].BaseAttack;
                }

            }
            return highest;
        }
        public int GetLowestBaseAttack() {
            int lowest = this[0].BaseAttack;
            for (int i = 0; i < this.Count; i++)
            {
                if (lowest > this[i].BaseAttack)
                {
                    lowest = this[i].BaseAttack;
                }
            }
            return lowest;
        }
        public List<Weapon> GetAllWeaponsOfType(WeaponType type) {
        WeaponCollection list = new WeaponCollection();

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Type == type)
                {
                    list.Add(this[i]);
                }
            }
            return list;
        }
        public List<Weapon> GetAllWeaponsOfRarity(int stars) {
        WeaponCollection list = new WeaponCollection();

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Rarity == stars)
                {
                    list.Add(this[i]);
                }
            }
            return list;
        }
        public void SortBy(string columnName) {
        
        
        
        }
        public bool Load(string fileName)
        {

            // TODO: implement the streamreader that reads the file and appends each line to the list
            // note that the result that you get from using read is a string, and needs to be parsed 
            // to an int for certain fields i.e. HP, Attack, etc.
            // i.e. int.Parse() and if the results cannot be parsed it will throw an exception
            // or can use int.TryParse() 

            // streamreader https://msdn.microsoft.com/en-us/library/system.io.streamreader(v=vs.110).aspx
            // Use string split https://msdn.microsoft.com/en-us/library/system.string.split(v=vs.110).aspx
            if (!File.Exists(fileName))
            {
                return false;
            }
            else
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    // Skip the first line because header does not need to be parsed.
                    // Name,Type,Rarity,BaseAttack

                    string header = reader.ReadLine();

                    // The rest of the lines looks like the following:
                    // Skyward Blade,Sword,5,46
                    while (reader.Peek() > 0)
                    {
                        string line = reader.ReadLine();

                        //Weapon weapon = new Weapon();
                        Weapon.TryParse(line, out Weapon weapon);

                        this.Add(weapon);
                        // TODO: validate that the string array the size expected.
                        // TODO: use int.Parse or TryParse for stats/number values.
                        // Populate the properties of the Weapon
                        // TODO: Add the Weapon to the list
                    }
                    return true;
                }
            }
        }
        public bool Save(string fileName, bool appendToFile)
        {
                if (!string.IsNullOrEmpty(fileName))
                {
                    FileStream fs;

                    // Check if the append flag is set, and if so, then open the file in append mode; otherwise, create the file to write.
                    if (appendToFile && File.Exists((fileName)))
                    {
                        fs = File.Open(fileName, FileMode.Append);
                    }
                    else
                    {
                        fs = File.Open(fileName, FileMode.Create);
                    }

                    // opens a stream writer with the file handle to write to the output file.
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        // Hint: use writer.WriteLine
                        // TODO: write the header of the output "Name,Type,Rarity,BaseAttack"
                        writer.WriteLine("Name,Type,Rarity,BaseAttack");
                        // TODO: use the writer to output the results.
                        for (int i = 0; i < this.Count; i++)
                        {
                            writer.WriteLine(this[i].ToString());
                        }
                        // TODO: print out the file has been saved.
                        Console.WriteLine("File Saved");

                    }
                }
                else
                {
                    // prints out each entry in the weapon list results.
                    for (int i = 0; i < this.Count; i++)
                    {
                        Console.WriteLine(this[i]);
                    }
                }
            Console.WriteLine("Done!");
            return true;
        }
    }
}

