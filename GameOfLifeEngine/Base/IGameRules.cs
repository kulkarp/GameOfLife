namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public interface IGameRules<TC, TG, TCR> where TC:ICell
                                             where TG:IGrid<TC>
                                             where TCR:ICellRule<TC, TG>
    {
        TCR LiveCellRule { get; }

        TCR DeadCellRule { get; }
    }
}