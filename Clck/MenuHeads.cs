using System;
using System.Collections.Generic;
using System.Text;

namespace Clck
{
    class MenuHeads
    {
        public static void Show(Helpers.MenuHeads heads)
        {
            switch (heads)
            {
                case Helpers.MenuHeads.Calculate:
                    Console.Clear();
                    Console.Write("1 2 3 + *\n" +
                                  "4 5 6 - %\n" +
                                  "7 8 9 / =\n" +
                                  "√ 0 .\n" +
                                  "Show menu\n");
                    break;
                case Helpers.MenuHeads.ArrayOperations:
                    Console.Clear();
                    Console.Write("Summ all elements\n" +
                                  "Show all elements\n" +
                                  "Back to main menu");
                    break;
                case Helpers.MenuHeads.MainMenu:
                    Console.Clear();
                    Console.Write("Show log\n" +
                                  "Clear log\n" +
                                  "Back to calculate\n" +
                                  "Make array\n" +
                                  "Exit");
                    break;
            }
        }
    }
}
