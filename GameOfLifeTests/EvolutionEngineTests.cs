using System.Linq;
using NUnit.Framework;
using PrathameshKulkarni.GameOfLifeEngine;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngineTests
{
    [TestFixture]
    public class EvolutionEngineTests
    {
        private IEvolution<ICell, IGrid<ICell>> _evolution;
        [SetUp]
        public void SetUp()
        {
            _evolution = new Evolution(new NeighbourCalculator(), new GameRules(new LiveCellRule(), new DeadCellRule()));
        }

        [TearDown]
        public void TearDown()
        {
            _evolution = null;
        }

        [Test]
        public void Test_OscillatorBlinkerPatternForFivexFiveGrid()
        {
            var grid = TestObjects.FivexFiveGridForBlinkerOscillatorPattern;
            //initial state
            Assert.That(grid.Cells.Where(c => c.IsAlive).Count(), Is.EqualTo(3));
            Assert.That(grid.GetCellByIndex(2, 1).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 3).IsAlive, Is.True);


            //1st evolution
            _evolution.Execute(grid);
            Assert.That(grid.Cells.Where(c => c.IsAlive).Count(), Is.EqualTo(3));
            Assert.That(grid.GetCellByIndex(1, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 2).IsAlive, Is.True);

            //2nd evolution
            _evolution.Execute(grid);
            Assert.That(grid.Cells.Where(c => c.IsAlive).Count(), Is.EqualTo(3));
            Assert.That(grid.GetCellByIndex(2, 1).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 3).IsAlive, Is.True);

            //3rd evolution
            _evolution.Execute(grid);
            Assert.That(grid.Cells.Where(c => c.IsAlive).Count(), Is.EqualTo(3));
            Assert.That(grid.GetCellByIndex(1, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 2).IsAlive, Is.True);

            //4th evolution
            _evolution.Execute(grid);
            Assert.That(grid.Cells.Where(c => c.IsAlive).Count(), Is.EqualTo(3));
            Assert.That(grid.GetCellByIndex(2, 1).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 3).IsAlive, Is.True);
        }

        [Test]
        public void Test_OscillatorToadPatternForSixxSixGrid()
        {
            var grid = TestObjects.SixxSixGridForToadOscillatorPattern;
            //initial state
            Assert.That(grid.Cells.Where(c => c.IsAlive).Count(), Is.EqualTo(6));
            Assert.That(grid.GetCellByIndex(2, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 3).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 4).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 1).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 3).IsAlive, Is.True);


            //1st evolution
            _evolution.Execute(grid);
            Assert.That(grid.Cells.Where(c => c.IsAlive).Count(), Is.EqualTo(6));
            Assert.That(grid.GetCellByIndex(2, 1).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 1).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(4, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(1, 3).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 4).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 4).IsAlive, Is.True);

            //2nd evolution
            _evolution.Execute(grid);
            //initial state
            Assert.That(grid.Cells.Where(c => c.IsAlive).Count(), Is.EqualTo(6));
            Assert.That(grid.GetCellByIndex(2, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 3).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 4).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 1).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 3).IsAlive, Is.True);

            //3rd evolution
            _evolution.Execute(grid);
            Assert.That(grid.Cells.Where(c => c.IsAlive).Count(), Is.EqualTo(6));
            Assert.That(grid.GetCellByIndex(2, 1).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 1).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(4, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(1, 3).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 4).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 4).IsAlive, Is.True);

            //4th evolution
            _evolution.Execute(grid);
            //initial state
            Assert.That(grid.Cells.Where(c => c.IsAlive).Count(), Is.EqualTo(6));
            Assert.That(grid.GetCellByIndex(2, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 3).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(2, 4).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 1).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 2).IsAlive, Is.True);
            Assert.That(grid.GetCellByIndex(3, 3).IsAlive, Is.True);
        }
    }
}