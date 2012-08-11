using System;
using PrathameshKulkarni.GameOfLifeEngine;
using PrathameshKulkarni.GameOfLifeEngine.Base;
using PrathameshKulkarni.GameOfLifeUI.Base;

namespace PrathameshKulkarni.GameOfLifeUI
{
    /// <summary>
    /// Implements the game of life using the Console
    /// for input and output.
    /// </summary>
    public class GameOfLife : IGameOfLife
    {
        #region Fields

        private int _numberOfRows;
        private int _numberOfColumns;
        private int _numberOfEvolutions;
        private IGrid<ICell> _userGrid = null;
        private readonly IGridRowColumnParser<IGrid<ICell>> _gridRowColumnParser;
        private readonly INeighbourCalculator<ICell, IGrid<ICell>> _neighbourCalculator;
        private IGameRules<ICell, IGrid<ICell>, ICellRule<ICell, IGrid<ICell>>> _gameRules;

        #endregion

        #region Constructor

        public GameOfLife(INeighbourCalculator<ICell, IGrid<ICell>> neighbourCalculator,
                          IGameRules<ICell, IGrid<ICell>, ICellRule<ICell, IGrid<ICell>>> gameRules,
                          IGridRowColumnParser<IGrid<ICell>> gridRowColumnParser)
        {
            _gridRowColumnParser = gridRowColumnParser;
            _neighbourCalculator = neighbourCalculator;
            _gameRules = gameRules;
            _gameRules.LiveCellRule.NeighbourCalculator = _neighbourCalculator;
            _gameRules.DeadCellRule.NeighbourCalculator = _neighbourCalculator;
        }

        #endregion

        #region Public

        public void Start()
        {
            do
            {
                PrintInstructionsToScreen();
                while (!TakeNumberOfRowsFromUser())
                {
                    PrintInvalidInputMessage();
                }
                while (!TakeNumberOfColumnsFromUser())
                {
                    PrintInvalidInputMessage();
                }
                while (!TakeLiveCellsFromUser())
                {
                    PrintInvalidInputMessage();
                }
                while (!TakeNumberOfEvolutionsFromUser())
                {
                    PrintInvalidInputMessage();
                }
                Console.WriteLine("Following grid will be used:");
                Console.WriteLine(_userGrid.ToConsoleFormattedString());
                StartEvolution();
            } while (GetUserConfirmation());
        }

        #endregion

        #region Private

        private void StartEvolution()
        {
            for (int count = 0; count < _numberOfEvolutions; count++)
            {
                //a copy of the current grid will be used
                //to calculate neighbors and apply rules
                //the current grid cell change as rules are 
                //applied and hence we need a copy
                var gridCopy = _userGrid.GetDeepCopy();
                _neighbourCalculator.Grid = gridCopy;
                _gameRules.LiveCellRule.Grid = gridCopy;
                _gameRules.DeadCellRule.Grid = gridCopy;

                foreach (var cell in _userGrid.Cells)
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

                Console.WriteLine("Grid after {0} evolution(s).\nPress enter to continue", count + 1);
                Console.WriteLine(_userGrid.ToConsoleFormattedString());
                Console.ReadLine();
            }
        }

        private bool GetUserConfirmation()
        {
            Console.WriteLine("Press Y followed by the Enter key to continue.");
            var userInput = Console.ReadLine();
            if (string.Equals(userInput.Trim(), "Y", StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        private void PrintInvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please enter again");
        }

        private void PrintInstructionsToScreen()
        {
            Console.WriteLine("-----------------------------The Game Of Life-----------------------------\n");
            Console.WriteLine(
                "To start you will have to specify the size of the grid,\nthe initial live cells in the grid and\nthe number of times you want the grid to evolve.\n\n");
            Console.WriteLine("Specify the live cells in the format : rowIndex,colIndex | rowIndex,colIndex\n\n");
            Console.WriteLine("A live cell is represented by X and ");
            Console.WriteLine("a dead cell is represented by .\n\n");
            Console.WriteLine("Messages on the screen will now prompt for an input .\n\n");
            Console.WriteLine("--------------------------------------------------------------------------\n");
        }

        private bool TakeNumberOfRowsFromUser()
        {
            Console.WriteLine("Enter number of rows followed by Enter key.");
            var userInput = Console.ReadLine();
            return Int32.TryParse(userInput, out _numberOfRows);
        }

        private bool TakeNumberOfColumnsFromUser()
        {
            Console.WriteLine("Enter number of columns followed by Enter key.");
            var userInput = Console.ReadLine();
            return Int32.TryParse(userInput, out _numberOfColumns);
        }

        private bool TakeNumberOfEvolutionsFromUser()
        {
            Console.WriteLine("Enter number of evolutions followed by Enter key.");
            var userInput = Console.ReadLine();
            return Int32.TryParse(userInput, out _numberOfEvolutions);
        }

        private bool TakeLiveCellsFromUser()
        {
            Console.WriteLine(
                "Enter live cells in the format : rowIndex,colIndex | rowIndex,colIndex.\nfollowed by Enter key");
            var userInput = Console.ReadLine();
            var result = false;
            try
            {
                _userGrid = _gridRowColumnParser.Parse(userInput, _numberOfRows, _numberOfColumns);
                result = true;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine("Following error occurred : " + exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unknown error occurred : " + exception.Message);
            }
            return result;
        }

        #endregion

    }
}