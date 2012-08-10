using System;
using NUnit.Framework;
using PrathameshKulkarni.GameOfLifeEngine;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngineTests
{
    [TestFixture]
    public class DeadCellRuleTests
    {
        private NeighbourCalculator _neighbourCalculator;
        private ICellRule<ICell> _deadCellRule;

        [SetUp]
        public void SetUp()
        {
            _neighbourCalculator = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            _deadCellRule = new DeadCellRule(TestObjects.ThreexThreeGrid, _neighbourCalculator);
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
            _deadCellRule = null;
        }

        [Test]
        public void Test_Execute_LiveCellIsPassedAsParam_ThrowsArgumentException()
        {
            var liveCell = TestObjects.ThreexThreeGrid.GetCellByIndex(0, 0);
            liveCell.IsAlive = true;

            Assert.Throws<ArgumentException>(() => _deadCellRule.Execute(liveCell),
                                             "A live cell passed to a dead cell rule throws an ArgumentException");
        }

        [Test]
        public void Test_Execute_DeadCellWithExactlyThreeLiveNeighboursIsPassedAsParam_MakesTheDeadCellAlive()
        {
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 0).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(0, 1).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(1, 1).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 0).IsAlive = true;
            TestObjects.ThreexThreeGrid.GetCellByIndex(2, 2).IsAlive = true;
            //L L D
            //D L D
            //L D L

            var deadCell = TestObjects.ThreexThreeGrid.GetCellByIndex(2, 1);
            Assert.That(deadCell.IsAlive, Is.False);

            _deadCellRule.Execute(deadCell);

            Assert.That(deadCell.IsAlive, Is.True, "Dead Cell should have become alive");
        }

        [Test]
        public void Test_Execute_DeadCellWithMoreThanThreeLiveNeighboursIsPassedAsParam_TheDeadCellWillRemainDead()
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

            var deadCell = TestObjects.ThreexThreeGrid.GetCellByIndex(1, 2);
            Assert.That(deadCell.IsAlive, Is.False);

            _deadCellRule.Execute(deadCell);

            Assert.That(deadCell.IsAlive, Is.False, "Dead Cell should have remained dead");
        }

        [Test]
        public void Test_Execute_DeadCellWithLessThanThreeLiveNeighboursIsPassedAsParam_TheDeadCellWillRemainDead()
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

            var deadCell = TestObjects.ThreexThreeGrid.GetCellByIndex(0, 2);
            Assert.That(deadCell.IsAlive, Is.False);

            _deadCellRule.Execute(deadCell);

            Assert.That(deadCell.IsAlive, Is.False, "Dead Cell should have remained dead");
        }
    }
}