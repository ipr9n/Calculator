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
            Console.Clear();
            Console.Write("Show log\nBack to calculate\nExit");
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

                    if (lineNumber < 2)
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
                        Console.Write(ReadLogFile());
                        Console.WriteLine("Press any key to return in menu");
                    }

                    if (lineNumber == 1)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.Write("1 2 3 + *\n4 5 6 - %\n7 8 9 / =\n√ 0 .\nShow menu\n");
                        Program.Restart();
                    }

                    if (lineNumber == 2)
                        Environment.Exit(0);
                    break;
            }

            Console.SetCursorPosition(0, lineNumber);
            CheckMenu();
        }

        private static string ReadLogFile()
        {
            try
            {  
                using (StreamReader sr = new StreamReader("Log.txt"))
                {
                    String line = sr.ReadToEnd();
                    sr.Close();
                    return line;
                }
            }
            catch (IOException e)
            {
                return "Log does not exists";
            }
        }
    }
}
