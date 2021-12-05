using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projetValo
{
    class Game
    {
        #region Attributs
        public int Index { get; set; }
        public string[] Options { get; set; }
        public string Prompt { get; set; }
        #endregion

       
        #region Builder
        public Game(string _prompt, string[] _options)
        {
            Prompt = _prompt;
            Options = _options;
            Index = 0;
        }
        public Game()
        {

        }
        #endregion

        /// <summary>
        ///  /// <summary>
        /// Methods inspired by a video for the design of the console      
        /// </summary>
        #region ConsoleBuilder
        /// <summary>
        ///  /// <summary>
        /// Method which design the different possible choices
        /// </summary>
        public void DisplayOptions()
        {
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine();
            }

            Console.WriteLine(Prompt);

            for (int j = 0; j < 12; j++)
            {
                Console.WriteLine();
            }

            for (int i = 0; i < Options.Length; i++) //  We display the different choices
            {
                string currentOption = Options[i];
                string Mouse;

                if (i == Index) // We just put an index for each choice
                {
                    Mouse = "=>";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Mouse = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                string Design = $"{Mouse} << {currentOption} >>";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + Design.Length / 2) + "}", Design);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Method that allows us to move our cursor and thus change the index according to our location. We make a loop to return to the index of the edge
        /// </summary>
        /// <returns></returns>
        public int Choice()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    Index--;
                    if (Index == -1)
                    {
                        Index = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    Index++;
                    if (Index == Options.Length)
                    {
                        Index = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return Index;
        }
        #endregion

        #region Game
        public void GameValoNoPrice()
        {
            List yo = new List();

            Showall();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player 1 ");
            Console.ResetColor();
            Console.Write("choose");

            string Agent1 = yo.VerifHero();

            Console.Clear();
            Showall();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player 1 ");
            Console.ResetColor();
            Console.Write("choose");

            string Weapon1 = yo.VerifWeapon();

            Console.Clear();
            Showall();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player 1 ");
            Console.ResetColor();
            Console.Write("choose");

            string Skill1 = yo.VerifSkill();

            Console.Clear();
            Showall();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player 2 ");
            Console.ResetColor();
            Console.Write("choose");

            string Agent2 = yo.VerifHero();

            Console.Clear();
            Showall();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player 2 ");
            Console.ResetColor();
            Console.Write("choose");

            string Weapon2 = yo.VerifWeapon();

            Console.Clear();
            Showall();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player 2 ");
            Console.ResetColor();
            Console.Write("choose");

            string Skill2 = yo.VerifSkill();
       
            Console.Clear();
            yo.Game(Agent1, Weapon1, Skill1, Agent2, Weapon2, Skill2);
            yo.ShowGame();
        }
        public void GameValo()
        {

            List yo = new List();
            Showall();

            Console.ResetColor();
            Console.Write("\n                                                                                        Each player has ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("800 $ ");
            Console.ResetColor();
            Console.Write("to make their selection\n");
            Console.Write("There is a table listing the ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("PRICES ");
            Console.ResetColor();
            Console.Write("of all agents, weapons and skills.\n");


            int MoneyP1 = 800;
            int MoneyP2 = 800;
            bool Verif = false;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nPlayer 1 ");
            Console.ResetColor();
            Console.Write("choose");
            int PAgent1 = PriceAgent();

            string Agent1 = "";
            string Weapon1 = "";
            string Skill1 = "";
            string Agent2 = "";
            string Weapon2 = "";
            string Skill2 = "";


            while (Verif != true)
            {
                if (MoneyP1 >= PAgent1)
                {
                    MoneyP1 = MoneyP1 - PAgent1;
                    Agent1 = StringAgent(PAgent1);
                    Verif = true;
                }
                else
                {
                    Console.WriteLine("You don't have enough money ! Choose another agent : \n");
                    PAgent1 = PriceAgent();
                }
            }

            Console.Clear();
            Showall();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player 1 ");
            Console.ResetColor();
            Console.Write("choose");

            Console.Write("\n\nThe remaining currency : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(MoneyP1);
            Console.ResetColor();

            int PWeapon1 = PriceWeapon();
            Verif = false;
            while (Verif != true)
            {
                if (MoneyP1 >= PWeapon1)
                {
                    MoneyP1 = MoneyP1 - PWeapon1;
                    Weapon1 = StringWeapon(PWeapon1);
                    Verif = true;
                }
                else
                {
                    Console.WriteLine("You don't have enough money ! Choose another weapon : \n");
                    PWeapon1 = PriceWeapon();                   
                }
            }

            Console.Clear();
            Showall();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player 1 ");
            Console.ResetColor();
            Console.Write("choose");

            Console.Write("\n\nThe remaining currency : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(MoneyP1);
            Console.ResetColor();

            int PSkill1 = PriceSkill();
            Verif = false;
            while (Verif != true)
            {
                if (MoneyP1 >= PSkill1)
                {
                    MoneyP1 = MoneyP1 - PSkill1;
                    Skill1 = StringSkill(PSkill1);
                    Verif = true;
                }
                else
                {
                    Console.WriteLine("You don't have enough money ! Choose another skill : \n");
                    PSkill1 = PriceSkill();
                }
            }

            Console.Clear();
            Showall();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player 2 ");
            Console.ResetColor();
            Console.Write("choose");

            int PAgent2 = PriceAgent();
            Verif = false;

            while (Verif != true)
            {
                if (MoneyP2 >= PAgent2)
                {
                    MoneyP2 = MoneyP2 - PAgent2;
                    Agent2 = StringAgent(PAgent2);
                    Verif = true;
                }
                else
                {
                    Console.WriteLine("You don't have enough money ! Choose another agent : \n");
                    PAgent2 = PriceAgent();
                }
            }

            Console.Clear();
            Showall();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player 2 ");
            Console.ResetColor();
            Console.Write("choose");

            Console.Write("\n\nThe remaining currency : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(MoneyP2);
            Console.ResetColor();

            int PWeapon2 = PriceWeapon();
            Verif = false;

            while (Verif != true)
            {
                if (MoneyP2 >= PWeapon2)
                {
                    MoneyP2 = MoneyP2 - PWeapon2;
                    Weapon2 = StringWeapon(PWeapon2);
                    Verif = true;
                }
                else
                {
                    Console.WriteLine("You don't have enough money ! Choose another weapon : \n");
                    PWeapon2 = PriceWeapon();
                }
            }

            Console.Clear();
            Showall();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player 2 ");
            Console.ResetColor();
            Console.Write("choose");

            Console.Write("\n\nThe remaining currency : ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(MoneyP2);
            Console.ResetColor();

            int PSkill2 = PriceSkill();
            Verif = false;

            while (Verif != true)
            {
                if (MoneyP2 >= PSkill2)
                {
                    MoneyP2 = MoneyP2 - PSkill2;
                    Skill2 = StringSkill(PSkill2);
                    Verif = true;
                }
                else
                {
                    Console.WriteLine("You don't have enough money ! Choose another skill : \n");
                    PSkill2 = PriceSkill();
                }
            }

            Console.Clear();
            yo.Game(Agent1, Weapon1, Skill1, Agent2, Weapon2, Skill2);
            yo.ShowGame();
        }

        /// <summary>
        /// We assign a price according to the agent, weapon and skill then in the affect to be able to return a string of the weapon and skill agent which will be saved in a new file, used for the game.
        /// </summary>
        /// <returns></returns>
        public int PriceAgent()
        {
            List yo = new List();

            int PriceAgent = -1;
            string Agent = yo.VerifHero();

            if (Agent == "chamber;150")
            {
                return PriceAgent = 200;
            }
            else if (Agent == "reyna;180")
            {
                return PriceAgent = 500;
            }
            else if (Agent == "breach;100")
            {
                return PriceAgent = 100;
            }
            return PriceAgent;
        }
        public int PriceWeapon()
        {
            List yo = new List();
            int PriceWeapon = -1;
            string Weapon = yo.VerifWeapon();

            if (Weapon == "phantom;20;5")
            {
                return PriceWeapon = 200;
            }
            else if (Weapon == "vandal;40;2")
            {
                return PriceWeapon = 500;
            }
            else if (Weapon == "odin;10;12")
            {
                return PriceWeapon = 100;
            }
            return PriceWeapon;
        }
        public int PriceSkill()
        {
            List yo = new List();
            int PriceSkill = -1;
            string Skill = yo.VerifSkill();

            if (Skill == "healing")
            {
                return PriceSkill = 200;
            }
            else if (Skill == "slaughter")
            {
                return PriceSkill = 500;
            }
            else if (Skill == "reloading")
            {
                return PriceSkill = 100;
            }
            return PriceSkill;
        }
        public string StringAgent(int PriceAgent)
        {           
            string StringAgent = "-1";

            if (PriceAgent == 500)
            {
                return StringAgent = "reyna;180";
            }
            else if (PriceAgent == 200)
            {
                return StringAgent = "chamber;150";
            }
            else if (PriceAgent == 100)
            {
                return StringAgent = "breach;100";
            }
            return StringAgent;
        }
        public string StringWeapon(int PriceWeapon)
        {
            string StringWeapon = "-1";

            if (PriceWeapon == 500)
            {
                return StringWeapon = "vandal;40;2";
            }
            else if (PriceWeapon == 200)
            {
                return StringWeapon = "phantom;20;5";
            }
            else if (PriceWeapon == 100)
            {
                return StringWeapon = "odin;10;12";
            }
            return StringWeapon;
        }
        public string StringSkill(int PriceSkill)
        {
            string StringSkill = "-1";

            if (PriceSkill == 500)
            {
                return StringSkill = "slaughter";
            }
            else if (PriceSkill == 200)
            {
                return StringSkill = "healing";
            }
            else if (PriceSkill == 100)
            {
                return StringSkill = "reloading";
            }
            return StringSkill;
        }
        public void Showall()
        {
            List yo = new List();

            yo.CreateHeros();
            yo.CreateWeapons();
            yo.CreatSkill();

            Console.WriteLine();
            yo.ShowHero();
            Console.WriteLine();
            yo.ShowWeapon();
            Console.WriteLine();
            yo.ShowSkill();
            Console.WriteLine();
            yo.ShowPrice();
            Console.WriteLine();
        }
        #endregion
    }
}
