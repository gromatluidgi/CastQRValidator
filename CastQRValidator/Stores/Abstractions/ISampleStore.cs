using CastQRValidator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Stores.Abstractions
{
    public interface ISampleStore
    {
        public Task<IEnumerable<Sample>> FindAll();
    }
}
