using System.Windows;
using System.Windows.Input;

namespace Base64Convertor
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

        private void Drag_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Normal) this.WindowState = WindowState.Minimized;
        }


        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            MainContentContainer.Children.Add(new MainContent());
        }
    }
}
