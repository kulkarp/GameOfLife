namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    /// <summary>
    /// interface to be implemented by a class
    /// which represent a single cell in a 
    /// <see cref="IGrid{TC}"/> object
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// gets/sets rows index of a cell
        /// </summary>
        int RowIndex { get; set; }

        /// <summary>
        /// gets/sets column index of a cell
        /// </summary>
        int ColIndex { get; set; }

        /// <summary>
        /// gets/sets if the the cell object is
        /// alive
        /// </summary>
        bool IsAlive { get; set; }
    }
}