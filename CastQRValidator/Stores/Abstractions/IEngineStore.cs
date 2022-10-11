using CastQRValidator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Stores.Abstractions
{
    public interface IEngineStore
    {
        Task Load(string source);

        public Task<IEnumerable<Engine>> FindAll();

        public Task<Engine?> FindByName(string name);

        public Task<int> Count();
    }
}
