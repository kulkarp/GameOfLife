using PrathameshKulkarni.GameOfLifeEngine;

namespace PrathameshKulkarni.GameOfLifeEngineTests
{
    public static class TestObjects
    {
        public static Grid TwoxTwoGrid;
        public static Grid ThreexThreeGrid;
        public static Grid FivexFiveGridForBlinkerOscillatorPattern;
        public static Grid SixxSixGridForToadOscillatorPattern;

        static TestObjects()
        {
            CreateAndInitializeTwoxTwoGrid();
            CreateAndInitializeThreexThreeGrid();
            CreateAndInitializeFivexFiveGridForBlinkerOscillatorPattern();
            CreateAndInitializeSixxSixGridForToadOscillatorPattern();
        }

        private static void CreateAndInitializeTwoxTwoGrid()
        {
            TwoxTwoGrid = new Grid(2, 2);

            TwoxTwoGrid.AddCell(new Cell() { RowIndex = 0, ColIndex = 0 });
            TwoxTwoGrid.AddCell(new Cell() { RowIndex = 0, ColIndex = 1 });
            TwoxTwoGrid.AddCell(new Cell() { RowIndex = 1, ColIndex = 0 });
            TwoxTwoGrid.AddCell(new Cell() { RowIndex = 1, ColIndex = 1 });
        }

        private static void CreateAndInitializeThreexThreeGrid()
        {
            ThreexThreeGrid = new Grid(3, 3);

            ThreexThreeGrid.AddCell(new Cell() { RowIndex = 0, ColIndex = 0 });
            ThreexThreeGrid.AddCell(new Cell() { RowIndex = 0, ColIndex = 1 });
            ThreexThreeGrid.AddCell(new Cell() { RowIndex = 0, ColIndex = 2 });
            ThreexThreeGrid.AddCell(new Cell() { RowIndex = 1, ColIndex = 0 });
            ThreexThreeGrid.AddCell(new Cell() { RowIndex = 1, ColIndex = 1 });
            ThreexThreeGrid.AddCell(new Cell() { RowIndex = 1, ColIndex = 2 });
            ThreexThreeGrid.AddCell(new Cell() { RowIndex = 2, ColIndex = 0 });
            ThreexThreeGrid.AddCell(new Cell() { RowIndex = 2, ColIndex = 1 });
            ThreexThreeGrid.AddCell(new Cell() { RowIndex = 2, ColIndex = 2 });
        }

        private static void CreateAndInitializeFivexFiveGridForBlinkerOscillatorPattern()
        {
            FivexFiveGridForBlinkerOscillatorPattern = new Grid(5, 5);

            for (int rowIndex = 0; rowIndex < 5; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 5; colIndex++)
                {
                    var cell = new Cell { RowIndex = rowIndex, ColIndex = colIndex, IsAlive = false };
                    FivexFiveGridForBlinkerOscillatorPattern.AddCell(cell);
                }
            }

            FivexFiveGridForBlinkerOscillatorPattern.GetCellByIndex(2, 1).IsAlive = true;
            FivexFiveGridForBlinkerOscillatorPattern.GetCellByIndex(2, 2).IsAlive = true;
            FivexFiveGridForBlinkerOscillatorPattern.GetCellByIndex(2, 3).IsAlive = true;
        }

        private static void CreateAndInitializeSixxSixGridForToadOscillatorPattern()
        {
            SixxSixGridForToadOscillatorPattern = new Grid(6, 6);

            for (int rowIndex = 0; rowIndex < 6; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 6; colIndex++)
                {
                    var cell = new Cell { RowIndex = rowIndex, ColIndex = colIndex, IsAlive = false };
                    SixxSixGridForToadOscillatorPattern.AddCell(cell);
                }
            }

            SixxSixGridForToadOscillatorPattern.GetCellByIndex(2, 2).IsAlive = true;
            SixxSixGridForToadOscillatorPattern.GetCellByIndex(2, 3).IsAlive = true;
            SixxSixGridForToadOscillatorPattern.GetCellByIndex(2, 4).IsAlive = true;
            SixxSixGridForToadOscillatorPattern.GetCellByIndex(3, 1).IsAlive = true;
            SixxSixGridForToadOscillatorPattern.GetCellByIndex(3, 2).IsAlive = true;
            SixxSixGridForToadOscillatorPattern.GetCellByIndex(3, 3).IsAlive = true;
        }
    }
}