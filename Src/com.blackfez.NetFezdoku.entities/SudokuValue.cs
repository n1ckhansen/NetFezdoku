using System.Collections.Generic;

namespace com.blackfez.NetFezdoku.entities
{
    public enum SudokuValue { One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Null = 0 }

    public class SudokuValues {
        public static HashSet<SudokuValue> GetBaseSetOfPossibles()
        {
            return new HashSet<SudokuValue>
            {
                SudokuValue.One,
                SudokuValue.Two,
                SudokuValue.Three,
                SudokuValue.Four,
                SudokuValue.Five,
                SudokuValue.Six,
                SudokuValue.Seven,
                SudokuValue.Eight,
                SudokuValue.Nine
            };
        }
    }
}
