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

namespace WPFCode.Lab3.Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEnumerable<FrameworkElementDescription> _elementsDescription;

        public MainWindow()
        {
            InitializeComponent();

            _elementsDescription = new List<FrameworkElementDescription>
            {
                new FrameworkElementDescription(ChangeBackgroundColorMenuItem, "Элемент меню который изменяет цвет фона"),
                new FrameworkElementDescription(AboutDeveloperMenuItem, "Элемент меню который отображает инфо о разработчике"),
                new FrameworkElementDescription(ExitMenuItem, "Элемент меню который выполняет выход"),

                new FrameworkElementDescription(ChangeBackgroundColorButton, "Кнопка которая изменяет цвет фона"),
                new FrameworkElementDescription(AboutDeveloperButton, "Кнопка которая отображает инфо о разработчике"),
                new FrameworkElementDescription(ExitButton, "Кнопка которая выполняет выход"),
            };

            SetEventHandlers();
        }

        private void SetEventHandlers()
        {
            foreach (var elementDescription in _elementsDescription)
            {
                elementDescription.FrameworkElement.MouseEnter += (s, e) =>
                {
                    statusBarText.Text = elementDescription.Description;
                };
                elementDescription.FrameworkElement.MouseLeave += (s, e) =>
                {
                    statusBarText.Text = string.Empty;
                };
            }
        }

        private void ChangeBackgroundColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var color = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                this.Background = new SolidColorBrush(color); 
            }// Close the popup once the color is selected
        }

        private void AboutDeveloper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Информация о разработчике: Соколов Владислав", "О разработчике", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
