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

        public static Puzzle CreateSolvable()
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
    }
}
