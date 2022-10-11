using CastQRValidator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Stores.Abstractions
{
    public interface IPlanStore
    {
        Task Load(string source);

        public Task<IEnumerable<Plan>> FindAll();

        public Task<int> Count();

    }
}
