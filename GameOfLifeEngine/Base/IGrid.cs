using System.Collections.Generic;

namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    /// <summary>
    /// interface to be implemented by class
    /// which will represent a grid in the 
    /// game of life
    /// </summary>
    /// <typeparam name="TC"></typeparam>
    public interface IGrid<TC> where TC:ICell
    {
        /// <summary>
        /// gets cells contained in the grid
        /// </summary>
        IEnumerable<TC> Cells { get; }

        /// <summary>
        /// gets number of rows in the grid
        /// </summary>
        int NumberOfRows { get; }

        /// <summary>
        /// gets the number of columns in the 
        /// grid
        /// </summary>
        int NumberOfColumns { get; }

        /// <summary>
        /// gets a cell from the grid by using
        /// its position - row and column index
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        TC GetCellByIndex(int rowIndex, int columnIndex);

        /// <summary>
        /// Adds a cell to the grid
        /// </summary>
        /// <param name="cell"></param>
        void AddCell(TC cell);
    }
}