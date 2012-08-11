using System;

namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    
    /// <summary>
    /// abstract class that should be implemented by 
    /// a class representing rule to act on 
    /// <see cref="ICell"/> objects.
    /// </summary>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="TG"></typeparam>
    public abstract class CellRule<TC, TG> : ICellRule<TC, TG>
                                                where TC : ICell
                                                where TG : IGrid<TC>
    {
        /// <summary>
        /// Acts on the <paramref name="cell"/>
        /// to execute the rule using <see cref="ICellRule{TC,TG}.NeighbourCalculator"/>
        /// and <see cref="ICellRule{TC,TG}.Grid"/>
        /// </summary>
        /// <param name="cell"></param>
        public abstract void Execute(TC cell);

        /// <summary>
        /// gets/sets instance of class implementing
        /// <see cref="INeighbourCalculator{TC,TG}"/>.
        /// Used by the <see cref="ICellRule{TC,TG}.Execute"/> method to
        /// implement the rule.
        /// </summary>
        public INeighbourCalculator<TC, TG> NeighbourCalculator { get; set; }

        /// <summary>
        /// gets/sets instance of class implementing
        /// <see cref="IGrid{TC}"/>. Used by the 
        /// <see cref="ICellRule{TC,TG}.Execute"/> method to implement the 
        /// rule
        /// </summary>
        public TG Grid { get; set; }

        /// <summary>
        /// Validates if the <paramref name="cell"/>
        /// is null or <see cref="NeighbourCalculator"/> 
        /// is null or <see cref="Grid"/> is null.
        /// </summary>
        /// <param name="cell"></param>
        protected virtual void ValidateCell(TC cell)
        {
            if (Grid == null)
            {
                throw new Exception("Grid needs to be set before calling this method");
            }

            if (NeighbourCalculator == null)
            {
                throw new Exception("NeighbourCalculator needs to be set before calling this method");
            }

            if (cell == null)
            {
                throw new ArgumentNullException("cell", "Cannot be null");
            }
        }
    }
}