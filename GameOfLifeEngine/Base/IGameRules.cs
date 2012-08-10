namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public interface IGameRules
    {
        ICellRule LiveCellRule { get; }

        ICellRule DeadCellRule { get; }
    }
}