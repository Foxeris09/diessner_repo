using othello.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace othello.ViewModel
{
    internal class CellViewModel : ViewModelBase
    {
        public int Row { get; }
        public int Column { get; }
        private Brush _backroundColor = Brushes.ForestGreen;
        public Brush BackroundColor
        {
            get => _backroundColor;
            set {  _backroundColor = value; OnPropertyChanged(); }
        }
    }
}
