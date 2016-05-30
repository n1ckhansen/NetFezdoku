using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.blackfez.NetFezdoku.entities
{

    public class Puzzle
    {

        private List<FezdokuBox> AllBoxes { get; set; }

        private List<FezdokuGroup> Blocks { get; set; }

        private List<FezdokuGroup> Columns { get; set; }

        private List<FezdokuGroup> Rows { get; set; }


        public Puzzle()
        {
            AllBoxes = new List<FezdokuBox>();
            Blocks = new List<FezdokuGroup>();
            Columns = new List<FezdokuGroup>();
            Rows = new List<FezdokuGroup>();
            
            int index = 0;
            while( index < 9 )
            {
                Blocks.Add(new FezdokuGroup());
                Columns.Add(new FezdokuGroup());
                Rows.Add(new FezdokuGroup());
                index++;
            }
            index = 0;
            while (index < 81)
            {
                var thisBox = new FezdokuBox(index);
                AllBoxes.Add(thisBox);
                var rowSort = index / 9;
                var columnSort = index % 9;
                var blockSort = (rowSort / 3)*3 + columnSort / 3;
                Rows[ rowSort ].AddBox( thisBox );
                Columns[columnSort].AddBox(thisBox);
                Blocks[blockSort].AddBox(thisBox);
                index++;
            }

        }

        public HashSet<FezdokuGroup> GetGroupsForId( int id )
        {
            return new HashSet<FezdokuGroup>
            {
                Rows[ id / 9 ],
                Columns[ id % 9 ],
                Blocks[ ((id / 9) / 3) * 3 + (id % 9) / 3 ]
            };
        }

        public FezdokuBox GetBoxForId( int id )
        {
            return AllBoxes[id];
        }
        
        public void PuzzlePrinter()
        {
            foreach (var row in Rows)
            {
                row.PrintBoxes();
            }
        }

        public List<SudokuValue> GetPossiblesForId( int id )
        {
            var returnSet = SudokuValues.GetBaseSetOfPossibles();
            foreach( var group in GetGroupsForId( id ) )
            {
                returnSet.IntersectWith(group.AvailableValues);
            }
            return returnSet.ToList();
        }

        public void SetValueAtId( int id, SudokuValue value )
        {
            foreach( var group in GetGroupsForId( id ) )
            {
                group.AvailableValues.Remove(value);
            }
            GetBoxForId(id).SetAssigned( value );
        }

    }
}
/*
0   1  2  3  4  5  6  7  8
9  10 11 12 13 14 15 16 17
18 19 20 21 22 23 24 25 26
27 28 29 30 31 32 33 34 35
36 37 38 39 40 41 42 43 44
45 46 47 48 49 50 51 52 53
54 55 56 57 58 59 60 61 62
63 64 65 66 67 68 69 70 71
72 73 74 75 76 77 78 79 80
*/