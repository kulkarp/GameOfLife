using System;
using PrathameshKulkarni.GameOfLifeUI;

namespace PrathameshKulkarni.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameOfLife = new GameOfLifeUI.GameOfLife(new GridRowColumnParser());
            gameOfLife.Start();
        }
    }
}
