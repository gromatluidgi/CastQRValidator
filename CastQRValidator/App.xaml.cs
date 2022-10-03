using CastQRValidator.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CastQRValidator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            // Root composition (configuration, dependencies...)
            Bootstraper.Initialize();

            // Retrieve AppViewModel from IOC container
            var appViewModel = Bootstraper.ServiceProvider!.GetRequiredService<AppViewModel>();

            // Initialize main view and assign AppViewModel as base context
            MainWindow window = new MainWindow();
            window.DataContext = appViewModel;
            window.Show();

            // Pass the reference of the application frame to the main viewmodel
            appViewModel.PagerFrame = window.PagerFrame;
        }
    }
}
