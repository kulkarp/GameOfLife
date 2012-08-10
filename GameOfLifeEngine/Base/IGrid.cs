using System.Collections.Generic;

namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public interface IGrid<TC> where TC:ICell
    {
        IEnumerable<TC> Cells { get; }
        int NumberOfRows { get; }
        int NumberOfColumns { get; }
        TC GetCellByIndex(int rowIndex, int columnIndex);
        void AddCell(TC cell);
    }
}