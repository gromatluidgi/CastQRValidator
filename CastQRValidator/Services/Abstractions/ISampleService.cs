using CastQRValidator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Services.Abstractions
{
    public interface ISampleService
    {
        Task<IEnumerable<Sample>> FindAll();
    }
}
