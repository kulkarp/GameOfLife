using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    public class GameRules : IGameRules<ICell,IGrid<ICell>,ICellRule<ICell, IGrid<ICell>>>
    {
        public GameRules(ICellRule<ICell, IGrid<ICell>> liveCellRule, ICellRule<ICell, IGrid<ICell>> deadCellRule)
        {
            LiveCellRule = liveCellRule;
            DeadCellRule = deadCellRule;
        }
        public ICellRule<ICell, IGrid<ICell>> LiveCellRule { get; private set; }
        public ICellRule<ICell, IGrid<ICell>> DeadCellRule { get; private set; }
    }
}