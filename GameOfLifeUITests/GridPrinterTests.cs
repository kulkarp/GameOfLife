using System;
using NUnit.Framework;
using PrathameshKulkarni.GameOfLifeEngineTests;
using PrathameshKulkarni.GameOfLifeUI;

namespace PrathameshKulkarni.GameOfLifeUITests
{
    [TestFixture]
    public class GridPrinterTests
    {
        [Test]
        public void Testing_ToConsoleFormattedString_ForTwoxTwoGrid()
        {
            var grid = TestObjects.TwoxTwoGrid;
            InitializeTwoxTwoGrid(false);
            //. .
            //. .
            var expectedString = ". . " + Environment.NewLine + ". . " + Environment.NewLine;
            Assert.That(grid.ToConsoleFormattedString(), Is.EqualTo(expectedString));

            InitializeTwoxTwoGrid(true);
            //X X
            //X X
            expectedString = "X X " + Environment.NewLine + "X X " + Environment.NewLine;
            Assert.That(grid.ToConsoleFormattedString(), Is.EqualTo(expectedString));

            InitializeTwoxTwoGrid(false);
            grid.GetCellByIndex(0, 0).IsAlive = true;
            grid.GetCellByIndex(1, 0).IsAlive = true;
            //X .
            //X .
            expectedString = "X . " + Environment.NewLine + "X . " + Environment.NewLine;
            Assert.That(grid.ToConsoleFormattedString(), Is.EqualTo(expectedString));
        }

        [Test]
        public void Testing_ToConsoleFormattedString_ForThreexThreeGrid()
        {
            var grid = TestObjects.ThreexThreeGrid;
            InitializeThreexThreeGrid(false);
            //. . . 
            //. . . 
            //. . . 
            var expectedString = ". . . " + Environment.NewLine + ". . . " + Environment.NewLine + ". . . " + Environment.NewLine;
            Assert.That(grid.ToConsoleFormattedString(), Is.EqualTo(expectedString));

            InitializeThreexThreeGrid(true);
            //X X X 
            //X X X 
            //X X X 
            expectedString = "X X X " + Environment.NewLine + "X X X " + Environment.NewLine + "X X X " + Environment.NewLine;
            Assert.That(grid.ToConsoleFormattedString(), Is.EqualTo(expectedString));

            InitializeThreexThreeGrid(false);
            grid.GetCellByIndex(0, 0).IsAlive = true;
            grid.GetCellByIndex(0, 2).IsAlive = true;
            grid.GetCellByIndex(1, 0).IsAlive = true;
            grid.GetCellByIndex(2, 1).IsAlive = true;
            //X . X 
            //X . . 
            //. X . 
            expectedString = "X . X " + Environment.NewLine + "X . . " + Environment.NewLine + ". X . " + Environment.NewLine;
            Assert.That(grid.ToConsoleFormattedString(), Is.EqualTo(expectedString));
        }

        private void InitializeTwoxTwoGrid(bool isAlive)
        {
            var grid = TestObjects.TwoxTwoGrid;

            foreach (var cell in grid.Cells)
            {
                cell.IsAlive = isAlive;
            }
        }

        private void InitializeThreexThreeGrid(bool isAlive)
        {
            var grid = TestObjects.ThreexThreeGrid;

            foreach (var cell in grid.Cells)
            {
                cell.IsAlive = isAlive;
            }
        }
    }
}