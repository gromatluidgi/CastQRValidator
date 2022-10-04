using CastQRValidator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Stores.Abstractions
{
    public interface IEngineStore
    {
        public Task<IEnumerable<Engine>> FindAll();

    }
}
