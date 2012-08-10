using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    public class GameRules : IGameRules
    {
        public GameRules(ICellRule liveCellRule, ICellRule deadCellRule)
        {
            LiveCellRule = liveCellRule;
            DeadCellRule = deadCellRule;
        }
        public ICellRule LiveCellRule { get; private set; }
        public ICellRule DeadCellRule { get; private set; }
    }
}