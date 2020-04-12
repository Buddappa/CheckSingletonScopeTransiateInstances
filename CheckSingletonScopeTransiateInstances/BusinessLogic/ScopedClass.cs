using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSingletonScopeTransiateInstances.BusinessLogic
{
    public interface IScopedClass
    {
    }

    public class ScopedClass: IScopedClass
    {
        public Guid Id { get; }

        public ScopedClass()
        {
            Id = Guid.NewGuid();
        }
    }
}
