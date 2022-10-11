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
        private readonly Plan _plan;

        public PlanItemViewModel(Plan plan)
        {
            _plan = plan;

            Name = plan.Name;
            Samples = string.Join(";", plan.SampleNames);
            Engine = plan.Engine;

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
                // Fetch engine
                var engineStore = Bootstraper.ServiceProvider!.GetRequiredService<IEngineStore>();
                var engine = await engineStore.FindByName(Engine);
                if (engine == null) throw new InvalidCastException();

                // Fetch samples
                var sampleStore = Bootstraper.ServiceProvider!.GetRequiredService<ISampleStore>();
                var samples = await sampleStore.FindByNames(Samples.Split(';'));


                runningPlanPage.DataContext = new RunningPlanViewModel(engine, _plan, samples.ToList());
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