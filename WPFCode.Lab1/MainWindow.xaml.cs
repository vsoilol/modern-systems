using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFCode.Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //await ShowWindowWithDelay(new Gradient());
        }

        private async Task ShowWindowWithDelay(Window window, int? delay = null)
        {
            if (delay.HasValue)
            {
                await Task.Delay(delay.Value);
            }

            window.Show();
        }

        private async void OpenNewWindow_Click(object sender, RoutedEventArgs e)
        {
            // Get the current margin
            Thickness currentMargin = Btn1.Margin;

            // Set random X and Y values within the window's bounds
            double maxX = ActualWidth - Btn1.ActualWidth;
            double maxY = ActualHeight - Btn1.ActualHeight;
            double newX = random.NextDouble() * maxX;
            double newY = random.NextDouble() * maxY;

            // Update the button's margin with the new values
            Btn1.Margin = new Thickness(newX, newY, 0, 0);

            //await ShowWindowWithDelay(new Gradient(), 50);
        }
    }
}