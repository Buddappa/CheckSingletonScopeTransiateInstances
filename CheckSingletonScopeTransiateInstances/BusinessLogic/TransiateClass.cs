using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSingletonScopeTransiateInstances.BusinessLogic
{
    public interface ITransiateClass
    {
    }

    public class TransiateClass : ITransiateClass
    {
        public Guid Id { get; }

        public TransiateClass()
        {
            Id = Guid.NewGuid();
        }
    }
}
