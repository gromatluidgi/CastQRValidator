using CastQRValidator.Attributes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CastQRValidator.ViewModels
{
    [Transient]
    public class PlanItemViewModel : ObservableObject
    {
        public PlanItemViewModel(string name, string samples)
        {
            Name = name;
            Samples = samples;
        }

        public string Name { get; set; }

        public string Samples { get; set; }

        public bool IsRunning { get; } = false;

        public RelayCommand RunSampleCommand { get; }

    }
}
