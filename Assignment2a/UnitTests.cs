using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NuGet.Frameworks;
using NUnit.Framework;

namespace Assignment2a
{
    [TestFixture]
    public class UnitTests
    {
        // private WeaponCollection WeaponCollection;
        private string inputPath;
        private string outputPath;

        const string INPUT_FILE = "data2.csv";
        const string OUTPUT_FILE = "output2.csv";

        // A helper function to get the directory of where the actual path is.
        private string CombineToAppPath(string filename)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
        }

        [SetUp]
        public void SetUp()
        {
            inputPath = CombineToAppPath(INPUT_FILE);
            outputPath = CombineToAppPath(OUTPUT_FILE);
            // WeaponCollection = new WeaponCollection();
        }

        [TearDown]
        public void CleanUp()
        {
            // We remove the output file after we are done.
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
        }

        // WeaponCollection Unit Tests
        [Test]
        public void WeaponCollection_GetHighestBaseAttack_HighestValue()
        {
            // Expected Value: 48
            // TODO: call WeaponCollection.GetHighestBaseAttack() and confirm that it matches the expected value using asserts
            WeaponCollection list = new WeaponCollection();
            list.Load(inputPath);
            int highest = list.GetHighestBaseAttack();
            Assert.AreEqual(48, highest);
        }

        [Test]
        public void WeaponCollection_GetLowestBaseAttack_LowestValue()
        {
            // Expected Value: 23
            // TODO: call WeaponCollection.GetLowestBaseAttack() and confirm that it matches the expected value using asserts.
            WeaponCollection list = new WeaponCollection();
            list.Load(inputPath);
            int lowest = list.GetLowestBaseAttack();
            Assert.AreEqual(23, lowest);
        }

        [TestCase(WeaponType.Sword, 21)]
        public void WeaponCollection_GetAllWeaponsOfType_ListOfWeapons(WeaponType type, int expectedValue)
        {
            List<Weapon> typeList = new List<Weapon>();
            WeaponCollection list = new WeaponCollection();
            list.Load(inputPath);
            typeList = list.GetAllWeaponsOfType(type);
            Assert.AreEqual(typeList.Count, expectedValue);
        }

        [TestCase(5, 10)]
        public void WeaponCollection_GetAllWeaponsOfRarity_ListOfWeapons(int rarity, int expectedValue)
        {
            List<Weapon> rarityList = new List<Weapon>();
            WeaponCollection list = new WeaponCollection();
            list.Load(inputPath);
            rarityList = list.GetAllWeaponsOfRarity(rarity);
            Assert.AreEqual(rarityList.Count, expectedValue);
        }

        [Test]
        public void WeaponCollection_LoadThatExistAndValid_True()
        {
            WeaponCollection list = new WeaponCollection();
            Assert.IsTrue(list.Load(inputPath));
            Assert.AreEqual(list.Count, 95);
        }

        [Test]
        public void WeaponCollection_LoadThatDoesNotExist_FalseAndEmpty()
        {
            string fakeInput = null;
            WeaponCollection list = new WeaponCollection();
            Assert.IsFalse(list.Load(fakeInput));
            Assert.AreEqual(list.Count, 0);

        }

        [Test]
        public void WeaponCollection_SaveWithValuesCanLoad_TrueAndNotEmpty()
        {
            string fakeInput = null;
            WeaponCollection list = new WeaponCollection();

            Assert.IsTrue(list.Load(inputPath));
            Assert.IsTrue(list.Save(outputPath, false));
            Assert.IsTrue(list.Count != 0);
        }

        [Test]
        public void WeaponCollection_SaveEmpty_TrueAndEmpty()
        {
            //After saving an empty WeaponCollection, load the file and expect WeaponCollection to be empty.
            WeaponCollection list = new WeaponCollection();
            Assert.IsTrue(list.Save(outputPath,false));
            Assert.IsTrue(list.Load(outputPath));
            Assert.IsTrue(list.Count == 0);
        }

        // Weapon Unit Tests
        [Test]
        public void Weapon_TryParseValidLine_TruePropertiesSet()
        {
            // TODO: create a Weapon with the stats above set properly
            Weapon expected = null;
            // TODO: uncomment this once you added the Type1 and Type2
            expected = new Weapon()
            {
                Name = "Skyward Blade",
                Type = WeaponType.Sword,
                Image = "https://vignette.wikia.nocookie.net/gensin-impact/images/0/03/Weapon_Skyward_Blade.png",
                Rarity = 5,
                BaseAttack = 46,
                SecondaryStat = "Energy Recharge",
                Passive = "Sky-Piercing Fang"
            };

            string line = "Skyward Blade,Sword,https://vignette.wikia.nocookie.net/gensin-impact/images/0/03/Weapon_Skyward_Blade.png,5,46,Energy Recharge,Sky-Piercing Fang";
            Weapon actual = null;

            // TODO: uncomment this once you have TryParse implemented.
            Assert.IsTrue(Weapon.TryParse(line, out actual));
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.BaseAttack, actual.BaseAttack);




