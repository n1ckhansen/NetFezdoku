using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.blackfez.NetFezdoku.entities
{
    public enum SudokuValue { ONE = 1, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, NULL = 0 }

    public class SudokuValues {
        public static HashSet<SudokuValue> GetBaseSetOfPossibles()
        {
            return new HashSet<SudokuValue>
            {
                SudokuValue.ONE,
                SudokuValue.TWO,
                SudokuValue.THREE,
                SudokuValue.FOUR,
                SudokuValue.FIVE,
                SudokuValue.SIX,
                SudokuValue.SEVEN,
                SudokuValue.EIGHT,
                SudokuValue.NINE
            };
        }
    }
}
