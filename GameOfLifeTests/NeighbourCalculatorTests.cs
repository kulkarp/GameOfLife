using System.Linq;
using NUnit.Framework;
using PrathameshKulkarni.GameOfLifeEngine;

namespace PrathameshKulkarni.GameOfLifeEngineTests
{
    [TestFixture]
    public class NeighbourCalculatorTests
    {
        #region Tests for TwoxTwo Grid

        [Test]
        public void Testing_NeighbourCellsForTwoxTwoGridRowIndex0AndColIndex0()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.TwoxTwoGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(0, 0);

            Assert.That(neighbours.Count(), Is.EqualTo(3), "Should have 3 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(1));
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(2));
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(3));
        }

        [Test]
        public void Testing_NeighbourCellsForTwoxTwoGridRowIndex0AndColIndex1()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.TwoxTwoGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(0, 1);

            Assert.That(neighbours.Count(), Is.EqualTo(3), "Should have 3 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(0));
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(2));
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(3));
        }

        [Test]
        public void Testing_NeighbourCellsForTwoxTwoGridRowIndex1AndColIndex0()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.TwoxTwoGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(1, 0);

            Assert.That(neighbours.Count(), Is.EqualTo(3), "Should have 3 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(0));
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(1));
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(3));
        }

        [Test]
        public void Testing_NeighbourCellsForTwoxTwoGridRowIndex1AndColIndex1()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.TwoxTwoGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(1, 1);

            Assert.That(neighbours.Count(), Is.EqualTo(3), "Should have 3 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(0));
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(1));
            CollectionAssert.Contains(neighbours, TestObjects.TwoxTwoGrid.Cells.ElementAt(2));
        }

        #endregion

        #region Tests for ThreexThree Grid

        [Test]
        public void Testing_NeighbourCellsForThreexThreeGridRowIndex0AndColIndex0()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(0, 0);

            Assert.That(neighbours.Count(), Is.EqualTo(3), "Should have 3 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(1));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(3));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(4));
        }

        [Test]
        public void Testing_NeighbourCellsForThreexThreeGridRowIndex0AndColIndex1()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(0, 1);

            Assert.That(neighbours.Count(), Is.EqualTo(5), "Should have 5 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(0));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(2));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(3));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(4));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(5));
        }
        
        [Test]
        public void Testing_NeighbourCellsForThreexThreeGridRowIndex0AndColIndex2()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(0, 2);

            Assert.That(neighbours.Count(), Is.EqualTo(3), "Should have 3 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(1));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(4));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(5));
        }

        [Test]
        public void Testing_NeighbourCellsForThreexThreeGridRowIndex1AndColIndex0()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(1, 0);

            Assert.That(neighbours.Count(), Is.EqualTo(5), "Should have 5 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(0));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(1));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(4));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(6));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(7));
        }

        [Test]
        public void Testing_NeighbourCellsForThreexThreeGridRowIndex1AndColIndex1()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(1, 1);

            Assert.That(neighbours.Count(), Is.EqualTo(8), "Should have 8 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(0));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(1));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(2));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(3));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(5));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(6));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(7));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(8));
        }
        
        [Test]
        public void Testing_NeighbourCellsForThreexThreeGridRowIndex1AndColIndex2()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(1, 2);

            Assert.That(neighbours.Count(), Is.EqualTo(5), "Should have 5 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(1));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(2));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(4));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(7));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(8));
        }

        [Test]
        public void Testing_NeighbourCellsForThreexThreeGridRowIndex2AndColIndex0()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(2, 0);

            Assert.That(neighbours.Count(), Is.EqualTo(3), "Should have 3 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(3));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(4));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(7));
        }

        [Test]
        public void Testing_NeighbourCellsForThreexThreeGridRowIndex2AndColIndex1()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(2, 1);

            Assert.That(neighbours.Count(), Is.EqualTo(5), "Should have 5 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(3));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(4));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(5));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(6));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(8));
        }

        [Test]
        public void Testing_NeighbourCellsForThreexThreeGridRowIndex2AndColIndex2()
        {
            var neighbourCalc = new NeighbourCalculator(TestObjects.ThreexThreeGrid);
            var neighbours = neighbourCalc.RetrieveNeighbours(2, 2);

            Assert.That(neighbours.Count(), Is.EqualTo(3), "Should have 3 neighbours");
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(4));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(5));
            CollectionAssert.Contains(neighbours, TestObjects.ThreexThreeGrid.Cells.ElementAt(7));
        }

        #endregion
    }
}