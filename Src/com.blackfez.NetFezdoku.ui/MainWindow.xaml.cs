using System.Windows;
using System.Collections.ObjectModel;
using com.blackfez.NeFezdoku.factories;
using com.blackfez.NetFezdoku.entities;

namespace com.blackfez.NetFezdoku.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public ObservableCollection<FezdokuBox> Boxes { get; set; } = new ObservableCollection<FezdokuBox>();


        public MainWindow()
        {
            InitializeComponent();
            //var puzzle = PuzzleGenerator.CreateEmptyPuzzle();
            var puzzle = PuzzleGenerator.CreateSolvable();

            foreach(var box in puzzle.AllBoxes )
            {
                Boxes.Add(box);
            }




            DataContext = this;
        }

    }
}
