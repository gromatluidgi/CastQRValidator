using CastQRValidator.Attributes;
using CastQRValidator.Services.Abstractions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CastQRValidator.ViewModels
{
    [Transient]
    internal class EnginesViewModel
    {
        private readonly IEngineService _engineService;
        private readonly ObservableCollection<EngineItemViewModel> _engines;

        private bool _isLoading = false;

        public EnginesViewModel(IEngineService engineService)
        {
            _engineService = engineService;
            _engines = new ObservableCollection<EngineItemViewModel>();
            Task.Run(Load);
        }


        public bool IsLoading { get { return _isLoading; } }

        public ObservableCollection<EngineItemViewModel> Engines
        {
            get { return _engines; }
        }

        private async Task Load()
        {
            _isLoading = true;
            var engines = await _engineService.FindAll();
            foreach (var engine in engines)
            {
            }
            _isLoading = false;
        }
    }
}
