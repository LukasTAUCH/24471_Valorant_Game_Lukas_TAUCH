using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projetValo
{
    public abstract class Damage // abstract class with generalist methods used in child classes.
    {
        /// <summary>
        /// Methods allowing to separate each indexes of the file "Game" to be able to treat them individually.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        #region Index
        public double LifePlayer(string player)
        {
            string path = ".\\Game.txt";
            // We get the first line of the file for the 1st player and the last for the 2nd player.

            if (player == "player1")
            {
                string reader = File.ReadLines(path).First();
                string[] separate = reader.Split(';');
                double LifePlayer1 = Convert.ToDouble(separate[1]);
                return LifePlayer1;
            }
            else if (player == "player2")
            {
                string reader = File.ReadLines(path).Last();
                string[] separate = reader.Split(';');
                double LifePlayer2 = Convert.ToDouble(separate[1]);
                return LifePlayer2;
            }
            return -1;
        }
        public double DamageWeaponPlayer(string player)
        {
            string path = ".\\Game.txt";

            if (player == "player1")
            {
                string reader = File.ReadLines(path).First();
                string[] separate = reader.Split(';');
                double DamageWeaponPlayer1 = Convert.ToDouble(separate[3]);
                return DamageWeaponPlayer1;
            }
            else if (player == "player2")
            {
                string reader = File.ReadLines(path).Last();
                string[] separate = reader.Split(';');
                double DamageWeaponPlayer2 = Convert.ToDouble(separate[3]);
                return DamageWeaponPlayer2;
            }
            return -1;
        }
        public int BulletPlayer(string player)
        {
            string path = ".\\Game.txt";

            if (player == "player1")
            {
                string reader = File.ReadLines(path).First();
                string[] separate = reader.Split(';');
                int BulletPlayer1 = Convert.ToInt32(separate[4]);
                return BulletPlayer1;
            }
            else if (player == "player2")
            {
                string reader = File.ReadLines(path).Last();
                string[] separate = reader.Split(';');
                int BulletPlayer2 = Convert.ToInt32(separate[4]);
                return BulletPlayer2;
            }
            return -1;
        }
        public string NameHero(string player)
        {
            string path = ".\\Game.txt";

            if (player == "player1")
            {
                string reader = File.ReadLines(path).First();
                string[] separate = reader.Split(';');
                string NameHero1 = Convert.ToString(separate[0]);
                return NameHero1;
            }
            else if (player == "player2")
            {
                string reader = File.ReadLines(path).Last();
                string[] separate = reader.Split(';');
                string NameHero2 = Convert.ToString(separate[0]);
                return NameHero2;
            }
            return "-1";
        }
        public string NameWeapon(string player)
        {
            string path = ".\\Game.txt";

            if (player == "player1")
            {
                string reader = File.ReadLines(path).First();
                string[] separate = reader.Split(';');
                string NameWeapon1 = Convert.ToString(separate[2]);
                return NameWeapon1;
            }
            else if (player == "player2")
            {
                string reader = File.ReadLines(path).Last();
                string[] separate = reader.Split(';');
                string NameWeapon2 = Convert.ToString(separate[2]);
                return NameWeapon2;
            }
            return "-1";
        }
        public string NameSkill(string player)
        {
            string path = ".\\Game.txt";

            if (player == "player1")
            {
                string reader = File.ReadLines(path).First();
                string[] separate = reader.Split(';');
                string NameSkill1 = Convert.ToString(separate[5]);
                return NameSkill1;
            }
            else if (player == "player2")
            {
                string reader = File.ReadLines(path).Last();
                string[] separate = reader.Split(';');
                string NameSkill2 = Convert.ToString(separate[5]);
                return NameSkill2;
            }
            return "-1";
        }
        #endregion

        #region Rules
        /// <summary>
        /// We come to look at the index of the life of an agent of a player and then comes to subtract by the damage of the weapon of the other player who consequently loses 1 bullets. We then rewrite the file.
        /// </summary>
        /// <param name="player"></param>
        public void AttackPlayer(string player)
        {
            string path = ".\\Game.txt";

            if (player == "player1")
            {
                string NewNameHero1 = NameHero("player1");
                double NewLife1 = LifePlayer("player1");
                string NewNameWeapon1 = NameWeapon("player1");
                double NewDamagePlayer1 = DamageWeaponPlayer("player1");
                string NewSkill = NameSkill("player1");

                string NewNameHero2 = NameHero("player2");
                string NewNameWeapon2 = NameWeapon("player2");
                double NewDamagePlayer2 = DamageWeaponPlayer("player2");
                int NewBullet2 = BulletPlayer("player2");
                string NewSkill2 = NameSkill("player2");

                if (LifePlayer("player2") > DamageWeaponPlayer("player1") && BulletPlayer("player1") > 0)
                {
                    double NewLife = LifePlayer("player2") - DamageWeaponPlayer("player1");
                    int NewBullet = BulletPlayer("player1") - 1;


                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet};{NewSkill}");
                        sw.WriteLine($"{NewNameHero2};{NewLife};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill2}");
                    }
                }
                else if (LifePlayer("player2") <= DamageWeaponPlayer("player1") && BulletPlayer("player1") > 0)
                {
                    double NewLife = 0;
                    int NewBullet = BulletPlayer("player1") - 1;

                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet};{NewSkill}");
                        sw.WriteLine($"{NewNameHero2};{NewLife};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill2}");
                    }

                    Console.WriteLine("Player 2 DEAD");

                }
                else if (BulletPlayer("player1") <= 0)
                {
                    Console.WriteLine("You can't shoot ! Please reload !");
                    Thread.Sleep(3000);

                }
            }

            if (player == "player2")
            {

                string NewNameHero1 = NameHero("player1");
                string NewNameWeapon1 = NameWeapon("player1");
                double NewDamagePlayer1 = DamageWeaponPlayer("player1");
                int NewBullet1 = BulletPlayer("player1");
                string NewSkill = NameSkill("player1");

                string NewNameHero2 = NameHero("player2");
                double NewLife2 = LifePlayer("player2");
                string NewNameWeapon2 = NameWeapon("player2");
                double NewDamagePlayer2 = DamageWeaponPlayer("player2");
                string NewSkill2 = NameSkill("player2");

                if (LifePlayer("player1") > DamageWeaponPlayer("player2") && BulletPlayer("player2") > 0)
                {
                    double NewLife = LifePlayer("player1") - DamageWeaponPlayer("player2");
                    int NewBullet = BulletPlayer("player2") - 1;


                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine($"{NewNameHero1};{NewLife};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill}");
                        sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet};{NewSkill2}");
                    }
                }
                else if (LifePlayer("player1") <= DamageWeaponPlayer("player2") && BulletPlayer("player2") > 0)
                {
                    double NewLife = 0;
                    int NewBullet = BulletPlayer("player2") - 1;

                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine($"{NewNameHero1};{NewLife};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill}");
                        sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet};{NewSkill2}");
                    }

                    Console.WriteLine("Player 1 DEAD");
                }
                else if (BulletPlayer("player2") <= 0)
                {
                    Console.WriteLine("You can't shoot ! Please reload !");
                    Thread.Sleep(3000);
                }
            }

        }

        /// <summary>
        /// We come to look at the index of the player's balls and add a ball. However, there is a bullet limit depending on the weapon.
        /// </summary>
        /// <param name="player"></param>
        public void ReloadBullet(string player)
        {
            string path = ".\\Game.txt";

            string NewNameHero1 = NameHero("player1");
            double NewLife1 = LifePlayer("player1");
            string NewNameWeapon1 = NameWeapon("player1");
            double NewDamagePlayer1 = DamageWeaponPlayer("player1");

            string NewSkill = NameSkill("player1");

            string NewNameHero2 = NameHero("player2");
            double NewLife2 = LifePlayer("player2");
            string NewNameWeapon2 = NameWeapon("player2");
            double NewDamagePlayer2 = DamageWeaponPlayer("player2");

            string NewSkill2 = NameSkill("player2");

            if (player == "player1")
            {

                if (NameWeapon("player1") == "vandal")
                {
                    int NewBullet2 = BulletPlayer("player2");

                    if (BulletPlayer("player1") < 2)
                    {
                        int NewBullet1 = BulletPlayer("player1") + 1;

                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill}");
                            sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill2}");
                        }
                    }
                    else Console.WriteLine("You can't reload !"); Thread.Sleep(3000);
                }

                else if (NameWeapon("player1") == "phantom")
                {
                    int NewBullet2 = BulletPlayer("player2");
                    if (BulletPlayer("player1") < 5)
                    {
                        int NewBullet1 = BulletPlayer("player1") + 1;

                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill}");
                            sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill2}");
                        }
                    }
                    else Console.WriteLine("You can't reload !"); Thread.Sleep(3000);
                }

                else if (NameWeapon("player1") == "odin")
                {
                    int NewBullet2 = BulletPlayer("player2");
                    if (BulletPlayer("player1") < 12)
                    {
                        int NewBullet1 = BulletPlayer("player1") + 1;

                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill}");
                            sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill2}");
                        }
                    }
                    else Console.WriteLine("You can't reload !"); Thread.Sleep(3000);
                }
            }

            if (player == "player2")
            {
                if (NameWeapon("player2") == "vandal")
                {
                    int NewBullet1 = BulletPlayer("player1");

                    if (BulletPlayer("player2") < 2)
                    {
                        int NewBullet2 = BulletPlayer("player2") + 1;

                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill}");
                            sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill2}");
                        }
                    }
                    else Console.WriteLine("You can't reload !"); Thread.Sleep(3000);
                }

                else if (NameWeapon("player2") == "phantom")
                {
                    int NewBullet1 = BulletPlayer("player1");
                    if (BulletPlayer("player2") < 5)
                    {
                        int NewBullet2 = BulletPlayer("player2") + 1;

                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill}");
                            sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill2}");
                        }
                    }
                    else Console.WriteLine("You can't reload !"); Thread.Sleep(3000);
                }

                else if (NameWeapon("player2") == "odin")
                {
                    int NewBullet1 = BulletPlayer("player1");
                    if (BulletPlayer("player2") < 12)
                    {
                        int NewBullet2 = BulletPlayer("player2") + 1;

                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill}");
                            sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill2}");
                        }
                    }
                    else Console.WriteLine("You can't reload !"); Thread.Sleep(3000);
                }
            }
        }

        /// <summary>
        /// We come to look at the index of the skill of the player and depending on the skill comes to add life, give more bullets or multiply by 2 the damage of the weapon.
        /// </summary>
        /// <param name="player"></param>
        public void UseSkill(string player)
        {
            string path = ".\\Game.txt";

            string NewNameHero1 = NameHero("player1");
            double NewLife1 = LifePlayer("player1");
            string NewNameWeapon1 = NameWeapon("player1");
            double NewDamagePlayer1 = DamageWeaponPlayer("player1");
            int NewBullet1 = BulletPlayer("player1");
            string NewSkill1 = NameSkill("player1");

            string NewNameHero2 = NameHero("player2");
            double NewLife2 = LifePlayer("player2");
            string NewNameWeapon2 = NameWeapon("player2");
            double NewDamagePlayer2 = DamageWeaponPlayer("player2");
            int NewBullet2 = BulletPlayer("player2");
            string NewSkill2 = NameSkill("player2");

            if (player == "player1")
            {
                if (NameSkill("player1") == "healing")
                {
                    double NewLife = LifePlayer("player1") + 100;
                    string NewSkill = " ";
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine($"{NewNameHero1};{NewLife};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill}");
                        sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill2}");
                    }

                }

                else if (NameSkill("player1") == "reloading")
                {
                    double NewBullet = BulletPlayer("player1") + 5;
                    string NewSkill = " ";
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet};{NewSkill}");
                        sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill2}");
                    }

                }

                else if (NameSkill("player1") == "slaughter")
                {
                    double NewDamagePlayer = DamageWeaponPlayer("player1") + DamageWeaponPlayer("player1");
                    string NewSkill = " ";
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer};{NewBullet1};{NewSkill}");
                        sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill2}");
                    }

                }
                else if (NameSkill("player1") == " ") Console.WriteLine(" you don't have skill, maybe you already use your skill"); Thread.Sleep(3000);

            }

            if (player == "player2")
            {
                if (NameSkill("player2") == "healing")
                {
                    double NewLife = LifePlayer("player2") + 100;
                    string NewSkill = " ";
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill1}");
                        sw.WriteLine($"{NewNameHero2};{NewLife};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet2};{NewSkill}");
                    }

                }

                else if (NameSkill("player2") == "reloading")
                {
                    double NewBullet = BulletPlayer("player2") + 5;
                    string NewSkill = " ";
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill1}");
                        sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer2};{NewBullet};{NewSkill}");
                    }

                }

                else if (NameSkill("player2") == "slaughter")
                {
                    double NewDamagePlayer = DamageWeaponPlayer("player2") * 2;
                    string NewSkill = " ";
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine($"{NewNameHero1};{NewLife1};{NewNameWeapon1};{NewDamagePlayer1};{NewBullet1};{NewSkill1}");
                        sw.WriteLine($"{NewNameHero2};{NewLife2};{NewNameWeapon2};{NewDamagePlayer};{NewBullet2};{NewSkill}");
                    }

                }
                else if (NameSkill("player2") == " ") Console.WriteLine(" you don't have skill, maybe you already use your skill"); Thread.Sleep(3000);
            }
        }
        #endregion
    }
}
