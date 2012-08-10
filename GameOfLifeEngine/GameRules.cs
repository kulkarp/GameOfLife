using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    public class GameRules : IGameRules<ICellRule<ICell>>
    {
        public GameRules(ICellRule<ICell> liveCellRule, ICellRule<ICell> deadCellRule)
        {
            LiveCellRule = liveCellRule;
            DeadCellRule = deadCellRule;
        }
        public ICellRule<ICell> LiveCellRule { get; private set; }
        public ICellRule<ICell> DeadCellRule { get; private set; }
    }
}