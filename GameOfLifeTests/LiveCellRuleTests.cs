using System;
using NUnit.Framework;
using PrathameshKulkarni.GameOfLifeEngine;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngineTests
{
    [TestFixture]
    public class LiveCellRuleTests
    {
        private NeighbourCalculator _neighbourCalculator;
        private ICellRule _liveCellRule;

        [SetUp]
        public void SetUp()
        {
            _neighbourCalculator = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            _liveCellRule = new LiveCellRule(TestObjects.ThreexThreeGrid, _neighbourCalculator);
        }

        [TearDown]
        public void TearDown()
        {
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 0).IsAlive = false;
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 1).IsAlive = false;
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 2).IsAlive = false;
            TestObjects.ThreexThreeGrid.GetCellByIndex(1, 0).IsAlive = false;
            TestObjects.ThreexThreeGrid.GetCellByIndex(1, 1).IsAlive = false;
            TestObjects.ThreexThreeGrid.GetCellByIndex(1, 2).IsAlive = false;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 0).IsAlive = false;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 1).IsAlive = false;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 2).IsAlive = false;
            //D D D
            //D D D
            //D D D

            _neighbourCalculator = null;
            _liveCellRule = null;
        }

        [Test]
        public void Test_Execute_DeadCellIsPassedAsParam_ThrowsArgumentException()
        {
            var deadCell = TestObjects.ThreexThreeGrid.GetCellByIndex(0, 0);

            Assert.Throws<ArgumentException>(() => _liveCellRule.Execute(deadCell),
                                             "A dead cell passed to a alive cell rule throws an ArgumentException");
        }

        [Test]
        public void Test_Execute_LiveCellWithExactlyThreeLiveNeighboursIsPassedAsParam_LiveCellSurvives()
        {
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 0).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 1).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(1, 1).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(1, 0).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 0).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 2).IsAlive = true;
            //L L D
            //L L D
            //L D L

            var liveCell = TestObjects.ThreexThreeGrid.GetCellByIndex(0, 1);
            Assert.That(liveCell.IsAlive, Is.True);

            _liveCellRule.Execute(liveCell);

            Assert.That(liveCell.IsAlive, Is.True, "Live Cell should have survived");
        }

        [Test]
        public void Test_Execute_LiveCellWithExactlyTwoLiveNeighboursIsPassedAsParam_LiveCellSurvives()
        {
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 0).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 1).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(1, 0).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 0).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 2).IsAlive = true;
            //L L D
            //L D D
            //L D L

            var liveCell = TestObjects.ThreexThreeGrid.GetCellByIndex(0, 1);
            Assert.That(liveCell.IsAlive, Is.True);

            _liveCellRule.Execute(liveCell);

            Assert.That(liveCell.IsAlive, Is.True, "Live Cell should have survived");
        }

        [Test]
        public void Test_Execute_LiveCellWithMoreThanThreeLiveNeighboursIsPassedAsParam_TheLiveCellWillDie()
        {
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 0).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 1).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(1, 1).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 0).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 1).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 2).IsAlive = true;
            //L L D
            //D L D
            //L L L

            var liveCell = TestObjects.ThreexThreeGrid.GetCellByIndex(1, 1);

            Assert.That(liveCell.IsAlive, Is.True);

            _liveCellRule.Execute(liveCell);

            Assert.That(liveCell.IsAlive, Is.False, "Live Cell should have died");
        }

        [Test]
        public void Test_Execute_LiveCellWithLessThanTwoLiveNeighboursIsPassedAsParam_TheLiveCellWillDie()
        {
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 0).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 1).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(1, 1).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 0).IsAlive = true;
            //L L D
            //D L D
            //L D D

            var liveCell = TestObjects.ThreexThreeGrid.GetCellByIndex(2, 0);
            Assert.That(liveCell.IsAlive, Is.True);

            _liveCellRule.Execute(liveCell);

            Assert.That(liveCell.IsAlive, Is.False, "Live Cell should have died");
        }
    }
}