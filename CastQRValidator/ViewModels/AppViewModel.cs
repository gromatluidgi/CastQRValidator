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

        public bool IsLoading { get { return _isLoading; } set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
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

        private async Task InitializeStores()
        {
            IsLoading = true;
            await _storeContext.Initialize();
            IsLoading = false;
        }


    }
}
