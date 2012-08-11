using PrathameshKulkarni.GameOfLifeEngine;
using PrathameshKulkarni.GameOfLifeUI;
using PrathameshKulkarni.GameOfLifeUI.Base;

namespace PrathameshKulkarni.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            //fetch the dependencies - here we just create them
            var neighbourCalculator = new NeighbourCalculator();
            var gameRules = new GameRules(new LiveCellRule(), new DeadCellRule());
            var gridRowColumnParser = new GridRowColumnParser();
            //typically we would create such an object and inject its dependencies
            //using an IoC container
            IGameOfLife gameOfLife = new GameOfLifeUI.GameOfLife(neighbourCalculator, gameRules, gridRowColumnParser);
            gameOfLife.Start();
        }
    }
}