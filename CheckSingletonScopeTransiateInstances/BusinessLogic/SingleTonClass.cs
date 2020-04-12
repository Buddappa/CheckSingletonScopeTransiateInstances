using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSingletonScopeTransiateInstances.BusinessLogic
{
    public interface ISingleTonClass
    {
    }

    public class SingleTonClass : ISingleTonClass
    {
        private ITransiateClass transiateClass;
        private IScopedClass scopedClass;

        public SingleTonClass(ITransiateClass transiateClass)
        {
           
          //  this.scopedClass = scopedClass;
           this.transiateClass = transiateClass;
        }
        public Guid Id { get; }

        public SingleTonClass()
        {
            Id = Guid.NewGuid();
        }
    }
}
