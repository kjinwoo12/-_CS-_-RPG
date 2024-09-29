using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BoxMaker
    {
        private BoxMaker()
        {
        }


        // 상자그리기
        public static void Draw(int width, int height, int cursorX = 0, int cursorY = 0, ConsoleColor borderColor = ConsoleColor.White)
        {
            Console.ForegroundColor = borderColor;

            Console.SetCursorPosition(cursorX, cursorY);

            DrawTop(width);

            
            for (int i = 0; i < height - 2; i++)
            {
                Console.SetCursorPosition(cursorX, cursorY + i + 1);
                DrawMiddle(width);
            }

            // 하단
            Console.SetCursorPosition(cursorX, cursorY + height - 1);
            DrawBottom(width);

            Console.ResetColor();
        }

        // 상단
        private static void DrawTop(int width)
        {
            Console.Write("┌");
            Console.Write(new string('─', width - 2));
            Console.WriteLine("┐");
        }

        // 중간
        private static void DrawMiddle(int width)
        {
            Console.Write("│");
            Console.Write(new string(' ', width - 2));
            Console.WriteLine("│");
        }

        // 하단
        private static void DrawBottom(int width)
        {
            Console.Write("└");
            Console.Write(new string('─', width - 2));
            Console.WriteLine("┘");
        }
    }
}
