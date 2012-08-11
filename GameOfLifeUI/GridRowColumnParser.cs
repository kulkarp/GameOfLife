using System;
using System.Linq;
using PrathameshKulkarni.GameOfLifeEngine;
using PrathameshKulkarni.GameOfLifeEngine.Base;
using PrathameshKulkarni.GameOfLifeUI.Base;

namespace PrathameshKulkarni.GameOfLifeUI
{
    /// <summary>
    /// Use this class to create a grid from a 
    /// string specifying live rows and columns
    /// </summary>
    public class GridRowColumnParser : IGridRowColumnParser<IGrid<ICell>>
    {
        #region Fields

        private readonly char[] _rowColumnPairsSeparator;
        private readonly char[] _rowColumnSeparator;

        #endregion

        #region Constructor

        public GridRowColumnParser(char rowColumnPairsSeparator = '|', char rowColumnSeparator = ',')
        {
            _rowColumnPairsSeparator = new[] {rowColumnPairsSeparator};
            _rowColumnSeparator = new[] {rowColumnSeparator};
        }

        #endregion

        #region Public

        /// <summary>
        /// Parses a string specifying row and column index of a live 
        /// <see cref="ICell"/> 
        /// The format of the sting is rowIndex,colIndex | rowIndex,colIndex
        /// and returns a <see cref="IGrid{ICell}"/> object containing <paramref name="numberofRows"/>
        /// rows and <paramref name="numberOfcolumns"/>
        /// </summary>
        /// <param name="gridRowColumnString"></param>
        /// <param name="numberofRows"> </param>
        /// <param name="numberOfcolumns"> </param>
        /// <returns></returns>
        public IGrid<ICell> Parse(string gridRowColumnString, int numberofRows, int numberOfcolumns)
        {
            //create a grid and initialize it with dead cells
            var grid = CreateGrid(numberofRows, numberOfcolumns);
            if (gridRowColumnString.Trim(' ', _rowColumnPairsSeparator[0]).Length != 0)//no alive cells
            {                
                var rowColumnPairs = gridRowColumnString.Split(_rowColumnPairsSeparator);   
                foreach (var rowColumnPair in rowColumnPairs)
                {
                    var index = ParseAndReturnCellIndex(rowColumnPair, numberofRows, numberOfcolumns);
                    grid.GetCellByIndex(index[0], index[1]).IsAlive = true;
                }
            }
            return grid;
        }

        #endregion

        #region Private

        private Grid CreateGrid(int numberOfRows, int numberOfColumns)
        {
            var grid = new Grid(numberOfRows, numberOfColumns);
            for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < numberOfColumns; colIndex++)
                {
                    grid.AddCell(new Cell{RowIndex = rowIndex, ColIndex = colIndex});
                }
            }
            return grid;
        }

        private int[] ParseAndReturnCellIndex(string rowColumnPair, int numberofRows, int numberOfcolumns)
        {
            if (!rowColumnPair.Contains(_rowColumnSeparator[0]))//no valid row,col index pair
            {
                throw new ArgumentException(string.Format("The row column pair {0} has no rowColumn separator", rowColumnPair));
            }

            var cellIndex = rowColumnPair.Split(_rowColumnSeparator);
            if (!cellIndex.Any())//no valid row,col index
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            int rowIndex;
            if (!Int32.TryParse(cellIndex[0], out rowIndex) || rowIndex < 0 || rowIndex >= numberofRows)
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            int colIndex;
            if (!Int32.TryParse(cellIndex[1], out colIndex) || colIndex < 0 || colIndex >= numberOfcolumns)
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            return new[] {rowIndex, colIndex};
        }

        #endregion
    }
}