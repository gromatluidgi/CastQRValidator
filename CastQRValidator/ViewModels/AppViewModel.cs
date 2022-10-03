using CastQRValidator.Attributes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public RelayCommand<string?> NavigateToCommand { get; }

        private void NavigateToHandler(string? target)
        {
            if (target == null) return;
            PagerFrame?.Navigate(new Uri(target, UriKind.Relative));
        }


    }
}
