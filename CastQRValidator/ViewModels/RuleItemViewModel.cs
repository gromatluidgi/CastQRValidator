using CastQRValidator.Attributes;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CastQRValidator.ViewModels
{
    [Transient]
    internal class RuleItemViewModel : ObservableObject
    {
        public RuleItemViewModel(int id, string originalName)
        {
            Id = id;
            OriginalName = originalName;
        }

        public int Id { get; set; }

        public string OriginalName { get; set; }
    }
}
