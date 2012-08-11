namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public interface ICellRule<TC, TG> where TC:ICell
                                       where TG:IGrid<TC>
    {
        void Execute(TC cell);

        INeighbourCalculator<TC, TG> NeighbourCalculator { get; set; }

        TG Grid { get; set; }
    }
}