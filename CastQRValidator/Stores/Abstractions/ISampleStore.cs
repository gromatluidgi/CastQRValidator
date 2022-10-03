using CastQRValidator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastQRValidator.Stores.Abstractions
{
    public interface ISampleStore
    {
        public Task<IList<Sample>> FindAll();
    }
}
