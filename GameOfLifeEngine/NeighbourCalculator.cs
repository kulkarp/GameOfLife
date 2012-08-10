using System.Collections.Generic;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    public class NeighbourCalculator:INeighbourCalculator<ICell>
    {
        #region Fields

        private readonly IGrid<ICell> _grid;

        #endregion

        #region Constructor

        public NeighbourCalculator(IGrid<ICell> grid)
        {
            _grid = grid;
        }

        #endregion

        #region Public

        public IEnumerable<ICell> RetrieveNeighbours(int rowIndex, int columnIndex)
        {
            var neighbours = new List<ICell>();

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