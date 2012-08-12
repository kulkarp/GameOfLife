using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    /// <summary>
    /// Extension class for <see cref="IGrid{ICell}"/>
    /// </summary>
    public static class GridExtensions
    {
        /// <summary>
        /// gets a deep copy of the <paramref name="grid"/>
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static IGrid<ICell> GetDeepCopy(this IGrid<ICell> grid)
        {
            var gridCopy = new Grid(grid.NumberOfRows, grid.NumberOfColumns);
            foreach (var cell in grid.Cells)
            {
                var cellCopy = new Cell { RowIndex = cell.RowIndex, ColIndex = cell.ColIndex, IsAlive = cell.IsAlive };
                gridCopy.AddCell(cellCopy);
            }

            return gridCopy;
        }
    }
}