using System;
using System.Linq;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    /// <summary>
    /// class representing the rule which will
    /// act on dead <see cref="ICell"/> objects.
    /// The rule is that each dead cell with exactly
    /// 3 neighbors becomes alive, in rest all cases
    /// it remains to be dead
    /// </summary>
    public class DeadCellRule : CellRule<ICell, IGrid<ICell>>
    {
        /// <summary>
        /// Acts on the <paramref name="cell"/>
        /// to execute the rule using <see cref="ICellRule{TC,TG}.NeighbourCalculator"/>
        /// and <see cref="ICellRule{TC,TG}.Grid"/>
        /// </summary>
        /// <param name="cell"></param>
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