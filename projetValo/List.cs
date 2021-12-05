using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetValo
{
    public class List
    {
        #region Agent
        public void CreateHeros()
        {
            List<Hero> Heros = new List<Hero>()
            {
               new Hero() {HeroName = "chamber", Life = 150},
               new Hero() {HeroName = "reyna", Life = 180},
               new Hero() {HeroName = "breach", Life = 100},
            };

            string path = ".\\Hero.txt";

            using (StreamWriter sw = new StreamWriter(path)) // We write our agent list to a new file
            {
                foreach (Hero currentHero in Heros)  // We display the list and write it to the file
                {
                    sw.WriteLine($"{currentHero.HeroName};{currentHero.Life}");
                }
            }
        }

        /// <summary>
        /// We read the file where we wrote the agents with their lives and we put our display in a table created with the methods below.
        /// </summary>
        public void ShowHero()
        {
            string path = ".\\Hero.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;


                    PrintLine();
                    PrintRow(" ", " ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    PrintRow("Agent's Name", "Agent's Life Hp");
                    Console.ResetColor();
                    PrintRow(" ", " ");
                    PrintLine();

                    while ((line = sr.ReadLine()) != null) 
                    {
                        string[] splitData = line.Split(';');

                        // PrintRow(" ", " ");
                        PrintRow($"{splitData[0]}", $"{splitData[1]}");
                        //PrintRow(" ", " ");
                        PrintLine();

                        //Console.WriteLine($"\t{splitData[0]}\t{splitData[1]}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }
        #endregion

        /// <summary>
        /// Methods inspire from a site that allows assigning a table design when viewing files.
        /// </summary>
        #region Table
        static int tableWidth = 73;
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }
        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }
        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        #endregion

        #region Weapon
        public void CreateWeapons()
        {
            List<Weapon> Weapons = new List<Weapon>()
            {
               new Weapon() {WeaponName = "vandal", Damage = 40 , Bullets = 2},
               new Weapon() { WeaponName = "phantom", Damage = 20 , Bullets = 5},
               new Weapon() { WeaponName = "odin", Damage = 10 , Bullets = 12},
            };

            string path = ".\\Weapon.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Weapon currentWeapon in Weapons)
                {
                    sw.WriteLine($"{currentWeapon.WeaponName};{currentWeapon.Damage};{currentWeapon.Bullets}");
                }
            }
        }
        public void ShowWeapon()
        {
            string path = ".\\Weapon.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    PrintLine();
                    PrintRow(" ", " ", " ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    PrintRow("Weapon", "Damage", "Bullet");
                    Console.ResetColor();
                    PrintRow(" ", " ", " ");
                    PrintLine();



                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(';');

                        //  PrintRow(" ", " ", " ");
                        PrintRow($"{splitData[0]}", $"{splitData[1]}", $"{splitData[2]}");
                        //  PrintRow(" ", " ", " ");
                        PrintLine();

                        // Console.WriteLine($"\t{splitData[0]}\t{splitData[1]}\t{splitData[2]}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Skill
        public void CreatSkill()
        {

            List<Skill> Skills = new List<Skill>()
            {
               new Skill() {SkillName = "healing"},
               new Skill() {SkillName = "reloading"},
               new Skill() {SkillName = "slaughter"},
            };

            string path = ".\\Skill.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Skill currentSkill in Skills)
                {
                    sw.WriteLine($"{currentSkill.SkillName}");
                }
            }
        }
        public void ShowSkill()
        {
            string path = ".\\Skill.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    PrintLine();
                    PrintRow(" ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    PrintRow("Skill");
                    Console.ResetColor();
                    PrintRow(" ");
                    PrintLine();
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(';');

                        //PrintRow(" ");
                        PrintRow($"{splitData[0]}");
                        //  PrintRow(" ");
                        PrintLine();

                        //Console.WriteLine($"\t{splitData[0]}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Money
        public void ShowMoney()
        {
            string path = ".\\Money.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("1100");
                sw.WriteLine("1100");
            }

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(';');
                        Console.WriteLine($"\t{splitData[0]}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public void ShowPrice()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string Agent = "AGENT";
            string Skill = "SKILL";
            string Weapon = "WEAPON";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string Price = "Price";
            int Money = 800;
           // Console.ResetColor();
            string Output = $@"      
                                                                           -------------------------------------------------------- 
                                                                           |                                              | {Price} |
                                                                           -------------------------------------------------------- 

        --------------------------------------------------------           --------------------------------------------------------           -------------------------------------------------------- 
        |                        {Agent}                 |       |           |                      {Weapon}                  |       |           |                      {Skill}                   |       |
        --------------------------------------------------------           --------------------------------------------------------           --------------------------------------------------------
        --------------------------------------------------------           --------------------------------------------------------           --------------------------------------------------------
        | Breach                                       | 100   |           | Odin                                         | 100   |           | Reloading                                    | 100   |
        --------------------------------------------------------           --------------------------------------------------------           -------------------------------------------------------- 
        | Chamber                                      | 200   |           | Phantom                                      | 200   |           | Healing                                      | 200   |
        --------------------------------------------------------           --------------------------------------------------------           -------------------------------------------------------- 
        | Reyna                                        | 500   |           | Vandal                                       | 500   |           | Slaughter                                    | 500   |
        --------------------------------------------------------           --------------------------------------------------------           --------------------------------------------------------

                                                                           --------------------------------------------------------
                                                                           |You have {Money} $ in order to pick one of each category  |
                                                                           --------------------------------------------------------

        ";
            
            Console.WriteLine(Output);          
        }
        public int Money1()
        {
            string path = ".\\Money.txt";

            string reader = File.ReadLines(path).First();
            int Money = Convert.ToInt32(reader[0]);
            return Money;
        }
        public int Money2()
        {
            string path = ".\\Money.txt";

            string reader = File.ReadLines(path).Last();
            int Money = Convert.ToInt32(reader[0]);
            return Money;
        }
        #endregion

        #region Verification & Creation Game

        /// <summary>
        /// We check if the name typed does exist in the file and we return the line of the chosen file in string.
        /// </summary>
        /// <returns></returns>
        public string VerifHero()
        {
            List<string> prénoms = new List<string>();
            List<string> aze = new List<string>(File.ReadAllLines($".\\Hero.txt")); // We just put our file in a list.


            foreach (string i in aze) // we just separate to take only the first index in front of the character ";" that we put in another list so that we only have a first name list.
            {
                prénoms.Add(i.Split(';')[0]);
            }

            Console.WriteLine();
            Console.Write("\nWrite the name of the "); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("AGENT ");
            Console.ResetColor();
            Console.Write("you want to pick :\n");
            string name = Convert.ToString(Console.ReadLine()).ToLower();

            bool result = prénoms.Contains($"{name}");

            while (result != true)
            {
                Console.WriteLine();
                Console.WriteLine(" Not find ! Retry again another name ");
                name = Convert.ToString(Console.ReadLine()).ToLower();
                result = prénoms.Contains($"{name}");

            }
            return aze[prénoms.IndexOf(name)]; // After checking the existence of the choice, we will return the choice as well as the separate indexes to have all of the information returned.

        }
        public string VerifWeapon()
        {
            List<string> NameWeapon = new List<string>();
            List<string> aze = new List<string>(File.ReadAllLines($".\\Weapon.txt"));

           
            Console.WriteLine();           
            Console.Write("\nWrite the name of the ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Weapon :\n");
            Console.ResetColor();
            string name = Convert.ToString(Console.ReadLine()).ToLower();


            foreach (string i in aze)
            {
                NameWeapon.Add(i.Split(';')[0]);
            }


            bool result = NameWeapon.Contains($"{name}");


            while (result != true)
            {
                Console.WriteLine();
                Console.WriteLine(" Not find ! Retry again another name ");
                name = Convert.ToString(Console.ReadLine()).ToLower();
                result = NameWeapon.Contains($"{name}");
            }
            return aze[NameWeapon.IndexOf(name)];
        }
        public string VerifSkill()
        {
            List<string> aze = new List<string>(File.ReadAllLines($".\\Skill.txt"));

           
            Console.WriteLine();
            Console.WriteLine("\n             Healing   : Heal you of 100 pv ");
            Console.WriteLine("               Reloading : Reload 5 bullets on your weapon ");
            Console.WriteLine("               Slaughter : Damage of your weapon is doubled ");

            Console.WriteLine();          
            Console.Write("\nWrite the name of the ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Skill ");
            Console.ResetColor();
            Console.Write("that you want :\n");
            string name = Convert.ToString(Console.ReadLine()).ToLower();



            bool result = aze.Contains($"{name}");

            while (result != true)
            {
                Console.WriteLine();
                Console.WriteLine(" Not find ! Retry another name ");
                name = Convert.ToString(Console.ReadLine()).ToLower();
                result = aze.Contains($"{name}");
            }
            return name;
        }

        /// <summary>
        /// After having retrieved all the information we write it in a new file that will be used for the game.
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="weapon"></param>
        /// <param name="skill"></param>
        /// <param name="hero2"></param>
        /// <param name="weapon2"></param>
        /// <param name="skill2"></param>
        public void Game(string hero, string weapon, string skill, string hero2, string weapon2, string skill2)
        {
            string path = ".\\Game.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine($"{hero};{weapon};{skill}");
                sw.WriteLine($"{hero2};{weapon2};{skill2}");
            }
        }
        public void ShowGame()
        {
            string path = ".\\Game.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    PrintLine();
                    PrintRow(" ", " ", " ", " ", " ", " ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    PrintRow("Agent", "Life", "Weapon", "Damage", "Bullet", "Skill");
                    Console.ResetColor();
                    PrintRow(" ", " ", " ", " ", " ", " ");
                    PrintLine();
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitData = line.Split(';');
                        PrintRow($"{splitData[0]}", $"{splitData[1]}", $"{splitData[2]}", $"{splitData[3]}", $"{splitData[4]}", $"{splitData[5]}");
                        PrintLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}
