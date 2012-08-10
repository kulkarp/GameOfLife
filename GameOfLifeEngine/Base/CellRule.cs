using System;
using System.Linq;

namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public abstract class CellRule<TG> : ICellRule<ICell> where TG:IGrid<ICell>
    {
        protected TG Grid;
        protected INeighbourCalculator<ICell> NeighbourCalculator;

        public CellRule(TG grid, INeighbourCalculator<ICell> neighbourCalculator)
        {
            Grid = grid;
            NeighbourCalculator = neighbourCalculator;
        }

        public abstract void Execute(ICell cell);
       
        protected virtual void ValidateCell(ICell cell)
        {
            if (cell == null)
            {
                throw new ArgumentNullException("cell", "Cannot be null");
            }
            if (!Grid.Cells.Contains(cell))
            {
                throw new ArgumentException("Cell should be part of grid that was used to initialize this rule", "cell");
            }
        }
    }
}