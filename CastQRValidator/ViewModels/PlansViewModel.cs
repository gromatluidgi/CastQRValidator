using CastQRValidator.Attributes;
using CastQRValidator.Services.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CastQRValidator.ViewModels
{
    [Transient]
    internal class PlansViewModel : ObservableObject
    {
        private readonly IPlanService _planService;
        private readonly ObservableCollection<PlanItemViewModel> _plans;

        private bool _isLoading = false;

        public PlansViewModel(IPlanService planService)
        {
            _planService = planService;
            _plans = new ObservableCollection<PlanItemViewModel>();
            Task.Run(Load);
        }


        public bool IsLoading {  get { return _isLoading; } }

        public ObservableCollection<PlanItemViewModel> Plans
        {
            get { return _plans; }
        }

        private async Task Load()
        {
            _isLoading = true;
            var plans = await _planService.FindAll();
            foreach (var plan in plans)
            {
                _plans.Add(new PlanItemViewModel(plan));
            }
            _isLoading = false;
        }
    }
}
