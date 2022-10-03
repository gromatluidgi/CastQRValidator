using CastQRValidator.Attributes;
using CastQRValidator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastQRValidator.ViewModels
{
    [Transient]
    public class SamplesViewModel
    {
        private readonly SampleService _sampleService;
        public SamplesViewModel(SampleService sampleService) { 
        
            _sampleService = sampleService;
        }
    }
}
