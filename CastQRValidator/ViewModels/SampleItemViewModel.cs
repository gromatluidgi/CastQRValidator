using CastQRValidator.Attributes;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CastQRValidator.ViewModels
{
    [Transient]
    internal class SampleItemViewModel : ObservableObject
    {
        public SampleItemViewModel(string name, string path, int ruleId)
        {
            Name = name;
            Path = path;
            RuleId = ruleId;
        }

        public string Name { get; set; }
        public string Path { get; set; }
        public int RuleId { get; set; }
    }
}
