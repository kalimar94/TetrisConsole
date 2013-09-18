using System;
using System.Collections.Generic;

namespace TetrisGame
{
    class TetrisParts
    {

    }
    public class Part
    {
        public Position position;
        public bool[,] elements;
        public int Width
        {
            get
            {
                if (direction == Direction.Left || direction == Direction.Right) return this.Height;
                else return this.Width;
            }
            private set
            {
                this.Width = value;
            }
        }
        public int Height
        {
            get
            {
                if (direction == Direction.Left || direction == Direction.Right) return this.Width;
                else return this.Height;
            }
            private set
            {
                this.Width = value;
            }
        }
        public bool[,] field;

        public Direction direction;

        public Part(Position position, bool[,] elements, bool[,] field)
        {
            this.position = position;
            this.elements = elements;
            this.field = field;

        }
        /// <summary>
        /// Generate Random Part
        /// </summary>
        public Part(bool[,] field)
        {

            bool[,] element1 = new bool[2, 3] { {true,false,false}, 
                                                {true,true,true}};

            bool[,] element2 = new bool[2, 3] { {false,true,false},
                                                {true,true,true}};
            bool[,] element3 = new bool[2, 3] { {false,false,false},
                                                {true,true,true}};
            bool[,] element4 = new bool[2, 3] { {true,true,false},
                                                {false,true,true}};
            bool[,] element5 = new bool[2, 3] { {false,true,true},
                                               {false,true,false}};

            List<bool[,]> availableElements = new List<bool[,]>()
            {
                element1,
                element2,
                element3,
                element4,
                element5
            };
            Random rng = new Random();

            this.elements = element2;
            this.position = new Position(0, 0);
            this.field = field;
        }

        private enum PrintType { RemovePart, DisplayPart }

        public void PrintPart(bool isStuck = false)
        {
            // Print '#' at the positions of the part
            PrintOnField(isStuck, PrintType.DisplayPart);
        }
        public void RemovePart()
        {
            // Print ' ' at the positions of the part
            PrintOnField(false, PrintType.RemovePart);
        }

        private void PrintOnField(bool isStuck, PrintType type)
        {
            Console.SetCursorPosition(position.x, position.y);
            switch (direction)
            {
                case Direction.Left:
                    for (int i = 0; i < elements.GetLength(1); i++)
                    {
                        for (int j = 0; j < elements.GetLength(0); j++)
                        {
                            if (elements[j, i])
                            {
                                if (type == PrintType.RemovePart)
                                {
                                    field[position.x + j, Console.CursorTop] = false;
                                    Console.Write(" ");
                                }
                                else if (isStuck) { field[position.x + elements.GetLength(0) - 1 - j, Console.CursorTop] = true; }
                                else Console.Write("#");
                            }
                        }
                        Console.CursorTop++;
                        Console.CursorLeft = position.x;
                    }
                    break;
                case Direction.Right:
                    for (int i = elements.GetLength(1) - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < elements.GetLength(0); j++)
                        {
                            if (elements[j, i])
                            {
                                if (type == PrintType.RemovePart)
                                {
                                    Console.Write(" ");
                                }
                                else if (isStuck) { field[position.x + j, Console.CursorTop] = true; }
                                else Console.Write("#");
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
                    for (int i = elements.GetLength(0) - 1; i >= 0; i--)
                    {
                        for (int j = elements.GetLength(1) - 1; j >= 0; j--)
                        {
                            if (elements[i, j])
                            {
                                if (type == PrintType.RemovePart)
                                {
                                    field[position.x + j, Console.CursorTop] = false;
                                    Console.Write(" ");
                                }
                                else if (isStuck) { field[position.x + j, Console.CursorTop] = true; }
                                else Console.Write("#");
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
                    for (int i = 0; i < elements.GetLength(0); i++)
                    {
                        for (int j = 0; j < elements.GetLength(1); j++)
                        {
                            if (elements[i, j])
                            {
                                if (type == PrintType.RemovePart)
                                {
                                    field[position.x + j, Console.CursorTop] = false;
                                    Console.Write(" ");
                                }
                                else if (isStuck) { field[position.x + j, Console.CursorTop] = true; }
                                else Console.Write("#");
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


        public bool CanMove(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return CanMoveTo(new Position(position.x - 1, position.y));
                case Direction.Right:
                    return CanMoveTo(new Position(position.x + 1, position.y));
                case Direction.Down:
                    return CanMoveTo(new Position(position.x, position.y + 1));
                default:
                    return false;
            }
        }

        private bool CanMoveTo(Position newPosition)
        {
            try
            {
                Console.SetCursorPosition(newPosition.x, newPosition.y);
                switch (direction)
                {
                    case Direction.Left:
                        for (int i = 0; i < elements.GetLength(1); i++)
                        {
                            for (int j = 0; j < elements.GetLength(0); j++)
                            {
                                if (elements[j, i] && field[newPosition.x + elements.GetLength(0) - 1 - j, Console.CursorTop])
                                {
                                    return false;
                                }
                            }
                            Console.CursorTop++;
                            Console.CursorLeft = newPosition.x;
                        }
                        break;
                    case Direction.Right:
                        for (int i = elements.GetLength(1) - 1; i >= 0; i--)
                        {
                            for (int j = 0; j < elements.GetLength(0); j++)
                            {
                                if (elements[j, i] && field[newPosition.x + j, Console.CursorTop])
                                {
                                    return false;
                                }
                            }
                            Console.CursorTop++;
                            Console.CursorLeft = newPosition.x;
                        }
                        break;
                    case Direction.Up:
                        for (int i = elements.GetLength(0) - 1; i >= 0; i--)
                        {
                            for (int j = elements.GetLength(1) - 1; j >= 0; j--)
                            {
                                if (elements[i, j] && field[newPosition.x + j, Console.CursorTop])
                                {
                                    return false;
                                }
                            }
                            Console.CursorTop++;
                            Console.CursorLeft = newPosition.x;
                        }
                        break;
                    case Direction.Down:
                        for (int i = 0; i < elements.GetLength(0); i++)
                        {
                            for (int j = 0; j < elements.GetLength(1); j++)
                            {
                                if (elements[i, j] && field[newPosition.x + j, Console.CursorTop])
                                {
                                    return false;
                                }
                            }
                            Console.CursorTop++;
                            Console.CursorLeft = newPosition.x;
                        }
                        break;
                    default:
                        break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
