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
                HashSet<SudokuValue> possibles = null;
                foreach( var possible in boxGroups)
                {
                    if (possibles == null)
                        possibles = possible.AvailableValues;
                    else
                        possibles.IntersectWith(possible.AvailableValues);
                }
                if (possibles.Count() < 1)
                {
                    //TODO: Break out of the loop and go back one more
                    break;
                }
                else if( possibles.Count() == 1 )
                {
                    puzzle.GetBoxForId(itr);
                    continue;
                }  
                else
                {

                }



                itr++;
            }

            return puzzle;
        }

        public static Puzzle CreateSolvable()
        {
            var puzzle = CreateEmptyPuzzle();
            int boxIndex = 0;
            while( boxIndex < 81 )
            {
                var possibles = puzzle.GetPossiblesForId(boxIndex);

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Working box {0}", boxIndex );
                Console.Write("Row: {0} ", boxIndex / 9);
                Console.Write("Column: {0} ", boxIndex % 9);
                Console.WriteLine("Block: {0} ", ((boxIndex / 9) / 3) * 3 + (boxIndex % 9) / 3 );
                Console.Write("Possible values are: ");
                foreach (var possible in possibles)
                    Console.Write("{0} ", possible);
                Console.WriteLine();

                if( possibles.Count > 0 )
                {
                    var selector = RandomNumberThinger.Instance.PickAValue(possibles.Count);
                    Console.WriteLine("Selector index {0} for possibles count {1}", selector, possibles.Count);
                    puzzle.SetValueAtId(boxIndex, possibles[ selector ]);
                    
                }
                else
                {
                    //Do evasive action stuff here
                    break;
                }
                boxIndex++;
            }



            return puzzle;
        }

    }
}
