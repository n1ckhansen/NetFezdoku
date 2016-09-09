using com.blackfez.NetFezdoku.factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using com.blackfez.NetFezdoku.entities;

namespace com.blackfez.NetFezdoku.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<FezdokuBox> _boxes = new ObservableCollection<FezdokuBox>();
        public ObservableCollection<FezdokuBox> Boxes { get { return _boxes; } set { _boxes = value; } }


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
