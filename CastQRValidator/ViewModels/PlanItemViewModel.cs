using CastQRValidator.Attributes;
using CastQRValidator.Models;
using CastQRValidator.Stores.Abstractions;
using CastQRValidator.Utils;
using CastQRValidator.Views.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static CastQRValidator.Utils.ProcessUtil;

namespace CastQRValidator.ViewModels
{
    public class PlanItemViewModel : ObservableObject
    {
        public PlanItemViewModel(Plan plan)
        {
            Name = plan.Name;
            Samples = String.Join(plan.SampleNames, "; ");
            Engine = engine;

            RunPlanCommand = new AsyncRelayCommand(RunPlanHandler);
        }

        public string Name { get; set; }

        public string Engine { get; set; }

        public string Samples { get; set; }

        public AsyncRelayCommand RunPlanCommand { get; }

        private async Task RunPlanHandler()
        {
            var appViewModel = Bootstraper.ServiceProvider!.GetRequiredService<AppViewModel>();
            var runningPlanPage = new RunningPlanPage();

            try
            {
                var engineStore = Bootstraper.ServiceProvider!.GetRequiredService<IEngineStore>();
                var sampleStore = Bootstraper.ServiceProvider!.GetRequiredService<ISampleStore>();

                runningPlanPage.DataContext = new RunningPlanViewModel();
            }
            catch(Exception e)
            {
                Debug.Print(e.Message);
            } finally
            {
                if (runningPlanPage.DataContext != null)
                {
                    appViewModel.PagerFrame!.Navigate(runningPlanPage);
                }
            }
        }

        private string ParseArgs(string args)
        {
            return args;
        }
    }
}