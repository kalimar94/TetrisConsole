using System;
using System.Linq;
using System.Threading;

namespace TetrisGame
{
    public enum Direction { Left, Right, Up, Down }
    class Tetris
    {
        static bool[,] field = new bool[50, 40];
        static bool[,] testPart = {
                                  {false, true, false},
                                  {true, true, true}
                                  };

        static void Main()
        {
            Console.WriteLine();
            Console.WindowHeight = 40;
            Console.WindowWidth = 50;
            Console.SetBufferSize(50, 40);

            var part = new Part(new Position(0, 0), testPart, field) ;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow && part.position.x > 0 && part.CanMove(Direction.Left))
                    {
                        part.position.x--;
                    }
                    else if (key.Key == ConsoleKey.RightArrow && part.position.x < 47 && part.CanMove(Direction.Right))
                    {
                        part.position.x++;
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        switch (part.direction)
                        {
                            case Direction.Left:
                                part.direction = Direction.Down;
                                break;
                            case Direction.Right:
                                part.direction = Direction.Up;
                                break;
                            case Direction.Up:
                                part.direction = Direction.Left;
                                break;
                            case Direction.Down:
                                part.direction = Direction.Right;
                                break;
                            default:
                                break;
                        }
                    }
                }
                part.position.y++;
                bool isStuck = !part.CanMove(Direction.Down);
                part.PrintPart(isStuck);
                if (isStuck)
                {
                    part = new Part(field);
                }
                PrintField();
                Thread.Sleep(150);
                part.RemovePart();
            }


        }

        static void PrintField()
        {
            for (int rows = 0; rows < field.GetLength(0); rows++)
            {
                for (int cols = 0; cols < field.GetLength(1); cols++)
                {
                    if (field[rows, cols])
                    {
                        Console.SetCursorPosition(rows, cols);
                        Console.Write("X");
                    }
                }
            }
        }
    }

    public struct Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
