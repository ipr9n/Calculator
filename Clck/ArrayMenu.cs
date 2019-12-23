using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Clck
{
    class ArrayMenu
    {
        private static int lineNumber = 0;
        private static int columnNumber = 0;
        public static int[] oneDimensionArray;
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("Choose number of dimensions\n" +
                              "1 2");
            lineNumber = 1;
            Console.SetCursorPosition(columnNumber, lineNumber);
            CheckMenu();
        }

        public static void CheckMenu()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    if (columnNumber > 0)
                        columnNumber -= 2;
                    break;
                case ConsoleKey.RightArrow:
                    if (columnNumber < 2)
                        columnNumber += 2;
                    break;

                case ConsoleKey.Enter:
                    if (columnNumber == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Write elements of array");
                        string textArray = Console.ReadLine();
                        TryConvertToInt(textArray.Split(' '));
                        MenuHeads.Show(Helpers.MenuHeads.ArrayOperations);
                        ArrayOperationMenu(1);
                        lineNumber = 0;

                        // odnomernii
                    }
                    else
                    {

                        //2 mernii
                    }
                    break;
            }

            Console.SetCursorPosition(columnNumber, lineNumber);
            CheckMenu();
        }

        public static void ArrayOperationMenu(int dimension)
        {
            Console.SetCursorPosition(0, lineNumber);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (lineNumber < 2) lineNumber++;
                    break;
                case ConsoleKey.UpArrow:
                    if (lineNumber > 0) lineNumber--;
                    break;
                case ConsoleKey.Enter:

                    if (dimension == 1 && lineNumber == 0)
                    {
                        Program.WriteLog($"Sum off this array is {oneDimensionArray.Sum()}");
                        Console.Clear();
                        Console.Write(oneDimensionArray.Sum());
                        Console.WriteLine("\nPress any key");
                        Console.ReadKey();
                        MenuHeads.Show(Helpers.MenuHeads.ArrayOperations);
                        ArrayOperationMenu(1);
                    }

                    if (dimension == 1 && lineNumber == 1)
                    {
                        Console.Clear();
                        foreach (var numberFromArray in oneDimensionArray)
                        {
                            Console.Write($"{numberFromArray} ");
                        }

                        Console.WriteLine("\nPress any key");
                        Console.ReadKey();
                        MenuHeads.Show(Helpers.MenuHeads.ArrayOperations);
                        ArrayOperationMenu(1);
                    }

                    if (dimension == 1 && lineNumber == 2)
                    {
                        Menu.Show();
                    }

                    break;
            }
            ArrayOperationMenu(dimension);


        }

        public static void TryConvertToInt(string[] text)
        {
            Program.WriteLog($"Making one dimension array");
            oneDimensionArray = new int[text.Length];
            int n;

            for (int i = 0; i < text.Length; i++)
            {
                if (int.TryParse(text[i], out n))
                {
                    oneDimensionArray[i] = int.Parse(text[i]);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error. Please write only numbers. Press any key");
                    Console.ReadKey();
                    Show();
                }
            }

        }
    }
}
