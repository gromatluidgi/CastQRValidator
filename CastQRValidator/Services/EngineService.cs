using CastQRValidator.Attributes;
using CastQRValidator.Models;
using CastQRValidator.Services.Abstractions;
using CastQRValidator.Stores.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Services
{
    [Transient]
    public class EngineService : IEngineService
    {
        private readonly IEngineStore _engineStore;
        public EngineService(IEngineStore engineStore) { 
            _engineStore = engineStore;
        }

        public async Task<IEnumerable<Engine>> FindAll()
        {
            return await _engineStore.FindAll();
        }
    }
}
