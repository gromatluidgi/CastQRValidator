using CastQRValidator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Stores.Abstractions
{
    public interface IRulesStore
    {
        Task Load(string source);

        public Task<IEnumerable<Rule>> FindAll();

    }
}
