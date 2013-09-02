using System;

namespace TetrisGame
{
    class TetrisParts
    {
       
    }
    struct Position
    {
        public int X;
        public int Y;
    }

    public class Part
    {
        Position position;
        bool[,] elements;
        public Part(Position position, bool[,] elements)
        {
            this.position = position;
            this.elements = elements;

        }
        /// <summary>
        /// Generate Random Part
        /// </summary>
        public Part()
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
        }
    }
}
