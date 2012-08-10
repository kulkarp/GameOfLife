using System;
using System.Linq;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    public class DeadCellRule : CellRule<IGrid<ICell>>
    {
        public DeadCellRule(IGrid<ICell> grid, INeighbourCalculator<ICell> neighbourCalculator)
            : base(grid, neighbourCalculator)
        {
        }

        public override void Execute(ICell cell)
        {
            ValidateCell(cell);

            var neighbours = NeighbourCalculator.RetrieveNeighbours(cell.RowIndex, cell.ColIndex);
            var aliveNeighbours = neighbours.Where(n => n.IsAlive);
            if (aliveNeighbours.Count() == 3)
            {
                cell.IsAlive = true;
            }
        }

        protected override void ValidateCell(ICell cell)
        {
            base.ValidateCell(cell);

            if (cell.IsAlive)
            {
                throw new ArgumentException("This rule can only be applied to dead cells");
            }
        }
    }
}