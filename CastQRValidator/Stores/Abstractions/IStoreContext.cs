using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastQRValidator.Stores.Abstractions
{
    internal interface IStoreContext
    {
        Task Initialize();

        ISampleStore SampleStore { get; }

        IRulesStore RulesStore { get; }

        IPlanStore PlanStore { get; }

        IEngineStore EngineStore { get; }
    }
}
