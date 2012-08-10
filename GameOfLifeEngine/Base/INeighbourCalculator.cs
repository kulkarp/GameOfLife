using System.Collections.Generic;

namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public interface INeighbourCalculator<TC> where TC:ICell
    {
        IEnumerable<TC> RetrieveNeighbours(int rowIndex, int columnIndex);
    }
}