using System;
using System.Linq;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeEngine
{
    /// <summary>
    /// class representing the rule which will
    /// act on live <see cref="ICell"/> objects.
    /// The rule states that a live cell continues
    /// to remain alive if it has exactly 2 or 3 
    /// neighbors. In all other cases, it becomes 
    /// dead.
    /// </summary>
    public class LiveCellRule : CellRule<ICell, IGrid<ICell>>
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