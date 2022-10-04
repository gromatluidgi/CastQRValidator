using CastQRValidator.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CastQRValidator.Views.Pages
{
    /// <summary>
    /// Interaction logic for PlansPage.xaml
    /// </summary>
    public partial class PlansPage : Page
    {
        public PlansPage()
        {
            InitializeComponent();
            this.DataContext = Bootstraper.ServiceProvider!.GetRequiredService<PlansViewModel>();
        }
    }
}
