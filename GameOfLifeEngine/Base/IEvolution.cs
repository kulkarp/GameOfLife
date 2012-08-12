namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    /// <summary>
    /// interface to be implemented by a class 
    /// which will evolve cells in a grid
    /// using the game rules
    /// </summary>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="TG"></typeparam>
    public interface IEvolution<TC, TG>
        where TC : ICell
        where TG : IGrid<TC>
    {
        /// <summary>
        /// Applies game rules on the <paramref name="currentGrid"/>
        /// object to evolve its cells
        /// </summary>
        /// <param name="currentGrid"></param>
        void Execute(TG currentGrid);
    }
}