using CastQRValidator.Attributes;
using CastQRValidator.Stores.Abstractions;
using System.Threading.Tasks;

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
    }
}
