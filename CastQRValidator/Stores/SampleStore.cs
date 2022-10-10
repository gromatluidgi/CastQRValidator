using CastQRValidator.Attributes;
using CastQRValidator.Models;
using CastQRValidator.Stores.Abstractions;
using CastQRValidator.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CastQRValidator.Stores
{
    [Singleton]
    public class SampleStore : ISampleStore
    {
        private readonly ISet<Sample> _samples;

        public SampleStore()
        {
            _samples = new HashSet<Sample>();
        }

        public Task Load(string source)
        {
            var samples = FileUtil.ReadJsonFromFile<ISet<Sample>>(source);
            if (samples == null) throw new SerializationException();
            foreach(var sample in samples)
            {
                _samples.Add(sample);
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Sample>> FindAll()
        {
            return await Task.FromResult(_samples.ToList());
        }
    }
}
