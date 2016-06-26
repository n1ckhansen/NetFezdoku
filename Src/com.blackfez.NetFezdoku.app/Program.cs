using com.blackfez.NetFezdoku.factories;
using System;

namespace com.blackfez.NetFezdoku.app
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzle = PuzzleGenerator.CreateSolvable();
            puzzle.PuzzlePrinter();

        }
    }
}
