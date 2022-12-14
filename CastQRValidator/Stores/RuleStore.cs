using CastQRValidator.Attributes;
using CastQRValidator.Models;
using CastQRValidator.Stores.Abstractions;
using CastQRValidator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastQRValidator.Stores
{
    [Singleton]
    public class RuleStore : IRulesStore
    {
        private readonly ISet<Rule> _rules;

        public RuleStore()
        {
            _rules = new HashSet<Rule>();
        }

        public Task Load(string source)
        {
            var rules = FileUtil.ReadJsonFromFile<ISet<Rule>>(source);
            if (rules == null) throw new InvalidOperationException("No rules found for {source}");
            foreach (var rule in rules)
            {
                _rules.Add(rule);
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Rule>> FindAll()
        {
            return await Task.FromResult(_rules.ToList());
        }

        public async Task<int> Count()
        {
            return await Task.FromResult(_rules.Count);
        }
    }
}
