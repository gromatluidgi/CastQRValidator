using CastQRValidator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Stores.Abstractions
{
    public interface IPlanStore
    {
        public Task<IEnumerable<Plan>> FindAll();

    }
}
