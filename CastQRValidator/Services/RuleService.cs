using CastQRValidator.Attributes;
using CastQRValidator.Models;
using CastQRValidator.Services.Abstractions;
using CastQRValidator.Stores.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Services
{
    [Transient]
    public class RuleService : IRuleService
    {
        private readonly IRulesStore _ruleStore;

        public RuleService(IRulesStore ruleStore)
        {
            _ruleStore = ruleStore;
        }

        public async Task<IEnumerable<Rule>> FindAll()
        {
            return await _ruleStore.FindAll();
        }
    }
}
