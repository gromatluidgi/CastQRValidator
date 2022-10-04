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
            Task.Run(Load);
        }

        internal Task Load()
        {
            var engines = FileUtil.ReadJsonFromFile<ISet<Engine>>("Resources/Data/engines.json");
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
    }
}
