using CastQRValidator.Attributes;
using CastQRValidator.Stores.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CastQRValidator.ViewModels
{
    [Singleton]
    internal class AppViewModel : ObservableObject
    {
        private bool _isLoading = false;
        private int _ruleCount = 0;
        private int _planCount = 0;
        private int _engineCount = 0;
        private int _sampleCount = 0;

        private Frame? _pagerFrame;
        private readonly IStoreContext _storeContext;

        public AppViewModel(IStoreContext storeContext)
        {
            _storeContext = storeContext;
            NavigateToCommand = new RelayCommand<string?>(NavigateToHandler);
            Task.Run(InitializeStores);
        }

        public Frame? PagerFrame
        {
            get => _pagerFrame;
            set => SetProperty(ref _pagerFrame, value);
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public int RuleCount
        {
            get { return _ruleCount; }
            set
            {
                _ruleCount = value;
                OnPropertyChanged();
            }
        }
        public int PlanCount
        {
            get { return _planCount; }
            set
            {
                _planCount = value;
                OnPropertyChanged();
            }
        }
        public int EngineCount
        {
            get { return _engineCount; }
            set
            {
                _engineCount = value;
                OnPropertyChanged();
            }
        }

        public int SampleCount
        {
            get { return _sampleCount; }
            set
            {
                _sampleCount = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<string?> NavigateToCommand { get; }

        private void NavigateToHandler(string? target)
        {
            if (target == null) return;
            PagerFrame?.Navigate(new Uri(target, UriKind.Relative));
        }

        private async Task InitializeStores()
        {
            IsLoading = true;
            await _storeContext.Initialize();
            EngineCount = await _storeContext.EngineStore.Count();
            RuleCount = await _storeContext.RulesStore.Count();
            PlanCount = await _storeContext.PlanStore.Count();
            SampleCount = await _storeContext.SampleStore.Count();
            IsLoading = false;
        }
    }
}