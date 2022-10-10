using CastQRValidator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Stores.Abstractions
{
    public interface ISampleStore
    {
        Task Load(string source);

        public Task<IEnumerable<Sample>> FindAll();

        public Task<IEnumerable<Sample>> FindByNames(string[] names);

    }
}
