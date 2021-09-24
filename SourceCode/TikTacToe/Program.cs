using System;
using System.Text.RegularExpressions;

namespace TikTacToe
{
    class Program
    {
        private const string X = "X";
        private const string O = "O";

        public string[] Line0 = new string[3] { "-", "-", "-" };
        public string[] Line1 = new string[3] { "-", "-", "-" };
        public string[] Line2 = new string[3] { "-", "-", "-" };

        private string PlayerSymbole = string.Empty;
        private string ConsoleString = string.Empty;

        private bool CurrentPlayerX = true;
        private bool CurrentPlayerO = false;

        private int ScoreX = 0;
        private int ScoreO = 0;

        static void Main()
        {
            //Main Menu
            Program p = new();

            Console.Write(@"







                     ██╗░░██╗░█████╗░
                     ╚██╗██╔╝██╔══██╗
                     ░╚███╔╝░██║░░██║(But you can call it TikTacToe)
                     ░██╔██╗░██║░░██║
                     ██╔╝╚██╗╚█████╔╝
                     ╚═╝░░╚═╝░╚════╝░

                     [1]Start new Game
                     [2]Load Game
");
            p.ConsoleString = Console.ReadLine();

            if(p.ConsoleString == "1")
            {
                Console.Clear();
                p.Game();
            }else if(p.ConsoleString == "2")
            {

            }
            p.ConsoleString = string.Empty;
          //  p.Game();
        }
        private void Reset()
        {
            Line0[0] = "-";
            Line0[1] = "-";
            Line0[2] = "-";

            Line1[0] = "-";
            Line1[1] = "-";
            Line1[2] = "-";

            Line2[0] = "-";
            Line2[1] = "-";
            Line2[2] = "-";

            CurrentPlayerX = true;
            CurrentPlayerO = false;
            PlayerSymbole = X;
        }
        private void HandleRound(int Value, bool StartWithX)
        {
            if (StartWithX == true)
            {
                PlayerSymbole = X;
            }

            if (StartWithX == false)
            {
                PlayerSymbole = O;
            }
            //Check for a valid number
            if (Value <= 9)
            {
                //Set the Symbole on the right position
                if (Value == 1 && Line0[0] == "-")
                {
                    Line0[0] = PlayerSymbole;
                }
                else if (Value == 2 && Line0[1] == "-")
                {
                    Line0[1] = PlayerSymbole;
                }
                else if (Value == 3 && Line0[2] == "-")
                {
                    Line0[2] = PlayerSymbole;
                }
                else if (Value == 4 && Line1[0] == "-")
                {
                    Line1[0] = PlayerSymbole;
                }
                else if (Value == 5 && Line1[1] == "-")
                {
                    Line1[1] = PlayerSymbole;
                }
                else if (Value == 6 && Line1[2] == "-")
                {
                    Line1[2] = PlayerSymbole;
                }
                else if (Value == 7 && Line2[0] == "-")
                {
                    Line2[0] = PlayerSymbole;
                }
                else if (Value == 8 && Line2[1] == "-")
                {
                    Line2[1] = PlayerSymbole;
                }
                else if (Value == 9 && Line2[2] == "-")
                {
                    Line2[2] = PlayerSymbole;
                }
                else
                {
                    //Log
                    Console.WriteLine("Please enter a number of a field that is empty!");
                    if(CurrentPlayerO == true)
                    {
                        CurrentPlayerX = false;
                        CurrentPlayerO = true;
                    }
                    else
                    {
                        CurrentPlayerX = true;
                        CurrentPlayerO = false;
                    }

                    HandleRound(int.Parse(Console.ReadLine()), CurrentPlayerX);
                }
            }
            else
            {
                //Log
                Console.WriteLine("Please enter a number between 1-9!");
            }

            if (CurrentPlayerO == true)
            {
                CurrentPlayerO = false;
                CurrentPlayerX = true;
            }
            else
            {
                CurrentPlayerO = true;
                CurrentPlayerX = false;
            }
            Console.Clear();
            //Log
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("   -------------");
            Console.WriteLine("   | " + Line0[0] + " | " + Line0[1] + " | " + Line0[2] + " | ");
            Console.WriteLine("   -------------");
            Console.WriteLine("   | " + Line1[0] + " | " + Line1[1] + " | " + Line1[2] + " | ");
            Console.WriteLine("   -------------");
            Console.WriteLine("   | " + Line2[0] + " | " + Line2[1] + " | " + Line2[2] + " | ");
            Console.WriteLine("   -------------");
            if (CurrentPlayerO)
            {
                Console.WriteLine("Player O's turn.");
            }
            else
            {
                Console.WriteLine("Player X's turn.");
            }
        }

        private void Game()
        {
            var p = this;

        MainGOTO:
            Console.WriteLine("Please enter a number between 1 and 9.");
            ConsoleString = Console.ReadLine();

            p.HandleRound(int.Parse(Regex.Replace(ConsoleString, @"[^\d]+", "").Trim()), p.CurrentPlayerX);
            ConsoleString = string.Empty;
            //Down
            if (p.Line0[0] == p.Line0[1] && p.Line0[1] == p.Line0[2] && p.Line0[2] == p.Line0[1] && p.Line0[0] != "-") { Win(p.Line0[0]); }
            else if (p.Line1[0] == p.Line1[1] && p.Line1[1] == p.Line1[2] && p.Line1[2] == p.Line1[1] && p.Line1[0] != "-") { Win(p.Line1[0]); }
            else if (p.Line2[0] == p.Line2[1] && p.Line2[1] == p.Line2[2] && p.Line2[2] == p.Line2[1] && p.Line2[0] != "-") { Win(p.Line1[0]); }
            //Up
            else if (p.Line0[0] == p.Line1[0] && p.Line1[0] == p.Line2[0] && p.Line2[0] == p.Line1[0] && p.Line0[0] != "-") { Win(p.Line0[0]); }
            else if (p.Line0[1] == p.Line1[1] && p.Line1[1] == p.Line2[1] && p.Line2[1] == p.Line1[1] && p.Line0[1] != "-") { Win(p.Line1[1]); }
            else if (p.Line0[2] == p.Line1[2] && p.Line1[2] == p.Line2[2] && p.Line2[2] == p.Line1[2] && p.Line0[2] != "-") { Win(p.Line1[2]); }
            //Diagonal
            else if (p.Line0[0] == p.Line1[1] && p.Line1[1] == p.Line2[2] && p.Line2[2] == p.Line1[0] && p.Line0[0] != "-") { Win(p.Line0[0]); }
            else if (p.Line0[2] == p.Line1[1] && p.Line1[1] == p.Line2[0] && p.Line2[0] == p.Line1[1] && p.Line0[2] != "-") { Win(p.Line1[1]); }
            else
                goto MainGOTO;
            Console.Read();
        }

        private void Win(string Winner)
        {
            if(Winner == "X")
            {
                ScoreX++;
            }else if(Winner == "O")
            {
                ScoreO++;
            }else { }
            Console.Clear();
            Console.WriteLine(@"
                        X: {0}  C: {1}

            Player {2} Won!

            Enter any key to start a new game", ScoreX, ScoreO, Winner);
            ConsoleString = Console.ReadLine();
            if (ConsoleString != string.Empty && ConsoleString != "T" && ConsoleString != "t")
            {
                Reset();
                Console.Clear();
                Game();
            }else
            {
                Console.WriteLine("   -------------");
                Console.WriteLine("   | " + Line0[0] + " | " + Line0[1] + " | " + Line0[2] + " | ");
                Console.WriteLine("   -------------");
                Console.WriteLine("   | " + Line1[0] + " | " + Line1[1] + " | " + Line1[2] + " | ");
                Console.WriteLine("   -------------");
                Console.WriteLine("   | " + Line2[0] + " | " + Line2[1] + " | " + Line2[2] + " | ");
                Console.WriteLine("   -------------");
            }
            ConsoleString = string.Empty;
            
        }
    }
}
