using System;
using NUnit.Framework;
using PrathameshKulkarni.GameOfLifeEngine;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngineTests
{
    public class FakeCellRule : CellRule
    {
        public FakeCellRule(IGrid grid, INeighbourCalculator neighbourCalculator)
            : base(grid, neighbourCalculator)
        {
        }

        public override void Execute(ICell cell)
        {
            throw new System.NotImplementedException();
        }

        public void Validate(ICell cell)
        {
            base.ValidateCell(cell);
        }
    }

    [TestFixture]
    public class CellRuleTests
    {
        private INeighbourCalculator _neighbourCalculator;
        private FakeCellRule _cellRule;

        [SetUp]
        public void SetUp()
        {
            _neighbourCalculator = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            _cellRule = new FakeCellRule(TestObjects.ThreexThreeGrid, _neighbourCalculator);
        }

        [TearDown]
        public void TearDown()
        {
            _neighbourCalculator = null;
            _cellRule = null;
        }

        [Test]
        public void Test_ValidateCell_NullCellIsPassedAsParam_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _cellRule.Validate(null));
        }

        [Test]
        public void Test_ValidateCell_CellNotAddedToGridIsPassedAsParam_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _cellRule.Validate(null));
        }
    }
}