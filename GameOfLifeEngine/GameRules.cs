using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    /// <summary>
    /// class which represents rules that
    /// will be applied on dead and live 
    /// cells in the game of life
    /// </summary>
    public class GameRules : IGameRules<ICell,IGrid<ICell>,ICellRule<ICell, IGrid<ICell>>>
    {
        public GameRules(ICellRule<ICell, IGrid<ICell>> liveCellRule, ICellRule<ICell, IGrid<ICell>> deadCellRule)
        {
            LiveCellRule = liveCellRule;
            DeadCellRule = deadCellRule;
        }

        /// <summary>
        /// gets/sets rule which will
        /// act on live cells
        /// </summary>
        public ICellRule<ICell, IGrid<ICell>> LiveCellRule { get; private set; }

        /// <summary>
        /// gets/sets rule which will 
        /// act on dead cells
        /// </summary>
        public ICellRule<ICell, IGrid<ICell>> DeadCellRule { get; private set; }
    }
}