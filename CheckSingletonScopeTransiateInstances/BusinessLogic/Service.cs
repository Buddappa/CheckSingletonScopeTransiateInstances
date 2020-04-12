using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSingletonScopeTransiateInstances.BusinessLogic
{
    public interface IService
    {
    }

    public class Service: IService
    {
        private ISingleTonClass singleTonClass;
        private ITransiateClass transiateClass;
        private IScopedClass scopedClass;
        public Service(ISingleTonClass singleTonClass, IScopedClass scopedClass, ITransiateClass transiateClass)
        {
            this.singleTonClass = singleTonClass;
            this.scopedClass = scopedClass;
            this.transiateClass = transiateClass;
        }
    }
}
