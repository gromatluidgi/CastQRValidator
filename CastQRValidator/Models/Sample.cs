using System.Collections.ObjectModel;

namespace CastQRValidator.Models
{
    public class Sample
    {
        public Sample(string name, string path, int ruleId, Collection<Violation> violations)
        {
            Name = name;
            Path = path;
            RuleId = ruleId;
            Violations = violations;
        }

        public string Name { get; }    
        public string Path { get; }
        public int RuleId { get; }
        public Collection<Violation> Violations { get; }

        public void AddViolation(Violation violation)
        {
            Violations.Add(violation);
        }
    }
}
