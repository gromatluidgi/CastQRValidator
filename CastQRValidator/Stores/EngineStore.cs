using CastQRValidator.Models;
using CastQRValidator.Stores.Abstractions;
using CastQRValidator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastQRValidator.Stores
{
    public class EngineStore : IEngineStore
    {
        private readonly ISet<Engine> _engines;

        public EngineStore()
        {
            _engines = new HashSet<Engine>();
        }

        public Task Load(string source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var engines = FileUtil.ReadJsonFromFile<ISet<Engine>>(source);
            if (engines == null) throw new ArgumentNullException();
            foreach (var engine in engines)
            {
                _engines.Add(engine);
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Engine>> FindAll()
        {
            return await Task.FromResult(_engines.ToList());

        }

        public async Task<Engine?> FindByName(string name)
        {
            return await Task.FromResult(_engines.FirstOrDefault(e => e.Name.Equals(name)));
        }
    }
}
