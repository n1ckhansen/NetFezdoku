
namespace com.blackfez.NetFezdoku.utilities
{
    public class PuzzleGeneratorState
    {
        public int Rollback { get; set; }
        public int HighestIndex { get; set; }
        public int CurrentIndex { get; set; }

        public PuzzleGeneratorState()
        {
            Rollback = 0;
            HighestIndex = 0;
            CurrentIndex = 0;
        }
    }
}
