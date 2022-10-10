using CastQRValidator.Attributes;
using CastQRValidator.Models;
using CastQRValidator.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Documents;
using static CastQRValidator.Utils.ProcessUtil;

namespace CastQRValidator.ViewModels
{
    internal class RunningPlanViewModel : ObservableObject
    {
        public RunningPlanViewModel(
            Engine engine,
            Plan plan, 
            List<Sample> samples)
        {
            Engine = engine;
            Plan = plan;
            Samples = samples;
            ProcessResults = new ObservableCollection<(SampleItemViewModel, ProcessResult)>();

            Task.Run(RunPlan);
        }

        public Engine Engine { get; set; }

        public Plan Plan { get; set; }

        public List<Sample> Samples { get; set; }

        public ObservableCollection<(SampleItemViewModel, ProcessResult)> ProcessResults { get; set; }
    
    
        private async Task RunPlan()
        {
            var appViewModel = Bootstraper.ServiceProvider!.GetRequiredService<AppViewModel>();
            appViewModel.IsLoading = true;

            foreach (var sample in Samples)
            {
                try
                {
                    var result = await ProcessUtil.ExecuteShellCommand(Engine.Path, ParseArgs(Engine.Arguments));
                    ProcessResults.Add((new SampleItemViewModel(sample.Name, sample.Path, sample.RuleId), result));
                } catch (Exception e)
                {
                    Debug.Write(e.Message);
                }
            }

            appViewModel.IsLoading = false;
        }

        private string ParseArgs(string args)
        {
            return args;
        }
    }
}