using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;

namespace WPFCode.Lab4.Task4
{
    public class ViewModel
    {
        public ObservableCollection<InkCanvasEditingMode> EditingModes { get; }
        public ObservableCollection<DrawingAttributes> DrawingAttributesCollection { get; }

        public InkCanvasEditingMode SelectedEditingMode { get; set; }
        public DrawingAttributes SelectedDrawingAttributes { get; set; }

        public ViewModel()
        {
            EditingModes = new ObservableCollection<InkCanvasEditingMode>
            {
                InkCanvasEditingMode.Ink,
                InkCanvasEditingMode.Select,
                InkCanvasEditingMode.EraseByPoint,
                InkCanvasEditingMode.EraseByStroke
            };

            DrawingAttributesCollection = new ObservableCollection<DrawingAttributes>
            {
                new DrawingAttributes { Color = Colors.Red, Width = 3, Height = 3 },
                new DrawingAttributes { Color = Colors.Green, Width = 10, Height = 10 },
                new DrawingAttributes { Color = Colors.Blue, Width = 15, Height = 15 }
            };
        }
    }
}
