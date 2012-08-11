using System;
using System.Linq;
using NUnit.Framework;
using PrathameshKulkarni.GameOfLifeUI;

namespace PrathameshKulkarni.GameOfLifeUITests
{
    [TestFixture]
    public class GridRowColumnParserTests
    {
        private GridRowColumnParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new GridRowColumnParser();
        }

        [TearDown]
        public void TearDown()
        {
            _parser = null;
        }

        [Test]
        public void Test_Parse_GridRowColumnStringIsEmpty_GridIsReturnedWithSpecifiedNumberOfRowsAndColumnsAndNoLiveCells()
        {
            var grid = _parser.Parse("   ", 3, 3);
            var aliveCells = grid.Cells.Where(c => c.IsAlive);

            Assert.That(grid.Cells.Count(), Is.EqualTo(9), "For a 3x3 grid total number of cells should have been 9");
            Assert.That(aliveCells.Count(), Is.EqualTo(0), "No cell should have been alive");
        }

        [Test]
        public void Test_Parse_GridRowColumnStringIsNotValidScenarioOne_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse(",", 4, 4));
        }

        [Test]
        public void Test_Parse_GridRowColumnStringIsNotValidScenarioTwo_ReturnsAGridOf4x4OfDeadCells()
        {
            var grid = _parser.Parse("|", 4, 4);

            Assert.That(grid.Cells.Count(), Is.EqualTo(16), "A 4x4 grid should have 16 cells");
            Assert.That(grid.Cells.Where(c=>c.IsAlive).Count(), Is.EqualTo(0), "Should have had 0 live cells");
        }

        [Test]
        public void Test_Parse_GridRowColumnStringIsNotValidScenarioThree_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse("sa,3|2,2|2,3", 4, 4));
        }

        [Test]
        public void Test_Parse_GridRowColumnStringIsNotValidScenarioFour_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse("2,3|2,2|2,3|1", 4, 4));
        }

        [Test]
        public void Test_Parse_GridRowColumnStringIsNotValidScenarioSix_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse("iwfiawflhao", 4, 4));
        }

        [Test]
        public void Test_Parse_APairHasRowIndexGreaterThanNumberOfRows_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse("2,3|2,2|2,3|5,1", 4, 4));
        }

        [Test]
        public void Test_Parse_APairHasRowIndexEqualToNumberOfRows_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse("4,3|2,2|2,3|5,1", 4, 4));
        }

        [Test]
        public void Test_Parse_APairHasColumnIndexGreaterThanNumberOfColumns_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse("2,5|2,2|2,3|3,1", 4, 4));
        }

        [Test]
        public void Test_Parse_APairHasColumnIndexEqualToNumberOfColumns_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse("2,4|2,2|2,3|5,1", 4, 4));
        }

        [Test]
        public void Test_Parse_APairHasRowIndexLessThanZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse("2,3|-2,2|2,3|5,1", 4, 4));
        }

        [Test]
        public void Test_Parse_APairHasColumnIndexLessThanZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse("2,3|2,2|2,-3|5,1", 4, 4));
        }
    }
}