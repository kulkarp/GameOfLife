using System;
using NUnit.Framework;
using PrathameshKulkarni.GameOfLifeEngine;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngineTests
{
    public class FakeCellRule : CellRule<ICell, IGrid<ICell>>
    {
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
        private INeighbourCalculator<ICell, IGrid<ICell>> _neighbourCalculator;
        private FakeCellRule _cellRule;

        [SetUp]
        public void SetUp()
        {
            _neighbourCalculator = new NeighbourCalculator { Grid = TestObjects.ThreexThreeGrid };
            _cellRule = new FakeCellRule();
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
            _cellRule.Grid = TestObjects.TwoxTwoGrid;
            _cellRule.NeighbourCalculator = _neighbourCalculator;
            Assert.Throws<ArgumentNullException>(() => _cellRule.Validate(null));
        }

        [Test]
        public void Test_ValidateCell_GridIsNotSet_ThrowsException()
        {
            _cellRule.Grid = null;
            _cellRule.NeighbourCalculator = _neighbourCalculator;

            Assert.Throws<Exception>(() => _cellRule.Validate(TestObjects.TwoxTwoGrid.GetCellByIndex(0, 0)));
        }
        
        [Test]
        public void Test_ValidateCell_NeighbourCalculatorIsNotSet_ThrowsException()
        {
            _cellRule.Grid = TestObjects.ThreexThreeGrid;
            _cellRule.NeighbourCalculator = null;

            Assert.Throws<Exception>(() => _cellRule.Validate(TestObjects.TwoxTwoGrid.GetCellByIndex(0, 0)));
        }

    }
}