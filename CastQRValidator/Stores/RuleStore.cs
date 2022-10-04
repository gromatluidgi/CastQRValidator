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
            Task.Run(Load);
        }

        internal Task Load()
        {
            var rules = FileUtil.ReadJsonFromFile<ISet<Rule>>("Resources/Data/mainframe_rules.json");
            if (rules == null) throw new ArgumentNullException();
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
    }
}
