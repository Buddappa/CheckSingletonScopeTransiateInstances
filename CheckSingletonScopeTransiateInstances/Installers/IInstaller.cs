using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSingletonScopeTransiateInstances.IInstallers
{
   public interface IInstaller
    {
        void Installervice(IServiceCollection services, IConfiguration configuration);
    }
}
