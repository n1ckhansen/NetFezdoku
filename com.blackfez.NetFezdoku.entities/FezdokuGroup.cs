using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.blackfez.NetFezdoku.entities
{
    public class FezdokuGroup
    {
        private List<FezdokuBox> Boxes = new List<FezdokuBox>(9);

        private HashSet<SudokuValue> _AvailableValues = new HashSet<SudokuValue> { 
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

        public HashSet<SudokuValue> AvailableValues
        {
            get { return _AvailableValues; }
        }
        
        public FezdokuGroup() 
        {
        }

        public void AddBox(FezdokuBox box)
        {
            this.Boxes.Add(box);
        }

        public void AddBox( FezdokuBox box, int pos )
        {
            if (Boxes.ElementAt(pos) == null)
                Boxes[pos] = box;
        }

    }
}
