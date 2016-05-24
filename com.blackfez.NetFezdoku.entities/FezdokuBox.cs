﻿using System;

namespace com.blackfez.NetFezdoku.entities
{
    public class FezdokuBox
    {
        public SudokuValue Assigned { get; private set; }

        public SudokuValue Guessed { get; private set; }
        
        public Boolean IsGiven { get; private set; }

        public int Index { get; private set; }


        public FezdokuBox( int index )
        {
            Assigned = SudokuValue.NULL;
            Guessed = SudokuValue.NULL;
            Index = index;
        }

        public Boolean IsCorrect()
        {
            return Assigned.Equals(Guessed);
        }



    }
}