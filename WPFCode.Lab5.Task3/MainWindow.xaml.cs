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

namespace WPFCode.Lab5.Task3
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

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox lostFocusTextBox = sender as TextBox;
            TextBox newFocusTextBox = Keyboard.FocusedElement as TextBox;

            StackPanel lostFocusParent = VisualTreeHelper.GetParent(lostFocusTextBox) as StackPanel;
            StackPanel newFocusParent = VisualTreeHelper.GetParent(newFocusTextBox) as StackPanel;

            if (lostFocusParent == newFocusParent)
            {
                ((FrameworkElement)sender).Style = (Style)Resources["SmallTextBoxStyle"];
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement)sender).Style = (Style)Resources["LargeTextBoxStyle"];

            TextBox gotFocusTextBox = sender as TextBox;
            StackPanel gotFocusParent = VisualTreeHelper.GetParent(gotFocusTextBox) as StackPanel;

            foreach (UIElement child in gotFocusParent.Children)
            {
                if (child != gotFocusTextBox)
                {
                    ((FrameworkElement)child).Style = (Style)Resources["SmallTextBoxStyle"];
                }
            }
        }
    }
}
