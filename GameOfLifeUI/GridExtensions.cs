﻿using System;
using System.Text;
using PrathameshKulkarni.GameOfLifeEngine;
using PrathameshKulkarni.GameOfLifeEngine.Base;

namespace PrathameshKulkarni.GameOfLifeUI
{
    public static class GridExtensions
    {
        private const char LiveCell = 'X';
        private const char DeadCell = '.';
        private const char Separator = ' ';

        /// <summary>
        /// Takes individual cells and returns a formatted
        /// string representing the grid.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static string ToConsoleFormattedString(this IGrid<ICell> grid)
        {
            var builder = new StringBuilder();
            for (var rowIndex = 0; rowIndex < grid.NumberOfRows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < grid.NumberOfColumns; columnIndex++)
                {
                    builder.Append(grid.GetCellByIndex(rowIndex, columnIndex).IsAlive ? LiveCell : DeadCell);
                    builder.Append(Separator);
                }
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }        
    }
}
