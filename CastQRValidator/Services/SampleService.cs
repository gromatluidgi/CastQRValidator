using CastQRValidator.Attributes;
using CastQRValidator.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastQRValidator.Services
{
    [Transient]
    public class SampleService
    {

        private readonly SamplesStore _sampleStore;
        
        public SampleService(SamplesStore samplesStore)
        {
            _sampleStore = samplesStore;
        }

    }
}
