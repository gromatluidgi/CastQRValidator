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
    public class SamplesStore : ISampleStore
    {
        private readonly ISet<Sample> _samples;

        public SamplesStore()
        {
            _samples = new HashSet<Sample>();
            Task.Run(Load);
        }

        internal Task Load()
        {
            var samples = FileUtil.ReadJsonFromFile<ISet<Sample>>("Resources/Data/mainframe_samples.json");
            if (samples == null) throw new ArgumentNullException();
            foreach(var sample in samples)
            {
                _samples.Add(sample);
            }
            return Task.CompletedTask;
        }

        public async Task<IList<Sample>> FindAll()
        {
            return await Task.FromResult(_samples.ToList());
        }
    }
}
