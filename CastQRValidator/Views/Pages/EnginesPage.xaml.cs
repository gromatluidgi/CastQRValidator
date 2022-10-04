using CastQRValidator.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CastQRValidator.Views.Pages
{
    /// <summary>
    /// Interaction logic for EnginesPage.xaml
    /// </summary>
    public partial class EnginesPage : Page
    {
        public EnginesPage()
        {
            InitializeComponent();
            this.DataContext = Bootstraper.ServiceProvider!.GetRequiredService<EnginesViewModel>();
        }
    }
}
