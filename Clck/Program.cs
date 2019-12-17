using System;
using System.Drawing;
using System.Linq;

namespace Clck
{
    class Program
    {
        Point cursorLoc = new Point(0, 0);
        Point numberLoc = new Point(10, 10);
        private string temporaryNumber = "";
        private double firstNumber;
        private double secondNumber;
        private byte action = 0;

        static void Main(string[] args)
        {
            Program method = new Program();
            Console.Write("1 2 3 + *\n4 5 6 - %\n7 8 9 / =\n√ 0 .\n");
            Console.WriteLine("Наберите первое число!");
            Console.SetCursorPosition(0, 0);
            method.checkKey();
        }

        private void checkKey()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:

                    if (cursorLoc.X > 0)
                    {
                        cursorLoc.X -= 2;
                        Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    }

                    checkKey();
                    break;

                case ConsoleKey.RightArrow:

                    if (cursorLoc.X < 8 && cursorLoc.Y != 3)
                    {
                        cursorLoc.X += 2;
                        Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    }
                    if (cursorLoc.X < 4 && cursorLoc.Y == 3)
                    {
                        cursorLoc.X += 2;
                        Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    }

                    checkKey();
                    break;

                case ConsoleKey.UpArrow:

                    if (cursorLoc.Y > 0)
                    {
                        cursorLoc.Y -= 1;
                        Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    }

                    checkKey();
                    break;

                case ConsoleKey.DownArrow:

                    if (cursorLoc.Y == 2 && cursorLoc.X < 6)
                    {
                        cursorLoc.Y += 1;
                        Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    }

                    if (cursorLoc.Y < 2 && cursorLoc.X <= 8)
                    {
                        cursorLoc.Y += 1;
                        Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    }

                    checkKey();
                    break;

                case ConsoleKey.Enter:

                    Console.SetCursorPosition(numberLoc.X, numberLoc.Y);
                    if (cursorLoc == new Point(0, 0))
                    {
                        Console.Write("1");
                        temporaryNumber += "1";
                    }

                    if (cursorLoc == new Point(2, 0))
                    {
                        Console.Write("2");
                        temporaryNumber += "2";
                    }

                    if (cursorLoc == new Point(4, 0))
                    {
                        Console.Write("3");
                        temporaryNumber += "3";
                    }

                    if (cursorLoc == new Point(0, 1))
                    {

                        Console.Write("4");
                        temporaryNumber += "4";
                    }

                    if (cursorLoc == new Point(2, 1))
                    {
                        Console.Write("5");
                        temporaryNumber += "5";
                    }

                    if (cursorLoc == new Point(4, 1))
                    {
                        Console.Write("6");
                        temporaryNumber += "6";
                    }

                    if (cursorLoc == new Point(0, 2))
                    {
                        Console.Write("7");
                        temporaryNumber += "7";
                    }

                    if (cursorLoc == new Point(2, 2))
                    {
                        Console.Write("8");
                        temporaryNumber += "8";
                    }

                    if (cursorLoc == new Point(4, 2))
                    {
                        Console.Write("9");
                        temporaryNumber += "9";
                    }

                    if (cursorLoc == new Point(2, 3))
                    {
                        Console.Write("0");
                        temporaryNumber += "0";
                    }

                    if (cursorLoc == new Point(4, 3))
                    {
                        if (temporaryNumber == "")
                        {
                            Console.Write("0,");
                            temporaryNumber += "0,";
                            numberLoc.X++;
                        }

                        if (temporaryNumber != "" && temporaryNumber.Last() != ',')
                        {
                            Console.Write(",");
                            temporaryNumber += ",";
                        }
                    }

                    if (temporaryNumber != "")
                    {
                        if (cursorLoc == new Point(6, 0) && action == 0)
                        {
                            Console.Write("\n Наберите второе число");
                            action = 1;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            temporaryNumber = "";
                            numberLoc.Y += 2;
                            numberLoc.X = 10;
                        }

                        if (cursorLoc == new Point(6, 1) && action == 0)
                        {
                            Console.Write("\n Наберите второе число");
                            action = 2;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            temporaryNumber = "";
                            numberLoc.Y += 2;
                            numberLoc.X = 10;
                        }

                        if (cursorLoc == new Point(6, 2) && action == 0)
                        {
                            Console.Write("\n Наберите второе число");
                            action = 3;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            temporaryNumber = "";
                            numberLoc.Y += 2;
                            numberLoc.X = 10;
                        }

                        if (cursorLoc == new Point(8, 0) && action == 0)
                        {
                            Console.Write("\n Наберите второе число");
                            action = 4;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            temporaryNumber = "";
                            numberLoc.Y += 2;
                            numberLoc.X = 10;
                        }

                        if (cursorLoc == new Point(8, 1) && action == 0)
                        {
                            action = 5;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            temporaryNumber = "";
                            numberLoc.Y += 1;
                            numberLoc.X = 10;
                            getResult();
                        }

                        if (cursorLoc == new Point(8, 2) && action != 0)
                        {
                            secondNumber = Convert.ToDouble(temporaryNumber);
                            temporaryNumber = "";
                            numberLoc.Y += 1;
                            numberLoc.X = 10;
                            getResult();
                            break;
                        }
                        if (cursorLoc == new Point(0, 3) && action == 0)
                        {
                            action = 6;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            temporaryNumber = "";
                            numberLoc.Y += 1;
                            numberLoc.X = 10;
                            getResult();
                            break;
                        }

                    }

                    numberLoc.X++;
                    Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    checkKey();
                    break;
                default:
                    checkKey();
                    break;
            }
        }

        private void getResult()
        {
            Console.SetCursorPosition(10, 15);
            Console.Write("Result is: ");
            switch (action)
            {
                case 1:
                    Console.WriteLine(firstNumber + secondNumber);
                    break;
                case 2:
                    Console.WriteLine(firstNumber - secondNumber);
                    break;
                case 3:
                    Console.WriteLine(firstNumber / secondNumber);
                    break;
                case 4:
                    Console.WriteLine(firstNumber * secondNumber);
                    break;
                case 5:
                    Console.WriteLine(firstNumber / 100);
                    break;
                case 6:
                    Console.WriteLine(Math.Sqrt(firstNumber));
                    break;
            }
            Console.WriteLine("Press any key to restart");
            Console.ReadKey();
            restart();
        }

        private void restart()
        {
            Console.Clear();
            temporaryNumber = "";
            cursorLoc = new Point(0, 0);
            numberLoc = new Point(10, 10);
            action = 0;
            Console.Write("1 2 3 + *\n4 5 6 - %\n7 8 9 / =\n√ 0 .");
            Console.WriteLine("Наберите первое число!");
            Console.SetCursorPosition(0, 0);
            checkKey();
        }
    }
}
