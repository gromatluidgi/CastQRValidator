using CastQRValidator.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CastQRValidator.Views.Pages
{
    /// <summary>
    /// Interaction logic for RulesPage.xaml
    /// </summary>
    public partial class RulesPage : Page
    {
        public RulesPage()
        {
            InitializeComponent();
            this.DataContext = Bootstraper.ServiceProvider!.GetRequiredService<RulesViewModel>();
        }
    }
}
