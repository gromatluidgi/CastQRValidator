using CastQRValidator.Attributes;
using CastQRValidator.Services.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CastQRValidator.ViewModels
{
    [Transient]
    internal class RulesViewModel : ObservableObject
    {
        private readonly IRuleService _ruleService;
        private readonly ObservableCollection<RuleItemViewModel> _rules;

        private bool _isLoading = false;

        public RulesViewModel(IRuleService ruleService)
        {
            _ruleService = ruleService;
            _rules = new ObservableCollection<RuleItemViewModel>();
            Task.Run(Load);
        }


        public bool IsLoading { get { return _isLoading; } }

        public ObservableCollection<RuleItemViewModel> Rules
        {
            get { return _rules; }
        }

        private async Task Load()
        {
            _isLoading = true;
            var rules = await _ruleService.FindAll();
            foreach (var rule in rules)
            {
                _rules.Add(new RuleItemViewModel(rule.Id, rule.OriginalName));
            }
            _isLoading = false;
        }
    }
}
