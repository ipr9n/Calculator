using System;
using System.Drawing;
using System.Linq;

namespace Clck
{
    class Program
    {
        static Point cursorLoc = new Point(0, 0);
        static Point numberLoc = new Point(10, 10);
        private static string temporaryNumber = "";
        private static double firstNumber;
        private static double secondNumber;
        static Operation action = Operation.nothing;

        static void Main(string[] args)
        {

            restart();
        }

        private static void restart()
        {
            Console.Clear();
            action = Operation.nothing;
            temporaryNumber = "";
            cursorLoc = new Point(0, 0);
            numberLoc = new Point(10, 10);
            Console.Write("1 2 3 + *\n4 5 6 - %\n7 8 9 / =\n√ 0 .");
            Console.WriteLine("Наберите первое число!");
            Console.SetCursorPosition(0, 0);
            checkKey();
        }

        private static void checkKey()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:

                    if (cursorLoc.X > 0)
                    {
                        cursorLoc.X -= 2;
                        Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    }

                    break;

                case ConsoleKey.RightArrow:

                    if (cursorLoc.X < 8 && cursorLoc.Y != 3 ||
                        cursorLoc.X < 4 && cursorLoc.Y == 3)
                    {
                        cursorLoc.X += 2;
                        Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    }

                    break;

                case ConsoleKey.UpArrow:

                    if (cursorLoc.Y > 0)
                    {
                        cursorLoc.Y -= 1;
                        Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    }

                    break;

                case ConsoleKey.DownArrow:

                    if (cursorLoc.Y == 2 && cursorLoc.X < 6 ||
                        cursorLoc.Y < 2 && cursorLoc.X <= 8)
                    {
                        cursorLoc.Y += 1;
                        Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    }

                    break;

                case ConsoleKey.Enter:

                    Console.SetCursorPosition(numberLoc.X, numberLoc.Y);

                    if (cursorLoc.X < 6 && cursorLoc.Y < 3 ||
                        cursorLoc.X == 2 && cursorLoc.Y == 3)
                    {
                        int cursorNumber = (int)number[cursorLoc.Y][cursorLoc.X / 2];
                        Console.Write(cursorNumber);
                        temporaryNumber += cursorNumber;

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
                        if (cursorLoc == new Point(6, 0) && action == Operation.nothing)
                        {
                            Console.Write("\n Наберите второе число");
                            action = Operation.sum;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            NextNumber();
                        }

                        if (cursorLoc == new Point(6, 1) && action == Operation.nothing)
                        {
                            Console.Write("\n Наберите второе число");
                            action = Operation.minus;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            NextNumber();
                        }

                        if (cursorLoc == new Point(6, 2) && action == Operation.nothing)
                        {
                            Console.Write("\n Наберите второе число");
                            action = Operation.divide;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            NextNumber();
                        }

                        if (cursorLoc == new Point(8, 0) && action == Operation.nothing)
                        {
                            Console.Write("\n Наберите второе число");
                            action = Operation.multiply;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            NextNumber();
                        }

                        if (cursorLoc == new Point(8, 1) && action == Operation.nothing)
                        {
                            action = Operation.percent;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            NextNumber();
                            getResult();
                            return;
                        }

                        if (cursorLoc == new Point(8, 2) && action != Operation.nothing)
                        {
                            secondNumber = Convert.ToDouble(temporaryNumber);
                            NextNumber();
                            getResult();
                            return;
                        }
                        if (cursorLoc == new Point(0, 3) && action == Operation.nothing)
                        {
                            action = Operation.sqrt;
                            firstNumber = Convert.ToDouble(temporaryNumber);
                            NextNumber();
                            getResult();
                            return;
                        }
                    }

                    numberLoc.X++;
                    Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                    break;
            }
            checkKey();
        }

        private static void getResult()
        {
            double result = 0;
            Console.SetCursorPosition(10, 15);
            Console.Write("Result is: ");
            switch (action)
            {
                case Operation.sum:
                    result = firstNumber + secondNumber;
                    break;
                case Operation.minus:
                    result = firstNumber - secondNumber;
                    break;
                case Operation.divide:
                    result = firstNumber / secondNumber;
                    break;
                case Operation.multiply:
                    result = firstNumber * secondNumber;
                    break;
                case Operation.percent:
                    result = firstNumber / 100;
                    break;
                case Operation.sqrt:
                    result = Math.Sqrt(firstNumber);
                    break;
            }
            Console.WriteLine(result);
            Console.WriteLine("Press any key to restart");
            Console.ReadKey();
            restart();
        }

        enum Operation
        {
            sum,
            divide,
            multiply,
            sqrt,
            minus,
            percent,
            nothing
        }

        enum Numbers
        {
            zero,
            one,
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine,
        }

        private static Numbers[][] number =
        {
            new[] {Numbers.one, Numbers.two, Numbers.three},
            new[] {Numbers.four, Numbers.five, Numbers.six},
            new[] {Numbers.seven, Numbers.eight, Numbers.nine},
            new[] {Numbers.zero, Numbers.zero, Numbers.zero}
        };

        private static void NextNumber()
        {
            numberLoc.Y += 2;
            numberLoc.X = 10;
            temporaryNumber = "";
        }

    }
}
