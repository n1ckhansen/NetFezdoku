using com.blackfez.NetFezdoku.factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.blackfez.NetFezdoku.entities;
using com.blackfez.NetFezdoku.utilities;

namespace com.blackfez.NetFezdoku.factories
{
    public class PuzzleGenerator
    {

        public static Puzzle CreateEmptyPuzzle()
        {
            var puzzle = new Puzzle();
            var itr = 0;
            while( itr < 81 )
            {
                var boxGroups = puzzle.GetGroupsForId(itr);
                itr++;
            }

            return puzzle;
        }

        public static Puzzle CreateSolvable()
        {
            var puzzle = CreateEmptyPuzzle();
            var scratchpad = new PuzzleGeneratorState();
            SetPuzzleBox(puzzle, scratchpad);
            return puzzle;
        }

        static private void SetPuzzleBox( Puzzle puzzle, PuzzleGeneratorState scratch )
        {
            if (scratch.CurrentIndex == 81)
                return;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Working box {0}", scratch.CurrentIndex);
            Console.Write("Row: {0} ", scratch.CurrentIndex / 9);
            Console.Write("Column: {0} ", scratch.CurrentIndex % 9);
            Console.WriteLine("Block: {0} ", ((scratch.CurrentIndex / 9) / 3) * 3 + (scratch.CurrentIndex % 9) / 3);

            var possibles = puzzle.GetPossiblesForId(scratch.CurrentIndex);

            while( possibles.Count > 0 && scratch.CurrentIndex < 81 )
            {
                var selector = RandomNumberThinger.Instance.PickAValue(possibles.Count);
                Console.WriteLine("Selector index {0} for possibles count {1}", selector, possibles.Count);
                puzzle.SetValueAtId(scratch.CurrentIndex, possibles[selector]);
                possibles.RemoveAt(selector);
                scratch.CurrentIndex++;
                SetPuzzleBox(puzzle, scratch);

                if (scratch.CurrentIndex == 81)
                    return;

                puzzle.ReleaseValueAtId(--scratch.CurrentIndex);
            }

            /*
            var possibles = puzzle.GetPossiblesForId(scratch.CurrentIndex);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Working box {0}", scratch.CurrentIndex);
            Console.Write("Row: {0} ", scratch.CurrentIndex / 9);
            Console.Write("Column: {0} ", scratch.CurrentIndex % 9);
            Console.WriteLine("Block: {0} ", ((scratch.CurrentIndex / 9) / 3) * 3 + (scratch.CurrentIndex % 9) / 3);
            Console.Write("Possible values are: ");
            foreach (var possible in possibles)
                Console.Write("{0} ", possible);
            Console.WriteLine();

            if (possibles.Count > 0)
            {
                var selector = RandomNumberThinger.Instance.PickAValue(possibles.Count);
                Console.WriteLine("Selector index {0} for possibles count {1}", selector, possibles.Count);
                puzzle.SetValueAtId(scratch.CurrentIndex, possibles[selector]);
                scratch.HighestIndex = (scratch.CurrentIndex > scratch.HighestIndex) ? scratch.CurrentIndex : scratch.HighestIndex;
            }
            else
            {
                //Do evasive action stuff here
                scratch.Rollback++;
                for( int x = 0; x < scratch.Rollback; x++ )
                {

                }
            }
            */

        }

    }
}
