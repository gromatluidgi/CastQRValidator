using System.Collections.ObjectModel;

namespace CastQRValidator.Models
{
    public class Plan
    {

        public Plan(string name, Collection<string> sampleNames)
        {
            Name = name;
            SampleNames = sampleNames;
        }

        public string Name { get; }

        public Collection<string> SampleNames { get; }
    }
}
