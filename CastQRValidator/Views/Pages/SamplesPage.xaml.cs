using CastQRValidator.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CastQRValidator.Views.Pages
{
    /// <summary>
    /// Interaction logic for SamplesPage.xaml
    /// </summary>
    public partial class SamplesPage : Page
    {
        public SamplesPage()
        {
            InitializeComponent();
            this.DataContext = Bootstraper.ServiceProvider!.GetRequiredService<SamplesViewModel>();
        }
    }
}
