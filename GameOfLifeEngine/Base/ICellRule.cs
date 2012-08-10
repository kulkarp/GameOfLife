namespace PrathameshKulkarni.GameOfLifeEngine.Base
{
    public interface ICellRule<TC> where TC:ICell
    {
        void Execute(TC cell);
    }
}