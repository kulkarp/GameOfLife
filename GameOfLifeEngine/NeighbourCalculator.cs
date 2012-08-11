using System;
using System.Collections.Generic;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    public class NeighbourCalculator:INeighbourCalculator<ICell, IGrid<ICell>>
    {
        #region Fields

        private IGrid<ICell> _grid;

        #endregion

        #region Public

        public IEnumerable<ICell> RetrieveNeighbours(int rowIndex, int columnIndex)
        {
            var neighbours = new List<ICell>();

            if (_grid == null)
            {
                throw new Exception("Grid needs to be initialized before calling this method");
            }

            ICell neighbour = CalculateDiagonalTopLeftNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateDiagonalTopRightNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateDiagonalBottomLeftNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateDiagonalBottomRightNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateTopNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateBottomNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateLeftNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateRightNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            return neighbours;
        }

        /// <summary>
        /// gets/sets the grid which will be 
        /// used by <see cref="RetrieveNeighbours"/>
        /// to calculate the neighbors of a cell
        /// </summary>
        public IGrid<ICell> Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }

        #endregion

        #region Private

        private ICell CalculateDiagonalTopLeftNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex - 1, columnIndex - 1);
        }

        private ICell CalculateDiagonalTopRightNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex - 1, columnIndex + 1);
        }

        private ICell CalculateDiagonalBottomLeftNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex + 1, columnIndex - 1);
        }

        private ICell CalculateDiagonalBottomRightNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex + 1, columnIndex + 1);
        }

        private ICell CalculateTopNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex - 1, columnIndex);
        }

        private ICell CalculateBottomNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex + 1, columnIndex);
        }

        private ICell CalculateLeftNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex, columnIndex - 1);
        }

        private ICell CalculateRightNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex, columnIndex + 1);
        }

        private ICell CalculateNeighbour(int neighbourRowIndex, int neighbourColIndex)
        {
            if (NeighbourIndexIsValid(neighbourRowIndex, neighbourColIndex))
            {
                return _grid.GetCellByIndex(neighbourRowIndex, neighbourColIndex);
            }

            return null;
        }

        private bool NeighbourIndexIsValid(int rowIndex, int colIndex)
        {
            int rowUpperBound = _grid.NumberOfRows - 1;
            int colUpperBound = _grid.NumberOfColumns - 1;

            if (rowIndex > rowUpperBound || rowIndex < 0)
            {
                return false;
            }

            if (colIndex > colUpperBound || colIndex < 0)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}