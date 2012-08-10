namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    /// <summary>
    /// interface to be implemented by classes which
    /// will be used as location of an <see cref="Organism"/>
    /// </summary>
    public interface ICell
    {
        int RowIndex { get; set; }
        int ColIndex { get; set; }

        bool IsAlive { get; set; }
    }
}