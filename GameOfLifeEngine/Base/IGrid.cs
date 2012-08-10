using System.Collections.Generic;

namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public interface IGrid
    {
        IEnumerable<ICell> Cells { get; }
        int NumberOfRows { get; }
        int NumberOfColumns { get; }
        ICell GetCellByIndex(int rowIndex, int columnIndex);
        void AddCell(ICell cell);
    }
}