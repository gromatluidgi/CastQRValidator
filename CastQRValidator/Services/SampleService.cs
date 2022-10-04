using CastQRValidator.Attributes;
using CastQRValidator.Models;
using CastQRValidator.Services.Abstractions;
using CastQRValidator.Stores.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Services
{
    [Transient]
    public class SampleService : ISampleService
    {

        private readonly ISampleStore _sampleStore;
        
        public SampleService(ISampleStore samplesStore)
        {
            _sampleStore = samplesStore;
        }

        public async Task<IEnumerable<Sample>> FindAll()
        {
            return await _sampleStore.FindAll();
        }
    }
}