            // TODO: check for the rest of the properties, Image,Rarity,SecondaryStat,Passive
        }

        [Test]
        public void Weapon_TryParseInvalidLine_FalseNull()
        {
            // TODO: use "1,Bulbasaur,A,B,C,65,65", Weapon.TryParse returns false, and Weapon is null.
            //Weapon weapon;
            //Assert.IsTrue(Weapon.TryParse("1,Bulbasaur,A,B,C,65,65", out weapon));
        }
        [Test]
        public void WeaponCollection_Load_Save_Load_ValidJson()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            weapons.Load("data2.csv");
            weapons.Save("weapons.JSON", false);
            weapons.Clear();
            weapons.Load("weapons.JSON");

            Assert.AreEqual(95, weapons.Count());
        }
        [Test]
        public void WeaponCollection_Load_SaveAsJSON_Load_ValidJson()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            weapons.Load("data2.csv");
            weapons.SaveAsJSON("weapons.JSON");
            weapons.Clear();
            weapons.Load("weapons.JSON");

            Assert.AreEqual(95, weapons.Count());
        }
        [Test]
        public void WeaponCollection_Load_SaveAsJSON_LoadJSON_ValidJson()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            weapons.Load("data2.csv");
            weapons.SaveAsJSON("weapons.JSON");
            weapons.Clear();
            weapons.LoadJSON("weapons.JSON");

            Assert.AreEqual(95, weapons.Count());
        }
        public void WeaponCollection_Load_Save_Load_JSON_ValidJson()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            weapons.Load("data2.csv");
            weapons.SaveAsJSON("weapons.JSON");
            weapons.Clear();
            weapons.LoadJSON("weapons.JSON");

            Assert.AreEqual(95, weapons.Count());
        }
        public void WeaponCollection_Load_Save_Load_ValidCsv()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            weapons.Load("data2.csv");
            weapons.Save("weapons.csv",false);
            weapons.Clear();
            weapons.Load("weapons.csv");

            Assert.AreEqual(95, weapons.Count());
        }
        [Test]
        public void WeaponCollection_Load_SaveAsCSV_LoadCSV_ValidCsv()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            weapons.Load("data2.csv");
            weapons.SaveAsCSV("weapons.csv", false);
            weapons.Clear();
            weapons.LoadCSV("weapons.csv");

            Assert.AreEqual(95, weapons.Count());
        }
        [Test]
        public void WeaponCollection_Load_Save_Load_ValidXml()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            weapons.Load("data2.csv");
            weapons.Save("weapons.XML", false);
            weapons.Clear();
            weapons.Load("weapons.XML");

            Assert.AreEqual(95, weapons.Count());
        }
        [Test]
        public void WeaponCollection_SaveEmpty_Load_ValidJson()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            
            weapons.SaveAsJSON("weapons.JSON");
            weapons.Clear();
            weapons.Load("weapons.JSON");

            Assert.AreEqual(0, weapons.Count());
        }
        [Test]
        public void WeaponCollection_SaveEmpty_Load_ValidCsv()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();

            weapons.SaveAsCSV("weapons.CSV", false);
            weapons.Clear();
            weapons.Load("weapons.CSV");

            Assert.AreEqual(0, weapons.Count());
        }
        [Test]
        public void WeaponCollection_ValidCsv_LoadJSON_InvalidJson()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            weapons.LoadJSON("data2.CSV");

            Assert.AreEqual(0, weapons.Count());
        }
        [Test]
        public void WeaponCollection_Load_SaveJSON_LoadXML_InvalidXml()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            weapons.LoadJSON("data2.CSV");
            weapons.SaveAsJSON("weapons.JSON");
            weapons.LoadXML("weapons.JSON");

            Assert.AreEqual(0, weapons.Count());
        }
        [Test]
        public void WeaponCollection_Load_SaveXML_LoadJSON_InvalidJson()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            weapons.LoadJSON("data2.CSV");
            weapons.SaveAsXML("weapons.XML");
            weapons.LoadJSON("weapons.XML");
            Assert.AreEqual(0, weapons.Count());
        }
        [Test]
        public void WeaponCollection_ValidCsv_LoadXML_InvalidXml()
        {
            //Load the data2.csv and Save() it weapons.json and call Load() output and validate that there’s 95 entries
            WeaponCollection weapons = new WeaponCollection();
            weapons.LoadXML("data2.CSV");

            Assert.AreEqual(0, weapons.Count());
        }
    }
}
