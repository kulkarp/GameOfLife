using System.Collections.Generic;

namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public interface INeighbourCalculator
    {
        IEnumerable<ICell> RetrieveNeighbours(int rowIndex, int columnIndex);
    }
}