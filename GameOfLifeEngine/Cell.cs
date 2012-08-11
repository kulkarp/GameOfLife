using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    /// <summary>
    /// class used to represent a cell that can be used 
    /// in a <see cref="IGrid{TC}"/> object
    /// </summary>
    public class Cell : ICell
    {
        /// <summary>
        /// gets/sets rows index of a cell
        /// </summary>
        public int RowIndex { get; set; }

        /// <summary>
        /// gets/sets column index of a cell
        /// </summary>
        public int ColIndex { get; set; }

        /// <summary>
        /// gets/sets if the the cell object is
        /// alive
        /// </summary>
        public bool IsAlive { get; set; }
    }
}