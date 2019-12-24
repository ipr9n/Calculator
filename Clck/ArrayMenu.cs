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
        public static Point sizeSecondDimentionArray = new Point(0, 0);
        public static int[,] secondDimentionArray;

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
                        oneDimensionArray = TryConvertToInt(textArray.Split(' '));
                        MenuHeads.Show(Helpers.MenuHeads.ArrayOperations);
                        ArrayOperationMenu(1);
                        lineNumber = 0;

                        // odnomernii
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Create array type: array[x][y]. Please write x and y separated by space");
                        var xyStringArray = Console.ReadLine().Split(' ');
                        if (xyStringArray.Length > 2)
                        {
                            Console.WriteLine("Error, please write only TWO numbers. Not more");
                            Console.ReadKey();
                            Show();
                        }

                        sizeSecondDimentionArray = new Point(TryConvertToInt(xyStringArray)[0],
                            TryConvertToInt(xyStringArray)[1]);
                        secondDimentionArray = new int[sizeSecondDimentionArray.X, sizeSecondDimentionArray.Y];
                        for (int i = 0; i < sizeSecondDimentionArray.X; i++)
                            for (int j = 0; j < sizeSecondDimentionArray.Y; j++)
                            {
                                int n;
                                Console.Write($"\narray[{i}][{j}] = ");
                                var tempNumber = Console.ReadLine();
                                if (int.TryParse(tempNumber, out n))
                                    secondDimentionArray[i, j] = int.Parse(tempNumber);
                                else
                                {
                                    Console.WriteLine("Write correct numbers. AnyKey to restart");
                                    Console.ReadKey();
                                    Show();
                                }
                            }
                        MenuHeads.Show(Helpers.MenuHeads.ArrayOperations);
                        ArrayOperationMenu(2);
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

                    if (dimension == 2 && lineNumber == 1)
                    {
                        int sum = 0;
                        for (int i = 0; i < sizeSecondDimentionArray.X; i++)
                            for (int j = 0; j < sizeSecondDimentionArray.Y; j++)
                                sum += secondDimentionArray[i, j];
                        Program.WriteLog($"Sum off this array is {sum}");
                        Console.Clear();
                        Console.Write(sum);
                        Console.WriteLine("\nPress any key");
                        Console.ReadKey();
                        MenuHeads.Show(Helpers.MenuHeads.ArrayOperations);
                        ArrayOperationMenu(2);
                    }

                    break;
            }

            ArrayOperationMenu(dimension);


        }

        public static int[] TryConvertToInt(string[] text)
        {

            int[] temp = new int[text.Length];
            Program.WriteLog($"Making one dimension array");
            int n;

            for (int i = 0; i < text.Length; i++)
            {
                if (int.TryParse(text[i], out n))
                {
                    temp[i] = int.Parse(text[i]);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error. Please write only numbers. Press any key");
                    Console.ReadKey();
                    Show();
                }
            }

            return temp;

        }
    }
}
