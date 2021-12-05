using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projetValo
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            Console.SetWindowSize(240, 63); // Allows you to make the console big
            Start();
            Console.ReadKey();
        }
        #endregion

        /// <summary>
        /// We find in this region methods of organizing the game
        /// </summary>
        #region Game
        static void Start()
        {
            string prompt = @"
                                                     ██╗   ██╗ █████╗ ██╗      ██████╗ ██████╗  █████╗ ███╗   ██╗████████╗     ██████╗  █████╗ ███╗   ███╗███████╗
                                                     ██║   ██║██╔══██╗██║     ██╔═══██╗██╔══██╗██╔══██╗████╗  ██║╚══██╔══╝    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝
                                                     ██║   ██║███████║██║     ██║   ██║██████╔╝███████║██╔██╗ ██║   ██║       ██║  ███╗███████║██╔████╔██║█████╗   
                                                     ╚██╗ ██╔╝██╔══██║██║     ██║   ██║██╔══██╗██╔══██║██║╚██╗██║   ██║       ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  
                                                      ╚████╔╝ ██║  ██║███████╗╚██████╔╝██║  ██║██║  ██║██║ ╚████║   ██║       ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗
                                                       ╚═══╝  ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝        ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝  ";
            Console.WriteLine();
            Console.WriteLine();
            string[] options = { "Play", "Credit", "Exit" };
            Game valo = new Game(prompt, options);

            int Index = valo.Choice();  

            switch (Index)          
            {
                case 0:
                    Beginning();
                    break;
                case 1:
                    Credits();
                    break;
                case 2:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }
        public static void GamePlayer1()
        {
            Console.Clear();
            List yo = new List();
            yo.ShowGame();

            Console.Write("\n Press ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter ");
            Console.ResetColor();
            Console.Write("to Play \n");
            Console.WriteLine(" Warning after this you can't see the Table ");

            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Enter)
            {

                Player1 P1 = new Player1();
                Console.WriteLine(" Choose what do you wamt to do : ");
                string prompt = @"
                                                           ____  _                         _ 
                                                          |  _ \| | __ _ _   _  ___ _ __  / |
                                                          | |_) | |/ _` | | | |/ _ \ '__| | |
                                                          |  __/| | (_| | |_| |  __/ |    | |
                                                          |_|   |_|\__,_|\__, |\___|_|    |_|
                                                                         |___/               
";
                Console.WriteLine();
                Console.WriteLine();
                string[] options = { "Attack", "Reload", "Use skill", "Quit" };
                Game valo = new Game(prompt, options);

                int Index = valo.Choice();

                switch (Index)
                {
                    case 0:
                        P1.AttackPlayer("player1");
                        break;
                    case 1:
                        P1.ReloadBullet("player1");
                        break;
                    case 2:
                        P1.UseSkill("player1");
                        break;
                    case 3:
                        ExitGame();
                        break;
                    default:
                        break;
                }
            }


        }
        public static void GamePlayer2()
        {
            Console.Clear();
            List yo = new List();
            yo.ShowGame();

            Console.Write("\n Press ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter ");
            Console.ResetColor();
            Console.Write("to Play \n");
            Console.WriteLine(" Warning after this you can't see the Table ");
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Enter)
            {
                Player2 P2 = new Player2();

                Console.WriteLine(" Choose what do you wamt to do : ");
                string prompt = @" 
                                                           ____  _                         ____  
                                                          |  _ \| | __ _ _   _  ___ _ __  |___ \ 
                                                          | |_) | |/ _` | | | |/ _ \ '__|   __) |
                                                          |  __/| | (_| | |_| |  __/ |     / __/ 
                                                          |_|   |_|\__,_|\__, |\___|_|    |_____|
                                                                         |___/                   
";
                Console.WriteLine();
                Console.WriteLine();
                string[] options = { "Attack", "Reload", "Use skill", "Quit" };
                Game valo = new Game(prompt, options);
                yo.ShowGame();
                int Index = valo.Choice();

                switch (Index)
                {
                    case 0:
                        P2.AttackPlayer("player2");
                        break;
                    case 1:
                        P2.ReloadBullet("player2");
                        break;
                    case 2:
                        P2.UseSkill("player2");
                        break;
                    case 3:
                        ExitGame();
                        break;
                    default:
                        break;
                }
            }

        }
        static void EndGame()
        {
            Player1 P1 = new Player1();
            Player2 P2 = new Player2();

            if (P1.LifePlayer("player1") == 0)
            {
                string prompt = @"
                                                                     __      _____ _  _ _  _ ___ ___   ___ _                     ___ 
                                                                     \ \    / /_ _| \| | \| | __| _ \ | _ \ |__ _ _  _ ___ _ _  |_  )
                                                                      \ \/\/ / | || .` | .` | _||   / |  _/ / _` | || / -_) '_|  / / 
                                                                       \_/\_/ |___|_|\_|_|\_|___|_|_\ |_| |_\__,_|\_, \___|_|   /___|
                                                                                                                   |__/                                                                                                                                                                                               
                                                                                                                                                                                                         
                                                                      ,*//*/*//**///***/****************************///////////////.                                                                    
                                                                      ,**/**,,,,,,,,,****************************/***//////////////.                                                                    
                                                              .,,,,,,,***//*,,,,,,,,,*****************************/**//////////////*,,*,,,.                                                             
                                                        .**/////****//**///**,,,,,,,,,******************************///////////////*/***////***,.                                                       
                                                     .****/********//////****,,,,,,,,,*/****************************///////////////**///*****///*/*.                                                    
                                                   ,**//*****,,..    .,**//**,,,,,,,,,******************************//////////////*.     .,**********.                                                  
                                                 .********,            ******,,,,,,,,,******************************//////////////,           ,**////*,                                                 
                                                 *******,              ******,,,,,,,,,,*****************************/////////////*.             ,****/*,                                                
                                                ,**/***,               ,******,,,,,,,,,******************************////////////*               ,******.                                               
                                                *******.               .*******,,,,,,,,*****************************/////////////,               .*****/,                                               
                                                */**/**.                ,//**/*,,,,,,,,,**/*/***********************/////////////.               .*****/*                                               
                                                ,**/***.                .****/*,,,,,,,,,**/*****/*******************////////////*                .******,                                               
                                                .**//***                 ,**/***,,,,,,,,**/****//**************/****////////////                 **/****.                                               
                                                 ,*/*****                .***//*,,,,,,,,,************************/**///////////,               .**/****.                                                
                                                  ,**/*/**.               ,******,,,,,,,,***************************//////////*               .**/*//*.                                                 
                                                   ,*/*/**/*.              ,*/*/**,,,,,,,,**************************//////////.             .*///****.                                                  
                                                    .**/**/***,.           .**/*/**,,,,,,,******/******************//////////,           .,***/****,                                                    
                                                      .,****/*****.         .*//*/**,,,,,,**/***/******************/////////,         .****///***,                                                      
                                                         .************.      .*****/*,,,,,,********************/***////////,     .,****//******.                                                        
                                                            .,********//**,.  .**//***,,,,,***********************////////*  .,****/***/***,                                                            
                                                                .,***//**//************,,,,*/****/****************////////******///*****.                                                               
                                                                     ,***//***/******/***,,,*/*******************///////*******/***,.                                                                   
                                                                         .,****////***/*/*,,*//******************//////*******,.                                                                        
                                                                              .,*//**//***/*********************/////*****.                                                                             
                                                                                   .,**///****///***************////,.                                                                                  
                                                                                      .****//****///*******/****//*                                                                                     
                                                                                        ,**/*************/**/**/*.                                                                                      
                                                                                          .***/**//************                                                                                         
                                                                                            ,///*********////.                                                                                          
                                                                                            .*//////////////,                                                                                           
                                                                                             ,***/**//******                                                                                            
                                                                                             .******//*****,                                                                                            
                                                                                              *//**********.                                                                                            
                                                                                              *************.                                                                                            
                                                                                             .**//***///***,                                                                                            
                                                                                            ,***/****//******.                                                                                          
                                                                                          .******/******/*****,                                                                                         
                                                                              .....   ...,****/*******/**///***,............                                                                            
                                                                            .**//**,,,*************************/*/**////////*                                                                           
                                                                            ,*//***,,,*/************************///**///////*                                                                           
                                                                            ,*//***,,,*/**/**************************///////*                                                                           
                                                                            ,******,,,**************************///*////////*                                                                           
                                                                            ,***//*,,,****************************/**///////*                                                                           
                                                                            ,******,,,****/*************************////////*                                                                           
                                                                            ,******,,,*******************************///////*                                                                           
                                                                            ,*//***,,,*/**/********************//*/*/////////                                                                           
                                                                            .*///**,,,******************************///////*.                                                                           
                                                                                                                                                                                                       
  ";
                Console.WriteLine();
                Console.WriteLine();
                string[] options = { "Credit", "Exit" };
                Game valo = new Game(prompt, options);

                int Index = valo.Choice();

                switch (Index)
                {
                    case 0:
                        Credits();
                        break;
                    case 1:
                        ExitGame();
                        break;
                    default:
                        break;
                }
            }
            if (P2.LifePlayer("player2") == 0)
            {
                string prompt = @"

                                                                      __      _____ _  _ _  _ ___ ___   ___ _                     _ 
                                                                      \ \    / /_ _| \| | \| | __| _ \ | _ \ |__ _ _  _ ___ _ _  / |
                                                                       \ \/\/ / | || .` | .` | _||   / |  _/ / _` | || / -_) '_| | |
                                                                        \_/\_/ |___|_|\_|_|\_|___|_|_\ |_| |_\__,_|\_, \___|_|   |_|
                                                                                                                    |__/             
                                                                                 
                                                                      ,*//*/*//**///***/****************************///////////////.                                                                    
                                                                      ,**/**,,,,,,,,,****************************/***//////////////.                                                                    
                                                              .,,,,,,,***//*,,,,,,,,,*****************************/**//////////////*,,*,,,.                                                             
                                                        .**/////****//**///**,,,,,,,,,******************************///////////////*/***////***,.                                                       
                                                     .****/********//////****,,,,,,,,,*/****************************///////////////**///*****///*/*.                                                    
                                                   ,**//*****,,..    .,**//**,,,,,,,,,******************************//////////////*.     .,**********.                                                  
                                                 .********,            ******,,,,,,,,,******************************//////////////,           ,**////*,                                                 
                                                 *******,              ******,,,,,,,,,,*****************************/////////////*.             ,****/*,                                                
                                                ,**/***,               ,******,,,,,,,,,******************************////////////*               ,******.                                               
                                                *******.               .*******,,,,,,,,*****************************/////////////,               .*****/,                                               
                                                */**/**.                ,//**/*,,,,,,,,,**/*/***********************/////////////.               .*****/*                                               
                                                ,**/***.                .****/*,,,,,,,,,**/*****/*******************////////////*                .******,                                               
                                                .**//***                 ,**/***,,,,,,,,**/****//**************/****////////////                 **/****.                                               
                                                 ,*/*****                .***//*,,,,,,,,,************************/**///////////,               .**/****.                                                
                                                  ,**/*/**.               ,******,,,,,,,,***************************//////////*               .**/*//*.                                                 
                                                   ,*/*/**/*.              ,*/*/**,,,,,,,,**************************//////////.             .*///****.                                                  
                                                    .**/**/***,.           .**/*/**,,,,,,,******/******************//////////,           .,***/****,                                                    
                                                      .,****/*****.         .*//*/**,,,,,,**/***/******************/////////,         .****///***,                                                      
                                                         .************.      .*****/*,,,,,,********************/***////////,     .,****//******.                                                        
                                                            .,********//**,.  .**//***,,,,,***********************////////*  .,****/***/***,                                                            
                                                                .,***//**//************,,,,*/****/****************////////******///*****.                                                               
                                                                     ,***//***/******/***,,,*/*******************///////*******/***,.                                                                   
                                                                         .,****////***/*/*,,*//******************//////*******,.                                                                        
                                                                              .,*//**//***/*********************/////*****.                                                                             
                                                                                   .,**///****///***************////,.                                                                                  
                                                                                      .****//****///*******/****//*                                                                                     
                                                                                        ,**/*************/**/**/*.                                                                                      
                                                                                          .***/**//************                                                                                         
                                                                                            ,///*********////.                                                                                          
                                                                                            .*//////////////,                                                                                           
                                                                                             ,***/**//******                                                                                            
                                                                                             .******//*****,                                                                                            
                                                                                              *//**********.                                                                                            
                                                                                              *************.                                                                                            
                                                                                             .**//***///***,                                                                                            
                                                                                            ,***/****//******.                                                                                          
                                                                                          .******/******/*****,                                                                                         
                                                                              .....   ...,****/*******/**///***,............                                                                            
                                                                            .**//**,,,*************************/*/**////////*                                                                           
                                                                            ,*//***,,,*/************************///**///////*                                                                           
                                                                            ,*//***,,,*/**/**************************///////*                                                                           
                                                                            ,******,,,**************************///*////////*                                                                           
                                                                            ,***//*,,,****************************/**///////*                                                                           
                                                                            ,******,,,****/*************************////////*                                                                           
                                                                            ,******,,,*******************************///////*                                                                           
                                                                            ,*//***,,,*/**/********************//*/*/////////                                                                           
                                                                            .*///**,,,******************************///////*.                                                                           
                                                                                                                                                                                                       
  ";
                Console.WriteLine();
                Console.WriteLine();
                string[] options = { "Credit", "Exit" };
                Game valo = new Game(prompt, options);

                int Index = valo.Choice();

                switch (Index)
                {
                    case 0:
                        Credits();
                        break;
                    case 1:
                        ExitGame();
                        break;
                    default:
                        break;
                }
            }

        }
        #endregion

        /// <summary>
        /// In this region the methods are the stone leaf chisel method as well as the start of play method.
        /// </summary>
        #region RPS
        static void Beginning()
        {
            List yo = new List();

            if (RockPaperScissors() == true)
            {
                Console.Clear();

                Console.Write("\n\nThe 1st player ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("won ");
                Console.ResetColor();
                Console.Write("against the computer !\n");

                Console.Write("\nSo the 1st player ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("begin ");
                Console.ResetColor();
                Console.Write("the game !\n");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n                                   Game Creation :\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nPlayer 1 ");
                Console.ResetColor();
                Console.Write("choose your Agent Weapon and Skill and after it s ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Player 2 ");
                Console.ResetColor();
                Console.Write("turn!\n");

                //Thread.Sleep(5000);
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();

                Console.Clear();

                Game Valo = new Game();
                Valo.GameValo();
                bool Player1 = true;

                Console.WriteLine(" Press any key to start the GAME :");
                ConsoleKeyInfo cki;
                cki = Console.ReadKey();
                while (cki.Key != ConsoleKey.Escape)
                {
                    if (Player1)
                    {
                        GamePlayer1();
                    }
                    else
                    {
                        GamePlayer2();
                    }
                    EndGame();
                    Player1 = !Player1;
                }

            }
            else
            {
                Console.Clear();

                Console.Write("\nThe 1st player ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("lost ");
                Console.ResetColor();
                Console.Write("against the computer !\n");


                Console.Write("\nSo the 2nd player ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("begin ");
                Console.ResetColor();
                Console.Write("the game !\n");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n                                   Game Creation :\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nPlayer 1 ");
                Console.ResetColor();
                Console.Write("choose your Agent Weapon and Skill and after it s ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Player 2 ");
                Console.ResetColor();
                Console.Write("turn!\n");
                // Thread.Sleep(5000);

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();

                Console.Clear();

                Game Valo = new Game();
                Valo.GameValo();
                bool Player2 = true;

                Console.WriteLine(" Press any key to start the GAME :");
                ConsoleKeyInfo cki;
                cki = Console.ReadKey();
                while (cki.Key != ConsoleKey.Escape)
                {
                    if (Player2)
                    {
                        GamePlayer2();
                    }
                    else
                    {
                        GamePlayer1();
                    }
                    EndGame();
                    Player2 = !Player2;
                }

            }
        }
        static bool RockPaperScissors()
        {
            bool result = false;
            int Index = 4;
            int computer = 1;

            while (Index >= 3 || Index <= -1)
            {
            telep:;

                Console.WriteLine();

                Console.Write("\nThe game is a Rock - Paper - Scissors ! In order to know who will ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("start ");
                Console.ResetColor();
                Console.Write("the game !\n");

                string Rules = @"                                

                                                                              Rules :

                                                                            - Player 1 plays Rock Paper Scissor against a computer. 
                                                                            - If he wins => he starts the game
                                                                            - If he lose => Player 2 starts the game ";

                Console.WriteLine(Rules);
                Console.ResetColor();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                //Thread.Sleep(5000);

                Console.Clear();

                ////  string prompt = @"
                //                                         ____             __      ____                           _____      _                     
                //                                        / __ \____  _____/ /__   / __ \____ _____  ___  _____   / ___/_____(_)_____________  _____
                //                                       / /_/ / __ \/ ___/ //_/  / /_/ / __ `/ __ \/ _ \/ ___/   \__ \/ ___/ / ___/ ___/ __ \/ ___/
                //                                      / _, _/ /_/ / /__/ ,<    / ____/ /_/ / /_/ /  __/ /      ___/ / /__/ (__  |__  ) /_/ / /    
                //                                     /_/ |_|\____/\___/_/|_|  /_/    \__,_/ .___/\___/_/      /____/\___/_/____/____/\____/_/     
                //                                                                         /_/                                                      ";

                string image = @"                                                                                                                                                                                     
                                            ,@@.                                                                                                                    @@,                                        
                             &@@@/        @@@@@@@&                                                                                                         &@#   @@@@@@@@   /@@                                
                            @@@@@@@       @@@@@@@@                                                                                                      .@@@@@@@ @@@@@@@% @@@@@@@(   %@&                       
                            @@@@@@@@      @@&@@@@@                                                                                                      #@@@@@@@ @@@@@@@@ @@@@@@@@ @@@@@@@                     
                            /@@@@@@@#     @@@@@@@@                                                                                                      #@@@@@@@ @@@@@@@@ @@@&@@@@ @@@@@@@*                    
                             @@@@@@@@     @@@@@@@@                                                                                                      #@@@@@@@ @@@@@@@@ @@@@@@@@ @@@@@@@*                    
                              @@@@@@@@    @@@@@@@@                                                                                                      #@@@@@@@ @@@@@@@@ @@@@@@@@ @@@@@@@*                    
                              /@@@&@@@#   @@@@@@@@                                                      @@.                                             #@@@@@@@ @@@@@@@@ @@@@@@@@ @@@@@@@*                    
                               @@@@@@@@   @@@@@@@@   (@@                                     @@@@@@  @@@@@@@@   *@@                                     #@@@@@@@ @@@@@@@@ @@@@@@@@ @@@@@@@*                    
                                @@@@@@@@  @@@@@@@@ @@@@@@@, %@@@@@/                         %@@@@@@@ @@@@@@@@ @@@@@@@# *@@@@@&                          #@@@@@@@ @@@@@@@@ @@@@@@@@ @@@@@@@*                    
                                /@@@@@@#      &@@@ @@@@@@@%.@@@@@@@                         #@@@@@%      #@@@ @@@@@@@@ @@@@@@@*                         #@@@@@%      #@@@ @@@@@@@@ @@@@@@@*                    
                                  @@@@@@@@@@@@@ (@ @@@@@@@% @@@@@@@                          &@@@@@@@@@@@@/ @ @@@@@@@@ @@@@@@@*                          &@@@@@@@@@@@&( @ @@@@@@@@ @@@@@@@*                    
                              %@@@@@@@@@@@@@@@@@ @ @@@@@@@% @@@@@@@                      @@@@@@@@@@@@@@@@@@ @ @@@@@@@@ @@@@@@@*                      @@@@@@@@@@@@@@@@@@ @@@@@@@@@@@@@@@@@@*                    
                             @@@@@@@@@@@@@@@@@@ @@ @@@@@@@% @@@@@@@                     &@@@@@@@@@@@@@@@@@ @@ @@@@@@@@ @@@@@@@*                     &@@@@@@@@@@@@@@@@@ @@@@@@@@@@@@@@@@@@@*                    
                              @@@@@@@@@@@   ,@@@@@ @@@@@@@% @@@@@@@                      @@@@@@@@@@@.   @@@@  @@@@@@@@ @@@@@@@*                      @@@@@@@@@@@.  .@@@@@@@@@@@@@@@@@@@@&@*                    
                              /@@@@@@@@@@@@* #@@@@% @@@@@&  @@@@@@@                       @@@@@@@@@@@@# *@@@@@ @@@@@@  @@@@@@@                        @@@@@@@@@@@@# *@@@@@@@@@@@@@@@@@@&@%,                    
                               @@@@@@@@@@@@@@@@ %@@@@@@@@@@@* ,%. #                       @@@@@@@@@@@@@@@@ *@@@@@@@@@@@% .%* ,*                       @@@@@@@@@@@@@@@@ *@@@@@@@@@@@@@@@@@&*                    
                                @@@@@@@@@@@@@@@@@ @@@@@@@@@@@@@@@@@                        @@@@@@@@@@@@@@@@@ #@@@@@@@@@@@@%@@@*                        @@@@@@@@@@@@@@@@@ %@@@@@@@@@@@@@@@@*                    
                                /@@@@@@@@@@@@@@@@@(.@@@@@@@@@@@@@@@                         @@@@@@@@@@@@@@@@@@ @@@@@@@@@@@@@@@*                         @@@@@@@@@@@@@@@@@@ @@@@@@@@@@@@@@@*                    
                                 @@@@@@@@@@@@@@@@@@ @@@@@@@@@@%@@@@                         @@@@@@@@@@@@@@@@@@,&@@@@@/@@@@@@@@*                         @@@@@@@@@@@@@@@@@@,&@@@@@@@@@@@@@@*                    
                                  @@@@@@@@@@@@@@@@@@.@@@@@@@@@@@@@@                          @@@@@@@@@@@@@@@@@@ @@@@@@@@@@@@@@                           @@#@@@@@@@@@@@@@@@ @@@@@@@@@@@@@@                     
                                    ##@@@@@@@@@@@@@@@@@@@%@@@@#(                               (#@@@@@@@@@@@@@@@%@@@@@@@@%(                                (#@@@@@@@@@@@@@@@@@@@@@@@@%(                        
                                      @@@@@@@@@@@@@@@@@@@@@@@@                                   &@@@@@@@@@@@@@@@@@@@@@@@.                                   &@@%@@@@@@@@@@@@@@@@@@@@.                         
                                      @@@@@@@@@@@@@@%@@@@@@@@@                                   &@@@@@@@@@/@@@@@@@@@@@@@.                                   &@@@@@&@@@@@@@@@@@@@@@@@.                         
                                      @@@@@@@@@@@@@@@@@@@@@@@@                                   &@@@@@@@@@@@@@@@@@@@@@@@.                                   &@@@@@@@#@@@@@@@@@@@@@@@.                         
                                      @@@@@@@@@%@@@@@@@@@@@@@@                                   &@@@@%@@@@@@@@@@@@@@@@@@.                                   &@@@@@@@@@@@@@@@@@@@@@@@.                         
                                      ########################                                   (#######################.                                   (############(##########.                         
                                                                                                                                                                                                                                                                                                                                                                                                             
";
                Console.WriteLine();

                Console.WriteLine();
                string[] options = { "Rock", "Paper", "Scissor" };
                //Game RPS = new Game(prompt, options);
                Game RPS = new Game(image, options);
                Index = RPS.Choice();

                Random rnd = new Random();
                computer = rnd.Next(3);
                if ((Index == 0 && computer == 0) || (Index == 1 && computer == 1) || (Index == 2 && computer == 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEgality !");
                    Console.ResetColor();
                    Console.WriteLine("\nThe computer had made " + choice(computer));
                    Console.WriteLine("\n\nPlease wait 3 seconds to repeat the battle !");
                    Thread.Sleep(3000);
                    goto telep;
                }
                if ((Index == 0 && computer == 1) || (Index == 1 && computer == 2) || (Index == 2 && computer == 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe computer won !");
                    Console.ResetColor();
                    Console.WriteLine("\nThe computer had made " + choice(computer));
                    Thread.Sleep(3000);
                    return result = false;
                }
                if ((Index == 1 && computer == 0) || (Index == 2 && computer == 1) || (Index == 0 && computer == 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou have won !");
                    Console.ResetColor();
                    Console.WriteLine("\nThe computer had made" + choice(computer));
                    Thread.Sleep(3000);
                    return result = true;
                }

            }
            return result;
        }
        static string choice(int choixcomputer)
        {
            string contenance = "";
            if (choixcomputer == 0)
            {
                contenance = "Rock";
            }
            if (choixcomputer == 1)
            {
                contenance = "Paper";
            }
            if (choixcomputer == 2)
            {
                contenance = "Scissors";
            }
            return contenance;
        }
        #endregion

        /// <summary>
        /// Method for credit and close the console.
        /// </summary>
        #region Other

        static void ExitGame()
        {
            Console.WriteLine("\nPress any key to leave the Game ! ");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        static void Credits()
        {
            Console.Clear();
            Console.WriteLine("                  The game was coded by");
            string Name = @"

                                                    /$$                 /$$                                 /$$$$$$$$ /$$$$$$  /$$   /$$  /$$$$$$  /$$   /$$      
                                                   | $$                | $$                                |__  $$__//$$__  $$| $$  | $$ /$$__  $$| $$  | $$      
                                                   | $$       /$$   /$$| $$   /$$  /$$$$$$   /$$$$$$$         | $$  | $$  \ $$| $$  | $$| $$  \__/| $$  | $$      
                                                   | $$      | $$  | $$| $$  /$$/ |____  $$ /$$_____/         | $$  | $$$$$$$$| $$  | $$| $$      | $$$$$$$$      
                                                   | $$      | $$  | $$| $$$$$$/   /$$$$$$$|  $$$$$$          | $$  | $$__  $$| $$  | $$| $$      | $$__  $$      
                                                   | $$      | $$  | $$| $$_  $$  /$$__  $$ \____  $$         | $$  | $$  | $$| $$  | $$| $$    $$| $$  | $$      
                                                   | $$$$$$$$|  $$$$$$/| $$ \  $$|  $$$$$$$ /$$$$$$$/         | $$  | $$  | $$|  $$$$$$/|  $$$$$$/| $$  | $$      
                                                   |________/ \______/ |__/  \__/ \_______/|_______/          |__/  |__/  |__/ \______/  \______/ |__/  |__/ .";
            Console.WriteLine(Name);
            Console.WriteLine("");
            Console.WriteLine("The game is entirely a creation of me.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("I used a tutorial from this site to help me with the graphics for reading files :  \n\n https://stackoverflow.com/questions/856845/how-to-best-way-to-draw-table-in-console-app-c ");
            Console.WriteLine("");
            Console.WriteLine("And I used this tutorial to help me design the console and the title : \n\n https://youtu.be/qAWhGEPMlS8 and \n https://patorjk.com/software/taag/#p=testall&f=Graffiti&t=Valorant%20Game");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey(true);
            Start();
        }
        #endregion
    }
}