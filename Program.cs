using System;
using System.Linq;

namespace visualnovel
{
    class Program
    {
        public static void printTextLine(in string textLine, in string plName, out ConsoleKeyInfo playerChoice)
        {
            string advice = "Press 'p' to pause.";
            string divider = "-------------------";
            Console.Write($"{advice}\n{divider}\n\n-> ");
            foreach (var letter in textLine)
            {
                Console.Write(letter);
                // Thread.Sleep(50);
            }
            Console.Write($" <-\n\n{divider}");
            playerChoice = Console.ReadKey(intercept: true);
            Console.Clear();
        }

        public static int basicActionSelection(in ConsoleKeyInfo playerChoice, in int countLine)
        {
            switch (playerChoice.Key)
            {
                case ConsoleKey.P:
                    enterPauseChoice(out var key);
                    switch (key.Key)
                    {
                        case ConsoleKey.R:
                            return -1;
                        case ConsoleKey.L:
                            if (loadNumberedSave(out int cCountLine))
                            {
                                return cCountLine;
                            }
                            else
                            {
                                return -1;
                            }
                        case ConsoleKey.S:
                            saveExistingGame(in countLine);
                            return -1;
                        default:
                            return -1;
                    }
                default:
                    return -2;
            }
        }

        public static void enterPauseChoice(out ConsoleKeyInfo pausePlayerChoice)
        {
            Console.WriteLine($"The game is currently paused.\nPress 'r' to resume\n'l' to load game\n's' to save existing game.\n\nt.me/ntfs808/");
            pausePlayerChoice = Console.ReadKey(intercept: true);
            Console.Clear();
        }

        public static bool loadNumberedSave(out int countLine)
        {
            Console.WriteLine("To load an existing game, enter the number of the string the game gave you last time you saved.");
            string sCountLine = Console.ReadLine();
            if (int.TryParse(sCountLine, out countLine) == false)
            {
                Console.WriteLine("You've entered incorrect save number");
                Console.ReadKey(intercept: true);
                return false;
            }
            countLine--;
            Console.Clear();
            return true;
        }

        public static void saveExistingGame(in int countLine)
        {
            Console.WriteLine($"Your save number is {countLine}.\nTo use it, press 'l' in the menu to load the game and enter it.");
            Console.ReadKey(intercept: true);
            Console.Clear();
        }

        public static void switchLines(in string textLine, in string plName, in int countLine, out int nCountLine)
        {
            nCountLine = countLine;
            printTextLine(in textLine, in plName, out ConsoleKeyInfo playerChoice);
            int whateverPlayerChose = basicActionSelection(in playerChoice, in countLine);
            switch (whateverPlayerChose)
            {
                case -1:
                    nCountLine--;
                    break;
                case -2:
                    break;
                default:
                    nCountLine = whateverPlayerChose;
                    break;
            }
            return;
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WriteLine($"Enter your name, please.");
            string plName = Console.ReadLine();
            Console.Clear();
            for (int countLine = 0; countLine != 123456; countLine++)
            {
                switch (countLine)
                {
                    case 0:
                        switchLines($"Hello, {plName}! Welcome to my game!", plName, countLine, out countLine);
                        break;
                    case 1:
                        switchLines($"This is a test engine for visual novels I made :3", plName, countLine, out countLine);
                        break;
                    case 2:
                        switchLines($"To see if the loading function works, try to load line 10001", plName, countLine, out countLine);
                        break;
                    case 3:
                        switchLines($"Okay I just realized", plName, countLine, out countLine);
                        break;
                    case 4:
                        switchLines($"Like\nThis ain't visual novel\nIt's just novel, nothing visual", plName, countLine, out countLine);
                        break;
                    case 5:
                        switchLines($"Fuck I'm stupid", plName, countLine, out countLine);
                        break;
                    case 6:
                        switchLines($"Okay so\nThe next time you'll swipe, the program will close because I don't know what else do I write\nSo bye :D", plName, countLine, out countLine);
                        break;
                    case 10001:
                        switchLines($"If you see this, you've succesfully loaded line 10001", plName, countLine, out countLine);
                        break;
                    default:
                        Console.WriteLine("You've entered a non-existent line of text.");
                        countLine = 123455;
                        break;
                }
            }
        }
    }
}
