using System;
using System.Linq;
using NUnit.Framework;
using PrathameshKulkarni.GameOfLifeEngine;

namespace PrathameshKulkarni.GameOfLifeEngineTests
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        public void Test_Constructor_NumberOfRowsIsLessThan2_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(1, 2),
                                             "ArgumentOutOfRangeException should be thrown if a grid has less than 2 rows");
        }

        [Test]
        public void Test_Constructor_NumberOfColumnsIsLessThan2_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(2, 1),
                                                       "ArgumentOutOfRangeException should be thrown if a grid has less than 2 rows");
        }

        [Test]
        public void Test_AddCell_NullParam_ThrowsArgumentNullException()
        {
            var grid = new Grid(4, 4);
            Assert.Throws<ArgumentNullException>(() => grid.AddCell(null),
                                                 "ArgumentNullException should be thrown if a null cell is added");
        }

        [Test]
        public void Test_AddCell_CellHasRowIndexEqualToFour_ThrowsArgumentOutOfRangeException()
        {
            var grid = new Grid(4, 4);
            var cell = new Cell
                           {
                               RowIndex = 4,
                               ColIndex = 1
                           };

            Assert.Throws<ArgumentOutOfRangeException>(() => grid.AddCell(cell),
                                                 "ArgumentOutOfRangeException should be thrown");
        }

        [Test]
        public void Test_AddCell_CellHasColumnIndexEqualToFour_ThrowsArgumentOutOfRangeException()
        {
            var grid = new Grid(4, 4);
            var cell = new Cell
            {
                RowIndex = 1,
                ColIndex = 4
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => grid.AddCell(cell),
                                                 "ArgumentOutOfRangeException should be thrown");
        }

        [Test]
        public void Test_GetCellByIndex_RowIndexEqualToFour_ThrowsArgumentOutOfRangeException()
        {
            var grid = new Grid(4, 4);
            var cell = new Cell
            {
                RowIndex = 1,
                ColIndex = 1
            };
            grid.AddCell(cell);

            Assert.Throws<ArgumentOutOfRangeException>(() => grid.GetCellByIndex(4,1),
                                                 "ArgumentOutOfRangeException should be thrown");
        }

        [Test]
        public void Test_GetCellByIndex_ColumnIndexEqualToFour_ThrowsArgumentOutOfRangeException()
        {
            var grid = new Grid(4, 4);
            var cell = new Cell
            {
                RowIndex = 1,
                ColIndex = 1
            };
            grid.AddCell(cell);

            Assert.Throws<ArgumentOutOfRangeException>(() => grid.GetCellByIndex(1, 4),
                                                       "ArgumentOutOfRangeException should be thrown");
        }

        [Test]
        public void Test_GetCellByIndex_CellIsNotAddedAtSpecifiedIndex_ReturnsNullCell()
        {
            var grid = new Grid(4, 4);

            var returnedCell = grid.GetCellByIndex(2,2);

            Assert.That(returnedCell, Is.Null, "Cell retrieved should have been null");
        }

        [Test]
        public void Test_GetCellByIndex_ValidCellIsAdded_ReturnsSameCellAddedUsingAddCell()
        {
            var grid = new Grid(4, 4);
            var cell = new Cell
            {
                RowIndex = 2,
                ColIndex = 2
            };

            grid.AddCell(cell);

            var returnedCell = grid.GetCellByIndex(2, 2);

            Assert.That(returnedCell, Is.EqualTo(cell),
                        "Cell added using AddCell and cell retrieved using GetCellByIndex should be same");
        }

        [Test]
        public void Test_Cells_ValidCellsAreAdded_ReturnsCollectionOfAddedCells()
        {
            var grid = new Grid(2, 2);
            var cell0 = new Cell
            {
                RowIndex = 0,
                ColIndex = 0
            };

            var cell1 = new Cell
            {
                RowIndex = 0,
                ColIndex = 1
            };

            var cell2 = new Cell
            {
                RowIndex = 1,
                ColIndex = 0
            };

            var cell3 = new Cell
            {
                RowIndex = 1,
                ColIndex = 1
            };

            grid.AddCell(cell0);
            grid.AddCell(cell1);
            grid.AddCell(cell2);
            grid.AddCell(cell3);

            var cells = grid.Cells;

            Assert.That(cells.Count(), Is.EqualTo(4), "Count should have been 4");
            Assert.That(cells.ElementAt(0), Is.EqualTo(cell0),
                        "Cell added using AddCell and cell retrieved using Cells should be same");
            Assert.That(cells.ElementAt(1), Is.EqualTo(cell1),
                        "Cell added using AddCell and cell retrieved using Cells should be same");
            Assert.That(cells.ElementAt(2), Is.EqualTo(cell2),
                        "Cell added using AddCell and cell retrieved using Cells should be same");
            Assert.That(cells.ElementAt(3), Is.EqualTo(cell3),
                        "Cell added using AddCell and cell retrieved using Cells should be same");
        }
    }
}