using CastQRValidator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CastQRValidator.Utils.ProcessUtil;

namespace CastQRValidator.ViewModels
{
    internal class RunningPlanViewModel : ObservableObject
    {
        private Engine _engine;
        private Plan _plan;
        private List<Sample> _samples;

        public RunningPlanViewModel(
            Engine engine,
            Plan plan, 
            List<Sample> samples)
        {
            _engine = engine;
            _plan = plan;
            _samples = samples;
            ProcessResults = new ObservableCollection<Tuple<SampleItemViewModel, string>>();

            Task.Run(RunPlan);
        }

        public string PlanName { get => _plan.Name; }

        public string? ProcessOutput { get; private set; }

        public ObservableCollection<Tuple<SampleItemViewModel, string>> ProcessResults { get; set; }
    
        private async Task RunPlan()
        {
            var appViewModel = Bootstraper.ServiceProvider!.GetRequiredService<AppViewModel>();
            appViewModel.IsLoading = true;

            try
            {

                foreach (var sample in _samples)
                {
                    try
                    {
                        var result = await ExecuteShellCommand(_engine.Path, ParseArgs(_engine.Arguments));
                        App.Current.Dispatcher.Invoke((Action)delegate
                        {
                            ProcessResults.Add(Tuple.Create(new SampleItemViewModel(sample.Name, sample.Path, sample.RuleId), result.Output));
                        });
                        await Task.Delay(2000);
                    }
                    catch (Exception e)
                    {
                        Debug.Write(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            appViewModel.IsLoading = false;
        }

        private string ParseArgs(string args)
        {
            return args.Replace("<SOURCE>", "");
        }
    }
}