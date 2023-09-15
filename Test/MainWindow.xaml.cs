using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double EraserIncrementSize = 10;
        //private RectangleStylusShape eraserShape = new RectangleStylusShape(20, 20);

        public MainWindow()
        {
            InitializeComponent();
            //inkCanvas.EraserShape = eraserShape;
            inkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void IncreaseEraserSize(object sender, RoutedEventArgs e)
        {
            var eraserShape = new RectangleStylusShape(20 + EraserIncrementSize, 20 + EraserIncrementSize);

            // Refresh the eraser shape
            inkCanvas.EraserShape = null;
            inkCanvas.EraserShape = eraserShape;
        }

        private void DecreaseEraserSize(object sender, RoutedEventArgs e)
        {
            var eraserShape = new RectangleStylusShape(20 - EraserIncrementSize, 20 - EraserIncrementSize);

            // Refresh the eraser shape
            inkCanvas.EraserShape = null;
            inkCanvas.EraserShape = eraserShape;
        }
    }
}
