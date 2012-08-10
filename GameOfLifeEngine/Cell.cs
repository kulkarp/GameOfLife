using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    public class Cell : ICell
    {
        public int RowIndex { get; set; }

        public int ColIndex { get; set; }

        public bool IsAlive { get; set; }
    }
}