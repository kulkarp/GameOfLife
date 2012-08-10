using PrathameshKulkarni.GameOfLifeEngine;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeUI.Base
{
    /// <summary>
    /// interface to be implemented by classes 
    /// which will return <see cref="Grid"/> after
    /// parsing input string
    /// </summary>
    /// <typeparam name="TG">type of grid</typeparam>
    public interface IGridRowColumnParser<TG> where TG:IGrid<ICell>
    {
        /// <summary>
        /// Parses a string specifying row and column index of a live 
        /// <see cref="ICell"/> 
        /// The format of the sting is rowIndex,colIndex | rowIndex,colIndex
        /// and returns a <see cref="TG"/> object containing <paramref name="numberofRows"/>
        /// rows and <paramref name="numberOfcolumns"/>
        /// </summary>
        /// <param name="gridRowColumnString"></param>
        /// <param name="numberofRows"> </param>
        /// <param name="numberOfcolumns"> </param>
        /// <returns></returns>
        TG Parse(string gridRowColumnString, int numberofRows, int numberOfcolumns);
    }
}