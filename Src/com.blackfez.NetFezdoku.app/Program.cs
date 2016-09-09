using com.blackfez.NeFezdoku.factories;

namespace com.blackfez.NetFezdoku.app
{
    internal class Program
    {
        private static void Main()
        {
            var puzzle = PuzzleGenerator.CreateSolvable();
            puzzle.PuzzlePrinter();
        }
    }
}
