namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public interface ICell
    {
        int RowIndex { get; set; }
        int ColIndex { get; set; }

        bool IsAlive { get; set; }
    }
}