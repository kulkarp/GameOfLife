namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public interface IGameRules<TCR> where TCR:ICellRule<ICell>
    {
        TCR LiveCellRule { get; }

        TCR DeadCellRule { get; }
    }
}