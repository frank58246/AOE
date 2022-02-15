using System;
using System.Threading.Tasks;
using AspectCore.DependencyInjection;
using AspectCore.DynamicProxy;
using CoreProfiler;
using Microsoft.Extensions.Logging;

namespace AOPExample.Core.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ProfilingAttribute:AbstractInterceptorAttribute
    {

        private readonly string _stepName;

        public ProfilingAttribute(string stepName)
        {
            _stepName = stepName;
        }

        public async  override Task Invoke(AspectContext context, AspectDelegate next)
        {
            var name = GetStepName(context);
            using (ProfilingSession.Current.Step(_stepName))
            {
                // executed before action
                
                await next(context);
                
                // executed after action

            }
        }
        private string GetStepName(AspectContext context)
        {
            var implement = context.Implementation.GetType().Name;
            var method = context.ProxyMethod.Name;
            return $"{implement}-{method}";
        }
    }
}