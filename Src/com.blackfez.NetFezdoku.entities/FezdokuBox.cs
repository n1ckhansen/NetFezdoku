
namespace com.blackfez.NetFezdoku.entities
{
    public class FezdokuBox
    {
        public SudokuValue Assigned { get; private set; }

        public SudokuValue Guessed { get; set; }
        
        public bool IsGiven { get; set; }

        public int Index { get; private set; }

        public FezdokuBox( int index )
        {
            Assigned = SudokuValue.Null;
            Guessed = SudokuValue.Null;
            Index = index;
        }

        public bool IsCorrect()
        {
            return Assigned.Equals(Guessed);
        }

        public void SetAssigned( SudokuValue value )
        {
            Assigned = value;
        }
    }
}
