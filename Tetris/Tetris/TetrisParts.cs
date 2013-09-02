using System;

namespace TetrisGame
{
    class TetrisParts
    {
        static void DeclaredObjects()
        {
            bool[,] fallingObjects = new bool[2, 3];

            for (int i = 0; i < fallingObjects.GetLength(0); i++)
            {
                for (int j = 0; j < fallingObjects.GetLength(1); j++)
                {
                    Console.WriteLine(fallingObjects[i,j]);
                }
            }
        }
    }
}
