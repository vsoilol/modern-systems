using System.Threading.Tasks;
using System.Windows;

namespace WPFCode.Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            await ShowWindowWithDelay(new Gradient());
        }
    }
}