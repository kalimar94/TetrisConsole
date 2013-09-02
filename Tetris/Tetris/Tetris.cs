using System;
using System.Threading;

namespace TetrisGame
{
    enum Direction { Left, Right, Up, Down }
    class Tetris
    {
        static bool[,] part = 
        {
            {false, true, false},
            {true, true, true}
        };

        static void Main()
        {
            Console.WriteLine();
            Console.WindowHeight = 60;
            Console.WindowWidth = 50;
            Console.SetBufferSize(50, 60);

            Direction currentDirection = Direction.Down;
            Position currentPosition = new Position(0, 0);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow && currentPosition.x > 0)
                    {
                        currentPosition.x--;
                    }
                    else if (key.Key == ConsoleKey.RightArrow && currentPosition.x < 47)
                    {
                        currentPosition.x++;
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        switch (currentDirection)
                        {
                            case Direction.Left:
                                currentDirection = Direction.Down;
                                break;
                            case Direction.Right:
                                currentDirection = Direction.Up;
                                break;
                            case Direction.Up:
                                currentDirection = Direction.Left;
                                break;
                            case Direction.Down:
                                currentDirection = Direction.Right;
                                break;
                            default:
                                break;
                        }
                    }
                    Console.SetCursorPosition(20, 30);
                    Console.WriteLine(currentDirection);
                }
                Console.SetCursorPosition(0, currentPosition.y);
                Console.Write(new string(' ', 50));
                Console.SetCursorPosition(0, currentPosition.y+1);
                Console.Write(new string(' ', 50));
                Console.SetCursorPosition(0, currentPosition.y+2);
                Console.Write(new string(' ', 50));
                currentPosition.y++;
                PrintPart(part, currentDirection, currentPosition);
                Thread.Sleep(400);
            }


        }

        static void PrintPart(bool[,] part, Direction direction, Position position)
        {
            Console.SetCursorPosition(position.x, position.y);
            switch (direction)
            {
                case Direction.Left:
                    for (int i = 0; i < part.GetLength(1); i++)
                    {
                        for (int j = 0; j < part.GetLength(0); j++)
                        {
                            if (part[j, i])
                            {
                                Console.Write("#");
                            }
                        }
                        Console.CursorTop++;
                        Console.CursorLeft = position.x;
                    }
                    break;
                case Direction.Right:
                    for (int i = part.GetLength(1) - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < part.GetLength(0); j++)
                        {
                            if (part[j, i])
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.CursorTop++;
                        Console.CursorLeft = position.x;
                    }
                    break;
                case Direction.Up:
                    for (int i = part.GetLength(0) - 1; i >= 0; i--)
                    {
                        for (int j = part.GetLength(1) - 1; j >= 0; j--)
                        {
                            if (part[i, j])
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.CursorTop++;
                        Console.CursorLeft = position.x;
                    }
                    break;
                case Direction.Down:
                    for (int i = 0; i < part.GetLength(0); i++)
                    {
                        for (int j = 0; j < part.GetLength(1); j++)
                        {
                            if (part[i, j])
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.CursorTop++;
                        Console.CursorLeft = position.x;
                    }
                    break;
                default:
                    break;
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
