using System.Collections.Generic;

namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public interface INeighbourCalculator<TC, TG> where TC:ICell
                                                  where TG:IGrid<TC>
    {
        IEnumerable<TC> RetrieveNeighbours(int rowIndex, int columnIndex);

        IGrid<TC> Grid { get; set; }
    }
}