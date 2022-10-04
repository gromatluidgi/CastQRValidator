using CastQRValidator.Attributes;
using CastQRValidator.Models;
using CastQRValidator.Services.Abstractions;
using CastQRValidator.Stores.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Services
{
    [Transient]
    public class PlanService : IPlanService
    {
        private readonly IPlanStore _planStore;

        public PlanService(IPlanStore planStore)
        {
            _planStore = planStore;
        }

        public async Task<IEnumerable<Plan>> FindAll()
        {
            return await _planStore.FindAll();
        }
    }
}
