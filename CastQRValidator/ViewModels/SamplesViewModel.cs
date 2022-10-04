using CastQRValidator.Attributes;
using CastQRValidator.Services;
using CastQRValidator.Services.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CastQRValidator.ViewModels
{
    [Transient]
    internal class SamplesViewModel : ObservableObject
    {
        private readonly ISampleService _sampleService;
        private readonly ObservableCollection<SampleItemViewModel> _samples;
        private bool _isLoading = false;

        public SamplesViewModel(ISampleService sampleService) { 
        
            _sampleService = sampleService;
            _samples = new ObservableCollection<SampleItemViewModel>();
            Task.Run(Load);
        }


        public bool IsLoading { get { return _isLoading; } }

        public ObservableCollection<SampleItemViewModel> Samples
        {
            get { return _samples; }
        }

        private async Task Load()
        {
            _isLoading = true;
            var samples = await _sampleService.FindAll();
            foreach (var sample in samples)
            {
                _samples.Add(new SampleItemViewModel(sample.Name, sample.Path, sample.RuleId));
            }
            _isLoading = false;
        }
    }
}
