using System.Collections.ObjectModel;

namespace CastQRValidator.Models
{
    public class Plan
    {

        public Plan(string name, string engine, Collection<string> sampleNames)
        {
            Name = name;
            Engine = engine;
            SampleNames = sampleNames;
        }

        public string Name { get; }

        public string Engine { get; }

        public Collection<string> SampleNames { get; }
    }
}
