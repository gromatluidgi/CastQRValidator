using CastQRValidator.Attributes;
using CastQRValidator.Stores.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace CastQRValidator.Stores
{
    [Singleton]
    internal class JsonStoreContext : IStoreContext
    {
        private readonly ISampleStore _sampleStore;
        private readonly IRulesStore _rulesStore;
        private readonly IPlanStore _planStore;
        private readonly IEngineStore _engineStore;

        public JsonStoreContext(ISampleStore sampleStore, IRulesStore rulesStore, IPlanStore planStore, IEngineStore engineStore)
        {
            _sampleStore = sampleStore;
            _rulesStore = rulesStore;
            _planStore = planStore;
            _engineStore = engineStore;
        }

        public ISampleStore SampleStore => _sampleStore;

        public IRulesStore RulesStore => _rulesStore;

        public IPlanStore PlanStore => _planStore;

        public IEngineStore EngineStore => _engineStore;

        public async Task Initialize()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(_sampleStore.Load("Resources/Data/mainframe_samples.json"));
            tasks.Add(_rulesStore.Load("Resources/Data/mainframe_rules.json"));
            tasks.Add(_planStore.Load("Resources/Data/plans.json"));
            tasks.Add(_engineStore.Load("Resources/Data/engines.json"));

            await Task.Run(() => Task.WaitAll(tasks.ToArray()));
        }
    }
}
