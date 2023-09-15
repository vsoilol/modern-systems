using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WPFCode.Lab3.Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var ellipseStylus = new EllipseStylusShape(10, 10, 0);
            inkCanvas.EraserShape = ellipseStylus;

            brushSizeSlider.ValueChanged += BrushSizeSlider_ValueChanged;
            drawRadio.Checked += ModeChanged;
            //fillRadio.Checked += ModeChanged;
            eraseRadio.Checked += ModeChanged;

            SetBrushSize();
            SetMode();

            colorPicker.SelectedColor = Colors.Black;
        }

        private void InkCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Do something when the mouse button is pressed
            Point position = e.GetPosition(inkCanvas);
            MessageBox.Show($"Mouse clicked at X:{position.X} Y:{position.Y}");
        }

        private void InkCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            /*if (colorPicker.SelectedColor.HasValue && fillRadio.IsChecked.Value)
            {
                // Update the brush color with the selected color from the ColorPicker.

                var color = colorPicker.SelectedColor.Value;
                FillInkCanvasWithLines(color);
            } */
        }

        private void InkCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            //FillInkCanvasWithLines(Colors.Black);
        }

        private void FillInkCanvasWithLines(Color color)
        {
            // The distance between lines
            var lineSize = 2;


            double lineSpacing = lineSize - 1;

            for (double y = 0; y <= inkCanvas.ActualHeight; y += lineSpacing)
            {
                // Create a new stroke for each line
                StylusPointCollection points = new StylusPointCollection
                {
                    new StylusPoint(0, y),
                    new StylusPoint(inkCanvas.ActualWidth, y)
                };

                Stroke stroke = new Stroke(points)
                {
                    DrawingAttributes = new DrawingAttributes
                    {
                        Color = color,
                        Height = lineSize,
                        Width = lineSize,
                        StylusTip = StylusTip.Ellipse
                    }
                };

                inkCanvas.Strokes.Add(stroke);
            }
        }

        private void OnSelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue.HasValue && !eraseRadio.IsChecked.Value)
            {
                // Update the brush color with the selected color from the ColorPicker.
                inkCanvas.DefaultDrawingAttributes.Color = e.NewValue.Value;
            }
        }

        private void BrushSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetBrushSize();
        }

        private void ModeChanged(object sender, RoutedEventArgs e)
        {
            SetMode();
        }

        private void SetBrushSize()
        {
            inkCanvas.DefaultDrawingAttributes.Width = brushSizeSlider.Value;
            inkCanvas.DefaultDrawingAttributes.Height = brushSizeSlider.Value;

            
        }

        private void SetMode()
        {
            if (drawRadio.IsChecked == true)
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                inkCanvas.DefaultDrawingAttributes.Color = colorPicker.SelectedColor ?? Colors.White;
            }
            /*else if (fillRadio.IsChecked == true)
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.None;
            }*/
            else if (eraseRadio.IsChecked == true)
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                inkCanvas.DefaultDrawingAttributes.Color = Colors.White;
            }
        }
    }
}
