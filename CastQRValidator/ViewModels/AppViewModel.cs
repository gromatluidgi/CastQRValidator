using CastQRValidator.Attributes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Controls;

namespace CastQRValidator.ViewModels
{
    [Singleton]
    internal class AppViewModel : ObservableObject
    {

        private Frame? _pagerFrame;

        public AppViewModel()
        {
            NavigateToCommand = new RelayCommand<string?>(NavigateToHandler);
        }

        public Frame? PagerFrame
        {
            get => _pagerFrame;
            set => SetProperty(ref _pagerFrame, value);
        }

        public int RuleCount { get; set; }
        public int PlanCount { get; set; }
        public int EngineCount { get; set; }

        public RelayCommand<string?> NavigateToCommand { get; }

        private void NavigateToHandler(string? target)
        {
            if (target == null) return;
            PagerFrame?.Navigate(new Uri(target, UriKind.Relative));
        }


    }
}
