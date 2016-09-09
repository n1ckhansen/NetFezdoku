using System;
using System.Collections.Generic;
using System.Linq;

namespace com.blackfez.NetFezdoku.entities
{
    public class FezdokuGroup
    {
        private readonly List<FezdokuBox> _boxes = new List<FezdokuBox>(9);

        public HashSet<SudokuValue> AvailableValues { get; } = new HashSet<SudokuValue> { 
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

        public void AddBox(FezdokuBox box)
        {
            _boxes.Add(box);
        }

        public void AddBox( FezdokuBox box, int pos )
        {
            if (_boxes.ElementAt(pos) == null)
                _boxes[pos] = box;
        }

        public void PrintBoxes()
        {
            foreach( var box in _boxes )
            {
                Console.Write($"{box.Assigned} ");
            }
            Console.WriteLine("");
        }

    }
}
