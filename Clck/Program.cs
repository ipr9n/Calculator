using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Clck.Helpers;
using Clck;

namespace Clck
{
    class Program
    {
        public static Point cursorLoc = new Point(0, 0);
        private static string temporaryNumber = "";
        private static string permanentNumber = "";
        public static bool IsMenuEnable = false;
        private static double firstNumber;
        private static double secondNumber;
        static Operation action = Operation.nothing;

        static void Main(string[] args)
        {
            Console.Write("1 2 3 + *\n4 5 6 - %\n7 8 9 / =\n√ 0 .\nShow menu\n");
            Restart();
        }

        public static void Restart()
        {
            cursorLoc = new Point(0, 0);
            IsMenuEnable = false;
            action = Operation.nothing;
            AddToVariable("\n");
            temporaryNumber = "";
            Console.SetCursorPosition(0, 0);
            CheckMain();
        }

        public static void MoveCursor(int offsetX, int offsetY)
        {
            cursorLoc.X += offsetX;
            cursorLoc.Y += offsetY;
            Console.SetCursorPosition(cursorLoc.X,cursorLoc.Y);
        }

        public static void CheckMain()
        {
            switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:

                        if (cursorLoc.X > 0)
                            MoveCursor(-2, 0);
                        break;

                    case ConsoleKey.RightArrow:

                        if (cursorLoc.X < 8 && cursorLoc.Y != 3 ||
                            cursorLoc.X < 4 && cursorLoc.Y == 3)
                            MoveCursor(2, 0);
                        break;

                    case ConsoleKey.UpArrow:

                        if (cursorLoc.Y > 0)
                            MoveCursor(0, -1);
                        break;

                    case ConsoleKey.DownArrow:

                        if (cursorLoc.Y < 4)
                            MoveCursor(0, 1);
                        break;

                    case ConsoleKey.Enter:

                        if (cursorLoc.X < 6 && cursorLoc.Y < 3 ||
                            cursorLoc.X == 2 && cursorLoc.Y == 3)
                        {
                            int cursorNumber = (int) number[cursorLoc.Y][cursorLoc.X / 2];
                            AddToVariable(Convert.ToString(cursorNumber));
                        }

                        if (cursorLoc.Y == 4)
                        {
                            Menu.Show();
                            break;
                        }

                        if (cursorLoc == new Point(4, 3))
                        {
                            if (temporaryNumber == "")
                            {
                                AddToVariable("0");
                            }

                            if (temporaryNumber != "" && temporaryNumber.Last() != ',')
                            {
                                AddToVariable(",");
                            }
                        }

                        if (cursorLoc == new Point(6, 1) && action == Operation.nothing && temporaryNumber == "")
                        {
                            AddToVariable("-");
                        }

                        if (temporaryNumber != "")
                        {
                            if (cursorLoc == new Point(6, 0) && action == Operation.nothing)
                            {
                                AddToVariable("+");
                                action = Operation.sum;
                                firstNumber = Convert.ToDouble(temporaryNumber);
                                NextNumber();
                            }

                            if (cursorLoc == new Point(6, 1) && action == Operation.nothing &&
                                temporaryNumber.Last() != '-')
                            {
                                AddToVariable("-");
                                action = Operation.minus;
                                firstNumber = Convert.ToDouble(temporaryNumber);
                                NextNumber();
                            }

                            if (cursorLoc == new Point(6, 2) && action == Operation.nothing)
                            {
                                AddToVariable("/");
                                action = Operation.divide;
                                firstNumber = Convert.ToDouble(temporaryNumber);
                                NextNumber();
                            }

                            if (cursorLoc == new Point(8, 0) && action == Operation.nothing)
                            {
                                AddToVariable("*");
                                action = Operation.multiply;
                                firstNumber = Convert.ToDouble(temporaryNumber);
                                NextNumber();
                            }

                            if (cursorLoc == new Point(8, 1) && action == Operation.nothing)
                            {
                                action = Operation.percent;
                                firstNumber = Convert.ToDouble(temporaryNumber);
                                AddToVariable($"% ={GetResult(action)}");
                                Restart();
                                return;
                            }

                            if (cursorLoc == new Point(8, 2) && action != Operation.nothing)
                            {
                                secondNumber = Convert.ToDouble(temporaryNumber);
                                AddToVariable($"={GetResult(action)}");
                                Restart();
                                return;
                            }

                            if (cursorLoc == new Point(0, 3) && action == Operation.nothing)
                            {
                                action = Operation.sqrt;
                                firstNumber = Convert.ToDouble(temporaryNumber);
                                AddToVariable($"√ ={GetResult(action)}");
                                Restart();
                                return;
                            }
                        }

                        Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
                        break;
                }
            CheckMain();
            }

        public static void AddToVariable(string text)
        {
            if (temporaryNumber == "" && text == "-")
                temporaryNumber += text;
            else if (text != "+" && text != "/" && text != "*" && !text.Contains('%') && !text.Contains('√') && text != "-")
                temporaryNumber += text;
            permanentNumber += text;
            Console.SetCursorPosition(0, 10);
            Console.WriteLine(permanentNumber);
            Console.SetCursorPosition(cursorLoc.X, cursorLoc.Y);
        }

        private static void WriteLog(string text)
        {
            StreamWriter fs = new StreamWriter("Log.txt", true);
            fs.WriteLine(text);
            fs.Close();
        }

        private static double GetResult(Operation action)
        {
            double result = 0;
            switch (action)
            {
                case Operation.sum:
                    result = firstNumber + secondNumber;
                    WriteLog($"{firstNumber}+{secondNumber}={result}");
                    break;
                case Operation.minus:
                    result = firstNumber - secondNumber;
                    WriteLog($"{firstNumber}-{secondNumber}={result}");
                    break;
                case Operation.divide:
                    result = firstNumber / secondNumber;
                    WriteLog($"{firstNumber}/{secondNumber}={result}");
                    break;
                case Operation.multiply:
                    result = firstNumber * secondNumber;
                    WriteLog($"{firstNumber}*{secondNumber}={result}");
                    break;
                case Operation.percent:
                    result = firstNumber / 100;
                    WriteLog($"1 percent of {firstNumber} = {result}");
                    break;
                case Operation.sqrt:
                    
                    result = Math.Sqrt(firstNumber);
                    WriteLog($"Square root of {firstNumber}={result}");
                    break;
            }
            return result;
        }

        private static void NextNumber()
        {
            temporaryNumber = "";
        }

        private static Numbers[][] number =
        {
            new[] {Numbers.one, Numbers.two, Numbers.three},
            new[] {Numbers.four, Numbers.five, Numbers.six},
            new[] {Numbers.seven, Numbers.eight, Numbers.nine},
            new[] {Numbers.zero, Numbers.zero, Numbers.zero}
        };
    }
}
