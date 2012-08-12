using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    /// <summary>
    /// class which applies rules on  the <see cref="ICell"/>
    /// objects of <see cref="IGrid{ICell}"/> to evolved it
    /// </summary>
    public class Evolution : IEvolution<ICell, IGrid<ICell>>
    {
        private INeighbourCalculator<ICell, IGrid<ICell>> _neighbourCalculator;
        private IGameRules<ICell, IGrid<ICell>, ICellRule<ICell, IGrid<ICell>>> _gameRules;

        public Evolution(INeighbourCalculator<ICell, IGrid<ICell>> neighbourCalculator,
                         IGameRules<ICell, IGrid<ICell>, ICellRule<ICell, IGrid<ICell>>> gameRules)
        {
            _neighbourCalculator = neighbourCalculator;
            _gameRules = gameRules;
            _gameRules.LiveCellRule.NeighbourCalculator = neighbourCalculator;
            _gameRules.DeadCellRule.NeighbourCalculator = neighbourCalculator;
        }


        /// <summary>
        /// Applies game rules on the <paramref name="currentGrid"/>
        /// object to evolve its cells
        /// </summary>
        /// <param name="currentGrid"></param>
        public void Execute(IGrid<ICell> currentGrid)
        {
            //a copy of the current grid will be used
            //to calculate neighbors and apply rules
            //the current grid cell change as rules are 
            //applied and hence we need a copy
            var gridCopy = currentGrid.GetDeepCopy();
            _neighbourCalculator.Grid = gridCopy;
            _gameRules.LiveCellRule.Grid = gridCopy;
            _gameRules.DeadCellRule.Grid = gridCopy;

            foreach (var cell in currentGrid.Cells)
            {
                if (cell.IsAlive)
                {
                    _gameRules.LiveCellRule.Execute(cell);
                }
                else
                {
                    _gameRules.DeadCellRule.Execute(cell);
                }
            }
        }
    }
}