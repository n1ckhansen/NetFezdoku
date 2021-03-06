﻿using com.blackfez.NetFezdoku.entities;
using com.blackfez.NetFezdoku.utilities;

namespace com.blackfez.NeFezdoku.factories
{
    public class PuzzleGenerator
    {
        public static Puzzle CreateEmptyPuzzle()
        {
            var puzzle = new Puzzle();
            var itr = 0;
            while( itr < 81 )
            {
                puzzle.GetGroupsForId(itr);
                itr++;
            }
            return puzzle;
        }

        public static Puzzle CreateSolvable()
        {
            var puzzle = CreateEmptyPuzzle();
            var scratchpad = new PuzzleGeneratorState();
            SetPuzzleBox(puzzle, scratchpad);
            var i = 0;
            while( i < 35 ) {
                var index = RandomNumberThinger.Instance.PickAValue( 81 );
                if (puzzle.AllBoxes[index].IsGiven)
                    continue;
                var givenBox = puzzle.AllBoxes[index];
                givenBox.Guessed = givenBox.Assigned;
                givenBox.IsGiven = true;
                i++;
            }
            return puzzle;
        }

        private static void SetPuzzleBox( Puzzle puzzle, PuzzleGeneratorState scratch )
        {
            if (scratch.CurrentIndex == 81)
                return;

            var possibles = puzzle.GetPossiblesForId(scratch.CurrentIndex);
            while( possibles.Count > 0 && scratch.CurrentIndex < 81 )
            {
                var selector = RandomNumberThinger.Instance.PickAValue(possibles.Count);
                puzzle.SetValueAtId(scratch.CurrentIndex, possibles[selector]);
                possibles.RemoveAt(selector);
                scratch.CurrentIndex++;
                SetPuzzleBox(puzzle, scratch);

                if (scratch.CurrentIndex == 81)
                    return;
                puzzle.ReleaseValueAtId(--scratch.CurrentIndex);
            }
        }
    }
}
