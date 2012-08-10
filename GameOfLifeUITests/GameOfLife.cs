using System;

namespace PrathameshKulkarni.GameOfLifeUITests
{
    public class GameOfLife
    {
        private void PrintInstructionsToScreen()
        {
            Console.WriteLine("Welcome to the Game Of Life");
            Console.WriteLine("To start you will have to specify the size of the grid, the initial live cells in the grid and the number of times you want the grid to evolve");
            Console.WriteLine("The grid cannot have more than 10 rows or 10 columns.");
            Console.WriteLine("Specify the live cells in the following format.");
            Console.WriteLine("<rowIndex>,<colIndex> | <rowIndex>,<colIndex>");
            Console.WriteLine("The grid cannot evolve more than 100 times");
        }
    }
}