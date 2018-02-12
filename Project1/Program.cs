using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static Player[] aPlayer = new Player[40];
        static List<Player> playerChoice = new List<Player>();
        static int BUDGET = 95000000;
        static int COST_EFFECTIVE = 65000000;
        static void Main(string[] args)
        {
            int x = 0;
            int y = 1;
            int z = 0;
            int i = 0;
            int playerDraftNum = 0;
            int playerCost = 0;

            playerCreator(x, y, z);

            housekeeping();

            tableRender();

            while (playerDraftNum < 5)
            {
                playerPicker();
                playerCost = playerCost + playerChoice[playerDraftNum].salery;
                playerDraftNum = nextPlayer(playerDraftNum);
                i++;
            }
            Console.WriteLine("");

            display(playerCost);
            restart();
        }
        public static void playerCreator(int x, int y, int z)
        {
            while (x < aPlayer.Length)
            {
                if (y < 6)
                {
                    if (z % 4 != 0)
                    {
                        aPlayer[x] = new Player(x, y, z);
                        x++;
                        y++;
                        z++;
                    }
                    else
                    {
                        z = 0;
                        aPlayer[x] = new Player(x, y, z);
                        x++;
                        y++;
                    }
                }
                else
                {
                    if (z % 4 != 0)
                    {
                        y = 1;
                        aPlayer[x] = new Player(x, y, z);
                        x++;
                        z++;
                    }
                    else
                    {
                        y = 1;
                        z = 0;
                        aPlayer[x] = new Player(x, y, z);
                        x++;
                    }
                }
            }
        }
        public static void housekeeping()
        {
            Console.WriteLine("Welcome, this program will help you pick and determine your draft picks this year");
            Console.WriteLine("Now we will display a table view of all your options");
        }
        public static void tableRender()
        {
            int tableWidth = 132;
            string[] playerPositions = { "Quarterback", "Running Back", "Wide-Reciever", "Defensive Lineman", "Defensive-Back", "Tight Ends", "Line-Backer's", "Offensive Tackles" };
            int rowCount = 0;
            int ROWS = 8;

            Console.WriteLine(new string('_', tableWidth));
            Console.WriteLine("|{0,21}|{1,21}|{2,21}|{3,21}|{4,21}|{5,21}", "Position", "The Best", "2nd Best", "3rd Best", "4th Best", "5th Best");
            Console.WriteLine(new string('-', tableWidth));

            int x = rowCount;
            while (rowCount < ROWS)
            {
                x = rowCount;
                Console.Write("|{0,21}", playerPositions[rowCount]);

                while (x < (rowCount + 5))
                {
                    if (aPlayer[x].isDrafted == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.Write("{0,21}|", aPlayer[x].name);
                    x++;
                }
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("|{0,21}", "");
                x = rowCount;
                while (x < (rowCount + 5))
                {
                    if (aPlayer[x].isDrafted == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.Write("{0,21}|", "(" + aPlayer[x].school + ")");
                    x++;
                }
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("|{0,21}", "");
                x = rowCount;
                while (x < (rowCount + 5))
                {
                    if (aPlayer[x].isDrafted == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.Write("{0,21}|", aPlayer[x].salery.ToString("C"));
                    x++;
                }
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("|{0,21}", "");
                Console.WriteLine(new string('_', tableWidth));
                rowCount++;
            }
        }
        public static void playerPicker()
        {
            string name;
            int x = 0;
            Console.WriteLine("Please enter the name of the player you would like to draft.");
            name = Console.ReadLine();
            while (x < 40)
            {
                if (name == aPlayer[x].name)
                {
                    aPlayer[x].isDrafted = true;
                    playerChoice.Add(aPlayer[x]);
                    x = 40;
                }
                else
                {
                    x++;
                }
            }
        }
        public static int nextPlayer(int playerDraftNum)
        {
            string choice;
            Console.WriteLine("Would you like to pick another player? (Y/N)");
            choice = Console.ReadLine();
            if (choice == "Y")
            {
                tableRender();
                Console.WriteLine();
                return playerDraftNum + 1;
            }
            else
            {
                return 5;
            }
        }
        public static void display(int playerCost)
        {
            int i = 0;
            Console.WriteLine("Here is the names of the players you've drafted");
            while (i < playerChoice.Count)
            {
                Console.WriteLine(playerChoice[i].name);
                i++;
            }
            Console.WriteLine("Your total cost is: {0}", playerCost.ToString("C"));
        }
        public static void restart()
        {
            string choice;
            Console.WriteLine("If you would like to restart, hit enter, otherwise hit any key to exit the program");
            choice = Console.ReadLine();
            if (choice != "")
            {
                Main(null);
            }
            else
            {
                exit();
            }
        }
        public static void exit()
        {
            Console.WriteLine("Thank you for using our program. We hope to see you soon!");
            Console.ReadLine();
        }
    }
    class Player
    {
        public string[] playerNames = { "Mason Rudolph", "Lamar Jackson", "Josh Rosen", "Sam Darnold", "Baker Mayfield",
                                        "Saquon Barkley", "Derrius Guice", "Bryce Love", "Ronald Jones II", "Damien Harris",
                                        "Courtland Sutton", "James Washington", "Marcell Ateman", "Anthony Miller", "Calvin Ridley",
                                        "Maurice Hurst", "Vita Vea", "Taven Bryan", "Da'Ron Payne", "Harrison Phillips",
                                        "Joshua Jackson", "Derwin James", "Denzel Ward", "Minkah Fitzpatrick", "Isaiah Oliver",
                                        "Mark Andrews", "Dallas Goedert", "Jaylen Samuels", "Mike Gesicki", "Troy Fumagalli",
                                        "Roquan Smith", "Tremaine Edmunds", "Kendall Joseph", "Dorian O'Daniel", "Malik Jefferson",
                                        "Orlando Brown", "Kolton Miller", "Chukwuma Okarafor", "Connor Williams", "Mike McGlinchey"};
        public string[] playerSchoolNames = { "Oklahoma State", "Louisville", "UCLA", "Southern California", "Oklahoma",
                                        "Penn State", "LSU", "Sanford", "Southern California", "Alabama",
                                        "Southern Methodist", "Oklahoma State", "Oklahoma State", "Memphis", "Alabama",
                                        "Michigan", "Washington", "Florida", "Alabama", "Stanford",
                                        "Iowa", "Florida State", "Ohio State", "Alabama", "Colorado",
                                        "Oklahoma", "So. Dakota State", "NC State", "Penn State", "Wisconsin",
                                        "Georgia", "Virginia Tech", "Clemson", "Clemson", "Texas",
                                        "Oklahoma", "UCLA", "Western Michigan", "Texas", "Notre Dame"};
        public int[] playerSalaries = { 26400100, 20300100, 17420300, 13100145, 10300000,
                                        24500100, 19890200, 18700800, 15000000, 11600400,
                                        23400000, 21900300, 19300230, 13400230, 10000000,
                                        26200300, 22000000, 16000000, 18000000, 13000000,
                                        24000000, 22500249, 20000100, 16000200, 11899999,
                                        27800900, 21000800, 17499233, 27900200, 14900333,
                                        22900300, 19000590, 18000222, 12999999, 10000100,
                                        23000000, 20000000, 19400000, 16200700, 15900000};
        string[] playerPositions = { "Quarterback", "Running Back", "Wide-Reciever", "Defensive Lineman", "Defensive-Back", "Tight Ends", "Line-Backer's", "Offensive Tackles" };
        public string name { get; set; }
        public string school{ get; set;}
        public int salery { get; set; }
        public int rating { get; set; }
        public string position { get; set; }
        public bool isDrafted { get; set; }

        public Player()
        {

        }
        public Player(int x, int y, int z)
        {
            name = playerNames[x];
            school = playerSchoolNames[x];
            salery = playerSalaries[x];
            rating = y;
            position = playerPositions[z];
            isDrafted = false;
        }
    }
}
