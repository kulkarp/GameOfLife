namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    /// <summary>
    /// interface to be implemented by a class
    /// which will represent rules of the game 
    /// of life
    /// </summary>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="TG"></typeparam>
    /// <typeparam name="TCR"></typeparam>
    public interface IGameRules<TC, TG, TCR> where TC:ICell
                                             where TG:IGrid<TC>
                                             where TCR:ICellRule<TC, TG>
    {
        /// <summary>
        /// gets/sets rule which will
        /// act on live cells
        /// </summary>
        TCR LiveCellRule { get; }

        /// <summary>
        /// gets/sets rule which will 
        /// act on dead cells
        /// </summary>
        TCR DeadCellRule { get; }
    }
}