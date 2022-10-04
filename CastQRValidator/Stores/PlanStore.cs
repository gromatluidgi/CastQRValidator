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
    public class PlanStore : IPlanStore
    {
        private readonly ISet<Plan> _plans;

        public PlanStore()
        {
            _plans = new HashSet<Plan>();
            Task.Run(Load);
        }

        internal Task Load()
        {
            var plans = FileUtil.ReadJsonFromFile<ISet<Plan>>("Resources/Data/plans.json");
            if (plans == null) throw new ArgumentNullException();
            foreach (var plan in plans)
            {
                _plans.Add(plan);
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Plan>> FindAll()
        {
            return await Task.FromResult(_plans.ToList());
        }
    }
}
