using CastQRValidator.Views.Pages;
using System.Windows;

namespace CastQRValidator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PagerFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            PagerFrame.Navigate(new HomePage());
        }
    }
}
