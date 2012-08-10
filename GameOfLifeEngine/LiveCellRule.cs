using System;
using System.Linq;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    public class LiveCellRule : CellRule<IGrid<ICell>>
    {
        public LiveCellRule(IGrid<ICell> grid, INeighbourCalculator<ICell> neighbourCalculator)
            : base(grid, neighbourCalculator)
        {
        }

        public override void Execute(ICell cell)
        {
            ValidateCell(cell);

            var neighbours = NeighbourCalculator.RetrieveNeighbours(cell.RowIndex, cell.ColIndex);
            var aliveNeighbours = neighbours.Where(n => n.IsAlive).ToList();
            if (aliveNeighbours.Count() < 2 || aliveNeighbours.Count() > 3)
            {
                cell.IsAlive = false;
            }
        }

        protected override void ValidateCell(ICell cell)
        {
            base.ValidateCell(cell);

            if (!cell.IsAlive)
            {
                throw new ArgumentException("This rule can only be applied to alive cells");
            }
        }
    }
}