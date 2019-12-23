using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Clck
{
    class Menu
    {
        public static bool IsLogActive = false;
        private static int lineNumber = 0;
        public static void Show()
        {
            lineNumber = 0;
            Program.cursorLoc = new Point(0,0);
           MenuHeads.Show(Helpers.MenuHeads.MainMenu);
            Console.SetCursorPosition(Program.cursorLoc.X, Program.cursorLoc.Y);
            CheckMenu();
        }

        public static void CheckMenu()
        {
            if (IsLogActive)
            {
                Console.ReadKey();
                IsLogActive = false;
                Show();
            }

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:

                    if (lineNumber < 3)
                       lineNumber++;
                    break;

                case ConsoleKey.UpArrow:

                    if (lineNumber > 0)
                        lineNumber--;
                    break;

                case ConsoleKey.Enter:

                    if (lineNumber == 0)
                    {
                        IsLogActive = true;
                        Console.Clear();
                        Console.Write(File.ReadAllText("Log.txt"));
                        Console.WriteLine("Press any key to return in menu");
                    }

                    if (lineNumber == 1)
                    {
                        File.WriteAllText("Log.txt","");
                        IsLogActive = true;
                        Console.Clear();
                        Console.WriteLine("Log is clear\n" +
                                          "Press any key to return in menu");
                    }

                    if (lineNumber == 2)
                    {
                       MenuHeads.Show(Helpers.MenuHeads.Calculate);
                        Program.Restart();
                      
                        break;
                    }

                    if (lineNumber == 3)
                    {
                        ArrayMenu.Show();
                        break;
                    }

                    if (lineNumber == 4)
                        Environment.Exit(0);
                    break;
            }

            Console.SetCursorPosition(0, lineNumber);
            CheckMenu();
        }
    }
}
