using CastQRValidator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastQRValidator.Services.Abstractions
{
    public interface IPlanService
    {
        public Task<IEnumerable<Plan>> FindAll();

    }
}
